using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using ItemChallenge.Models;

namespace ItemChallenge
{
    public class ItemHandler
    {
        private List<Item> _items = new ();

        public void AddItem(Item item) { _items.Add(item); }
        private static IEnumerable<SubItemSummary> TransformSubItems(Item item, IEnumerable<Item> _)
        {
            if (item != null)
            {
                return item.GetSubItems().Select(subItem => new SubItemSummary(subItem)).ToArray();
            }
            throw new ApplicationException("Item cannot be null.");
        }
            
        private IEnumerable<Item> GetSubItems(string itemNumber)
        {
            return _items.First(item => itemNumber == item.Number).GetSubItems();
        }
        
        /// <summary>
        /// Gets a sub-item summary for a given item number.
        /// </summary>
        /// <param name="itemNumber">The item number of the item to get the sub-item summary of.</param>
        public SubItemSummary[] GetSubItemSummary(string itemNumber)
        {
            IEnumerable<Item> subItems = GetSubItems(itemNumber);

            List<SubItemSummary> subItemSummary = new List<SubItemSummary>();

            foreach (Item item in subItems)
            {
                IEnumerable<SubItemSummary> tempSummaries = TransformSubItems(item, item.GetSubItems());

                subItemSummary.AddRange(tempSummaries);
            }

            return subItemSummary.ToArray();
        }

        public SubItemSummary[] GetSubItemSummaryAlt(string itemNumber)
        {
            return GetSubItems(itemNumber).SelectMany(subItem => TransformSubItems(subItem, null)).ToArray();
        }

    }
}