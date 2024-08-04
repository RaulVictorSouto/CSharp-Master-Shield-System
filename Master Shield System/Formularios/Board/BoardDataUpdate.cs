using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSSLibrary;
using MySql.Data.MySqlClient;

namespace Master_Shield_System.Formularios.Board
{
    public partial class BoardDataUpdate : UserControl
    {
        public byte[] ReadBoardCover;
        public byte[] ReadBoardMap;
        private string caminhoArquivoImagemCapa = "";
        private string caminhoArquivoImagemMapa = "";
        public int ReadBoardId { get; set; }
        private BoardClass bc = new BoardClass();
       
        public BoardDataUpdate()
        {
            InitializeComponent();
        }

        public void SetDados(int boardId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                {
                    connection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM sgrpg.tblboard WHERE BoardId = @BoardId", connection);
                    mySqlCommand.Parameters.AddWithValue("@BoardId", (object)boardId);
                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        if (mySqlDataReader.Read())
                        {
                            this.ReadBoardId = Convert.ToInt32(mySqlDataReader["BoardId"]);
                            this.Txt_NomeCampanha.Text = mySqlDataReader["BoardTitle"].ToString();
                            this.Txt_NomeMestre.Text = mySqlDataReader["BoardMaster"].ToString();
                            if (!mySqlDataReader.IsDBNull(mySqlDataReader.GetOrdinal("BoardCover")))
                            {
                                byte[] byteArrayIn = (byte[])mySqlDataReader["BoardCover"];
                                this.Pcb_Capa.Image = this.ByteArrayToImage(byteArrayIn);
                                this.ReadBoardCover = byteArrayIn;
                            }
                            else
                                this.Btn_AlterarCapa.Text = "Incluir Capa";
                            if (!mySqlDataReader.IsDBNull(mySqlDataReader.GetOrdinal("BoardMap")))
                            {
                                byte[] byteArrayIn = (byte[])mySqlDataReader["BoardMap"];
                                this.Pcb_Mapa.Image = this.ByteArrayToImage(byteArrayIn);
                                this.ReadBoardMap = byteArrayIn;
                            }
                            else
                                this.Btn_AlterarMapa.Text = "Incluir Mapa";
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("ERRO: " + ex.Message, "Ocorreu um erro: SQL", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream memoryStream = new MemoryStream(byteArrayIn))
                return Image.FromStream((Stream)memoryStream);
        }

        private void Btn_Retornar_Click(object sender, EventArgs e)
        {
            BoardMain boardMain = new BoardMain();
            this.Controls.Clear();
            this.Controls.Add((Control)boardMain);
            boardMain.BringToFront();
        }

        private bool ValidarBoard(object obj)
        {
            // Valida o objeto usando o método ValidarObjeto
            IEnumerable<ValidationResult> validationResults = ValidadorClass.ValidarObjeto(obj);

            // Concatena as mensagens de erro de validação em uma string
            StringBuilder errorMessages = new StringBuilder();
            foreach (ValidationResult validationResult in validationResults)
            {
                errorMessages.AppendLine(validationResult.ErrorMessage);
            }

            // Verifica se há mensagens de erro e exibe-as em um MessageBox, se houver
            if (errorMessages.Length == 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show(errorMessages.ToString(), "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private BoardClass LeituraDeFormulario(int boardId)
        {
            try
            {
                BoardClass boardClass = new BoardClass()
                {
                    BoardId = boardId,
                    BoardTitle = this.Txt_NomeCampanha.Text.Trim(),
                    BoardMaster = this.Txt_NomeMestre.Text.Trim()
                };
                if (!string.IsNullOrEmpty(this.caminhoArquivoImagemCapa) && File.Exists(this.caminhoArquivoImagemCapa))
                {
                    byte[] byteArrayIn = File.ReadAllBytes(this.caminhoArquivoImagemCapa);
                    this.Pcb_Capa.Image = this.ByteArrayToImage(byteArrayIn);
                    boardClass.BoardCover = byteArrayIn;
                }
                else if (boardClass.BoardCover == null)
                    boardClass.BoardCover = this.ReadBoardCover;
                if (!string.IsNullOrEmpty(this.caminhoArquivoImagemMapa) && File.Exists(this.caminhoArquivoImagemMapa))
                {
                    byte[] byteArrayIn = File.ReadAllBytes(this.caminhoArquivoImagemMapa);
                    this.Pcb_Mapa.Image = this.ByteArrayToImage(byteArrayIn);
                    boardClass.BoardMap = byteArrayIn;
                }
                else if (boardClass.BoardMap == null)
                    boardClass.BoardMap = this.ReadBoardMap;
                this.ValidarBoard((object)boardClass);
                return boardClass;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("ERRO na leitura do formulário: " + ex.Message, "Ocorreu um erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return (BoardClass)null;
            }
        }

        private void Btn_Atualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int readBoardId = this.ReadBoardId;
                BoardClass boardClass = this.LeituraDeFormulario(readBoardId);
                if (!this.ValidarBoard((object)boardClass))
                    return;
                boardClass.UpdateBoard();
                this.SetDados(readBoardId);
                BoardMain boardMain = new BoardMain();
                this.Controls.Clear();
                this.Controls.Add((Control)boardMain);
                boardMain.BringToFront();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("Erro ao atualizar o board: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void Btn_ApagarCapa_Click(object sender, EventArgs e)
        {
            //remove a imagem de capa selecionada
            Pcb_Capa.Image = null;
            caminhoArquivoImagemCapa = null;
            AtualizarTextoBotaoCapa(false);
            bc.BoardCover = null;
        }

        private void Btn_ApagarMapa_Click(object sender, EventArgs e)
        {
            //remove a imagem de mapa selecionada
            Pcb_Mapa.Image = null;
            caminhoArquivoImagemMapa = null;
            AtualizarTextoBotaoMapa(false);
            bc.BoardMap = null;
        }

        private void AtualizarTextoBotaoCapa(bool imagemSelecionada) => Btn_AlterarCapa.Text = imagemSelecionada ? "Alterar Capa" : "Adicionar Capa";
        private void AtualizarTextoBotaoMapa(bool imagemSelecionada) => Btn_AlterarMapa.Text = imagemSelecionada ? "Alterar Mapa" : "Adicionar Mapa";


        private void Btn_Limpar_Click(object sender, EventArgs e) => LimparFormulario();

        private void LimparFormulario()
        {
            Txt_NomeCampanha.Text = string.Empty;
            Txt_NomeMestre.Text = string.Empty;
            Pcb_Capa.Image = null;
            caminhoArquivoImagemCapa = null;
            Pcb_Mapa.Image = null;
            caminhoArquivoImagemMapa = null;
            bc.BoardCover = null;
            bc.BoardMap = null;
        }

        private void Btn_AlterarCapa_Click(object sender, EventArgs e)
        {
            // Cria uma nova instância de OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                // Define os filtros para os tipos de arquivo suportados
                Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos os Arquivos|*.*"
            };

            // Verifica se o usuário selecionou um arquivo e clicou em "OK"
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Obtém o caminho do arquivo selecionado
                    this.caminhoArquivoImagemCapa = openFileDialog.FileName;

                    // Carrega a imagem e exibe no PictureBox
                    this.Pcb_Capa.Image = Image.FromFile(this.caminhoArquivoImagemCapa);

                    // Atualiza o texto do botão para "Alterar Capa"
                    AtualizarTextoBotaoCapa(true);
                }
                catch (Exception ex)
                {
                    // Exibe uma mensagem de erro se ocorrer uma exceção ao carregar a imagem
                    MessageBox.Show("Erro ao carregar a imagem: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_AlterarMapa_Click(object sender, EventArgs e)
        {
            // Cria uma nova instância de OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                // Define os filtros para os tipos de arquivo suportados
                Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos os Arquivos|*.*"
            };

            // Verifica se o usuário selecionou um arquivo e clicou em "OK"
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Obtém o caminho do arquivo selecionado
                    this.caminhoArquivoImagemMapa = openFileDialog.FileName;

                    // Carrega a imagem e exibe no PictureBox
                    this.Pcb_Mapa.Image = Image.FromFile(this.caminhoArquivoImagemMapa);

                    // Atualiza o texto do botão para "Alterar Mapa"
                    AtualizarTextoBotaoMapa(true);
                }
                catch (Exception ex)
                {
                    // Exibe uma mensagem de erro se ocorrer uma exceção ao carregar a imagem
                    MessageBox.Show("Erro ao carregar a imagem: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       
    }
}
