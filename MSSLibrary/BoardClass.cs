using MSSLibrary;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SGRPGLibrary
{
    public class BoardClass
    {
        public int BoardId { get; set; }

        //[Required(ErrorMessage = "O Título da Mesa é obrigatório")]
        //[StringLength(100, ErrorMessage = "O Título da Mesa deve ter no máximo 50 caracteres.")]
        public string BoardTitle { get; set; }

        //[Required(ErrorMessage = "O Nome do Mestre é obrigatório")]
        //[StringLength(255, ErrorMessage = "O Nome do Mestre deve ter no máximo 255 caracteres.")]
        public string BoardMaster { get; set; }

        public byte[] BoardCover { get; set; }

        public byte[] BoardMap { get; set; }

        public void CreateBoard()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                {
                    connection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO sgrpg.tblboard (BoardTitle, BoardMaster, BoardCover, BoardMap) VALUES (@BoardTitle, @BoardMaster, @BoardCover, @BoardMap)", connection);
                    mySqlCommand.Parameters.AddWithValue("@BoardTitle", (object)this.BoardTitle);
                    mySqlCommand.Parameters.AddWithValue("@BoardMaster", (object)this.BoardMaster);
                    mySqlCommand.Parameters.AddWithValue("@BoardCover", (object)this.BoardCover);
                    mySqlCommand.Parameters.AddWithValue("@BoardMap", (object)this.BoardMap);
                    mySqlCommand.ExecuteNonQuery();
                    int num = (int)MessageBox.Show("Inclusão de Campanha realizada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("ERRO: " + ex.Message, "Ocorreu um erro: SQL", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public void UpdateBoard()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                {
                    connection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("UPDATE sgrpg.tblboard SET BoardTitle = @BoardTitle, BoardMaster = @BoardMaster, BoardCover = @BoardCover, BoardMap = @BoardMap WHERE BoardId = @BoardId", connection);
                    mySqlCommand.Parameters.AddWithValue("@BoardTitle", (object)this.BoardTitle);
                    mySqlCommand.Parameters.AddWithValue("@BoardMaster", (object)this.BoardMaster);
                    mySqlCommand.Parameters.AddWithValue("@BoardCover", (object)this.BoardCover);
                    mySqlCommand.Parameters.AddWithValue("@BoardMap", (object)this.BoardMap);
                    mySqlCommand.Parameters.AddWithValue("@BoardId", (object)this.BoardId);
                    mySqlCommand.ExecuteNonQuery();
                    int num = (int)MessageBox.Show("Alteração de Campanha realizada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("ERRO: " + ex.Message, "Ocorreu um erro: SQL", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public void DeleteBoard(int boardId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                {
                    connection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("DELETE FROM sgrpg.tblboard WHERE BoardId = @BoardId", connection);
                    mySqlCommand.Parameters.AddWithValue("@BoardId", (object)boardId);
                    mySqlCommand.ExecuteNonQuery();
                    int num = (int)MessageBox.Show("Exclusão de Campanha realizada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("ERRO: " + ex.Message, "Ocorreu um erro: SQL", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public static DataTable GetBoard(bool ativos)
        {
            DataTable dataTable = new DataTable();
            string selectCommandText = "SELECT BoardId, BoardTitle, BoardMaster FROM sgrpg.tblboard";
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