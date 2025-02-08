using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Master_Shield_System.Formularios.City;
using Master_Shield_System.Formularios.Npc;
using MSSLibrary;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crmf;

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
        private List<string> raceSelect = new List<string>();
        private List<string> classesSelect = new List<string>();
        private List<string> genderSelect = new List<string>();
        private List<string> moralSelect = new List<string>();
        private List<string> statusSelect = new List<string>();
        private List<string> profissoesSelect = new List<string>();

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

            // Se estiver marcando todos, preenche a lista
            if (marcarTodos)
            {
                raceSelect = pnl_racas.Controls
                    .OfType<CheckBox>()
                    .Where(cb => cb != chb_Racas_MarcarTodos) // Ignora o "Marcar Todos"
                    .Select(cb => cb.Text) // Pega os textos dos checkboxes
                    .ToList();
            }
            else
            {
                // Se estiver desmarcando todos, esvazia a lista
                raceSelect.Clear();
            }

            isUpdating = false;
        }

        private void CheckBoxIndividualRacas_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdating) return; // Evita loops desnecessários

            isUpdating = true;

            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                if (checkBox.Checked)
                {
                    // Adiciona o valor se não estiver na lista
                    if (!raceSelect.Contains(checkBox.Text))
                        raceSelect.Add(checkBox.Text);
                }
                else
                {
                    // Remove o valor da lista se o checkbox for desmarcado
                    raceSelect.Remove(checkBox.Text);
                }
            }

            // Verifica se todos os checkboxes estão marcados
            bool todosMarcados = pnl_racas.Controls.OfType<CheckBox>()
                .Where(cb => cb != chb_Racas_MarcarTodos) // Ignora o "Marcar Todos"
                .All(cb => cb.Checked);

            // Atualiza o estado do "Marcar Todos"
            chb_Racas_MarcarTodos.Checked = todosMarcados;

            isUpdating = false;
        }

        #endregion

        #region marcar todos alinhamento
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

            // Se estiver marcando todos, preenche a lista
            if (marcarTodos)
            {
                moralSelect = pnl_alinhamento.Controls
                    .OfType<CheckBox>()
                    .Where(cb => cb != chb_Alinhamento_MarcarTodos) // Ignora o "Marcar Todos"
                    .Select(cb => cb.Text) // Pega os textos dos checkboxes
                    .ToList();
            }
            else
            {
                // Se estiver desmarcando todos, esvazia a lista
                moralSelect.Clear();
            }

            isUpdating = false;
        }

        private void CheckBoxIndividualAlinhamento_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdating) return; // Evita loops desnecessários

            isUpdating = true;

            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                if (checkBox.Checked)
                {
                    // Adiciona o valor se não estiver na lista
                    if (!moralSelect.Contains(checkBox.Text))
                        moralSelect.Add(checkBox.Text);
                }
                else
                {
                    // Remove o valor da lista se o checkbox for desmarcado
                    moralSelect.Remove(checkBox.Text);
                }
            }

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

            // Se estiver marcando todos, preenche a lista
            if (marcarTodos)
            {
                classesSelect = pnl_classes.Controls
                    .OfType<CheckBox>()
                    .Where(cb => cb != chb_classes_MarcarTodos) // Ignora o "Marcar Todos"
                    .Select(cb => cb.Text) // Pega os textos dos checkboxes
                    .ToList();
            }
            else
            {
                // Se estiver desmarcando todos, esvazia a lista
                classesSelect.Clear();
            }

            isUpdating = false;
        }

        private void CheckBoxIndividualClasses_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdating) return; // Evita loops desnecessários

            isUpdating = true;

            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                if (checkBox.Checked)
                {
                    // Adiciona o valor se não estiver na lista
                    if (!classesSelect.Contains(checkBox.Text))
                        classesSelect.Add(checkBox.Text);
                }
                else
                {
                    // Remove o valor da lista se o checkbox for desmarcado
                    classesSelect.Remove(checkBox.Text);
                }
            }

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

            // Se estiver marcando todos, preenche a lista
            if (marcarTodos)
            {
                genderSelect = pnl_genero.Controls
                    .OfType<CheckBox>()
                    .Where(cb => cb != chb_genero_MarcarTodos) // Ignora o "Marcar Todos"
                    .Select(cb => cb.Text) // Pega os textos dos checkboxes
                    .ToList();
            }
            else
            {
                // Se estiver desmarcando todos, esvazia a lista
                genderSelect.Clear();
            }

            isUpdating = false;
        }

        private void CheckBoxIndividualGenero_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdating) return; // Evita loops desnecessários

            isUpdating = true;

            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                if (checkBox.Checked)
                {
                    // Adiciona o valor se não estiver na lista
                    if (!genderSelect.Contains(checkBox.Text))
                        genderSelect.Add(checkBox.Text);
                }
                else
                {
                    // Remove o valor da lista se o checkbox for desmarcado
                    genderSelect.Remove(checkBox.Text);
                }
            }

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

            // Se estiver marcando todos, preenche a lista
            if (marcarTodos)
            {
                profissoesSelect = pnl_profissoes.Controls
                    .OfType<CheckBox>()
                    .Where(cb => cb != chb_Profissoes_MarcarTodos) // Ignora o "Marcar Todos"
                    .Select(cb => cb.Text) // Pega os textos dos checkboxes
                    .ToList();
            }
            else
            {
                // Se estiver desmarcando todos, esvazia a lista
                profissoesSelect.Clear();
            }

            isUpdating = false;
        }

        private void CheckBoxIndividuaProfissoes_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdating) return; // Evita loops desnecessários

            isUpdating = true;

            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                if (checkBox.Checked)
                {
                    // Adiciona o valor se não estiver na lista
                    if (!profissoesSelect.Contains(checkBox.Text))
                        profissoesSelect.Add(checkBox.Text);
                }
                else
                {
                    // Remove o valor da lista se o checkbox for desmarcado
                    profissoesSelect.Remove(checkBox.Text);
                }
            }

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

            // Se estiver marcando todos, preenche a lista
            if (marcarTodos)
            {
                statusSelect = pnl_status.Controls
                    .OfType<CheckBox>()
                    .Where(cb => cb != chb_status_MarcarTodos) // Ignora o "Marcar Todos"
                    .Select(cb => cb.Text) // Pega os textos dos checkboxes
                    .ToList();
            }
            else
            {
                // Se estiver desmarcando todos, esvazia a lista
                statusSelect.Clear();
            }

            isUpdating = false;
        }

        private void CheckBoxIndividualStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdating) return; // Evita loops desnecessários

            isUpdating = true;

            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                if (checkBox.Checked)
                {
                    // Adiciona o valor se não estiver na lista
                    if (!statusSelect.Contains(checkBox.Text))
                        statusSelect.Add(checkBox.Text);
                }
                else
                {
                    // Remove o valor da lista se o checkbox for desmarcado
                    statusSelect.Remove(checkBox.Text);
                }
            }

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

                if (!int.TryParse(Txt_Numero.Text, out int numeroNpc) || numeroNpc <= 0)
                {
                    MessageBox.Show("Por favor, insira um número válido para gerar os NPC's.", "Erro de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (raceRandon == null || raceRandon.Length == 0 ||
                    classesRandon == null || classesRandon.Length == 0 ||
                    genderRandon == null || genderRandon.Length == 0 ||
                    moralRandon == null || moralRandon.Length == 0 ||
                    statusRandon == null || statusRandon.Length == 0)
                {
                    MessageBox.Show("Uma ou mais listas obrigatórias estão vazias ou não inicializadas.", "Erro de Dados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                for (int index = 0; index < (int)Txt_Numero.Value; ++index)
                {
                    string firstName = SelecionarNomesAleatorio();
                    string lastName = SelecionarSobrenomesAleatorio();
                    string npcClass = classesSelect[random.Next(classesSelect.Count)];
                    string npcRace = raceSelect[random.Next(raceSelect.Count)];
                    string npcGender = genderSelect[random.Next(genderSelect.Count)];
                    string npcMoralAlignment = moralSelect[random.Next(moralSelect.Count)];
                    string npcStatus = statusSelect[random.Next(statusSelect.Count)];
                    bool npcIsDead = npcStatus.Equals("Morto", StringComparison.OrdinalIgnoreCase);
                    string npcProfession = profissoesSelect[random.Next(profissoesSelect.Count)];

                    int hp = AjustarIntervalo(txt_hp_min, txt_hp_max);
                    int level = AjustarIntervalo(txt_nivel_min, txt_nivel_max);
                    int energy = AjustarIntervalo(txt_energia_min, txt_energia_max);
                    int strength = AjustarIntervalo(txt_forca_min, txt_forca_max);
                    int speed = AjustarIntervalo(txt_veloc_min, txt_veloc_max);
                    int intelligence = AjustarIntervalo(txt_intel_min, txt_intel_max);
                    int charisma = AjustarIntervalo(txt_carisma_min, txt_carisma_max);
                    int luck = AjustarIntervalo(txt_sorte_min, txt_sorte_max);
                    int physical = AjustarIntervalo(txt_fis_min, txt_fis_max);
                    int mental = AjustarIntervalo(txt_mental_min, txt_mental_max);

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
                            mySqlCommand.Parameters.AddWithValue("@NpcIsDead", npcIsDead);
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

        // Retorna um número aleatório entre um mínimo e um máximo, garantindo que min ≤ max.
        int AjustarIntervalo(NumericUpDown minControl, NumericUpDown maxControl)
        {
            int min = (int)minControl.Value;
            int max = (int)maxControl.Value;
            if (min > max)
            {
                int temp = min;
                min = max;
                max = temp;
            }
            return random.Next(min, max + 1);
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
