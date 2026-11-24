namespace UTB.Rusryl_Interaktivni_mapa_kasina.Web.Areas.Admin.Controllers
{
    public class RouletteBetDto
    {
        public string BetType { get; set; } = string.Empty;
        public int Amount { get; set; }
    }

    public class RouletteTableViewModel
    {
        public long Balance { get; set; } = 1000;
        public int BetAmount { get; set; } = 10;
        public string SelectedBetType { get; set; } = "";
        public int? SelectedNumber { get; set; }
        public List<RouletteBetDto> Bets { get; set; } = new();
        public long TotalBetAmount => Bets.Sum(bet => (long)bet.Amount);
        public long GetBetAmount(string betType) => Bets.Where(bet => bet.BetType == betType).Sum(bet => (long)bet.Amount);
        public int? ResultNumber { get; set; }
        public string ResultColor { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public bool IsWin { get; set; }

        public static string GetNumberColor(int number)
        {
            if (number == 0)
            {
                return "green";
            }

            return RedNumbers.Contains(number) ? "red" : "black";
        }

        public static readonly int[] WheelNumbers =
        [
            0, 32, 15, 19, 4, 21, 2, 25, 17, 34, 6, 27, 13, 36, 11, 30, 8, 23, 10,
            5, 24, 16, 33, 1, 20, 14, 31, 9, 22, 18, 29, 7, 28, 12, 35, 3, 26
        ];

        private static readonly HashSet<int> RedNumbers =
        [
            1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36
        ];
    }
}
