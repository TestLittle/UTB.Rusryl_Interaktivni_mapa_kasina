using System.Security.Cryptography;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class Poker : Controller
    {
        private const string PokerGameSessionKey = "PokerGame";

        public IActionResult Index()
        {
            var game = LoadGame();
            if (game == null)
            {
                game = CreateNewGame();
                SaveGame(game);
            }

            return View("PokerManager", game);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Continue()
        {
            var game = LoadGame() ?? CreateNewGame();
            if (game.RevealedCommunityCardsCount < 5)
            {
                game.RevealedCommunityCardsCount = game.RevealedCommunityCardsCount == 0
                    ? 3
                    : game.RevealedCommunityCardsCount + 1;

                for (var i = 0; i < game.CommunityCards.Count; i++)
                {
                    game.CommunityCards[i].IsFaceUp = i < game.RevealedCommunityCardsCount;
                }

                game.RoundName = game.RevealedCommunityCardsCount switch
                {
                    3 => "Flop",
                    4 => "Turn",
                    _ => "River"
                };
                game.NextActionText = game.RevealedCommunityCardsCount switch
                {
                    3 => "Otočit turn",
                    4 => "Otočit river",
                    _ => "Hotovo"
                };
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

        private PokerTableViewModel? LoadGame()
        {
            var json = HttpContext.Session.GetString(PokerGameSessionKey);
            return json == null ? null : JsonSerializer.Deserialize<PokerTableViewModel>(json);
        }

        private void SaveGame(PokerTableViewModel game)
        {
            HttpContext.Session.SetString(PokerGameSessionKey, JsonSerializer.Serialize(game));
        }

        private static PokerTableViewModel CreateNewGame()
        {
            string[] suits = ["Hearts", "Diamonds", "Clubs", "Spades"];
            string[] values = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
            var deck = suits
                .SelectMany(suit => values.Select(value => new CardDto { Value = value, Suit = suit }))
                .ToList();

            for (var i = deck.Count - 1; i > 0; i--)
            {
                var swapIndex = RandomNumberGenerator.GetInt32(i + 1);
                (deck[i], deck[swapIndex]) = (deck[swapIndex], deck[i]);
            }

            return new PokerTableViewModel
            {
                PlayerCards = deck.Take(2).ToList(),
                CommunityCards = deck.Skip(2).Take(5).Select(card => new CardDto
                {
                    Value = card.Value,
                    Suit = card.Suit,
                    IsFaceUp = false
                }).ToList(),
                RevealedCommunityCardsCount = 0,
                RoundName = "Před flopem",
                NextActionText = "Otočit flop"
            };
        }
    }
}
