using ProtoBuf;

namespace tictaktoe.Model
{
    [ProtoContract]
    public record TurnModel
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public int TurnCell { get; set; }
    }
}
