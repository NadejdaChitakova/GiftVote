﻿namespace GiftVote.Data.Models
{
    public sealed class Gifts
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public List<Vote> Votes { get; set; }

        public static Gifts GiftFactory(string name)
            => new()
            {
                Name = name
            };
    }
}
