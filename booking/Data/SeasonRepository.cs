using System;

namespace booking.Data
{
    public class SeasonRepository
    {
        public decimal GetRateForDate(DateTime date)
        {
            if (date.Month == 12)
            {
                if (date.Day >= 1 && date.Day <= 7)
                    return 550m;
                else if (date.Day >= 8 && date.Day <= 15)
                    return 750m;
                else
                    return 995m;
            }
            return 550m;
        }

        public decimal CalculateStayCost(DateTime checkIn, DateTime checkOut)
        {
            decimal total = 0m;
            DateTime current = checkIn;
            while (current < checkOut)
            {
                total += GetRateForDate(current);
                current = current.AddDays(1);
            }
            return total;
        }

        public decimal CalculateDeposit(decimal totalCost)
        {
            return totalCost * 0.10m;
        }
    }
}