using ProtoBuf;

namespace tictaktoe.Model
{
    [ProtoContract]
    public record GameModel
    {
        [ProtoMember(1)]
        public int Id { get; set; }
    }
}
