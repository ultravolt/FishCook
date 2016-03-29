namespace FishCookLib
{
    public class Resource
    {
        public int? Cost { get; internal set; }
        public int? Value { get; internal set; }
        public override string ToString()
        {
            return Value?.ToString();
        }
    }
}