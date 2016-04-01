using System;

namespace FishCookLib
{
    public class FishResource : IResource
    {
        public int? Cost { get; set; }

        public int? Value { get; set; }

        public void Spoil()
        {
            throw new NotImplementedException();
        }
    }
}