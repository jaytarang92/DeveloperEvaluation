using System;

namespace ItemChallenge.Models
{
    public class SubItemSummary
    {
        public SubItemSummary(Item subItem)
        {
            Id = subItem.Id;
            Name = subItem.Name;
        }

        public Guid Id;
        public string Name;
    }
}