using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSSLibrary;
using MySql.Data.MySqlClient;

namespace Master_Shield_System
{
    public partial class ChaveApiForm : Form
    {
        private ApiClass ac = new ApiClass();
        public ChaveApiForm()
        {
            InitializeComponent();
            SetDados();
        }

        public ApiClass SetDados()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                {
                    connection.Open();
                    using (MySqlDataReader mySqlDataReader = new MySqlCommand("SELECT ApiGeminiKey FROM sgrpg.tblapi WHERE ApiGeminiId = 1", connection).ExecuteReader())
                    {
                        if (mySqlDataReader.Read())
                        {
                            this.Txt_ChaveGemini.Text = mySqlDataReader["ApiGeminiKey"].ToString();
                            ApiClass.GeminiKey = this.Txt_ChaveGemini.Text;
                        }
                    }
                }
                return this.ac;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("ERRO: " + ex.Message, "Ocorreu um erro: SQL", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return (ApiClass)null;
            }
        }

        private void Btn_Confirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Txt_ChaveGemini.Text))
            {
                if (MessageBox.Show("ATENÇÃO: Nenhuma chave foi digitada. Deseja salvar mesmo assim?", "Nenhuma chave foi digitada", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                ApiClass.GeminiKey = this.Txt_ChaveGemini.Text;
                this.ac.UpdateKey();
            }
            else
            {
                ApiClass.GeminiKey = this.Txt_ChaveGemini.Text;
                this.ac.UpdateKey();
            }
        }

        private void Btn_Sair_Click(object sender, EventArgs e) => this.Close();
    }
}
