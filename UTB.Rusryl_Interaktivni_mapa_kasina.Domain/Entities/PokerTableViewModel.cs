namespace UTB.Rusryl_Interaktivni_mapa_kasina.Web.Areas.Admin.Controllers
{
    public class CardDto
    {
        public string Value { get; set; } = string.Empty;
        public string Suit { get; set; } = string.Empty;
        public bool IsFaceUp { get; set; } = true;
    }

    public class PokerTableViewModel
    {
        public List<CardDto> CommunityCards { get; set; } = new();
        public List<CardDto> PlayerCards { get; set; } = new();
        public int RevealedCommunityCardsCount { get; set; }
        public string RoundName { get; set; } = "Před flopem";
        public string NextActionText { get; set; } = "Otočit flop";

        public bool CanContinue => RevealedCommunityCardsCount < 5;
    }
}
