using System.Collections.Generic;

namespace CashMaster
{
    public static class Country
    {
        public static List<decimal> GetDenomination(string currency)
        {
            switch (currency)
            {
                case "USD":
                    return new List<decimal>() {0.01M, 0.05M, 0.10M, 0.25M, 0.50M, 1.00M, 2.00M, 5.00M, 10.00M, 20.00M, 50.00M, 100.00M};
                case "MXN":
                    return new List<decimal>() {0.05M, 0.10M, 0.20M, 0.50M, 1.00M, 2.00M, 5.00M, 10.00M, 20.00M, 50.00M, 100.00M};
                case "XYZ":
                    return new List<decimal>() {5.00M, 10.00M, 20.00M, 25.00M};
                default:
                    throw new System.NotImplementedException();
            }
        }
    }
}