namespace GiftVote.Data.Models
{
    public sealed class Ballot
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int CreatorId { get; set; }
        public Employee Creator { get; set; }
        public int GiftReceiverId { get; set; }
        public Employee GiftReceiver { get; set; }
        public List<Vote> Votes { get; set; }
    }
}
