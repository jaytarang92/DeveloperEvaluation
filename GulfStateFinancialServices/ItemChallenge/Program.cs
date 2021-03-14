using System.Collections.Generic;
using ItemChallenge.Models;

namespace ItemChallenge
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var carHandler = new ItemHandler();
            
            /*
             * - Brand
             *   - Car
             *     - Engine
             *     - Transmission
             */
            
            var bmwBrand = new Item("0", "Manufacturer", "Bayerische Motoren Werke AG");
            var bmwZ4 = new Item("1", "Includes the Executive and ShadowLine packages", "2021 BMW X3 M40i");
            List<Item> carSubItems = new List<Item>()
            {
                new Item("2", "BMW Engine in Supra, Z4, M40i", "B58 Engine"),
                new Item("3", "One of the fastest Automatic transmissions", "ZF 8-Speed Transmission")
            };
            
            carSubItems.ForEach(subItem => bmwZ4.AddSubItem(subItem));
            bmwBrand.AddSubItem(bmwZ4);
            carHandler.AddItem(bmwBrand);
            
            var bmw4SubItemSummary = carHandler.GetSubItemSummary("0");
            var bmw4SubItemSummaryAlt = carHandler.GetSubItemSummaryAlt("0");
        }
    }
}