using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Master_Shield_System.Formularios.City;
using Master_Shield_System.Formularios.Npc;
using MSSLibrary;
using MySql.Data.MySqlClient;

namespace Master_Shield_System.Formularios.Gerador
{
    public partial class GeradorNPC : Form
    {
        #region Arrays para criação randomica

        private readonly string[] nomesRandon = new string[69]
    {
      "Alana","Beatrix", "Camille", "Delilah", "Elara", "Freya", "Gwendolyn", "Hadley", "Isla", "Juniper", "Kieran","Lilian","Maeve","Naomi","Olivia","Penelope",
      "Quinn","Rowan","Seraphina","Tessa","Uma","Valerie","Willow","Xenia","Arya","Bryn","Calliope","Delaney","Elowen","Freya","Greer","Hadley","Imogen","Juniper",
      "Kieran","Lyla","Maeve","Nora","Olive","Priya","Quinn","Rowan","Seraphina","Tabitha","Uma","Vanessa","Willow","Xanthe","Yara","Zelda","Alex","Avery","Blair",
      "Cameron","Emery","Finley","Harper","Jamie","Jordan","Morgan","Parker","Quincy","Riley","Rowan","Skyler","Taylor","Tristan","Wren","Zephyr"
    };
        private readonly string[] sobrenomesRandon = new string[188]
        {
      "Adler", "Blackwood", "Crawford", "Davenport", "Elara", "Foster", "Grey", "Hawke", "Ironsmith", "Johnson", "Knight", "Lawson", "Moore", "Nolan", "Oliver",
      "Parker", "Quinn", "Reed", "Stone", "Thompson", "Vance", "Walker", "Anderson", "Bailey", "Carter", "Davis", "Edwards", "Fisher", "Garcia", "Harris", "Jackson", "Kelly",
      "Miller", "Parker","Perez", "Robinson", "Smith", "Taylor", "Williams", "Brown", "Campbell", "Evans", "Green", "Jones", "Lewis", "Martinez", "Scott", "Turner", "White",
      "Archer", "Bell", "Carter", "Davis", "Ellis", "Finch", "Grey", "Hunter", "Jackson", "Knight", "Lawson", "Miller", "Norris", "Olsen", "Parker", "Quinn",
      "Reed", "Stone", "Thompson", "Vance", "Walker", "Anderson", "Bailey", "Carter", "Davis", "Edwards", "Fisher", "Garcia", "Harris", "Jackson", "Kelly", "Miller",
      "Parker","Perez", "Robinson", "Smith", "Taylor", "Williams", "Brown", "Campbell", "Evans", "Green", "Jones","Lewis", "Martinez", "Scott", "Turner", "White",
      "Ashwood", "Blackwood","Emberwood","Evergreen","Frostwood","Glenwood","Hillwood","Hollowwood","Leafwood","Meadowood","Mosswood","Nightwood","Oakwood",
      "Pinewood","Ravenwood","Riverwood","Shadowwood","Skywood","Stonewood","Stormwood","Sunwood","Whisperwood", "Alana","Beatrix", "Camille", "Delilah", "Elara", "Freya", "Gwendolyn", "Hadley", "Isla", "Juniper", "Kieran","Lilian","Maeve","Naomi","Olivia","Penelope",
      "Quinn","Rowan","Seraphina","Tessa","Uma","Valerie","Willow","Xenia","Arya","Bryn","Calliope","Delaney","Elowen","Freya","Greer","Hadley","Imogen","Juniper",
      "Kieran","Lyla","Maeve","Nora","Olive","Priya","Quinn","Rowan","Seraphina","Tabitha","Uma","Vanessa","Willow","Xanthe","Yara","Zelda","Alex","Avery","Blair",
      "Cameron","Emery","Finley","Harper","Jamie","Jordan","Morgan","Parker","Quincy","Riley","Rowan","Skyler","Taylor","Tristan","Wren","Zephyr"
        };
        private readonly string[] raceRandon = new string[6]
        {
        "Humano","Elfo","Anão","Cambion","Gigante das Montanhas","Merenian"
        };
        private readonly string[] classesRandon = new string[10]
        {
      "Guerreiro","Bárbaro","Mago","Druida","Monge","Assassino","Ladino","Curandeiro","Arqueiro","Paladino"
        };
        private readonly string[] genderRandon = new string[3]
        {
      "Masculino","Feminino","Não definido"
        };
        private readonly string[] moralRandon = new string[9]
       {
      "Ordeiro e Bom","Ordeiro e Neutro","Ordeiro e Mau","Neutro e Bom","Neutro","Neutro e Mau","Caótico e Bom","Caótico e Neutro","Caótico e Mau"
       };
        private readonly string[] statusRandon = new string[2]
       {
           "Vivo", "Morto"
       };
        private readonly string[] profissoesRandon = new string[41]
       {
           "Sem Profissão", "Alquimista", "Apostador", "Artesão", "Botânico", "Camponês",
            "Carpinteiro", "Caçador", "Cavaleiro", "Ceramista", "Comerciante", "Contador",
            "Cozinheiro", "Diplomata", "Domador de Animais", "Escudeiro", "Espião", "Ferreiro",
            "Guarda", "Joalheiro", "Lenhador", "Líder Tribal", "Líder Religioso", "Médico",
            "Mendigo", "Mercenário", "Mestre de Armas", "Músico", "Navegador", "Nobre",
            "Padre", "Pecuarista", "Pescador", "Prefeito", "Sacerdote", "Soldado", "Tecelão",
            "Taverneiro", "Vendedor Ambulante", "Vidente", "Outro"
       };
        private readonly Random random = new Random();
        private readonly List<string> nomesSelecionados = new List<string>();
        private readonly List<string> sobrenomesSelecionados = new List<string>();
        private int _readBoardId;
        private int _readCityId;
        private NpcMain _npcMain;

        #endregion
        public GeradorNPC(NpcMain npcMain, int readBoardId, int readCityId)
        {
            InitializeComponent();
            _npcMain = npcMain;
            _readCityId = readCityId;
            _readBoardId = readBoardId;
        }

        private void GeradorNPC_Load(object sender, EventArgs e)
        {
            AdicionarCheckBoxes(raceRandon, pnl_racas, CheckBoxIndividualRacas_CheckedChanged);
            AdicionarCheckBoxes(moralRandon, pnl_alinhamento, CheckBoxIndividualAlinhamento_CheckedChanged);
            AdicionarCheckBoxes(classesRandon, pnl_classes, CheckBoxIndividualClasses_CheckedChanged);
            AdicionarCheckBoxes(genderRandon, pnl_genero, CheckBoxIndividualGenero_CheckedChanged);
            AdicionarCheckBoxes(statusRandon, pnl_status, CheckBoxIndividualStatus_CheckedChanged);
            AdicionarCheckBoxes(profissoesRandon, pnl_profissoes, CheckBoxIndividuaProfissoes_CheckedChanged);

            // Configura o checkbox "Marcar Todos"
            chb_Racas_MarcarTodos.CheckedChanged += chb_Racas_MarcarTodos_CheckedChanged;
            chb_Alinhamento_MarcarTodos.CheckedChanged += chb_Alinhamento_MarcarTodos_CheckedChanged;
            chb_classes_MarcarTodos.CheckedChanged += chb_classes_MarcarTodos_CheckedChanged;
            chb_genero_MarcarTodos.CheckedChanged += chb_genero_MarcarTodos_CheckedChanged;
            chb_status_MarcarTodos.CheckedChanged += chb_status_MarcarTodos_CheckedChanged;
            chb_Profissoes_MarcarTodos.CheckedChanged += chb_Profissoes_MarcarTodos_CheckedChanged;

            chb_Racas_MarcarTodos.Checked = true;
            chb_Alinhamento_MarcarTodos.Checked = true;
            chb_classes_MarcarTodos.Checked = true;
            chb_genero_MarcarTodos.Checked = true;
            chb_status_MarcarTodos.Checked = true;
            chb_Profissoes_MarcarTodos.Checked = true;

        }

        private void AdicionarCheckBoxes(string[] items, Panel targetPanel, EventHandler checkedChangedHandler)
        {
            for (int i = 0; i < items.Length; i++)
            {
                CheckBox checkBox = new CheckBox
                {
                    Text = items[i],
                    Location = new Point(10, i * 25),
                    AutoSize = true
                };
                if (checkedChangedHandler != null)
                    checkBox.CheckedChanged += checkedChangedHandler;

                targetPanel.Controls.Add(checkBox);
            }
        }

        private bool isUpdating = false; // Variável para controlar atualizações em andamento
        #region marcar todos racas

        private void chb_Racas_MarcarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdating) return; // Evita loops desnecessários

            isUpdating = true;

            bool marcarTodos = chb_Racas_MarcarTodos.Checked;

            // Atualiza todos os checkboxes individuais
            foreach (Control control in pnl_racas.Controls)
            {
                if (control is CheckBox checkBox && checkBox != chb_Racas_MarcarTodos)
                {
                    checkBox.Checked = marcarTodos;
                }
            }

            isUpdating = false;
        }

        private void CheckBoxIndividualRacas_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdating) return; // Evita loops desnecessários

            isUpdating = true;

            // Verifica se todos os checkboxes estão marcados
            bool todosMarcados = pnl_racas.Controls.OfType<CheckBox>()
                .Where(cb => cb != chb_Racas_MarcarTodos) // Ignora o "Marcar Todos"
                .All(cb => cb.Checked);

            // Atualiza o estado do "Marcar Todos"
            chb_Racas_MarcarTodos.Checked = todosMarcados;

            isUpdating = false;
        }

        #endregion

        #region marcar todos racas
        private void chb_Alinhamento_MarcarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdating) return; // Evita loops desnecessários

            isUpdating = true;

            bool marcarTodos = chb_Alinhamento_MarcarTodos.Checked;

            // Atualiza todos os checkboxes individuais
            foreach (Control control in pnl_alinhamento.Controls)
            {
                if (control is CheckBox checkBox && checkBox != chb_Alinhamento_MarcarTodos)
                {
                    checkBox.Checked = marcarTodos;
                }
            }

            isUpdating = false;
        }

        private void CheckBoxIndividualAlinhamento_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdating) return; // Evita loops desnecessários

            isUpdating = true;

            // Verifica se todos os checkboxes estão marcados
            bool todosMarcados = pnl_alinhamento.Controls.OfType<CheckBox>()
                .Where(cb => cb != chb_Alinhamento_MarcarTodos) // Ignora o "Marcar Todos"
                .All(cb => cb.Checked);

            // Atualiza o estado do "Marcar Todos"
            chb_Alinhamento_MarcarTodos.Checked = todosMarcados;

            isUpdating = false;
        }

        #endregion

        #region marcar todos classes

        private void chb_classes_MarcarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdating) return; // Evita loops desnecessários

            isUpdating = true;

            bool marcarTodos = chb_classes_MarcarTodos.Checked;

            // Atualiza todos os checkboxes individuais
            foreach (Control control in pnl_classes.Controls)
            {
                if (control is CheckBox checkBox && checkBox != chb_classes_MarcarTodos)
                {
                    checkBox.Checked = marcarTodos;
                }
            }

            isUpdating = false;
        }

        private void CheckBoxIndividualClasses_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdating) return; // Evita loops desnecessários

            isUpdating = true;

            // Verifica se todos os checkboxes estão marcados
            bool todosMarcados = pnl_classes.Controls.OfType<CheckBox>()
                .Where(cb => cb != chb_classes_MarcarTodos) // Ignora o "Marcar Todos"
                .All(cb => cb.Checked);

            // Atualiza o estado do "Marcar Todos"
            chb_classes_MarcarTodos.Checked = todosMarcados;

            isUpdating = false;
        }

        #endregion

        #region marcar todos genero

        private void chb_genero_MarcarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdating) return; // Evita loops desnecessários

            isUpdating = true;

            bool marcarTodos = chb_genero_MarcarTodos.Checked;

            // Atualiza todos os checkboxes individuais
            foreach (Control control in pnl_genero.Controls)
            {
                if (control is CheckBox checkBox && checkBox != chb_genero_MarcarTodos)
                {
                    checkBox.Checked = marcarTodos;
                }
            }

            isUpdating = false;
        }

        private void CheckBoxIndividualGenero_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdating) return; // Evita loops desnecessários

            isUpdating = true;

            // Verifica se todos os checkboxes estão marcados
            bool todosMarcados = pnl_genero.Controls.OfType<CheckBox>()
                .Where(cb => cb != chb_genero_MarcarTodos) // Ignora o "Marcar Todos"
                .All(cb => cb.Checked);

            // Atualiza o estado do "Marcar Todos"
            chb_genero_MarcarTodos.Checked = todosMarcados;

            isUpdating = false;
        }

        #endregion

        #region marcar todos profissoes

        private void chb_Profissoes_MarcarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdating) return; // Evita loops desnecessários

            isUpdating = true;

            bool marcarTodos = chb_Profissoes_MarcarTodos.Checked;

            // Atualiza todos os checkboxes individuais
            foreach (Control control in pnl_profissoes.Controls)
            {
                if (control is CheckBox checkBox && checkBox != chb_Profissoes_MarcarTodos)
                {
                    checkBox.Checked = marcarTodos;
                }
            }

            isUpdating = false;
        }

        private void CheckBoxIndividuaProfissoes_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdating) return; // Evita loops desnecessários

            isUpdating = true;

            // Verifica se todos os checkboxes estão marcados
            bool todosMarcados = pnl_profissoes.Controls.OfType<CheckBox>()
                .Where(cb => cb != chb_Profissoes_MarcarTodos) // Ignora o "Marcar Todos"
                .All(cb => cb.Checked);

            // Atualiza o estado do "Marcar Todos"
            chb_Profissoes_MarcarTodos.Checked = todosMarcados;

            isUpdating = false;
        }

        #endregion
        
        #region marcar todos Status

        private void chb_status_MarcarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdating) return; // Evita loops desnecessários

            isUpdating = true;

            bool marcarTodos = chb_status_MarcarTodos.Checked;

            // Atualiza todos os checkboxes individuais
            foreach (Control control in pnl_status.Controls)
            {
                if (control is CheckBox checkBox && checkBox != chb_status_MarcarTodos)
                {
                    checkBox.Checked = marcarTodos;
                }
            }

            isUpdating = false;
        }

        private void CheckBoxIndividualStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdating) return; // Evita loops desnecessários

            isUpdating = true;

            // Verifica se todos os checkboxes estão marcados
            bool todosMarcados = pnl_status.Controls.OfType<CheckBox>()
                .Where(cb => cb != chb_status_MarcarTodos) // Ignora o "Marcar Todos"
                .All(cb => cb.Checked);

            // Atualiza o estado do "Marcar Todos"
            chb_status_MarcarTodos.Checked = todosMarcados;

            isUpdating = false;
        }


        #endregion

        private void Btn_Cancelar_Click(object sender, EventArgs e) => this.Close();

        private void Btn_Gerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Tem certeza que deseja gerar NPC's aleatórios?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                // Valida a entrada numérica
                if (!int.TryParse(Txt_Numero.Text, out int numeroNpc) || numeroNpc <= 0)
                {
                    MessageBox.Show("Por favor, insira um número válido para gerar os NPC's.", "Erro de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (raceRandon == null || raceRandon.Length == 0)
                {
                    MessageBox.Show("A lista de raças está vazia ou não inicializada.", "Erro de Dados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (classesRandon == null || classesRandon.Length == 0)
                {
                    MessageBox.Show("A lista de classes está vazia ou não inicializada.", "Erro de Dados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (genderRandon == null || genderRandon.Length == 0)
                {
                    MessageBox.Show("A lista de gêneros está vazia ou não inicializada.", "Erro de Dados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (moralRandon == null || moralRandon.Length == 0)
                {
                    MessageBox.Show("A lista de alinhamentos está vazia ou não inicializada.", "Erro de Dados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (statusRandon == null || statusRandon.Length == 0)
                {
                    MessageBox.Show("A lista de status está vazia ou não inicializada.", "Erro de Dados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Random random = new Random();
                for (int index = 0; index < 10; ++index)
                {
                    string firstName = SelecionarNomesAleatorio();
                    string lastName = SelecionarSobrenomesAleatorio();
                    string npcClass = classesRandon[random.Next(classesRandon.Length)];
                    string npcRace = raceRandon[random.Next(raceRandon.Length)];
                    string npcGender = genderRandon[random.Next(genderRandon.Length)];
                    string npcMoralAlignment = moralRandon[random.Next(moralRandon.Length)];
                    string npcStatus = statusRandon[random.Next(statusRandon.Length)];
                    string npcProfession = profissoesRandon[random.Next(profissoesRandon.Length)];
                    int hp = random.Next((int)txt_hp_min.Value, (int)txt_hp_min.Value + 1);
                    int level = random.Next((int)txt_nivel_min.Value, (int)txt_nivel_min.Value + 1);
                    int energy = random.Next((int)txt_energia_min.Value, (int)txt_energia_min.Value + 1);
                    int strength = random.Next((int)txt_forca_min.Value, (int)txt_forca_min.Value + 1);
                    int speed = random.Next((int)txt_veloc_min.Value, (int)txt_veloc_min.Value + 1);
                    int intelligence = random.Next((int)txt_intel_min.Value, (int)txt_intel_min.Value + 1);
                    int charisma = random.Next((int)txt_carisma_min.Value, (int)txt_carisma_min.Value + 1);
                    int luck = random.Next((int)txt_sorte_min.Value, (int)txt_sorte_min.Value + 1);
                    int physical = random.Next((int)txt_fis_min.Value, (int)txt_fis_min.Value + 1);
                    int mental = random.Next((int)txt_mental_min.Value, (int)txt_mental_min.Value + 1);

                    using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                    {
                        connection.Open();
                        string query = @"
                    INSERT INTO sgrpg.tblnpc 
                    (BoardId, CityId, NpcFirstName, NpcLastName, NpcRace, NpcClass, NpcGender, NpcMoralAlignment, NpcHp, NpcLevel, NpcEnergy, NpcIsDead, NpcStrength, NpcSpeed, NpcIntelligence, NpcCharisma, NpcLuck, NpcProfession, NpcPhysicalResistance, NpcMentalResistance) 
                    VALUES 
                    (@BoardId, @CityId, @NpcFirstName, @NpcLastName, @NpcRace, @NpcClass, @NpcGender, @NpcMoralAlignment, @NpcHp, @NpcLevel, @NpcEnergy, @NpcIsDead, @NpcStrength, @NpcSpeed, @NpcIntelligence, @NpcCharisma, @NpcLuck, @NpcProfession, @NpcPhysicalResistance, @NpcMentalResistance)";

                        using (MySqlCommand mySqlCommand = new MySqlCommand(query, connection))
                        {
                            mySqlCommand.Parameters.AddWithValue("@BoardId", _readBoardId);
                            mySqlCommand.Parameters.AddWithValue("@CityId", _readCityId);
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
                            mySqlCommand.Parameters.AddWithValue("@NpcProfession", npcProfession);
                            mySqlCommand.Parameters.AddWithValue("@NpcPhysicalResistance", physical);
                            mySqlCommand.Parameters.AddWithValue("@NpcMentalResistance", mental);

                            mySqlCommand.ExecuteNonQuery();
                        }

                        connection.Close();
                    }
                }

                MessageBox.Show("Inclusão de NPC's realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();

                _npcMain.Inicializar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO ao inserir NPC's: " + ex.Message, "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

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
    }
}
