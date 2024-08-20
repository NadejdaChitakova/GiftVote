namespace GiftVote.Data.Models
{
    public sealed class Ballot(
                           DateTime startTime, 
                           DateTime? endTime,
                           int creatorId,
                           int giftReceiverId) 
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; } = startTime;
        public DateTime? EndTime { get; set; } = endTime;
        public int CreatorId { get; set; } = creatorId;
        public Employee Creator { get; set; }
        public int GiftReceiverId { get; set; } = giftReceiverId;
        public Employee GiftReceiver { get; set; }
        public List<Vote> Votes { get; set; }

    }
}
