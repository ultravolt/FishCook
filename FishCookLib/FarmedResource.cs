using System;

namespace FishCookLib
{
    public class FarmedResource : IResource
    {
        public byte[] FillsOn { get; set;}

        public int? Value { get; set; }

        public int? Cost { get; set; }
    }
}