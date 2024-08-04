using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Master_Shield_System.Formularios.Board;
using MSSLibrary;

namespace Master_Shield_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UCClass.AddUserControl(this.panelContainer, (UserControl)new BoardMain());
        }
    }
}
