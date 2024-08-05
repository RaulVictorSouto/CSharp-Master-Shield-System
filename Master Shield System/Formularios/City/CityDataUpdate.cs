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

namespace Master_Shield_System.Formularios.City
{
    public partial class CityDataUpdate : UserControl
    {
        public int ReadCityId;
        public int ReadBoardId;
        public byte[] ReadCityImage;
        private string caminhoArquivoImagem = "";

        CityClass cc = new CityClass();
        public CityDataUpdate()
        {
            InitializeComponent();
        }

        public void SetDados(int cityId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                {
                    connection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM sgrpg.tblcity WHERE CityId = @CityId", connection);
                    mySqlCommand.Parameters.AddWithValue("@CityId", (object)cityId);
                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        if (mySqlDataReader.Read())
                        {
                            this.ReadBoardId = Convert.ToInt32(mySqlDataReader["BoardId"]);
                            this.ReadCityId = Convert.ToInt32(mySqlDataReader["CityId"]);
                            this.Txt_NomeCidade.Text = mySqlDataReader["CityName"].ToString();
                            this.Cbb_Bioma.Text = mySqlDataReader["CityBiome"].ToString();
                            this.Txt_descricao.Text = mySqlDataReader["CityDescription"].ToString();
                            if (!mySqlDataReader.IsDBNull(mySqlDataReader.GetOrdinal("CityImage")))
                            {
                                byte[] byteArrayIn = (byte[])mySqlDataReader["CityImage"];
                                this.Pcb_ImagemCidade.Image = this.ByteArrayToImage(byteArrayIn);
                                this.ReadCityImage = byteArrayIn;
                            }
                            else
                                this.Btn_IncluirImagem.Text = "Incluir Imagem";
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

        private CityClass LeituraDeFormulario(int cityId)
        {
            try
            {
                CityClass cityClass = new CityClass()
                {
                    CityId = cityId,
                    CityName = this.Txt_NomeCidade.Text.Trim(),
                    CityBiome = this.Cbb_Bioma.Text.Trim(),
                    CityDescription = this.Txt_descricao.Text.Trim()
                };
                if (!string.IsNullOrEmpty(this.caminhoArquivoImagem) && File.Exists(this.caminhoArquivoImagem))
                {
                    byte[] byteArrayIn = File.ReadAllBytes(this.caminhoArquivoImagem);
                    this.Pcb_ImagemCidade.Image = this.ByteArrayToImage(byteArrayIn);
                    cityClass.CityImage = byteArrayIn;
                }
                else if (cityClass.CityImage == null)
                    cityClass.CityImage = this.ReadCityImage;
                this.ValidarCity((object)cityClass);
                return cityClass;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("ERRO na leitura do formulário: " + ex.Message, "Ocorreu um erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return (CityClass)null;
            }
        }

        private bool ValidarCity(object obj)
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

        private void Btn_Atualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int readCityId = this.ReadCityId;
                CityClass cityClass1 = new CityClass();
                CityClass cityClass2 = this.LeituraDeFormulario(readCityId);
                if (!this.ValidarCity((object)cityClass2))
                    return;
                cityClass2.UpdateCity();
                CityMain cityMain = new CityMain();
                cityMain.SetBoardId(this.ReadBoardId);
                this.Controls.Clear();
                this.Controls.Add((Control)cityMain);
                cityMain.BringToFront();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("Erro ao atualizar a cidade: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void Btn_Retornar_Click(object sender, EventArgs e)
        {
            CityMain cityMain = new CityMain();
            cityMain.SetBoardId(this.ReadBoardId);
            this.Controls.Clear();
            this.Controls.Add((Control)cityMain);
            cityMain.BringToFront();
        }

        private void Btn_Limpar_Click(object sender, EventArgs e)
        {
            this.Txt_NomeCidade.Text = "";
            this.Cbb_Bioma.SelectedItem = (object)"Campos";
            this.Txt_descricao.Text = "";
            this.Pcb_ImagemCidade.Image = (Image)null;
            this.caminhoArquivoImagem = (string)null;
            AtualizarTextoBotao(false);
            this.cc.CityImage = (byte[])null;
        }

        private async void Btn_GerarDescricao_Click(object sender, EventArgs e)
        {
            ApiClass.LoadApiKey();
            await ApiClass.GerarTextoCidade(ApiClass.GeminiKey, this.Txt_NomeCidade.Text, this.Cbb_Bioma.Text);
            this.Txt_descricao.Text = ApiClass.TextoGerado;
        }

        private void Btn_ApagarImagem_Click(object sender, EventArgs e)
        {
            this.Pcb_ImagemCidade.Image = (Image)null;
            this.caminhoArquivoImagem = (string)null;
            AtualizarTextoBotao(false);
            this.cc.CityImage = (byte[])null;
        }

        private void Btn_IncluirImagem_Click(object sender, EventArgs e)
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
                    this.caminhoArquivoImagem = openFileDialog.FileName;

                    // Carrega a imagem e exibe no PictureBox
                    this.Pcb_ImagemCidade.Image = Image.FromFile(this.caminhoArquivoImagem);

                    // Atualiza o texto do botão para "Alterar Capa"
                    AtualizarTextoBotao(true);
                }
                catch (Exception ex)
                {
                    // Exibe uma mensagem de erro se ocorrer uma exceção ao carregar a imagem
                    MessageBox.Show("Erro ao carregar a imagem: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AtualizarTextoBotao(bool imagemSelecionada) => Btn_IncluirImagem.Text = imagemSelecionada ? "Alterar Imagem" : "Adicionar Imagem";
    }
}
