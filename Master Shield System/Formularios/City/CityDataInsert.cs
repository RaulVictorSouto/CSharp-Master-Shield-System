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

namespace Master_Shield_System.Formularios.City
{
    public partial class CityDataInsert : UserControl
    {
        private CityClass cc = new CityClass();
        public int ConfirmBoardId;
        private string caminhoArquivoImagemCidade = "";

        public CityDataInsert()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            if (Cbb_Bioma.Items.Count > 0)
            {
                Cbb_Bioma.SelectedIndex = 0; // Seleciona o primeiro item
            }
            AtualizarEstadoBotoes();
        }

        public void SetDados(int boardId) => this.ConfirmBoardId = boardId;

        private CityClass LeituraDeFormulario()
        {
            // Lê os dados do formulário e preenche a instância de CityClass
            cc.CityName = Txt_NomeCampanha.Text;
            cc.CityBiome = Cbb_Bioma.Text;
            cc.CityDescription = Txt_descricao.Text;

            // Lê a imagem da cidade se o caminho estiver válido
            cc.CityImage = CarregarImagem(this.caminhoArquivoImagemCidade);

            // Valida a instância de CityClass
            ValidarCity(cc);

            return cc;
        }

        // Função auxiliar para carregar a imagem da cidade
        private byte[] CarregarImagem(string caminhoArquivo)
        {
            if (!string.IsNullOrEmpty(caminhoArquivo) && File.Exists(caminhoArquivo))
            {
                return File.ReadAllBytes(caminhoArquivo);
            }
            return null;
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

        private void Btn_Incluir_Click(object sender, EventArgs e)
        {
            this.cc = this.LeituraDeFormulario();
            if (!this.ValidarCity((object)this.cc))
                return;
            this.cc.CreateCity(this.ConfirmBoardId);
            LimparFormulario();
            
        }

        private void LimparFormulario()
        {
            this.Cbb_Bioma.SelectedItem = (object)"Campos";
            this.Txt_NomeCampanha.Text = "";
            this.Txt_descricao.Text = "";
            this.Pcb_Imagem.Image = (Image)null;
            this.caminhoArquivoImagemCidade = (string)null;
            AtualizarTextoBotao(false);
            AtualizarEstadoBotoes();
            this.cc.CityImage = (byte[])null;
        }

        private void Btn_Limpar_Click(object sender, EventArgs e) => LimparFormulario();

        private void Btn_Retornar_Click(object sender, EventArgs e)
        {
            CityMain cityMain = new CityMain();
            cityMain.SetBoardId(this.ConfirmBoardId);
            this.Controls.Clear();
            this.Controls.Add((Control)cityMain);
            cityMain.BringToFront();
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
                    this.caminhoArquivoImagemCidade = openFileDialog.FileName;

                    // Carrega a imagem e exibe no PictureBox
                    this.Pcb_Imagem.Image = Image.FromFile(this.caminhoArquivoImagemCidade);

                    // Atualiza o texto do botão para "Alterar Capa"
                    AtualizarTextoBotao(true);
                    AtualizarEstadoBotoes();
                }
                catch (Exception ex)
                {
                    // Exibe uma mensagem de erro se ocorrer uma exceção ao carregar a imagem
                    MessageBox.Show("Erro ao carregar a imagem: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AtualizarTextoBotao(bool imagemSelecionada) => Btn_IncluirImagem.Text = imagemSelecionada ? "Alterar Imagem" : "Adicionar Imagem";

        private void Btn_ApagarImagem_Click(object sender, EventArgs e)
        {
            //remove a imagem de capa selecionada
            Pcb_Imagem.Image = null;
            caminhoArquivoImagemCidade = null;
            AtualizarTextoBotao(false);
            AtualizarEstadoBotoes(); 
            cc.CityImage = null;
        }

        private async void Btn_GerarDescricao_Click(object sender, EventArgs e)
        {
            ApiClass.LoadApiKey();
            await ApiClass.GerarTextoCidade(ApiClass.GeminiKey, this.Txt_NomeCampanha.Text, this.Cbb_Bioma.Text);
            this.Txt_descricao.Text = ApiClass.TextoGerado;
        }

        private void AtualizarEstadoBotoes() => Btn_ApagarImagem.Enabled = Pcb_Imagem.Image != null || cc.CityImage != null;
    }
}
