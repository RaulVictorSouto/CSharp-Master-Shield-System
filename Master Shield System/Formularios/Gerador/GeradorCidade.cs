using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using K4os.Compression.LZ4.Internal;
using Master_Shield_System.Formularios.City;
using MSSLibrary;
using MySql.Data.MySqlClient;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace Master_Shield_System.Formularios.Gerador
{
    public partial class GeradorCidade : Form
    {
        public string[] biomas = new string[]
        {
            "Campos", "Caverna", "Deserto", "Estepes", "Floresta", "Gélido", "Litoral", "Manguezal", "Marinha", "Montanha", "Planaltos", 
            "Planície", "Pântano", "Savana", "Selva", "Subterrâneo", "Taiga", "Tundra", "Tropical", "Vulcânico", "Outro"
        };

        public string[] reputacoes = new string[]
        {
            "Neutros", "Proibidos", "Odiados", "Indesejados", "Mal falados", "Irrelevantes", "Relevantes", "Bem falados", "Desejados", "Amados", "Heróis"
        };

        private string[] cidades = new string[41]
        {
            "Valeria", "Rivendell", "Neverwinter", "Stormwind", "Baldur's Gate", "Ankh-Morpork", "Winterfell", "Gotham", "Mordheim", "Midgar", 
            "Gondor", "Whiterun", "Novigrad", "Silent Hill", "Raccoon City", "Eldoria", "Ravenmoor", "Silvervale", "Frostholm", "Stormreach", 
            "Shadowfen", "Ironcrest", "Emberfall", "Sunhaven", "Mistwood", "Thunderbreak", "Arkania", "Mistyhollow", "Goldenhold", "Ironhold", 
            "Whogmar", "Wrierheith", "Schasmoe", "Vrapcuum", "Dukush", "Ventobravo", "Valdrakken", "Orgrimmar", "Luaprata", "Marea Azul", "Xique-Xique"
        };

        private Random random = new Random();
        private List<string> cidadesSelecionadas = new List<string>();
        private int _readBoardId;
        private CityMain _cityMain;


        public GeradorCidade(CityMain cityMain, int readBoardId)
        {
            InitializeComponent();
            _cityMain = cityMain;
            _readBoardId = readBoardId;
        }

        private void GeradorCidade_Load(object sender, EventArgs e)
        {
            // Adiciona checkboxes de biomas
            AdicionarCheckBoxes(biomas, pnl_biomas, CheckBoxIndividualBiomas_CheckedChanged);

            // Adiciona checkboxes de reputação
            AdicionarCheckBoxes(reputacoes, pnl_reputacao, CheckBoxIndividualReputacao_CheckedChanged);

            // Configura o checkbox "Marcar Todos"
            chb_Biomas_MarcarTodos.CheckedChanged += chb_Biomas_MarcarTodos_CheckedChanged;
            chb_Reputacao_MarcarTodos.CheckedChanged += chb_Reputacao_MarcarTodos_CheckedChanged;
            chb_Biomas_MarcarTodos.Checked = true;
            chb_Reputacao_MarcarTodos.Checked = true;
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

        #region Marcar Todos Biomas
        private void chb_Biomas_MarcarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdating) return; // Evita loops desnecessários

            isUpdating = true;

            bool marcarTodos = chb_Biomas_MarcarTodos.Checked;

            // Atualiza todos os checkboxes individuais
            foreach (Control control in pnl_biomas.Controls)
            {
                if (control is CheckBox checkBox && checkBox != chb_Biomas_MarcarTodos)
                {
                    checkBox.Checked = marcarTodos;
                }
            }

            isUpdating = false;
        }

        // Evento para os checkboxes individuais
        private void CheckBoxIndividualBiomas_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdating) return; // Evita loops desnecessários

            isUpdating = true;

            // Verifica se todos os checkboxes estão marcados
            bool todosMarcados = pnl_biomas.Controls.OfType<CheckBox>()
                .Where(cb => cb != chb_Biomas_MarcarTodos) // Ignora o "Marcar Todos"
                .All(cb => cb.Checked);

            // Atualiza o estado do "Marcar Todos"
            chb_Biomas_MarcarTodos.Checked = todosMarcados;

            isUpdating = false;
        }

        #endregion

        #region Marcar Todos Reputacao
        private void chb_Reputacao_MarcarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdating) return; // Evita loops desnecessários

            isUpdating = true;

            bool marcarTodos = chb_Reputacao_MarcarTodos.Checked;

            // Atualiza todos os checkboxes individuais
            foreach (Control control in pnl_reputacao.Controls)
            {
                if (control is CheckBox checkBox && checkBox != chb_Reputacao_MarcarTodos)
                {
                    checkBox.Checked = marcarTodos;
                }
            }

            isUpdating = false;
        }

        private void CheckBoxIndividualReputacao_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdating) return; // Evita loops desnecessários

            isUpdating = true;

            // Verifica se todos os checkboxes estão marcados
            bool todosMarcados = pnl_reputacao.Controls.OfType<CheckBox>()
                .Where(cb => cb != chb_Reputacao_MarcarTodos) // Ignora o "Marcar Todos"
                .All(cb => cb.Checked);

            // Atualiza o estado do "Marcar Todos"
            chb_Reputacao_MarcarTodos.Checked = todosMarcados;

            isUpdating = false;
        }
        #endregion

        private void Btn_Cancelar_Click(object sender, EventArgs e) => this.Close();

        private void Btn_Gerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Tem certeza que deseja gerar cidades aleatórias?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                // Valida a entrada numérica
                if (!int.TryParse(Txt_Numero.Text, out int numeroCidades) || numeroCidades <= 0)
                {
                    MessageBox.Show("Por favor, insira um número válido para gerar as cidades.", "Erro de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (biomas == null || biomas.Length == 0)
                {
                    MessageBox.Show("A lista de biomas está vazia ou não inicializada.", "Erro de Dados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (reputacoes == null || reputacoes.Length == 0)
                {
                    MessageBox.Show("A lista de reputações está vazia ou não inicializada.", "Erro de Dados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Random random = new Random();

                for (int index = 0; index < numeroCidades; ++index)
                {
                    string cidade = cidades[random.Next(cidades.Length)];
                    string bioma = biomas[random.Next(biomas.Length)];
                    string reputacao = reputacoes[random.Next(reputacoes.Length)];

                    using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                    {
                        connection.Open();
                        using (MySqlCommand mySqlCommand = new MySqlCommand(
                            "INSERT INTO sgrpg.tblcity (BoardId, CityName, CityBiome, CityReputation) VALUES (@BoardId, @CityName, @CityBiome, @CityReputation)", connection))
                        {
                            mySqlCommand.Parameters.AddWithValue("@BoardId", _readBoardId);
                            mySqlCommand.Parameters.AddWithValue("@CityName", cidade);
                            mySqlCommand.Parameters.AddWithValue("@CityBiome", bioma);
                            mySqlCommand.Parameters.AddWithValue("@CityReputation", reputacao);

                            // Executa o comando
                            mySqlCommand.ExecuteNonQuery();
                        }
                    }

                    // Adiciona à lista de cidades
                    if (cidadesSelecionadas != null)
                    {
                        cidadesSelecionadas.Add(cidade);
                    }
                }

                MessageBox.Show("Inclusão de Cidades realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

                _cityMain.Inicializar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO ao inserir cidade: " + ex.Message, "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Txt_Numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas números e a tecla Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela o evento para entradas inválidas
            }
        }
    }
}
