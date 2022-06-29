namespace GeodistanceApi.Extensions
{
    public static class DoubleExtensions
    {
        public static double ToRadian(this double degree) => degree * Math.PI / 180;
        public static double FromRadian(this double degree) => degree / Math.PI * 180;
    }
}
