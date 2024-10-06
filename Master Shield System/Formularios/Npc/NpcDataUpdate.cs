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

namespace Master_Shield_System.Formularios.Npc
{
    public partial class NpcDataUpdate : UserControl
    {
        public NpcClass nc = new NpcClass();
        public NpcMain nm = new NpcMain();
        private string caminhoArquivoImagem = "";
        public int ConfirmBoardId;
        public int ConfirmCityId;
        public string ConfirmCityName;
        public string ConfirmCityBiome;
        public byte[] ReadNpcImage;
        public int ReadNpcId;
        public NpcDataUpdate()
        {
            InitializeComponent();
        }

        public void SetDados(int NpcId, string CityName, string CityBiome)
        {
            try
            {
                ConfirmCityName = CityName;
                ConfirmCityBiome = CityBiome;
                using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                {
                    connection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM sgrpg.tblnpc WHERE NpcId = @NpcId", connection);
                    mySqlCommand.Parameters.AddWithValue("@NpcId", (object)NpcId);
                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        if (mySqlDataReader.Read())
                        {
                            this.ReadNpcId = Convert.ToInt32(mySqlDataReader[nameof(NpcId)]);
                            this.ConfirmBoardId = Convert.ToInt32(mySqlDataReader["BoardId"]);
                            this.ConfirmCityId = Convert.ToInt32(mySqlDataReader["CityId"]);
                            this.Txt_Nome.Text = mySqlDataReader["NpcFirstName"].ToString();
                            this.Txt_Sobrenome.Text = mySqlDataReader["NpcLastName"].ToString();
                            this.Txt_Nivel.Text = mySqlDataReader["NpcLevel"].ToString();
                            this.Txt_Hp.Text = mySqlDataReader["NpcHp"].ToString();
                            this.Txt_Energia.Text = mySqlDataReader["NpcEnergy"].ToString();
                            this.Txt_Forca.Text = mySqlDataReader["NpcStrength"].ToString();
                            this.Txt_Velocidade.Text = mySqlDataReader["NpcSpeed"].ToString();
                            this.Txt_Inteligencia.Text = mySqlDataReader["NpcIntelligence"].ToString();
                            this.Txt_Carisma.Text = mySqlDataReader["NpcCharisma"].ToString();
                            this.Txt_Sorte.Text = mySqlDataReader["NpcLuck"].ToString();
                            this.Txt_Descricao.Text = mySqlDataReader["NpcDescription"].ToString();
                            string str1 = mySqlDataReader["NpcRace"].ToString();
                            if (this.Cbb_Race.Items.Contains((object)str1))
                                this.Cbb_Race.SelectedItem = (object)str1;
                            string str2 = mySqlDataReader["NpcClass"].ToString();
                            if (this.Cbb_Class.Items.Contains((object)str2))
                                this.Cbb_Class.SelectedItem = (object)str2;
                            string str3 = mySqlDataReader["NpcMoralAlignment"].ToString();
                            if (this.Cbb_Moral.Items.Contains((object)str3))
                                this.Cbb_Moral.SelectedItem = (object)str3;
                            string str4 = mySqlDataReader["NpcGender"].ToString();
                            if (this.Cbb_Genero.Items.Contains((object)str4))
                                this.Cbb_Genero.SelectedItem = (object)str4;
                            this.Cbb_Status.SelectedItem = !Convert.ToBoolean(mySqlDataReader["NpcIsDead"]) ? (object)"Vivo" : (object)"Morto";
                            if (!mySqlDataReader.IsDBNull(mySqlDataReader.GetOrdinal("NpcImage")))
                            {
                                byte[] byteArrayIn = (byte[])mySqlDataReader["NpcImage"];
                                this.Pcb_Image.Image = this.ByteArrayToImage(byteArrayIn);
                                this.ReadNpcImage = byteArrayIn;
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

                ApiClass.LoadApiKey();
                await ApiClass.GerarTextoNpc(ApiClass.GeminiKey,
                                             this.Txt_Nome.Text,
                                             this.Txt_Sobrenome.Text,
                                             nm.readCityName,
                                             nm.readCityBiome,
                                             this.Cbb_Race.Text,
                                             this.Cbb_Class.Text,
                                             this.Cbb_Genero.Text,
                                             this.Cbb_Moral.Text,
                                             forca,
                                             velocidade,
                                             carisma,
                                             sorte,
                                             inteligencia);
                this.Txt_Descricao.Text = ApiClass.TextoGerado;
            }
        }


        private void Btn_Retornar_Click(object sender, EventArgs e)
        {
            NpcMain npcMain = new NpcMain();
            npcMain.SetCityId(this.ConfirmCityId, this.ConfirmBoardId, this.ConfirmCityName, this.ConfirmCityBiome);
            this.Controls.Clear();
            this.Controls.Add((Control)npcMain);
            npcMain.BringToFront();
        }

        private void Btn_Limpar_Click(object sender, EventArgs e) => LimparDados();

        private void LimparDados()
        {
            this.Txt_Nome.Text = "";
            this.Txt_Sobrenome.Text = "";
            this.Cbb_Race.SelectedItem = (object)"Humano";
            this.Cbb_Class.SelectedItem = (object)"Guerreiro";
            this.Cbb_Genero.SelectedItem = (object)"Masculino";
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

        private NpcClass LeituraDeFormulario(int npcId)
        {
            try
            {
                int result1;
                int result2;
                int result3;
                int result4;
                int result5;
                int result6;
                int result7;
                int result8;

                // Criação da instância de NpcClass e preenchimento dos campos
                NpcClass npcClass = new NpcClass()
                {
                    NpcId = npcId,
                    NpcFirstName = this.Txt_Nome.Text.Trim(),
                    NpcLastName = this.Txt_Sobrenome.Text.Trim(),
                    NpcRace = this.Cbb_Race.SelectedItem?.ToString(),
                    NpcCls = this.Cbb_Class.SelectedItem?.ToString(),
                    NpcGender = this.Cbb_Genero.SelectedItem?.ToString(),
                    NpcMoral = this.Cbb_Moral.SelectedItem?.ToString(),
                    NpcHp = int.TryParse(this.Txt_Hp.Text.Trim(), out result1) ? result1 : 0,
                    NpcLevel = int.TryParse(this.Txt_Nivel.Text.Trim(), out result2) ? result2 : 0,
                    NpcEnergy = int.TryParse(this.Txt_Energia.Text.Trim(), out result3) ? result3 : 0,
                    NpcIsDead = this.Cbb_Status.SelectedItem?.ToString() == "Morto",
                    NpcStrength = int.TryParse(this.Txt_Forca.Text.Trim(), out result4) ? result4 : 0,
                    NpcSpeed = int.TryParse(this.Txt_Velocidade.Text.Trim(), out result5) ? result5 : 0,
                    NpcIntelligence = int.TryParse(this.Txt_Inteligencia.Text.Trim(), out result6) ? result6 : 0,
                    NpcCharisma = int.TryParse(this.Txt_Carisma.Text.Trim(), out result7) ? result7 : 0,
                    NpcLuck = int.TryParse(this.Txt_Sorte.Text.Trim(), out result8) ? result8 : 0,
                    NpcDescription = this.Txt_Descricao.Text.Trim()
                };

                // Verifica se o caminho da imagem não está vazio e se o arquivo existe
                if (!string.IsNullOrEmpty(this.caminhoArquivoImagem) && File.Exists(this.caminhoArquivoImagem))
                {
                    byte[] byteArrayIn = File.ReadAllBytes(this.caminhoArquivoImagem);
                    this.Pcb_Image.Image = this.ByteArrayToImage(byteArrayIn);
                    npcClass.NpcImage = byteArrayIn;
                }
                else if (npcClass.NpcImage == null)
                {
                    npcClass.NpcImage = this.ReadNpcImage;
                }

                // Validação do NPC
                this.ValidarNpc((object)npcClass);

                return npcClass;
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro e retorna null
                MessageBox.Show("ERRO na leitura do formulário: " + ex.Message, "Ocorreu um erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
        }

        private void Btn_Alterar_Click(object sender, EventArgs e)
        {
            try
            {
                int readNpcId = this.ReadNpcId; // Lê o ID do NPC

                // Lê os dados do formulário e cria uma instância de NpcClass
                NpcClass npcClass = this.LeituraDeFormulario(readNpcId);

                // Valida os dados do NPC
                if (!this.ValidarNpc(npcClass))
                    return;

                // Atualiza o NPC
                npcClass.UpdateNpc();

                // Cria uma nova instância de NpcMain
                NpcMain npcMain = new NpcMain();

                // Configura os detalhes da cidade no NpcMain
                npcMain.SetCityId(this.ConfirmCityId, this.ConfirmBoardId, this.ConfirmCityName, this.ConfirmCityBiome);

                // Limpa os controles existentes e adiciona o NpcMain
                this.Controls.Clear();
                this.Controls.Add((Control)npcMain);
                npcMain.BringToFront();
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro se ocorrer uma exceção
                MessageBox.Show("Erro ao atualizar a cidade: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

    
    }
}
