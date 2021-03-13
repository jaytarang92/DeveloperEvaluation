using System;
using System.Collections.Generic;

namespace ItemChallenge.Models
{
    public class Item
    {
        private List<Item> _subItems = new List<Item>();
        public Item(string itemNumber, string itemDescription, string itemName)
        {
            Id = Guid.NewGuid();
            Number = itemNumber;
            Description = itemDescription;
            Name = itemName;
        }
        public void AddSubItem(Item item) { _subItems.Add(item); }

        public IEnumerable<Item> GetSubItems() { return _subItems; }

        public Guid Id;
        public string Number;
        public string Description;
        public string Name;
    }
}