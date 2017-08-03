using FishCookLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FishCookWF
{
    public partial class MainForm : Form
    {
        public static GameLogic GameLogic;
        public static Dictionary<string, Image> ImageCache;
        public MainForm()
        {
            GameLogic=new GameLogic();
            ImageCache = new Dictionary<string, Image>();
            var a=GameLogic.Recipes.Select(x => x).ToList();
            var dieFaces = new List<string> { "One", "Two", "Three", "Four", "Five", "Six" };
            //this.DoubleBuffered = true;
            InitializeComponent();


            a.ForEach(x => ImageCache.Add(x.Source, Bitmap.FromFile($@".\Content\{x.Source}.png")));
            dieFaces.ForEach(x => ImageCache.Add(x, Bitmap.FromFile($@".\Content\{x}.png")));
            //this.BackgroundImage = Game.BackgroundImage;
            this.Paint += new PaintEventHandler(this.PaintEvent);
            this.MouseDown += new MouseEventHandler(this.MouseEvent);
        }

        private void MouseEvent(object sender, MouseEventArgs e)
        {
            var p = new Point(e.X, e.Y);
        }
            private void PaintEvent(object sender, PaintEventArgs e)
        {
            using (var g = e.Graphics)
            {
                var i = ImageCache.ElementAt(0).Value;
                g.DrawImage(i, 0, 0, i.Width, i.Height);
            }
        }
    }
}
