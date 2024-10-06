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

namespace Master_Shield_System.Formularios.Npc
{
    public partial class NpcDataInsert : UserControl
    {
        public NpcClass nc = new NpcClass();
        public NpcMain nm = new NpcMain();
        public int ConfirmBoardId;
        public int ConfirmCityId;
        private string caminhoArquivoImagem = "";
        public string ConfirmCityName;
        public string ConfirmCityBiome;
        public NpcDataInsert()
        {
            InitializeComponent();
            this.Cbb_Race.SelectedItem = (object)"Humano";
            this.Cbb_Class.SelectedItem = (object)"Guerreiro";
            this.Cbb_Gender.SelectedItem = (object)"Masculino";
            this.Cbb_Status.SelectedItem = (object)"Vivo";
            this.Cbb_Moral.SelectedItem = (object)"Ordeiro e Bom";
        }

        public void SetDados(int boardId, int cityId, string cityName, string cityBiome)
        {
            this.ConfirmBoardId = boardId;
            this.ConfirmCityId = cityId;
            this.ConfirmCityName = cityName;
            this.ConfirmCityBiome = cityBiome;
        }

        private NpcClass LeituraDeFormulario()
        {
            this.nc.NpcFirstName = this.Txt_Nome.Text;
            this.nc.NpcLastName = this.Txt_Sobrenome.Text;
            this.nc.NpcRace = this.Cbb_Race.Text;
            this.nc.NpcCls = this.Cbb_Class.Text;
            this.nc.NpcMoral = this.Cbb_Moral.Text;
            this.nc.NpcGender = this.Cbb_Gender.Text;
            this.nc.NpcLevel = this.ParseToInt(this.Txt_Nivel.Text);
            this.nc.NpcHp = this.ParseToInt(this.Txt_Hp.Text);
            this.nc.NpcEnergy = this.ParseToInt(this.Txt_Energia.Text);
            this.nc.NpcStrength = this.ParseToInt(this.Txt_Forca.Text);
            this.nc.NpcSpeed = this.ParseToInt(this.Txt_Velocidade.Text);
            this.nc.NpcCharisma = this.ParseToInt(this.Txt_Carisma.Text);
            this.nc.NpcLuck = this.ParseToInt(this.Txt_Sorte.Text);
            this.nc.NpcIntelligence = this.ParseToInt(this.Txt_Inteligencia.Text);
            this.nc.NpcDescription = this.Txt_Descricao.Text;
            this.nc.NpcIsDead = !(this.Cbb_Status.Text == "Vivo");
            byte[] numArray = (byte[])null;
            if (!string.IsNullOrEmpty(this.caminhoArquivoImagem))
                numArray = File.ReadAllBytes(this.caminhoArquivoImagem);
            this.nc.NpcImage = numArray;
            this.ValidarNpc((object)this.nc);
            return this.nc;
        }

        private int ParseToInt(string text)
        {
            int result;
            if (int.TryParse(text, out result))
                return result;
            throw new InvalidOperationException("Invalid integer value: " + text);
        }

        private bool ValidarNpc(object obj)
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

        private void Btn_IncluirImagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.bmp|Todos os Arquivos|*.*";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                this.caminhoArquivoImagem = openFileDialog.FileName;
                this.Pcb_Image.Image = Image.FromFile(this.caminhoArquivoImagem);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("Erro ao carregar a imagem: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void LimparDados()
        {
            this.Txt_Nome.Text = "";
            this.Txt_Sobrenome.Text = "";
            this.Cbb_Race.SelectedItem = (object)"Humano";
            this.Cbb_Class.SelectedItem = (object)"Guerreiro";
            this.Cbb_Gender.SelectedItem = (object)"Masculino";
            this.Cbb_Status.SelectedItem = (object)"Vivo";
            this.Cbb_Moral.SelectedItem = (object)"Ordeiro e Bom";
            this.Txt_Nivel.Text = "0";
            this.Txt_Hp.Text = "0";
            this.Txt_Energia.Text = "0";
            this.Txt_Forca.Text = "0";
            this.Txt_Velocidade.Text = "0";
            this.Txt_Carisma.Text = "0";
            this.Txt_Sorte.Text = "0";
            this.Txt_Inteligencia.Text = "0";
            this.Txt_Descricao.Text = "";
            this.Pcb_Image.Image = (Image)null;
            this.caminhoArquivoImagem = (string)null;
            this.nc.NpcImage = (byte[])null;
        }


        #region Permite que apenas numeros seja adicionar ao campos numericos

        public static void IntNumber(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '-')
                return;
            e.Handled = true;
        }

        private void Txt_Nivel_KeyPress(object sender, KeyPressEventArgs e)
        {
            NpcDataInsert.IntNumber(e);
            if (e.KeyChar != '-' || this.Txt_Nivel.Text.IndexOf('-') <= -1 && this.Txt_Nivel.SelectionStart == 0)
                return;
            e.Handled = true;
        }

        private void Txt_Hp_KeyPress(object sender, KeyPressEventArgs e)
        {
            NpcDataInsert.IntNumber(e);
            if (e.KeyChar != '-' || this.Txt_Hp.Text.IndexOf('-') <= -1 && this.Txt_Hp.SelectionStart == 0)
                return;
            e.Handled = true;
        }

        private void Txt_Energia_KeyPress(object sender, KeyPressEventArgs e)
        {
            NpcDataInsert.IntNumber(e);
            if (e.KeyChar != '-' || this.Txt_Energia.Text.IndexOf('-') <= -1 && this.Txt_Energia.SelectionStart == 0)
                return;
            e.Handled = true;
        }

        private void Txt_Forca_KeyPress(object sender, KeyPressEventArgs e)
        {
            NpcDataInsert.IntNumber(e);
            if (e.KeyChar != '-' || this.Txt_Forca.Text.IndexOf('-') <= -1 && this.Txt_Forca.SelectionStart == 0)
                return;
            e.Handled = true;
        }

        private void Txt_Velocidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            NpcDataInsert.IntNumber(e);
            if (e.KeyChar != '-' || this.Txt_Velocidade.Text.IndexOf('-') <= -1 && this.Txt_Velocidade.SelectionStart == 0)
                return;
            e.Handled = true;
        }

        private void Txt_Inteligencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            NpcDataInsert.IntNumber(e);
            if (e.KeyChar != '-' || this.Txt_Inteligencia.Text.IndexOf('-') <= -1 && this.Txt_Inteligencia.SelectionStart == 0)
                return;
            e.Handled = true;
        }

        private void Txt_Carisma_KeyPress(object sender, KeyPressEventArgs e)
        {
            NpcDataInsert.IntNumber(e);
            if (e.KeyChar != '-' || this.Txt_Carisma.Text.IndexOf('-') <= -1 && this.Txt_Carisma.SelectionStart == 0)
                return;
            e.Handled = true;
        }

        private void Txt_Sorte_KeyPress(object sender, KeyPressEventArgs e)
        {
            NpcDataInsert.IntNumber(e);
            if (e.KeyChar != '-' || this.Txt_Sorte.Text.IndexOf('-') <= -1 && this.Txt_Sorte.SelectionStart == 0)
                return;
            e.Handled = true;
        }

        #endregion

        private void Btn_Limpar_Click(object sender, EventArgs e) => LimparDados();

        private void Btn_Retornar_Click(object sender, EventArgs e)
        {
            NpcMain npcMain = new NpcMain();
            npcMain.SetCityId(this.ConfirmCityId, this.ConfirmBoardId, this.ConfirmCityName, this.ConfirmCityBiome);
            this.Controls.Clear();
            this.Controls.Add((Control)npcMain);
            npcMain.BringToFront();
        }

        private void Btn_ApagarImagem_Click(object sender, EventArgs e)
        {
            this.Pcb_Image.Image = (Image)null;
            this.caminhoArquivoImagem = (string)null;
            this.nc.NpcImage = (byte[])null;
        }

        private async void Btn_GerarDescricao_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Tem certeza que quer incluir uma descrição para o NPC {Txt_Nome.Text} {Txt_Sobrenome.Text}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Função para mapear o valor do atributo para a string adequada
                string MapearAtributo(string atributo)
                {
                    if (int.TryParse(atributo, out int valor))
                    {
                        if (valor == 0) return "regular";
                        if (valor >= 1 && valor <= 3) return "alto";
                        if (valor > 3) return "muito alto";
                        if (valor >= -3 && valor <= -1) return "baixo";
                        if (valor < -3) return "muito baixo";
                    }
                    return "desconhecido"; // Valor padrão se houver algum erro
                }

                string forca = MapearAtributo(this.Txt_Forca.Text);
                string velocidade = MapearAtributo(this.Txt_Velocidade.Text);
                string carisma = MapearAtributo(this.Txt_Carisma.Text);
                string sorte = MapearAtributo(this.Txt_Sorte.Text);
                string inteligencia = MapearAtributo(this.Txt_Inteligencia.Text);

                // Exibir os valores convertidos em um MessageBox
                MessageBox.Show($"Força: {forca}\nVelocidade: {velocidade}\nCarisma: {carisma}\nSorte: {sorte}\nInteligência: {inteligencia}",
                                "Atributos Enviados",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                ApiClass.LoadApiKey();
                await ApiClass.GerarTextoNpc(ApiClass.GeminiKey,
                                             this.Txt_Nome.Text,
                                             this.Txt_Sobrenome.Text,
                                             nm.readCityName,
                                             nm.readCityBiome,
                                             this.Cbb_Race.Text,
                                             this.Cbb_Class.Text,
                                             this.Cbb_Gender.Text,
                                             this.Cbb_Moral.Text,
                                             forca,
                                             velocidade,
                                             carisma,
                                             sorte,
                                             inteligencia);
                this.Txt_Descricao.Text = ApiClass.TextoGerado;
            }
        }

        private void Btn_IncluirImagem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos os Arquivos|*.*";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                this.caminhoArquivoImagem = openFileDialog.FileName;
                this.Pcb_Image.Image = Image.FromFile(this.caminhoArquivoImagem);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("Erro ao carregar a imagem: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void Btn_Incluir_Click(object sender, EventArgs e)
        {
            this.nc = this.LeituraDeFormulario();
            if (!this.ValidarNpc((object)this.nc))
                return;
            this.nc.CreateNpc(this.ConfirmBoardId, this.ConfirmCityId);
            LimparDados();
        }

        
    }
}
