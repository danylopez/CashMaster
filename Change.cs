using System;
using System.Collections.Generic;
using System.Linq;

namespace CashMaster
{
    public static class Change
    {
        private static readonly string currency = "XYZ";
        private static List<decimal> _result = new List<decimal>();
        public static List<Money> MainChange(decimal price, List<Money> paid)
        {
            var due = CalculateDue(price, paid);
            if (due <= 0)
            {
                Console.WriteLine("You need to provide enough money.");
                return null;
            }
            else
            {
                CalculateChange(new List<decimal>(), Country.GetDenomination(currency), 0, 0, due);
                return DisplayChange(_result, Country.GetDenomination(currency));
            }
        }
        private static decimal CalculateDue(decimal price, List<Money> paid)
        {
            try
            {
                var sum = decimal.Zero;
                foreach (var t in paid)
                {
                    sum += (t.Denomination * t.Total);
                }
                return sum - price;
            }
            catch (Exception ex) {
                Console.WriteLine("Exception caught: {0}", ex.Message);
            }
            return Decimal.Zero;
        }
        private static void CalculateChange(List<decimal> coinsBills, List<decimal> amounts, decimal max, decimal sum, decimal goal)
        {
            if (sum == goal)
            {
                _result = coinsBills;
                return;
            }
            if (sum > goal)
            {
                return;
            }
            foreach (decimal value in amounts)
            {
                if (value >= max)
                {
                    List<decimal> copy = new List<decimal>(coinsBills);
                    copy.Add(value);
                    CalculateChange(copy, amounts, value, sum + value, goal);
                }
            }
        }
        private static List<Money> DisplayChange(List<decimal> coinsBills, List<decimal> amounts)
        {
            List<Money> listChange =  new List<Money>();
            Console.WriteLine("Change...");
            foreach (decimal amount in amounts)
            {
                int count = coinsBills.Count(value => value == amount);
                listChange.Add(new Money(){Denomination = amount, Total = count});
                Console.WriteLine("{0}: {1}", amount, count);
            }
            return listChange;
        }
    }
}