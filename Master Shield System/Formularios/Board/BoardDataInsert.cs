using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSSLibrary;
using System.ComponentModel.DataAnnotations;

namespace Master_Shield_System.Formularios.Board
{
    public partial class BoardDataInsert : UserControl
    {
        private BoardClass bc = new BoardClass();
        private string caminhoArquivoImagemCapa = "";
        private string caminhoArquivoImagemMapa = "";
        public BoardDataInsert()
        {
            InitializeComponent();
        }

        private BoardClass LeituraDeFormulario()
        {
            // Inicializa variáveis para os bytes das imagens
            byte[] coverImageBytes = null;
            byte[] mapImageBytes = null;

            // Lê o nome da campanha
            bc.BoardTitle = Txt_NomeCampanha.Text;

            // Lê o nome do mestre
            bc.BoardMaster = Txt_NomeMestre.Text;

            // Lê o caminho da imagem da capa
            if (!string.IsNullOrEmpty(this.caminhoArquivoImagemCapa) && File.Exists(this.caminhoArquivoImagemCapa))
            {
                coverImageBytes = File.ReadAllBytes(this.caminhoArquivoImagemCapa);
            }
            bc.BoardCover = coverImageBytes;

            // Lê o caminho da imagem do mapa
            if (!string.IsNullOrEmpty(this.caminhoArquivoImagemMapa) && File.Exists(this.caminhoArquivoImagemMapa))
            {
                mapImageBytes = File.ReadAllBytes(this.caminhoArquivoImagemMapa);
            }
            bc.BoardMap = mapImageBytes;

            return bc;
        }


        private void Btn_Incluir_Click(object sender, EventArgs e)
        {
            //realiza a leitura do formulario
            bc = LeituraDeFormulario();
            // Valida o objeto BoardClass
            if (!this.ValidarBoard(this.bc))
            {
                return;
            }
            // Cria um novo Board com os dados lidos
            bc.CreateBoard();
            // Limpa os campos do formulário após a inclusão
            LimparFormulario();
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

        private void Btn_Limpar_Click(object sender, EventArgs e) => LimparFormulario();

        private void Btn_Retornar_Click(object sender, EventArgs e)
        {
            //Abre a aba BoardMain
            BoardMain boardMain = new BoardMain();
            this.Controls.Clear();
            this.Controls.Add((Control)boardMain);
            boardMain.BringToFront();
        }

        private void Btn_IncluirCapa_Click(object sender, EventArgs e)
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

        private void Btn_IncluirMapa_Click(object sender, EventArgs e)
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

        private void AtualizarTextoBotaoCapa(bool imagemSelecionada) => Btn_IncluirCapa.Text = imagemSelecionada ? "Alterar Capa" : "Adicionar Capa";

        private void AtualizarTextoBotaoMapa(bool imagemSelecionada) => Btn_IncluirMapa.Text = imagemSelecionada ? "Alterar Mapa" : "Adicionar Mapa";

    }
}
