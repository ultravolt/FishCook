namespace FishCookLib
{
    public interface IResource
    {
        int? Cost { get; set;}
        int? Value { get; set;}
        string ToString();

    }
}