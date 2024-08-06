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
            Dgv_Npc.Columns["NpcFullName"].Width = 260;

            // Configurações da coluna "Raça"
            Dgv_Npc.Columns["NpcRace"].HeaderText = "Raça";
            Dgv_Npc.Columns["NpcRace"].Width = 160;

            // Configurações da coluna "Classe"
            Dgv_Npc.Columns["NpcClass"].HeaderText = "Classe";
            Dgv_Npc.Columns["NpcClass"].Width = 160;

            // Configurações da coluna "Gênero"
            Dgv_Npc.Columns["NpcGender"].HeaderText = "Gênero";
            Dgv_Npc.Columns["NpcGender"].Width = 180;

            // Configurações da coluna "Status"
            Dgv_Npc.Columns["NpcIsDead"].HeaderText = "Status";
            Dgv_Npc.Columns["NpcIsDead"].Width = 60;
            Dgv_Npc.Columns["NpcIsDead"].DisplayIndex = 9;
            Dgv_Npc.Columns["NpcIsDead"].CellTemplate = new DataGridViewCheckBoxCell();

            // Configurações de índices das colunas "Editar" e "Excluir"
            Dgv_Npc.Columns["Editar"].DisplayIndex = 10;
            Dgv_Npc.Columns["Excluir"].DisplayIndex = 10;

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
                        //this.AlterarStatus(result, e.RowIndex);
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


    }
}
