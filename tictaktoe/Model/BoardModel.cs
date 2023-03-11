using ProtoBuf;

namespace tictaktoe.Model
{
    [ProtoContract]
    public record BoardModel
    {
        [ProtoMember(1)]
        public int[] BoardAsset { get; set; }
        [ProtoMember(2)]
        public int TurnNumber { get; set; }
        [ProtoMember(3)]
        public bool CurrentPlayer { get; set; }
        [ProtoMember(4)]
        public int WinningCombination { get; set; }
    }
}
