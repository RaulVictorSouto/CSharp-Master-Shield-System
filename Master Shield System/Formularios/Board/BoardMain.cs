using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Master_Shield_System.Formularios.City;
using MSSLibrary;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Master_Shield_System.Formularios.Board
{
    public partial class BoardMain : UserControl
    {
        private DataTable dt = new DataTable();
        public int ConfirmBoardId;
        CityMain cityMain = new CityMain();
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
                    this.Dgv_Board_CellClick(this.Dgv_Board, new DataGridViewCellEventArgs(0, 0));
                }
            }
            else
            {
                MessageBox.Show("Nenhum dado encontrado.");
            }

            if (Cbb_BoardFilter.Items.Count > 0)
            {
                Cbb_BoardFilter.SelectedIndex = 0; // Seleciona o primeiro item
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
            Dgv_Board.ReadOnly = true;

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
                this.Dgv_Board.Columns["BoardMaster"].Width = 155;
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

        private void Btn_Incluir_Click(object sender, EventArgs e)
        {
            BoardDataInsert boardDataInsert = new BoardDataInsert();
            this.Controls.Clear();
            this.Controls.Add((Control)boardDataInsert);
            boardDataInsert.BringToFront();
        }

        private void Dgv_Board_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se o índice da linha ou coluna é inválido
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            // Obtém o nome da coluna clicada
            string columnName = this.Dgv_Board.Columns[e.ColumnIndex].Name;

            // Tenta converter o valor da célula "BoardId" para um inteiro
            if (int.TryParse(this.Dgv_Board.Rows[e.RowIndex].Cells["BoardId"].Value?.ToString(), out int boardId))
            {
                // Executa a ação apropriada com base no nome da coluna
                switch (columnName)
                {
                    case "editar":
                        EditarCampanha(boardId);
                        break;

                    case "excluir":
                        ExcluirCampanha(boardId, e.RowIndex);
                        break;

                    default:
                        // Nenhuma ação para outras colunas
                        break;
                }
            }
            else
            {
                // Exibe uma mensagem de erro se o ID da campanha não for válido
                MessageBox.Show("O ID da campanha não é válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditarCampanha(int boardId)
        {
            try
            {
                BoardDataUpdate boardDataUpdate = new BoardDataUpdate();
                this.Controls.Clear();
                boardDataUpdate.SetDados(boardId);
                this.Controls.Add((Control)boardDataUpdate);
                boardDataUpdate.BringToFront();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("Erro ao carregar a campanha para edição: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void ExcluirCampanha(int boardId, int rowIndex)
        {
            // Exibe uma mensagem de confirmação antes de excluir a campanha
            DialogResult result = MessageBox.Show(
                "Deseja excluir esta campanha?\n\nOBS: Ao excluí-la, todas as Cidades e NPCs atribuídos a ela também serão excluídos. Deseja continuar?",
                "Exclusão de Campanha",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Se o usuário escolheu "No", interrompe a execução
            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                // Exclui a campanha utilizando a classe BoardClass
                new BoardClass().DeleteBoard(boardId);

                // Remove a linha correspondente da DataGridView
                this.Dgv_Board.Rows.RemoveAt(rowIndex);

                // Se ainda há linhas restantes na DataGridView
                if (this.Dgv_Board.Rows.Count > 0)
                {
                    this.Dgv_Board.ClearSelection();

                    // Seleciona a linha apropriada após a remoção
                    int newSelectedIndex = rowIndex > 0 ? rowIndex - 1 : 0;
                    this.Dgv_Board.Rows[newSelectedIndex].Selected = true;

                    // Carrega os detalhes da campanha selecionada
                    int newBoardId = Convert.ToInt32(this.Dgv_Board.Rows[newSelectedIndex].Cells["BoardId"].Value);
                    this.CarregarDetalhesCampanha(newBoardId);
                }
                else
                {
                    // Se não há mais linhas, limpa os detalhes da campanha
                    this.Lbl_Title.Text = "";
                    this.Lbl_Master.Text = "";
                    this.Pcb_Capa.Image = null;
                    this.Pcb_Mapa.Image = null;
                }
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro em caso de exceção
                MessageBox.Show("Erro ao excluir a campanha: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarDetalhesCampanha(int boardId)
        {
            try
            {
                // Cria e abre uma conexão com o banco de dados
                using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                {
                    connection.Open();

                    // Prepara o comando SQL para buscar os detalhes da campanha
                    MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM sgrpg.tblboard WHERE BoardId = @BoardId", connection);
                    mySqlCommand.Parameters.AddWithValue("@BoardId", boardId);

                    // Executa o comando e lê os dados retornados
                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        if (mySqlDataReader.Read())
                        {
                            // Atualiza os controles com os dados da campanha
                            this.Lbl_Title.Text = mySqlDataReader["BoardTitle"].ToString();
                            this.Lbl_Master.Text = mySqlDataReader["BoardMaster"].ToString();
                            this.Pcb_Capa.Image = mySqlDataReader.IsDBNull(mySqlDataReader.GetOrdinal("BoardCover"))
                                ? null
                                : ByteArrayToImage((byte[])mySqlDataReader["BoardCover"]);
                            this.Pcb_Mapa.Image = mySqlDataReader.IsDBNull(mySqlDataReader.GetOrdinal("BoardMap"))
                                ? null
                                : ByteArrayToImage((byte[])mySqlDataReader["BoardMap"]);
                        }
                        else
                        {
                            // Limpa as imagens se não encontrar a campanha
                            this.Pcb_Capa.Image = null;
                            this.Pcb_Mapa.Image = null;
                        }
                    }
                }

                // Define o ID da campanha confirmada
                ConfirmBoardId = boardId;
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro em caso de exceção
                MessageBox.Show("ERRO: " + ex.Message, "Ocorreu um erro ao carregar os detalhes da campanha: SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para converter um array de bytes em uma imagem
        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private void Dgv_Board_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se o clique foi em uma célula válida
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Obtém o nome da coluna clicada
            string columnName = Dgv_Board.Columns[e.ColumnIndex].Name;

            // Tenta obter o ID da campanha da célula clicada
            if (int.TryParse(Dgv_Board.Rows[e.RowIndex].Cells["BoardId"].Value?.ToString(), out int boardId))
            {
                // Carrega os detalhes da campanha com base no ID
                CarregarDetalhesCampanha(boardId);
            }
            else
            {
                // Exibe uma mensagem de erro se o ID não for válido
                MessageBox.Show("O ID da campanha não é válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Pesquisar_Click(object sender, EventArgs e) => this.FiltrarGrade();

        public void FiltrarGrade()
        {
            // Verifica se o filtro está selecionado e a pesquisa não está vazia
            if (string.IsNullOrEmpty(this.Txt_Pesquisa.Text) || this.Cbb_BoardFilter.SelectedIndex < 0)
            {
                // Limpa o filtro se a pesquisa estiver vazia
                this.dt.DefaultView.RowFilter = string.Empty;
                return;
            }

            // Obtém o nome da coluna com base na seleção do ComboBox
            string filterColumn;
            switch (this.Cbb_BoardFilter.Text)
            {
                case "Campanha":
                    filterColumn = "BoardTitle";
                    break;
                case "Mestre":
                    filterColumn = "BoardMaster";
                    break;
                default:
                    throw new InvalidOperationException("Filtro não reconhecido.");
            }

            // Aplica o filtro à DefaultView do DataTable
            string filterExpression = $"{filterColumn} LIKE '%{this.Txt_Pesquisa.Text}%'";
            this.dt.DefaultView.RowFilter = filterExpression;
        }

        private void Dgv_Board_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se o clique foi em uma célula válida
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Obtém o nome da coluna clicada
            string columnName = this.Dgv_Board.Columns[e.ColumnIndex].Name;

            // Verifica se a coluna clicada não é "Editar" ou "Excluir"
            if (columnName != "editar" && columnName != "excluir")
            {
                try
                {
                    // Obtém o valor da célula "BoardId" e converte para int
                    if (int.TryParse(this.Dgv_Board.Rows[e.RowIndex].Cells["BoardId"].Value?.ToString(), out int boardId))
                    {
                        // Atualiza a interface do usuário
                        this.SuspendLayout();
                        cityMain.SetBoardId(this.ConfirmBoardId);
                        this.Controls.Clear();
                        this.Controls.Add(cityMain);
                        cityMain.BringToFront();
                        this.ResumeLayout();
                    }
                    else
                    {
                        MessageBox.Show("ID da campanha não é válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao processar a ação: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_Selecionar_Click(object sender, EventArgs e)
        {
            cityMain.SetBoardId(this.ConfirmBoardId);
            this.Controls.Clear();
            this.Controls.Add((Control)cityMain);
            cityMain.BringToFront();
        }
    }
}
