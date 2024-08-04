using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SGRPGLibrary;

namespace Master_Shield_System.Formularios.Board
{
    public partial class BoardMain : UserControl
    {
        private DataTable dt = new DataTable();
        public BoardMain()
        {
            InitializeComponent();
            this.Inicializar();
        }

        private void Inicializar()
        {
            dt = BoardClass.GetBoard(true);

            if (this.dt != null)
            {
                this.Dgv_Board.DataSource = this.dt;
                this.ConfigurarGradeBoard();

                if (this.Dgv_Board.Rows.Count > 0)
                {
                    this.Dgv_Board.Rows[0].Selected = true;
                    //this.Dgv_Board_CellClick(this.Dgv_Board, new DataGridViewCellEventArgs(0, 0));
                }
            }
            else
            {
                MessageBox.Show("Nenhum dado encontrado.");
            }
        }

        private void ConfigurarGradeBoard()
        {

            // Configurações gerais de fonte e alinhamento
            Dgv_Board.ColumnHeadersDefaultCellStyle.Font = new Font("Noto Sans", 9f, FontStyle.Bold);
            Dgv_Board.DefaultCellStyle.Font = new Font("Noto Sans", 9f);

            // Configuração da cor do texto
            Dgv_Board.DefaultCellStyle.ForeColor = Color.Black; // Cor do texto das células
            Dgv_Board.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Cor do texto dos cabeçalhos
            Dgv_Board.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray; // Cor de fundo dos cabeçalhos
            Dgv_Board.RowsDefaultCellStyle.ForeColor = Color.Black; // Cor do texto das linhas
            Dgv_Board.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // Cor de fundo das linhas alternadas

            // Configuração da coluna BoardId
            if (this.Dgv_Board.Columns["BoardId"] != null)
            {
                this.Dgv_Board.Columns["BoardId"].HeaderText = "ID";
                this.Dgv_Board.Columns["BoardId"].Visible = false;
            }

            // Configuração da coluna BoardTitle
            if (this.Dgv_Board.Columns["BoardTitle"] != null)
            {
                this.Dgv_Board.Columns["BoardTitle"].HeaderText = "Campanha";
                this.Dgv_Board.Columns["BoardTitle"].Width = 300;
                this.Dgv_Board.Columns["BoardTitle"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.Dgv_Board.Columns["BoardTitle"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Configuração da coluna BoardMaster
            if (this.Dgv_Board.Columns["BoardMaster"] != null)
            {
                this.Dgv_Board.Columns["BoardMaster"].HeaderText = "Mestre";
                this.Dgv_Board.Columns["BoardMaster"].Width = 150;
                this.Dgv_Board.Columns["BoardMaster"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.Dgv_Board.Columns["BoardMaster"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Configuração das colunas Editar e Excluir
            if (this.Dgv_Board.Columns["Editar"] != null)
            {
                this.Dgv_Board.Columns["Editar"].DisplayIndex = 4;
            }

            if (this.Dgv_Board.Columns["Excluir"] != null)
            {
                this.Dgv_Board.Columns["Excluir"].DisplayIndex = 4;
            }
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
