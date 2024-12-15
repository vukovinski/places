namespace places.web
{
    public class GeoDistanceCalculator
    {
        private const double EarthRadiusKm = 6371.0;

        public static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            double radLat1 = DegreesToRadians(lat1);
            double radLat2 = DegreesToRadians(lat2);
            double deltaLat = DegreesToRadians(lat2 - lat1);
            double deltaLon = DegreesToRadians(lon2 - lon1);

            double a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                       Math.Cos(radLat1) * Math.Cos(radLat2) *
                       Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = EarthRadiusKm * c;

            return distance;
        }

        private static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }
    }
}
