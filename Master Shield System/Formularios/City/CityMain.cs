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
using MySql.Data.MySqlClient;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace Master_Shield_System.Formularios.City
{
    public partial class CityMain : UserControl
    {
        private DataTable dt = new DataTable();
        private int readBoardId;
        public int ConfirmCityId;
        public string ConfirmCityName;
        public string ConfirmCityBiome;
        private Random random = new Random();
        private List<string> cidadesSelecionadas = new List<string>();

        public CityMain()
        {
            InitializeComponent();
        }

        public void SetBoardId(int ConfirmBoardId)
        {
            this.readBoardId = ConfirmBoardId;
            this.Inicializar();
        }

        private void Inicializar()
        {
            this.dt = CityClass.GetCity(true, this.readBoardId);
            this.Dgv_City.DataSource = (object)this.dt;
            this.ConfigurarGradeCity();
            if (this.Dgv_City.Rows.Count <= 0)
                return;
            this.Dgv_City.Rows[0].Selected = true;
            this.Dgv_City_CellClick((object)this.Dgv_City, new DataGridViewCellEventArgs(0, 0));

            if (Cbb_CityFilter.Items.Count > 0)
            {
                Cbb_CityFilter.SelectedIndex = 0; // Seleciona o primeiro item
            }

            if (Cbb_Operadores.Items.Count > 0)
            {
                Cbb_Operadores.SelectedIndex = 0; // Seleciona o primeiro item
            }
        }

        private void ConfigurarGradeCity()
        {
            this.Dgv_City.ColumnHeadersDefaultCellStyle.Font = new Font("Noto Sans", 9f, FontStyle.Bold);
            this.Dgv_City.DefaultCellStyle.Font = new Font("Noto Sans", 9f);

            // Configuração da cor do texto
            Dgv_City.DefaultCellStyle.ForeColor = Color.Black; // Cor do texto das células
            Dgv_City.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Cor do texto dos cabeçalhos
            Dgv_City.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray; // Cor de fundo dos cabeçalhos
            Dgv_City.RowsDefaultCellStyle.ForeColor = Color.Black; // Cor do texto das linhas
            Dgv_City.ReadOnly = true;

            this.Dgv_City.Columns["CityId"].HeaderText = "ID Cidade";
            this.Dgv_City.Columns["CityId"].Visible = false;

            this.Dgv_City.Columns["BoardId"].HeaderText = "ID Campanha";
            this.Dgv_City.Columns["BoardId"].Visible = false;

            this.Dgv_City.Columns["CityName"].HeaderText = "Cidade";
            this.Dgv_City.Columns["CityName"].Width = 300;
            this.Dgv_City.Columns["CityName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.Dgv_City.Columns["CityName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.Dgv_City.Columns["CityBiome"].HeaderText = "Bioma";
            this.Dgv_City.Columns["CityBiome"].Width = 200;
            this.Dgv_City.Columns["CityBiome"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.Dgv_City.Columns["CityBiome"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.Dgv_City.Columns["NpcCount"].HeaderText = "População";
            this.Dgv_City.Columns["NpcCount"].Width = 115;
            this.Dgv_City.Columns["NpcCount"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.Dgv_City.Columns["NpcCount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.Dgv_City.Columns["CityDescription"].HeaderText = "Descrição";
            this.Dgv_City.Columns["CityDescription"].Visible = false;

            this.Dgv_City.Columns["Editar"].DisplayIndex = 7;

            this.Dgv_City.Columns["Excluir"].DisplayIndex = 7;
        }

        private void Dgv_City_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            string name = this.Dgv_City.Columns[e.ColumnIndex].Name;
            int result;
            if (int.TryParse(this.Dgv_City.Rows[e.RowIndex].Cells["CityId"].Value?.ToString(), out result))
            {
                this.CarregarDetalhesCidade(result);
            }
            else
            {
                int num = (int)MessageBox.Show("O ID da cidade não é válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void CarregarDetalhesCidade(int cityId)
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
                            this.ConfirmCityName = mySqlDataReader["CityName"].ToString();
                            this.ConfirmCityBiome = mySqlDataReader["CityBiome"].ToString();
                            this.Txt_Descricao.Text = mySqlDataReader["CityDescription"].ToString();
                            if (this.Txt_Descricao.Text == "")
                                this.Txt_Descricao.Text = "Sem Descrição";
                            this.Pcb_City.Image = mySqlDataReader.IsDBNull(mySqlDataReader.GetOrdinal("CityImage")) ? (Image)null : this.ByteArrayToImage((byte[])mySqlDataReader["CityImage"]);
                        }
                    }
                }
                this.ConfirmCityId = cityId;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("ERRO: " + ex.Message, "Ocorreu um erro ao carregar os detalhes da cidade: SQL", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream memoryStream = new MemoryStream(byteArrayIn))
                return Image.FromStream((Stream)memoryStream);
        }

        private void Dgv_City_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            string name = this.Dgv_City.Columns[e.ColumnIndex].Name;
            int result;
            if (int.TryParse(this.Dgv_City.Rows[e.RowIndex].Cells["CityId"].Value?.ToString(), out result))
            {
                this.CarregarDetalhesCidade(result);
            }
            else
            {
                int num = (int)MessageBox.Show("O ID da cidade não é válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void Btn_Pesquisar_Click(object sender, EventArgs e) => FiltrarGrade();

        public void FiltrarGrade()
        {
            string name;
            switch (this.Cbb_CityFilter.Text.Trim())
            {
                case "Cidade":
                    name = "CityName";
                    break;
                case "Bioma":
                    name = "CityBiome";
                    break;
                case "População":
                    name = "NpcCount";
                    break;
                default:
                    int num1 = (int)MessageBox.Show("Selecione uma coluna válida para filtrar.", "Coluna Inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
            }
            bool flag = false;
            if (this.dt.Columns.Contains(name))
            {
                Type dataType = this.dt.Columns[name].DataType;
                flag = dataType == typeof(int) || dataType == typeof(Decimal) || dataType == typeof(double) || dataType == typeof(long);
            }
            string str1 = "";
            if (!string.IsNullOrWhiteSpace(this.Txt_pesquisa.Text))
            {
                if (flag)
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
                this.dt.DefaultView.RowFilter = !string.IsNullOrWhiteSpace(this.Txt_pesquisa.Text) ? str1 : "";
                this.Dgv_City.DataSource = (object)this.dt;
            }
            catch (Exception ex)
            {
                int num3 = (int)MessageBox.Show("Erro ao aplicar filtro: " + ex.Message, "Erro de Filtro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void Btn_Incluir_Click(object sender, EventArgs e)
        {
            CityDataInsert cityDataInsert = new CityDataInsert();
            this.Controls.Clear();
            cityDataInsert.SetDados(this.readBoardId);
            this.Controls.Add((Control)cityDataInsert);
            cityDataInsert.BringToFront();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.G | Keys.Control:
                    this.CriarCidadesRandon();
                    return true;
                case Keys.T | Keys.Control:
                    this.GerarTextoAutomaticamente(this.ConfirmCityId);
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        public async void GerarTextoAutomaticamente(int cityId)
        {
            DialogResult result = MessageBox.Show("Tem certeza que quer incluir uma descrição para a cidade selecionada?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;
            try
            {
                using (MySqlConnection cn = new MySqlConnection(ConexaoSQLClass.ConnString))
                {
                    cn.Open();
                    string sql = "SELECT * FROM sgrpg.tblcity WHERE CityId = @CityId";
                    MySqlCommand command = new MySqlCommand(sql, cn);
                    command.Parameters.AddWithValue("@CityId", (object)cityId);
                    ApiClass.LoadApiKey();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            await ApiClass.GerarTextoCidade(ApiClass.GeminiKey, reader["CityName"].ToString(), reader["CityBiome"].ToString());
                        }
                        else
                        {
                            int num = (int)MessageBox.Show("ERRO ao ler os dados da cidade. ", "Ocorreu um erro ao gerar a descrição da cidade", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                    }
                    string insertSql = "UPDATE sgrpg.tblcity SET CityDescription = @CityDescription WHERE CityId = @CityId";
                    MySqlCommand insertCommand = new MySqlCommand(insertSql, cn);
                    insertCommand.Parameters.AddWithValue("@CityDescription", (object)ApiClass.TextoGerado);
                    insertCommand.Parameters.AddWithValue("@CityId", (object)cityId);
                    insertCommand.ExecuteNonQuery();
                    cn.Close();
                    this.CarregarDetalhesCidade(this.ConfirmCityId);
                    sql = (string)null;
                    command = (MySqlCommand)null;
                    insertSql = (string)null;
                    insertCommand = (MySqlCommand)null;
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("ERRO: " + ex.Message, "Ocorreu um erro ao gerar a descrição do NPC", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public void CriarCidadesRandon()
        {
            try
            {
                if (MessageBox.Show("Tem certeza que deseja gerar cidades aleatórias?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                for (int index = 0; index < 10; ++index)
                {
                    string cidade = SelecionarCidadeAleatoria();
                    string bioma = biomesRandon[random.Next(biomesRandon.Length)];

                    using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                    {
                        connection.Open();
                        using (MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO sgrpg.tblcity (BoardId, CityName, CityBiome) VALUES (@BoardId, @CityName, @CityBiome)", connection))
                        {
                            mySqlCommand.Parameters.AddWithValue("@BoardId", readBoardId);
                            mySqlCommand.Parameters.AddWithValue("@CityName", cidade);
                            mySqlCommand.Parameters.AddWithValue("@CityBiome", bioma);
                            mySqlCommand.ExecuteNonQuery();
                        }
                        connection.Close();
                    }

                    cidadesSelecionadas.Add(cidade);
                }

                MessageBox.Show("Inclusão de Cidades realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Inicializar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO ao inserir cidade: " + ex.Message, "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private string SelecionarCidadeAleatoria()
        {
            string cidade;
            do
            {
                cidade = cidadesRandon[random.Next(cidadesRandon.Length)];
            }
            while (cidadesSelecionadas.Contains(cidade));
            return cidade;
        }


        private string[] cidadesRandon = new string[41]
   {
      "Valeria",
      "Rivendell",
      "Neverwinter",
      "Stormwind",
      "Baldur's Gate",
      "Ankh-Morpork",
      "Winterfell",
      "Gotham",
      "Mordheim",
      "Midgar",
      "Gondor",
      "Whiterun",
      "Novigrad",
      "Silent Hill",
      "Raccoon City",
      "Eldoria",
      "Ravenmoor",
      "Silvervale",
      "Frostholm",
      "Stormreach",
      "Shadowfen",
      "Ironcrest",
      "Emberfall",
      "Sunhaven",
      "Mistwood",
      "Thunderbreak",
      "Arkania",
      "Mistyhollow",
      "Goldenhold",
      "Ironhold",
      "Whogmar",
      "Wrierheith",
      "Schasmoe",
      "Vrapcuum",
      "Dukush",
      "Ventobravo",
      "Valdrakken",
      "Orgrimmar",
      "Luaprata",
      "Marea Azul",
      "Xique-Xique"
   };
        private string[] biomesRandon = new string[21]
        {
      "Campos",
      "Cavernas",
      "Deserto",
      "Estepes",
      "Floresta",
      "Gélido",
      "Litoral",
      "Manguezal",
      "Marinha",
      "Montanha",
      "Planaltos",
      "Planície",
      "Pântano",
      "Savana",
      "Selva",
      "Subterrâneo",
      "Taiga",
      "Tundra",
      "Tropical",
      "Vulcânico",
      "Outro"
        };
    }
}
