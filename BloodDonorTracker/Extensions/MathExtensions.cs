using System;

namespace BloodDonorTracker.Extensions
{
    public static class MathExtensions
    {
        public static double RoundToTwoDecimalPlaces(this double number)
        {
            var rounded = Math.Round(number, 2);

            return rounded;
        }

        public static double RoundUpOrDown(this double number)
        {
            var roundedDoubleNumber = RoundedDivision(number);

            return roundedDoubleNumber;
        }

        private static double RoundedDivision(double number)
        {
            double divisor = 1;
            double div = number / divisor;
            double floor = Math.Floor(div);
            double celing = Math.Ceiling(div);
            var difference = (div - floor);

            return difference < 0.5 ? floor : celing;
        }
    }
}