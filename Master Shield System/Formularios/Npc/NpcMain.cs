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

        public NpcMain()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            this.dt = NpcClass.GetNpc(true, this.readCityId);
            this.Dgv_Npc.DataSource = (object)this.dt;
            if (this.Dgv_Npc.Rows.Count <= 0)
                return;
            this.Dgv_Npc.Rows[0].Selected = true;
            if (this.Dgv_Npc.Columns.Contains("NpcId"))
            {
                object obj = this.Dgv_Npc.Rows[0].Cells["NpcId"].Value;
                int result;
                if (obj != null && int.TryParse(obj.ToString(), out result))
                {
                    this.readNpcId = result;
                    this.Dgv_Npc_CellClick((object)this.Dgv_Npc, new DataGridViewCellEventArgs(0, 0));
                }
                else
                {
                    int num = (int)MessageBox.Show("Erro ao converter o valor da célula 'NpcId' para inteiro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                int num1 = (int)MessageBox.Show("A coluna 'NpcId' não foi encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public void SetCityId(int ConfirmCityId,int ConfirmBoardId,string ConfirmCityName,string ConfirmCityBiome)
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
                       // this.EditarNpc(result);
                        break;
                    case "excluir":
                        //this.ExcluirNpc(result, e.RowIndex);
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
            if (e.RowIndex < 0)
                return;
            int int32 = Convert.ToInt32(this.Dgv_Npc.Rows[e.RowIndex].Cells["NpcId"].Value);
            this.CarregarDetalhesNpc(int32);
            this.readNpcId = int32;
        }

        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream memoryStream = new MemoryStream(byteArrayIn))
                return Image.FromStream((Stream)memoryStream);
        }

        private void CarregarDetalhesNpc(int npcId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                {
                    connection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("SELECT *, CONCAT(NpcFirstName, ' ', NpcLastName) AS NpcFullName FROM sgrpg.tblnpc WHERE NpcId = @NpcId", connection);
                    mySqlCommand.Parameters.AddWithValue("@NpcId", (object)npcId);
                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        if (mySqlDataReader.Read())
                        {
                            this.Txt_Descricao.Text = mySqlDataReader["NpcDescription"].ToString();
                            if (this.Txt_Descricao.Text == "")
                                this.Txt_Descricao.Text = "Sem Descrição";
                            this.Lbl_Nome.Text = mySqlDataReader["NpcFullName"].ToString();
                            this.Lbl_Raca.Text = mySqlDataReader["NpcRace"].ToString();
                            this.Lbl_Classe.Text = mySqlDataReader["NpcClass"].ToString();
                            bool result;
                            if (bool.TryParse(mySqlDataReader["NpcIsDead"].ToString(), out result))
                                this.Lbl_Status.Text = result ? "Morto" : "Vivo";
                            else
                                this.Lbl_Status.Text = "Desconhecido";
                            this.Lbl_Genero.Text = mySqlDataReader["NpcGender"].ToString();
                            this.Lbl_Alinhamento.Text = mySqlDataReader["NpcMoralAlignment"].ToString();
                            this.Lbl_Nivel.Text = mySqlDataReader["NpcLevel"].ToString();
                            this.Lbl_Hp.Text = mySqlDataReader["NpcHp"].ToString();
                            this.Lbl_Energia.Text = mySqlDataReader["NpcEnergy"].ToString();
                            this.Lbl_Forca.Text = mySqlDataReader["NpcStrength"].ToString();
                            this.Lbl_Velocidade.Text = mySqlDataReader["NpcSpeed"].ToString();
                            this.Lbl_Inteligencia.Text = mySqlDataReader["NpcIntelligence"].ToString();
                            this.Lbl_Carisma.Text = mySqlDataReader["NpcCharisma"].ToString();
                            this.Lbl_Sorte.Text = mySqlDataReader["NpcLuck"].ToString();
                            this.Pcb_Imagem.Image = mySqlDataReader.IsDBNull(mySqlDataReader.GetOrdinal("NpcImage")) ? (Image)null : this.ByteArrayToImage((byte[])mySqlDataReader["NpcImage"]);
                        }
                        else
                        {
                            this.Txt_Descricao.Text = "";
                            this.Lbl_Nome.Text = "";
                            this.Lbl_Raca.Text = "";
                            this.Lbl_Classe.Text = "";
                            this.Lbl_Status.Text = "";
                            this.Lbl_Genero.Text = "";
                            this.Lbl_Alinhamento.Text = "";
                            this.Lbl_Nivel.Text = "";
                            this.Lbl_Hp.Text = "";
                            this.Lbl_Energia.Text = "";
                            this.Lbl_Forca.Text = "";
                            this.Lbl_Velocidade.Text = "";
                            this.Lbl_Inteligencia.Text = "";
                            this.Lbl_Carisma.Text = "";
                            this.Lbl_Sorte.Text = "";
                            this.Pcb_Imagem.Image = (Image)null;
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("ERRO: " + ex.Message, "Ocorreu um erro ao carregar os detalhes do NPC: SQL", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

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


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.G | Keys.Control:
                    this.CriarNPCRandon();
                    return true;
                case Keys.T | Keys.Control:
                    //this.GerarTextoAutomaticamente(this.readNpcId);
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }


    }
}
