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

namespace FishCook32
{
    public partial class FishCook32Form : Form
    {
        public FishCook32Form()
        {
            base.Paint += new System.Windows.Forms.PaintEventHandler(this.Paint);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown);
            InitializeComponent();
        }

        

    

        
    }
}
