using System.Security.Cryptography;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class Blackjack : Controller
    {
        private const string BlackjackGameSessionKey = "BlackjackGame";

        public IActionResult Index()
        {
            var game = LoadGame();
            if (game == null)
            {
                game = CreateNewGame();
                SaveGame(game);
            }

            return View("BlackjackManager", game);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Hit()
        {
            var game = LoadGame() ?? CreateNewGame();
            if (game.IsPlayerTurn && !game.IsGameOver && game.PlayerScore < 21 && game.RemainingCards.Count > 0)
            {
                var card = game.RemainingCards[0];
                game.RemainingCards.RemoveAt(0);

                if (BlackjackTableViewModel.GetHandValue(game.PlayerCards.Append(card)) <= 21)
                {
                    game.PlayerCards.Add(card);
                    game.StatusMessage = $"Byla rozdána karta {card.Value} {card.Suit}.";
                }
                else
                {
                    game.StatusMessage = $"Karta {card.Value} {card.Suit} by překročila 21, proto nebyla hráči přidána.";
                }
            }
            else if (game.RemainingCards.Count == 0)
            {
                game.StatusMessage = "V balíčku už nejsou žádné karty.";
            }

            SaveGame(game);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Stand()
        {
            var game = LoadGame() ?? CreateNewGame();
            if (game.IsPlayerTurn && !game.IsGameOver)
            {
                game.IsPlayerTurn = false;
                foreach (var card in game.DealerCards)
                {
                    card.IsFaceUp = true;
                }

                while (BlackjackTableViewModel.GetHandValue(game.DealerCards) < 17 && game.RemainingCards.Count > 0)
                {
                    game.DealerCards.Add(game.RemainingCards[0]);
                    game.RemainingCards.RemoveAt(0);
                }

                var playerScore = game.PlayerScore;
                var dealerScore = BlackjackTableViewModel.GetHandValue(game.DealerCards);
                game.RoundResult = dealerScore > 21 || playerScore > dealerScore
                    ? "Vyhrál hráč!"
                    : playerScore == dealerScore
                        ? "Remíza."
                        : "Vyhrál dealer.";
                game.IsGameOver = true;
                game.StatusMessage = $"Hráč: {playerScore} bodů. Dealer: {dealerScore} bodů.";
            }

            SaveGame(game);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewGame()
        {
            SaveGame(CreateNewGame());
            return RedirectToAction(nameof(Index));
        }

        private BlackjackTableViewModel? LoadGame()
        {
            var json = HttpContext.Session.GetString(BlackjackGameSessionKey);
            return json == null ? null : JsonSerializer.Deserialize<BlackjackTableViewModel>(json);
        }

        private void SaveGame(BlackjackTableViewModel game)
        {
            HttpContext.Session.SetString(BlackjackGameSessionKey, JsonSerializer.Serialize(game));
        }

        private static BlackjackTableViewModel CreateNewGame()
        {
            string[] suits = ["Hearts", "Diamonds", "Clubs", "Spades"];
            string[] values = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
            var deck = suits
                .SelectMany(suit => values.Select(value => new BlackjackCardDto { Value = value, Suit = suit }))
                .ToList();

            for (var i = deck.Count - 1; i > 0; i--)
            {
                var swapIndex = RandomNumberGenerator.GetInt32(i + 1);
                (deck[i], deck[swapIndex]) = (deck[swapIndex], deck[i]);
            }

            var game = new BlackjackTableViewModel
            {
                PlayerCards = deck.Take(2).ToList(),
                DealerCards = deck.Skip(2).Take(2).ToList(),
                RemainingCards = deck.Skip(4).ToList(),
                StatusMessage = "Hra začala. Rozhodněte se, zda chcete další kartu, nebo stát."
            };
            game.DealerCards[1].IsFaceUp = false;
            return game;
        }
    }
}
