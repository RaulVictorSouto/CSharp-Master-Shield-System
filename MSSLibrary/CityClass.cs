using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace MSSLibrary
{
    public class CityClass
    {
        public int CityId { get; set; }

        [Required(ErrorMessage = "O Nome da Cidade é obrigatório")]
        [StringLength(100, ErrorMessage = "O Nome da Cidade deve ter no máximo 255 caracteres.")]
        public string CityName { get; set; }

        [Required(ErrorMessage = "O Bioma da Cidade é obrigatório")]
        public string CityBiome { get; set; }

        [StringLength(2000, ErrorMessage = "A Descrição da Cidade deve ter no máximo 2000 caracteres.")]
        public string CityDescription { get; set; }

        public byte[] CityImage { get; set; }

        public void CreateCity(int ConfirmBoardId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                {
                    connection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO sgrpg.tblcity (BoardId, CityName, CityBiome, CityImage, CityDescription) VALUES (@BoardId, @CityName, @CityBiome, @CityImage, @CityDescription)", connection);
                    mySqlCommand.Parameters.AddWithValue("@BoardId", (object)ConfirmBoardId);
                    mySqlCommand.Parameters.AddWithValue("@CityName", (object)this.CityName);
                    mySqlCommand.Parameters.AddWithValue("@CityBiome", (object)this.CityBiome);
                    mySqlCommand.Parameters.AddWithValue("@CityImage", (object)this.CityImage);
                    mySqlCommand.Parameters.AddWithValue("@CityDescription", (object)this.CityDescription);
                    mySqlCommand.ExecuteNonQuery();
                    int num = (int)MessageBox.Show("Inclusão de Cidade realizada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("ERRO: " + ex.Message, "Ocorreu um erro: SQL", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public void UpdateCity()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                {
                    connection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("UPDATE sgrpg.tblcity SET CityName = @CityName, CityBiome = @CityBiome, CityImage = @CityImage, CityDescription = @CityDescription WHERE CityId = @CityId", connection);
                    mySqlCommand.Parameters.AddWithValue("@CityName", (object)this.CityName);
                    mySqlCommand.Parameters.AddWithValue("@CityBiome", (object)this.CityBiome);
                    mySqlCommand.Parameters.AddWithValue("@CityImage", (object)this.CityImage);
                    mySqlCommand.Parameters.AddWithValue("@CityDescription", (object)this.CityDescription);
                    mySqlCommand.Parameters.AddWithValue("@CityId", (object)this.CityId);
                    mySqlCommand.ExecuteNonQuery();
                    int num = (int)MessageBox.Show("Alteração de cidade realizada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("ERRO: " + ex.Message, "Ocorreu um erro: SQL", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public void DeleteCity(int cityId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                {
                    connection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("DELETE FROM sgrpg.tblcity WHERE CityId = @CityId", connection);
                    mySqlCommand.Parameters.AddWithValue("@CityId", (object)cityId);
                    mySqlCommand.ExecuteNonQuery();
                    int num = (int)MessageBox.Show("Exclusão de Cidade realizada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("ERRO: " + ex.Message, "Ocorreu um erro: SQL", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public static DataTable GetCity(bool ativos, int readBoardId)
        {
            DataTable dataTable = new DataTable();
            string selectCommandText = string.Format("\r\n        SELECT c.CityId, c.BoardId, c.CityName, c.CityBiome, c.CityDescription, \r\n               COUNT(n.CityId) AS NpcCount \r\n        FROM sgrpg.tblcity c \r\n        LEFT JOIN sgrpg.tblnpc n ON c.CityId = n.CityId \r\n        WHERE c.BoardId = {0}\r\n        GROUP BY c.CityId, c.BoardId, c.CityName, c.CityBiome, c.CityDescription", (object)readBoardId);
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                {
                    connection.Open();
                    using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(selectCommandText, connection))
                        mySqlDataAdapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
            return dataTable;
        }
    }
}
