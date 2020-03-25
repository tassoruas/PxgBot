using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PxgBot
{
    public partial class HUD : Form
    {
        public HUD()
        {
            InitializeComponent();
            TransparencyKey = BackColor;
        }
    }
}
