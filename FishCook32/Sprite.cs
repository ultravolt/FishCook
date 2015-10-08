using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FishCook32
{
    public class Sprite
    {
        
        public Sprite(string fileName, double Scale=1.0)
        {
            this._surface = Image.FromFile(fileName);
            if (Scale != 1.0)
                SetScaledVersion(Scale);
            else
                this.Surface = _surface;
            
        }

        private void SetScaledVersion(double Scale)
        {
            this.Surface = (Image)(new Bitmap(this._surface, new Size((int)(this._surface.Size.Width * Scale), (int)(this._surface.Size.Height * Scale))));            
        }

        ~Sprite()
        {
            if (this.Surface != null)
                this.Surface.Dispose();
            if (this._surface != null)
                this._surface.Dispose();
        }

        public Image Surface { get; set; }

        public int Y { get; set; }

        public int Height { get { return this.Surface.Height; } }

        public int X { get; set; }

        public int Width { get { return this.Surface.Width; }}

        public string FileName { get; set; }

        public double Scale { get { return this.Scale; } set { this.Scale = value; SetScaledVersion(value); } }

        public Image _surface { get; set; }
    }
}
