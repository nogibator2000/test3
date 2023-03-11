namespace tictaktoe.Model
{
    public static class GlobalData
    {
        public static Queue<int> Queue { get; set; }
        public static Dictionary<int, BoardModel> Games { get; set; }
        public static Dictionary<int, int> PlayerGame { get; set; }
    }
}
