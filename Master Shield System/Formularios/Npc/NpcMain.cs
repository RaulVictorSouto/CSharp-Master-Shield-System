using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Master_Shield_System.Formularios.City;
using Master_Shield_System.Properties;
using MSSLibrary;
using MySql.Data.MySqlClient;

namespace Master_Shield_System.Formularios.Npc
{
    public partial class NpcMain : UserControl
    {
        private NpcClass nc = new NpcClass();
        private DataTable dt = new DataTable();
        private int readCityId;
        private int readNpcId;
        public string readCityName;
        public string readCityBiome;
        private int readBoardId;
        private Random random = new Random();
        private List<string> nomesSelecionados = new List<string>();
        private List<string> sobrenomesSelecionados = new List<string>();

        #region Arrays para criação randomica

        private string[] nomesRandon = new string[69]
    {
      "Alana",
      "Beatrix",
      "Camille",
      "Delilah",
      "Elara",
      "Freya",
      "Gwendolyn",
      "Hadley",
      "Isla",
      "Juniper",
      "Kieran",
      "Lilian",
      "Maeve",
      "Naomi",
      "Olivia",
      "Penelope",
      "Quinn",
      "Rowan",
      "Seraphina",
      "Tessa",
      "Uma",
      "Valerie",
      "Willow",
      "Xenia",
      "Arya",
      "Bryn",
      "Calliope",
      "Delaney",
      "Elowen",
      "Freya",
      "Greer",
      "Hadley",
      "Imogen",
      "Juniper",
      "Kieran",
      "Lyla",
      "Maeve",
      "Nora",
      "Olive",
      "Priya",
      "Quinn",
      "Rowan",
      "Seraphina",
      "Tabitha",
      "Uma",
      "Vanessa",
      "Willow",
      "Xanthe",
      "Yara",
      "Zelda",
      "Alex",
      "Avery",
      "Blair",
      "Cameron",
      "Emery",
      "Finley",
      "Harper",
      "Jamie",
      "Jordan",
      "Morgan",
      "Parker",
      "Quincy",
      "Riley",
      "Rowan",
      "Skyler",
      "Taylor",
      "Tristan",
      "Wren",
      "Zephyr"
    };
        private string[] sobrenomesRandon = new string[119]
        {
      "Adler",
      "Blackwood",
      "Crawford",
      "Davenport",
      "Elara",
      "Foster",
      "Grey",
      "Hawke",
      "Ironsmith",
      "Johnson",
      "Knight",
      "Lawson",
      "Moore",
      "Nolan",
      "Oliver",
      "Parker",
      "Quinn",
      "Reed",
      "Stone",
      "Thompson",
      "Vance",
      "Walker",
      "Anderson",
      "Bailey",
      "Carter",
      "Davis",
      "Edwards",
      "Fisher",
      "Garcia",
      "Harris",
      "Jackson",
      "Kelly",
      "Miller",
      "Parker",
      "Perez",
      "Robinson",
      "Smith",
      "Taylor",
      "Williams",
      "Brown",
      "Campbell",
      "Evans",
      "Green",
      "Jones",
      "Lewis",
      "Martinez",
      "Scott",
      "Turner",
      "White",
      "Archer",
      "Bell",
      "Carter",
      "Davis",
      "Ellis",
      "Finch",
      "Grey",
      "Hunter",
      "Jackson",
      "Knight",
      "Lawson",
      "Miller",
      "Norris",
      "Olsen",
      "Parker",
      "Quinn",
      "Reed",
      "Stone",
      "Thompson",
      "Vance",
      "Walker",
      "Anderson",
      "Bailey",
      "Carter",
      "Davis",
      "Edwards",
      "Fisher",
      "Garcia",
      "Harris",
      "Jackson",
      "Kelly",
      "Miller",
      "Parker",
      "Perez",
      "Robinson",
      "Smith",
      "Taylor",
      "Williams",
      "Brown",
      "Campbell",
      "Evans",
      "Green",
      "Jones",
      "Lewis",
      "Martinez",
      "Scott",
      "Turner",
      "White",
      "Ashwood",
      "Blackwood",
      "Emberwood",
      "Evergreen",
      "Frostwood",
      "Glenwood",
      "Hillwood",
      "Hollowwood",
      "Leafwood",
      "Meadowood",
      "Mosswood",
      "Nightwood",
      "Oakwood",
      "Pinewood",
      "Ravenwood",
      "Riverwood",
      "Shadowwood",
      "Skywood",
      "Stonewood",
      "Stormwood",
      "Sunwood",
      "Whisperwood"
        };
        private string[] raceRandon = new string[36]
        {
      "Humano",
      "Elfo",
      "Anão",
      "Aarakocra",
      "Aasimar",
      "Cambion",
      "Centauro",
      "Draenei",
      "Draconato",
      "Dragonborn",
      "Elfo Sombrio",
      "Firbolg",
      "Gnomo",
      "Goblin",
      "Githzerai",
      "Gigante das Montanhas",
      "Golem",
      "Halfling",
      "Kenku",
      "Lizardfolk",
      "Meio-Anão",
      "Meio-Elfo",
      "Merfolk",
      "Merenian",
      "Minotauro",
      "Morto-Vivo",
      "Naga",
      "Orc",
      "Sátiro",
      "Tabaxi",
      "Tauren",
      "Tiefling",
      "Tritão",
      "Troll",
      "Warforged",
      "Worgen"
        };
        private string[] classesRandon = new string[26]
        {
      "Guerreiro",
      "Bárbaro",
      "Mago",
      "Druida",
      "Monge",
      "Assassino",
      "Ladino",
      "Curandeiro",
      "Arqueiro",
      "Paladino",
      "Alquimista",
      "Arcanista",
      "Bardo",
      "Bruxo",
      "Caçador de Demônios",
      "Camponês",
      "Cavaleiro",
      "Clérigo",
      "Comerciante",
      "Feiticeiro",
      "Ferreiro",
      "Necromante",
      "Patrulheiro",
      "Pistoleiro",
      "Samurai",
      "Xamã"
        };
        private string[] genderRandon = new string[3]
        {
      "Masculino",
      "Feminino",
      "Não definido"
        };

        private string[] moralRandon = new string[9]
       {
      "Ordeiro e Bom",
      "Ordeiro e Neutro",
      "Ordeiro e Mau",
      "Neutro e Bom",
      "Neutro",
      "Neutro e Mau",
      "Caótico e Bom",
      "Caótico e Neutro",
      "Caótico e Mau"
       };

        #endregion

        public NpcMain()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            this.dt = NpcClass.GetNpc(true, this.readCityId);
            this.Dgv_Npc.DataSource = this.dt;

            if (this.Dgv_Npc.Rows.Count <= 0)
                return;

            this.Dgv_Npc.Rows[0].Selected = true;

            if (this.Dgv_Npc.Columns.Contains("NpcId"))
            {
                object obj = this.Dgv_Npc.Rows[0].Cells["NpcId"].Value;
                if (obj != null && int.TryParse(obj.ToString(), out int result))
                {
                    this.readNpcId = result;
                    this.Dgv_Npc_CellClick(this.Dgv_Npc, new DataGridViewCellEventArgs(0, 0));
                }
                else
                {
                    MessageBox.Show("Erro ao converter o valor da célula 'NpcId' para inteiro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("A coluna 'NpcId' não foi encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }


            if (Cbb_Filter.Items.Count > 0)
            {
                Cbb_Filter.SelectedIndex = 0; // Seleciona o primeiro item
            }

            if (Cbb_Operadores.Items.Count > 0)
            {
                Cbb_Operadores.SelectedIndex = 0; // Seleciona o primeiro item
            }
        }


        public void SetCityId(int ConfirmCityId, int ConfirmBoardId, string ConfirmCityName, string ConfirmCityBiome)
        {
            this.readCityId = ConfirmCityId;
            this.readBoardId = ConfirmBoardId;
            this.readCityName = ConfirmCityName;
            this.readCityBiome = ConfirmCityBiome;
            this.Inicializar();
            this.ConfigurarGradeNpc();
        }

        private void ConfigurarGradeNpc()
        {
            // Definindo estilo das fontes
            Dgv_Npc.ColumnHeadersDefaultCellStyle.Font = new Font("Noto Sans", 9f, FontStyle.Bold);
            Dgv_Npc.DefaultCellStyle.Font = new Font("Noto Sans", 9f);
            // Configuração da cor do texto
            Dgv_Npc.DefaultCellStyle.ForeColor = Color.Black; // Cor do texto das células
            Dgv_Npc.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Cor do texto dos cabeçalhos
            Dgv_Npc.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray; // Cor de fundo dos cabeçalhos
            Dgv_Npc.RowsDefaultCellStyle.ForeColor = Color.Black; // Cor do texto das linhas
            Dgv_Npc.ReadOnly = true;
            Dgv_Npc.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dgv_Npc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Configurações de visibilidade e cabeçalho das colunas
            Dgv_Npc.Columns["NpcId"].HeaderText = "ID NPC";
            Dgv_Npc.Columns["NpcId"].Visible = false;

            Dgv_Npc.Columns["CityId"].HeaderText = "ID Cidade";
            Dgv_Npc.Columns["CityId"].Visible = false;

            Dgv_Npc.Columns["BoardId"].HeaderText = "ID Campanha";
            Dgv_Npc.Columns["BoardId"].Visible = false;

            // Configurações da coluna "Nome"
            Dgv_Npc.Columns["NpcFullName"].HeaderText = "Nome";
            Dgv_Npc.Columns["NpcFullName"].Width = 210;

            // Configurações da coluna "Raça"
            Dgv_Npc.Columns["NpcRace"].HeaderText = "Raça";
            Dgv_Npc.Columns["NpcRace"].Width = 160;

            // Configurações da coluna "Classe"
            Dgv_Npc.Columns["NpcClass"].HeaderText = "Classe";
            Dgv_Npc.Columns["NpcClass"].Width = 160;

            // Configurações da coluna "Gênero"
            Dgv_Npc.Columns["NpcGender"].HeaderText = "Gênero";
            Dgv_Npc.Columns["NpcGender"].Width = 180;

            // Configurações da coluna "Alinhamento"
            Dgv_Npc.Columns["NpcMoralAlignment"].HeaderText = "Alinhamento";
            Dgv_Npc.Columns["NpcMoralAlignment"].Width = 120;

            // Configurações da coluna "Status"
            Dgv_Npc.Columns["NpcIsDead"].HeaderText = "Status";
            Dgv_Npc.Columns["NpcIsDead"].Width = 60;
            Dgv_Npc.Columns["NpcIsDead"].CellTemplate = new DataGridViewCheckBoxCell();

            // Configurações de visibilidade das colunas adicionais
            Dgv_Npc.Columns["NpcEnergy"].Visible = false;
            Dgv_Npc.Columns["NpcLevel"].Visible = false;
            Dgv_Npc.Columns["NpcHp"].Visible = false;
            Dgv_Npc.Columns["NpcStrength"].Visible = false;
            Dgv_Npc.Columns["NpcSpeed"].Visible = false;
            Dgv_Npc.Columns["NpcCharisma"].Visible = false;
            Dgv_Npc.Columns["NpcLuck"].Visible = false;
            Dgv_Npc.Columns["NpcIntelligence"].Visible = false;
            Dgv_Npc.Columns["NpcImage"].Visible = false;
            Dgv_Npc.Columns["NpcDescription"].Visible = false;

            int contarColunas = Dgv_Npc.Columns.Count;

            Dgv_Npc.Columns["Editar"].DisplayIndex = contarColunas - 2;
            Dgv_Npc.Columns["Excluir"].DisplayIndex = contarColunas - 1;

            // Evento de pintura de células
            Dgv_Npc.CellPainting += new DataGridViewCellPaintingEventHandler(Dgv_Npc_CellPainting);
        }

        private void Dgv_Npc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            string name = this.Dgv_Npc.Columns[e.ColumnIndex].Name;
            int result;
            if (int.TryParse(this.Dgv_Npc.Rows[e.RowIndex].Cells["NpcId"].Value?.ToString(), out result))
            {
                switch (name)
                {
                    case "editar":
                        this.EditarNpc(result);
                        break;
                    case "excluir":
                        this.ExcluirNpc(result, e.RowIndex);
                        break;
                    case "NpcIsDead":
                        this.AlterarStatus(result, e.RowIndex);
                        break;
                }
            }
            else
            {
                int num = (int)MessageBox.Show("O ID do NPC não é válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void Dgv_Npc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (this.Dgv_Npc.Columns.Contains("NpcId"))
            {
                if (int.TryParse(this.Dgv_Npc.Rows[e.RowIndex].Cells["NpcId"].Value?.ToString(), out int result))
                {
                    readNpcId = result;
                    this.CarregarDetalhesNpc(result);
                }
                else
                {
                    MessageBox.Show("O ID do NPC não é válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void CarregarDetalhesNpc(int npcId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                {
                    connection.Open();
                    string query = "SELECT *, CONCAT(NpcFirstName, ' ', NpcLastName) AS NpcFullName FROM sgrpg.tblnpc WHERE NpcId = @NpcId";
                    MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
                    mySqlCommand.Parameters.AddWithValue("@NpcId", npcId);

                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        if (mySqlDataReader.Read())
                        {
                            Txt_Descricao.Text = mySqlDataReader["NpcDescription"]?.ToString() ?? "Sem Descrição";
                            Lbl_Nome.Text = mySqlDataReader["NpcFullName"]?.ToString() ?? "";
                            Lbl_Raca.Text = mySqlDataReader["NpcRace"]?.ToString() ?? "";
                            Lbl_Classe.Text = mySqlDataReader["NpcClass"]?.ToString() ?? "";

                            bool isDead;
                            if (bool.TryParse(mySqlDataReader["NpcIsDead"]?.ToString(), out isDead))
                            {
                                Lbl_Status.Text = isDead ? "Morto" : "Vivo";
                            }
                            else
                            {
                                Lbl_Status.Text = "Desconhecido";
                            }

                            Lbl_Genero.Text = mySqlDataReader["NpcGender"]?.ToString() ?? "";
                            Lbl_Alinhamento.Text = mySqlDataReader["NpcMoralAlignment"]?.ToString() ?? "";
                            Lbl_Nivel.Text = mySqlDataReader["NpcLevel"]?.ToString() ?? "";
                            Lbl_Hp.Text = mySqlDataReader["NpcHp"]?.ToString() ?? "";
                            Lbl_Energia.Text = mySqlDataReader["NpcEnergy"]?.ToString() ?? "";
                            Lbl_Forca.Text = mySqlDataReader["NpcStrength"]?.ToString() ?? "";
                            Lbl_Velocidade.Text = mySqlDataReader["NpcSpeed"]?.ToString() ?? "";
                            Lbl_Inteligencia.Text = mySqlDataReader["NpcIntelligence"]?.ToString() ?? "";
                            Lbl_Carisma.Text = mySqlDataReader["NpcCharisma"]?.ToString() ?? "";
                            Lbl_Sorte.Text = mySqlDataReader["NpcLuck"]?.ToString() ?? "";

                            if (!mySqlDataReader.IsDBNull(mySqlDataReader.GetOrdinal("NpcImage")))
                            {
                                byte[] imgData = (byte[])mySqlDataReader["NpcImage"];
                                Pcb_Imagem.Image = ByteArrayToImage(imgData);
                            }
                            else
                            {
                                Pcb_Imagem.Image = null;
                            }
                        }
                        else
                        {
                            LimparDetalhesNpc();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message, "Ocorreu um erro ao carregar os detalhes do NPC: SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Método auxiliar para limpar os detalhes do NPC
        private void LimparDetalhesNpc()
        {
            Txt_Descricao.Text = "";
            Lbl_Nome.Text = "";
            Lbl_Raca.Text = "";
            Lbl_Classe.Text = "";
            Lbl_Status.Text = "";
            Lbl_Genero.Text = "";
            Lbl_Alinhamento.Text = "";
            Lbl_Nivel.Text = "";
            Lbl_Hp.Text = "";
            Lbl_Energia.Text = "";
            Lbl_Forca.Text = "";
            Lbl_Velocidade.Text = "";
            Lbl_Inteligencia.Text = "";
            Lbl_Carisma.Text = "";
            Lbl_Sorte.Text = "";
            Pcb_Imagem.Image = null;
        }



        #region alterar status

        public async void AlterarStatus(int npcId, int rowIndex)
        {
            int columnIndex = this.Dgv_Npc.Columns["NpcIsDead"].Index;
            DataGridViewCell cell;
            if (columnIndex == -1)
            {
                cell = (DataGridViewCell)null;
            }
            else
            {
                cell = this.Dgv_Npc.Rows[rowIndex].Cells[columnIndex];
                bool currentValue = (bool)cell.Value;
                bool newValue = !currentValue;
                cell.Value = (object)newValue;
                await this.nc.MatarRessucitarNPC(npcId, newValue);
                this.CarregarDetalhesNpc(npcId);
                cell = (DataGridViewCell)null;
            }
        }

        private Image IconToImage(Icon icon)
        {
            using (Bitmap bitmap = icon.ToBitmap())
                return (Image)new Bitmap((Image)bitmap);
        }

        private Image ResizeImage(Image img, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage((Image)bitmap))
                graphics.DrawImage(img, 0, 0, width, height);
            return (Image)bitmap;
        }

        private void Dgv_Npc_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex != this.Dgv_Npc.Columns["NpcIsDead"].Index || e.RowIndex < 0)
                return;
            e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentBackground | DataGridViewPaintParts.ErrorIcon | DataGridViewPaintParts.Focus | DataGridViewPaintParts.SelectionBackground);
            Image image1 = this.IconToImage((bool)e.Value ? Resources.morte : Resources.vida);
            int width = 16;
            int height = 16;
            Image image2 = this.ResizeImage(image1, width, height);
            Rectangle cellBounds = e.CellBounds;
            int left = cellBounds.Left;
            cellBounds = e.CellBounds;
            int num1 = (cellBounds.Width - width) / 2;
            int x = left + num1;
            cellBounds = e.CellBounds;
            int top = cellBounds.Top;
            cellBounds = e.CellBounds;
            int num2 = (cellBounds.Height - height) / 2;
            int y = top + num2;
            e.Graphics.DrawImage(image2, new Rectangle(x, y, width, height));
            e.Handled = true;
        }

        #endregion

        #region Criar NPC Aleatóriamente
        //Adicionar NPC randomicamente

        //Estas funções não permitem que um mesmo nome/sobrenome seja selecionado duas vezes
        private string SelecionarNomesAleatorio()
        {
            string str;
            do
            {
                str = this.nomesRandon[this.random.Next(this.nomesRandon.Length)];
            }
            while (this.nomesSelecionados.Contains(str));
            this.nomesSelecionados.Add(str);
            return str;
        }

        private string SelecionarSobrenomesAleatorio()
        {
            string str;
            do
            {
                str = this.sobrenomesRandon[this.random.Next(this.sobrenomesRandon.Length)];
            }
            while (this.sobrenomesSelecionados.Contains(str));
            this.sobrenomesSelecionados.Add(str);
            return str;
        }

        public void CriarNPCRandon()
        {
            try
            {
                if (MessageBox.Show("Tem certeza que deseja gerar NPC's aleatórios?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                Random random = new Random();
                for (int index = 0; index < 10; ++index)
                {
                    string firstName = SelecionarNomesAleatorio();
                    string lastName = SelecionarSobrenomesAleatorio();
                    string npcClass = classesRandon.Length != 0 ? classesRandon[random.Next(classesRandon.Length)] : "";
                    string npcRace = raceRandon.Length != 0 ? raceRandon[random.Next(raceRandon.Length)] : "";
                    string npcGender = genderRandon.Length != 0 ? genderRandon[random.Next(genderRandon.Length)] : "";
                    string npcMoralAlignment = moralRandon.Length != 0 ? moralRandon[random.Next(moralRandon.Length)] : "";
                    int hp = random.Next(1, 11);
                    int level = random.Next(1, 11);
                    int energy = random.Next(1, 11);
                    int strength = random.Next(-6, 7);
                    int speed = random.Next(-6, 7);
                    int intelligence = random.Next(-6, 7);
                    int charisma = random.Next(-6, 7);
                    int luck = random.Next(-6, 7);

                    using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                    {
                        connection.Open();
                        string query = @"
                    INSERT INTO sgrpg.tblnpc 
                    (BoardId, CityId, NpcFirstName, NpcLastName, NpcRace, NpcClass, NpcGender, NpcMoralAlignment, NpcHp, NpcLevel, NpcEnergy, NpcIsDead, NpcStrength, NpcSpeed, NpcIntelligence, NpcCharisma, NpcLuck) 
                    VALUES 
                    (@BoardId, @CityId, @NpcFirstName, @NpcLastName, @NpcRace, @NpcClass, @NpcGender, @NpcMoralAlignment, @NpcHp, @NpcLevel, @NpcEnergy, @NpcIsDead, @NpcStrength, @NpcSpeed, @NpcIntelligence, @NpcCharisma, @NpcLuck)";

                        using (MySqlCommand mySqlCommand = new MySqlCommand(query, connection))
                        {
                            mySqlCommand.Parameters.AddWithValue("@BoardId", readBoardId);
                            mySqlCommand.Parameters.AddWithValue("@CityId", readCityId);
                            mySqlCommand.Parameters.AddWithValue("@NpcFirstName", firstName);
                            mySqlCommand.Parameters.AddWithValue("@NpcLastName", lastName);
                            mySqlCommand.Parameters.AddWithValue("@NpcRace", npcRace);
                            mySqlCommand.Parameters.AddWithValue("@NpcClass", npcClass);
                            mySqlCommand.Parameters.AddWithValue("@NpcGender", npcGender);
                            mySqlCommand.Parameters.AddWithValue("@NpcMoralAlignment", npcMoralAlignment);
                            mySqlCommand.Parameters.AddWithValue("@NpcHp", hp);
                            mySqlCommand.Parameters.AddWithValue("@NpcLevel", level);
                            mySqlCommand.Parameters.AddWithValue("@NpcEnergy", energy);
                            mySqlCommand.Parameters.AddWithValue("@NpcIsDead", 0);
                            mySqlCommand.Parameters.AddWithValue("@NpcStrength", strength);
                            mySqlCommand.Parameters.AddWithValue("@NpcSpeed", speed);
                            mySqlCommand.Parameters.AddWithValue("@NpcIntelligence", intelligence);
                            mySqlCommand.Parameters.AddWithValue("@NpcCharisma", charisma);
                            mySqlCommand.Parameters.AddWithValue("@NpcLuck", luck);

                            mySqlCommand.ExecuteNonQuery();
                        }

                        connection.Close();
                    }
                }

                MessageBox.Show("Inclusão de NPC's realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Inicializar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO ao inserir NPC's: " + ex.Message, "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        #endregion

        //Atalhos especificos do tela de NPC
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.G | Keys.Control:
                    this.CriarNPCRandon();
                    return true;
                case Keys.T | Keys.Control:
                    this.GerarTextoAutomaticamente(this.readNpcId);
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream memoryStream = new MemoryStream(byteArrayIn))
                return Image.FromStream((Stream)memoryStream);
        }

        private void Btn_Retornar_Click(object sender, EventArgs e)
        {
            CityMain cityMain = new CityMain();
            this.Controls.Clear();
            cityMain.SetBoardId(this.readBoardId);
            this.Controls.Add((Control)cityMain);
            cityMain.BringToFront();
        }

        private void Btn_Incluir_Click(object sender, EventArgs e)
        {
            NpcDataInsert npcDataInsert = new NpcDataInsert();
            this.Controls.Clear();
            npcDataInsert.SetDados(this.readBoardId, this.readCityId);
            this.Controls.Add((Control)npcDataInsert);
            npcDataInsert.BringToFront();
        }

        private void EditarNpc(int npcId)
        {
            try
            {
                NpcDataUpdate npcDataUpdate = new NpcDataUpdate();
                this.Controls.Clear();
                npcDataUpdate.SetDados(npcId);
                this.Controls.Add((Control)npcDataUpdate);
                npcDataUpdate.BringToFront();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("Erro ao carregar o NPC para edição: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void ExcluirNpc(int npcId, int rowIndex)
        {
            // Confirmação antes da exclusão
            if (MessageBox.Show("Deseja excluir este NPC?", "Exclusão de NPC", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                // Excluir o NPC do banco de dados
                new NpcClass().DeleteNpc(npcId);

                // Remover a linha da DataGridView
                if (rowIndex >= 0 && rowIndex < this.Dgv_Npc.Rows.Count)
                {
                    this.Dgv_Npc.Rows.RemoveAt(rowIndex);

                    // Atualizar a seleção
                    if (this.Dgv_Npc.Rows.Count > 0)
                    {
                        int newRowIndex = rowIndex > 0 ? rowIndex - 1 : 0;
                        this.Dgv_Npc.ClearSelection();
                        this.Dgv_Npc.Rows[newRowIndex].Selected = true;

                        // Carregar detalhes do NPC selecionado
                        int newNpcId = Convert.ToInt32(this.Dgv_Npc.Rows[newRowIndex].Cells["NpcId"].Value);
                        this.CarregarDetalhesNpc(newNpcId);
                    }
                    else
                    {
                        // Limpar detalhes se não houver linhas na DataGridView
                        LimparDetalhesNpc();
                    }
                }
                else
                {
                    // Se o índice da linha for inválido
                    LimparDetalhesNpc();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir o NPC: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        #region Gerar Descrição NPC

        public async void GerarTextoAutomaticamente(int npcId)
        {
            DialogResult result = MessageBox.Show("Tem certeza que quer incluir uma descrição para o NPC selecionado?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            try
            {
                using (MySqlConnection cn = new MySqlConnection(ConexaoSQLClass.ConnString))
                {
                    await cn.OpenAsync();
                    string sql = "SELECT * FROM sgrpg.tblnpc WHERE NpcId = @NpcId";
                    MySqlCommand command = new MySqlCommand(sql, cn);
                    command.Parameters.AddWithValue("@NpcId", npcId);
                    ApiClass.LoadApiKey();

                    using (MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            await ApiClass.GerarTextoNpc(ApiClass.GeminiKey,
                                                         reader["NpcFirstName"].ToString(),
                                                         reader["NpcLastName"].ToString(),
                                                         this.readCityName,
                                                         this.readCityBiome,
                                                         reader["NpcRace"].ToString(),
                                                         reader["NpcClass"].ToString(),
                                                         reader["NpcGender"].ToString(),
                                                         reader["NpcMoralAlignment"].ToString(),
                                                         reader["NpcLevel"].ToString(),
                                                         reader["NpcHp"].ToString(),
                                                         reader["NpcEnergy"].ToString(),
                                                         reader["NpcStrength"].ToString(),
                                                         reader["NpcSpeed"].ToString(),
                                                         reader["NpcCharisma"].ToString(),
                                                         reader["NpcLuck"].ToString(),
                                                         reader["NpcIntelligence"].ToString());
                        }
                        else
                        {
                            MessageBox.Show("ERRO ao ler os dados do NPC.", "Ocorreu um erro ao gerar a descrição do NPC", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                    }

                    string insertSql = "UPDATE sgrpg.tblnpc SET NpcDescription = @NpcDescription WHERE NpcId = @NpcId";
                    MySqlCommand insertCommand = new MySqlCommand(insertSql, cn);
                    insertCommand.Parameters.AddWithValue("@NpcDescription", ApiClass.TextoGerado);
                    insertCommand.Parameters.AddWithValue("@NpcId", npcId);
                    await insertCommand.ExecuteNonQueryAsync();

                    this.CarregarDetalhesNpc(npcId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message, "Ocorreu um erro ao gerar a descrição do NPC", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }


        #endregion

        #region Pesquisa

        private void Btn_Pesquisar_Click(object sender, EventArgs e) => FiltrarGrade();

        public void FiltrarGrade()
        {
            bool flag1 = false;
            string name;
            switch (this.Cbb_Filter.Text.Trim())
            {
                case "Carisma":
                    name = "NpcCharisma";
                    break;
                case "Classe":
                    name = "NpcClass";
                    break;
                case "Energia":
                    name = "NpcEnergy";
                    break;
                case "Força":
                    name = "NpcStrength";
                    break;
                case "Gênero":
                    name = "NpcGender";
                    break;
                case "HP":
                    name = "NpcHp";
                    break;
                case "Inteligência":
                    name = "NpcIntelligence";
                    break;
                case "Morto":
                    name = "NpcIsDead";
                    flag1 = true;
                    break;
                case "Nome":
                    name = "NpcFullName";
                    break;
                case "Nível":
                    name = "NpcLevel";
                    break;
                case "Raça":
                    name = "NpcRace";
                    break;
                case "Sorte":
                    name = "NpcLuck";
                    break;
                case "Velocidade":
                    name = "NpcSpeed";
                    break;
                case "Vivo":
                    name = "NpcIsDead";
                    flag1 = true;
                    break;
                default:
                    int num1 = (int)MessageBox.Show("Selecione uma coluna válida para filtrar.", "Coluna Inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
            }
            bool flag2 = false;
            if (this.dt.Columns.Contains(name))
            {
                Type dataType = this.dt.Columns[name].DataType;
                flag2 = dataType == typeof(int) || dataType == typeof(Decimal) || dataType == typeof(double);
            }
            string str1 = "";
            if (flag1)
            {
                if (this.Cbb_Filter.Text.Trim() == "Morto")
                    str1 = name + " = true";
                else if (this.Cbb_Filter.Text.Trim() == "Vivo")
                    str1 = name + " = false";
            }
            else if (!string.IsNullOrWhiteSpace(this.Txt_pesquisa.Text))
            {
                if (flag2)
                {
                    string str2;
                    switch (this.Cbb_Operadores.Text.Trim())
                    {
                        case "Igual a":
                            str2 = "=";
                            break;
                        case "Maior do que":
                            str2 = ">";
                            break;
                        case "Menor do que":
                            str2 = "<";
                            break;
                        case "Maior ou igual a":
                            str2 = ">=";
                            break;
                        case "Menor ou igual a":
                            str2 = "<=";
                            break;
                        case "Diferente de":
                            str2 = "<>";
                            break;
                        default:
                            int num2 = (int)MessageBox.Show("Selecione um operador válido para valores numéricos.", "Operador Inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                    }
                    str1 = name + " " + str2 + " " + this.Txt_pesquisa.Text;
                }
                else
                {
                    switch (this.Cbb_Operadores.Text.Trim())
                    {
                        case "Igual a":
                            str1 = name + " LIKE '%" + this.Txt_pesquisa.Text + "%'";
                            break;
                        case "Diferente de":
                            str1 = name + " NOT LIKE '%" + this.Txt_pesquisa.Text + "%'";
                            break;
                        default:
                            str1 = name + " LIKE '%" + this.Txt_pesquisa.Text + "%'";
                            break;
                    }
                }
            }
            try
            {
                this.dt.DefaultView.RowFilter = !string.IsNullOrWhiteSpace(this.Txt_pesquisa.Text) || flag1 ? str1 : "";
                this.Dgv_Npc.DataSource = (object)this.dt;
            }
            catch (Exception ex)
            {
                int num3 = (int)MessageBox.Show("Erro ao aplicar filtro: " + ex.Message, "Erro de Filtro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        #endregion


    }
}
