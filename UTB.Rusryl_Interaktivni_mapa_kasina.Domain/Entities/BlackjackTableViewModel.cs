namespace UTB.Rusryl_Interaktivni_mapa_kasina.Web.Areas.Admin.Controllers
{
    public class BlackjackCardDto
    {
        public string Value { get; set; } = string.Empty;
        public string Suit { get; set; } = string.Empty;
        public bool IsFaceUp { get; set; } = true;
    }

    public class BlackjackTableViewModel
    {
        public List<BlackjackCardDto> PlayerCards { get; set; } = new();
        public List<BlackjackCardDto> DealerCards { get; set; } = new();
        public List<BlackjackCardDto> RemainingCards { get; set; } = new();
        public bool IsPlayerTurn { get; set; } = true;
        public bool IsGameOver { get; set; }
        public string StatusMessage { get; set; } = string.Empty;
        public string RoundResult { get; set; } = string.Empty;

        public int PlayerScore => GetHandValue(PlayerCards);
        public int DealerScore => GetHandValue(DealerCards.Where(card => card.IsFaceUp));

        public static int GetHandValue(IEnumerable<BlackjackCardDto> cards)
        {
            var score = 0;
            var aceCount = 0;

            foreach (var card in cards)
            {
                if (card.Value == "A")
                {
                    score += 11;
                    aceCount++;
                }
                else if (card.Value is "K" or "Q" or "J")
                {
                    score += 10;
                }
                else if (int.TryParse(card.Value, out var value))
                {
                    score += value;
                }
            }

            while (score > 21 && aceCount > 0)
            {
                score -= 10;
                aceCount--;
            }

            return score;
        }
    }
}
