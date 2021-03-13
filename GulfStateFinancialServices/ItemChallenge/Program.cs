using System;
using System.Collections.Generic;
using ItemChallenge.Models;
using ItemChallenge;

namespace ItemChallenge
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var carSubItems = new List<Item>()
            {
                 new Item("2", "BMW Engine in Supra, Z4, M40i", "B58 Engine"),
                 new Item("3", "One of the fastest Automatic transmissions", "ZF 8-Speed Transmission")
            };
            var bmwZ4 = new Item("1", "Includes the Executive and ShadowLine packages", "2022 BMW X3 M40i");
            foreach (var subItem in carSubItems)
            {
                bmwZ4.AddSubItem(subItem);
            }
            var carHandler = new ItemHandler();
            carHandler.AddItem(bmwZ4);
            var bmwz4SubItemSummary = carHandler.GetSubItemSummaryAlt("1");
            Console.WriteLine(bmwZ4.Id);
        }
    }
}
