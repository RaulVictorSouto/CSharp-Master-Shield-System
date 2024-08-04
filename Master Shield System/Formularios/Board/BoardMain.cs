using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Master_Shield_System.Formularios.Board
{
    public partial class BoardMain : UserControl
    {
        public BoardMain()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Incluir_Click(object sender, EventArgs e)
        {
            BoardDataInsert boardDataInsert = new BoardDataInsert();
            this.Controls.Clear();
            this.Controls.Add((Control)boardDataInsert);
            boardDataInsert.BringToFront();
        }
    }
}
