using System;
using BloodDonorTracker.Extensions;

namespace BloodDonorTracker.Helper
{
    public class DistanceTracker
    {

        public static double Calculate(double latFrom,double longFrom,double latTo,double longTo,DistanceType distanceType)
        {
            var haversineInKilometres = HaversineFormula(latFrom, longFrom, latTo, longTo);

            // switch (distanceType)
            // {
            //     case DistanceType.Kilometres:
            //         return $"{FormatKilometres(haversineInKilometres)} Kilometres";
            //     case DistanceType.Miles:
            //         return $"{KilometresToMiles(haversineInKilometres)} Miles";
            //     case DistanceType.Metres:
            //         return $"{KilometresToMetres(haversineInKilometres)} Metres";
            //     default:
            //         return string.Empty;
            // }

            switch (distanceType)
            {
                case DistanceType.Kilometres:
                    return FormatKilometres(haversineInKilometres);
                case DistanceType.Miles:
                    return KilometresToMiles(haversineInKilometres);
                case DistanceType.Metres:
                    return KilometresToMetres(haversineInKilometres);
                default:
                    return double.MaxValue;
            }
        }

        private static double HaversineFormula(double latFrom, double longFrom, double latTo, double longTo)
        {
            const double EquatorialRadiusOfEarth = 6371D;
            const double DegreesToRadians = (Math.PI / 180D);

            var deltalat = (latTo - latFrom) * DegreesToRadians;
            var deltalong = (longTo - longFrom) * DegreesToRadians;

            var a = Math.Pow(
                Math.Sin(deltalat / 2D), 2D) +
                Math.Cos(latFrom * DegreesToRadians) *
                Math.Cos(latTo * DegreesToRadians) *
                Math.Pow(Math.Sin(deltalong / 2D), 2D);

            var c = 2D * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1D - a));

            var d = EquatorialRadiusOfEarth * c;

            return d;
        }

        private static double FormatKilometres(double kilometres)
        {
            var roundedToTwoDecimalPlaces = kilometres.RoundToTwoDecimalPlaces();

            if (roundedToTwoDecimalPlaces <= 1)
            {
                return roundedToTwoDecimalPlaces;
            }
            else
            {
                var roundedUpOrDown = roundedToTwoDecimalPlaces.RoundUpOrDown();

                return roundedUpOrDown;
            }
        }

        private static double KilometresToMetres(double kilometres)
        {
            var result = (1000D * kilometres);
            var roundedToTwoDecimalPlaces = result.RoundToTwoDecimalPlaces();

            if (roundedToTwoDecimalPlaces <= 1)
            {
                return roundedToTwoDecimalPlaces;
            }
            else
            {
                var roundedUpOrDown = roundedToTwoDecimalPlaces.RoundUpOrDown();

                return roundedUpOrDown;
            }
        }

        private static double KilometresToMiles(double kilometres)
        {
            var result = (kilometres / 1.609344);
            var roundedToTwoDecimalPlaces = result.RoundToTwoDecimalPlaces();

            if (roundedToTwoDecimalPlaces <= 1)
            {
                return roundedToTwoDecimalPlaces;
            }
            else
            {
                var roundedUpOrDown = roundedToTwoDecimalPlaces.RoundUpOrDown();

                return roundedUpOrDown;
            }
        }

    }
}
