namespace tictaktoe.Model
{
    public record BoardModel
    {
        public int[] BoardAsset { get; set; }
        public int TurnNumber { get; set; }
        public bool CurrentPlayer { get; set; }
        public int WinningCombination { get; set; }
    }
}
