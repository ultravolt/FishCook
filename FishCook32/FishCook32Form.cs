using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FishCookLib;
using System.Linq;
using System.Configuration;
using log4net;
using System.Diagnostics;

namespace FishCook32
{
    public partial class FishCook32Form : Form
    {
        public class Hex
        {
            public override string ToString()
            {
                return String.Format("({0}, {1})", this.Row, this.Column);
            }
            public PointF[] Points = new PointF[6];
            public Rectangle BoundingBox
            {
                get
                {
                    var upperLeft = new Point((int)Math.Round(Points[5].X), (int)Math.Round(Points[0].Y));
                    var lowerRight = new Point((int)Math.Round(Points[2].X), (int)Math.Round(Points[3].Y));
                    var rect = new Rectangle(upperLeft.X, upperLeft.Y, lowerRight.X - upperLeft.X, lowerRight.Y - upperLeft.Y);
                    return rect;
                }
            }

            public Point MiddlePoint
            {
                get
                {
                    int midX = (int)Math.Round(this.BoundingBox.X + (this.BoundingBox.Width * .5));
                    int midY = (int)Math.Round(this.BoundingBox.Y + (this.BoundingBox.Height * .5));
                    return new Point(midX, midY);
                }
            }


            public int Row { get; set; }

            public int Column { get; set; }

            public bool Hilight { get; set; }
        }

        public List<Hex> Hexes = new List<Hex>();

        private ILog log;
        private int side = 35;//35;
        public FishCook32Form()
        {
            base.Paint += new System.Windows.Forms.PaintEventHandler(this.Paint);
            //base.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown);
            base.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick);

            try
            {

                log = LogManager.GetLogger(this.GetType());
                log4net.Config.XmlConfigurator.Configure();
                log4net.NDC.Push(this.GetType().Assembly.FullName);
                RecipesConfigurationSection recipes = ConfigurationManager.GetSection("recipesConfiguration") as RecipesConfigurationSection;
                List<RecipeElement> recipeCards = recipes.Cards.Cast<RecipeElement>().ToList();

                if (Sprites == null)
                    Sprites = new SpriteCollection();

                if (Sprites.Count == 0)
                {

                    string[] images = null;
                    int horizontalOffset = 0;
                    int verticalOffset = 0;

                    images = new string[] { 
                    "./images/boards/FishMarket.png",
                    "./images/boards/IngredientMarket.png"
                    //"./images/cards/Assets_img_2.png"
                };

                    foreach (string i in images)
                    {
                        Sprite s = new Sprite(i, .10);
                        s.Y = verticalOffset;
                        verticalOffset += s.Height;
                        Sprites.Add(s);
                    }

                    images = new string[] 
                    {
                        "./images/counters/b.png",
                        "./images/counters/g.png",
                        "./images/counters/p.png",
                        "./images/counters/r.png",
                        "./images/counters/w.png",
                        "./images/counters/y.png"
                    };

                    foreach (string i in images)
                    {
                        Sprite s = new Sprite(i, .25);
                        s.X = horizontalOffset;
                        horizontalOffset += s.Width;
                        Sprites.Add(s);
                    }

                    Pen blackPen = new Pen(Color.Black, 3);
                    int height = (int)Math.Round(side * 1.714285714285714);
                    int width = (int)Math.Round(side * 1.514285714285714);
                    int leftMargin = (int)Math.Round(side * 0.5428571428571429);
                    int topMargin = 0;
                    float ShortSide = Convert.ToSingle(System.Math.Sin(30 * System.Math.PI / 180) * side);
                    float LongSide = Convert.ToSingle(System.Math.Cos(30 * System.Math.PI / 180) * side);

                    for (int j = 0; j < this.Columns; j++)
                    {
                        for (int i = 0; i < this.Rows; i++)
                        {
                            //if (i==0 && j==0)
                            var h = new Hex();
                            //PointF[] p = new PointF[6];//
                            var x = leftMargin + (width * j);
                            var y = topMargin + (j % 2 == 0 ? height / 2 : 0) + (height * i);
                            h.Points[0] = new PointF(x, y);
                            h.Points[1] = new PointF(x + side, y);
                            h.Points[2] = new PointF(x + side + ShortSide, y + LongSide);
                            h.Points[3] = new PointF(x + side, y + LongSide + LongSide);
                            h.Points[4] = new PointF(x, y + LongSide + LongSide);
                            h.Points[5] = new PointF(x - ShortSide, y + LongSide);
                            h.Row = i;
                            h.Column = j;
                            h.Hilight = false;
                            //this.Hexes
                            this.Hexes.Add(h);
  

                            //DrawGrid(g, (width * j), (j % 2 == 0 ? height / 2 : 0) + (height * i));
                        }

                    }

                }
                //Events.Run();
                //Video.Close();
            }
            catch (TypeInitializationException e)
            {
                log.Error(e.InnerException.Message, e);
            }
            InitializeComponent();
        }

        private new void Paint(object sender, PaintEventArgs e)
        {
            if (Sprites == null)
                return;

            Graphics g = e.Graphics;
            this.Hexes.ForEach(h => DrawHex(g, h));
            
        }

        public void DrawHex(Graphics bmg, Hex hex)// int x, int y, int row, int column)
        {
            //the length of the side of a hex
            Pen bpen = new Pen(Color.Black, 3);
            Pen rpen = new Pen(Color.Red, 1);
            bmg.DrawRectangle(rpen, hex.BoundingBox);
            if (hex.Hilight)
                bmg.FillPolygon(new SolidBrush(Color.White), hex.Points);

            bmg.DrawPolygon(bpen, hex.Points);
            
            var mp = hex.MiddlePoint;
            bmg.FillRectangle(new SolidBrush(bpen.Color), mp.X, mp.Y, 1, 1);
        
        }



        private new void MouseClick(object sender, MouseEventArgs e)
        {
            var p = new PointF(e.X, e.Y);
            var r = new Rectangle { X = (int)Math.Round(p.X), Y = e.Y, Height = 1, Width = 1 };
            var matches = this.Hexes.Where(x => x.BoundingBox.Contains(r));
            Hex match = null;
            if (matches.Any())
            {
                if (matches.Count() == 1)
                    match = matches.FirstOrDefault();
                else
                {
                    var a=matches.First();
                    var b=matches.Last();
                    var p1 = a.MiddlePoint;
                    var p2 = b.MiddlePoint;
                    var d1 = Math.Pow(p1.X - p.X, 2) + Math.Pow(p1.Y - p.Y, 2);
                    var d2 = Math.Pow(p2.X - p.X, 2) + Math.Pow(p2.Y - p.Y, 2);

                    match = d1 > d2 ? b : a;
                    Debug.WriteLine(matches);
                }

               Hilight(match);
               
            }
        }

        private void Hilight(Hex hex)
        {
            this.Hexes.ForEach(x => x.Hilight = false);
            hex.Hilight = true;
            this.DrawHex(this.CreateGraphics(), hex);
            //this.Refresh();
            
            //this.UpdateBounds(hex.BoundingBox.X, hex.BoundingBox.Y, hex.BoundingBox.Height, hex.BoundingBox.Width);
            //this.Paint(this, new PaintEventArgs(this.GetGra));
        }


        public List<Sprite> Sprites { get; set; }

        public int Columns = 12;
        public int Rows = 8;

    

        
    }
}
