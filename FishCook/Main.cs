using System;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Input;
using SdlDotNet.Core;
using SdlDotNet.Graphics.Sprites;
using System.IO;

namespace FishCook
{
    public class MainClass : SDLApplication
    {
        
        /// <summary>
        /// Static Entry Point for the Class.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            // Create the demo application
            using (MainClass main = new MainClass())
            {
                
                main.Run(800, 600);
            }

        }

        private void Run(int p, int p_2)
        {
            base.Initialize(p, p_2);
        }



        
    }
   

}
