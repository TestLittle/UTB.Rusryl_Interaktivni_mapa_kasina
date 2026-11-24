using System.Security.Cryptography;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class Roulette : Controller
    {
        private const string RouletteSessionKey = "RouletteGame";

        public IActionResult Index()
        {
            var game = LoadGame() ?? new RouletteTableViewModel();
            return View("RouletteManager", game);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PlaceBet(string? betType, int betAmount)
        {
            var game = LoadGame() ?? new RouletteTableViewModel();
            betType ??= string.Empty;
            game.BetAmount = betAmount;
            game.SelectedBetType = betType;
            game.SelectedNumber = TryParseNumberBet(betType, out var selectedNumber) ? selectedNumber : null;

            if (!IsValidBet(betType))
            {
                game.Message = "Vyberte platnou pozici pro sázku.";
            }
            else if (betAmount < 1 || betAmount > game.Balance)
            {
                game.Message = $"Sázka musí být mezi 1 a {game.Balance} žetony.";
            }
            else
            {
                game.Balance -= betAmount;
                game.Bets.Add(new RouletteBetDto { BetType = betType, Amount = betAmount });
                game.Message = $"Na pozici {GetBetName(betType)} jste vsadili {betAmount} žetonů. Můžete přidat další sázky nebo zatočit.";
            }

            SaveGame(game);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Spin()
        {
            var game = LoadGame() ?? new RouletteTableViewModel();
            if (game.Bets.Count == 0)
            {
                game.Message = "Nejprve umístěte alespoň jednu sázku na hrací plochu.";
                SaveGame(game);
                return RedirectToAction(nameof(Index));
            }

            var result = RandomNumberGenerator.GetInt32(37);
            var resultColor = RouletteTableViewModel.GetNumberColor(result);
            var winningBets = game.Bets
                .Where(bet => IsWinningBet(bet.BetType, result, resultColor))
                .ToList();
            var payout = winningBets.Sum(bet => (long)bet.Amount * GetPayoutMultiplier(bet.BetType));

            game.Balance += payout;
            game.ResultNumber = result;
            game.ResultColor = resultColor;
            game.IsWin = winningBets.Count > 0;
            game.Message = game.IsWin
                ? $"Výhra! Padlo {result} ({GetColorName(resultColor)}). Výherních sázek: {winningBets.Count}, výplata: {payout} žetonů."
                : $"Prohra. Padlo {result} ({GetColorName(resultColor)}), žádná z vašich sázek nevyhrála.";
            game.Bets.Clear();

            SaveGame(game);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ClearBets()
        {
            var game = LoadGame() ?? new RouletteTableViewModel();
            game.Balance += game.TotalBetAmount;
            game.Bets.Clear();
            game.Message = "Sázky byly vráceny do zůstatku.";
            SaveGame(game);
            return RedirectToAction(nameof(Index));
        }

        private static bool IsValidBet(string? betType) =>
            !string.IsNullOrEmpty(betType) &&
            (TryParseNumberBet(betType, out _) || betType is "low" or "high" or "even" or "odd"
                or "first12" or "second12" or "third12" or "red" or "black");

        private static bool TryParseNumberBet(string? betType, out int number)
        {
            number = -1;
            return betType != null && betType.StartsWith("number:", StringComparison.Ordinal) &&
                int.TryParse(betType.AsSpan("number:".Length), out number) &&
                number is >= 0 and <= 36;
        }

        private static bool IsWinningBet(string betType, int result, string color)
        {
            if (TryParseNumberBet(betType, out var number))
            {
                return result == number;
            }

            return betType switch
            {
                "low" => result is >= 1 and <= 18,
                "high" => result is >= 19 and <= 36,
                "even" => result != 0 && result % 2 == 0,
                "odd" => result % 2 == 1,
                "first12" => result is >= 1 and <= 12,
                "second12" => result is >= 13 and <= 24,
                "third12" => result is >= 25 and <= 36,
                "red" or "black" => color == betType,
                _ => false
            };
        }

        private static int GetPayoutMultiplier(string betType) =>
            TryParseNumberBet(betType, out _) ? 36 :
            betType is "first12" or "second12" or "third12" ? 3 : 2;

        private static string GetBetName(string betType)
        {
            if (TryParseNumberBet(betType, out var number))
            {
                return $"číslo {number}";
            }

            return betType switch
            {
                "low" => "1–18",
                "high" => "19–36",
                "even" => "sudá čísla",
                "odd" => "lichá čísla",
                "first12" => "1. tucet (1–12)",
                "second12" => "2. tucet (13–24)",
                "third12" => "3. tucet (25–36)",
                "red" => "červenou",
                "black" => "černou",
                _ => "neznámou sázku"
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewGame()
        {
            HttpContext.Session.Remove(RouletteSessionKey);
            return RedirectToAction(nameof(Index));
        }

        private RouletteTableViewModel? LoadGame()
        {
            var json = HttpContext.Session.GetString(RouletteSessionKey);
            return json == null ? null : JsonSerializer.Deserialize<RouletteTableViewModel>(json);
        }

        private void SaveGame(RouletteTableViewModel game)
        {
            HttpContext.Session.SetString(RouletteSessionKey, JsonSerializer.Serialize(game));
        }

        private static string GetColorName(string color) => color switch
        {
            "red" => "červená",
            "black" => "černá",
            _ => "zelená"
        };
    }
}
