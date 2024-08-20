namespace GiftVote.Data.Models
{
    public sealed class Gifts(
        string name)
    {
        public int Id { get; init; }

        public string Name { get; init; } = name;

        public List<Vote> Votes { get; set; }
    }
}
