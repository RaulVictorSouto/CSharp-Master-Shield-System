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
    public class NpcClass
    {
        public int NpcId { get; set; }

        [Required(ErrorMessage = "O Nome do NPC é obrigatório")]
        [StringLength(255, ErrorMessage = "O Nome do NPC deve ter no máximo 255 caracteres.")]
        public string NpcFirstName { get; set; }

        [Required(ErrorMessage = "O Sobrenome do NPC é obrigatório")]
        [StringLength(255, ErrorMessage = "O Sobrenome do NPC deve ter no máximo 255 caracteres.")]
        public string NpcLastName { get; set; }

        public string NpcGender { get; set; }

        public string NpcCls { get; set; }

        public string NpcRace { get; set; }

        public int NpcLevel { get; set; }

        public int NpcHp { get; set; }

        public int NpcEnergy { get; set; }

        public int NpcStrength { get; set; }

        public int NpcSpeed { get; set; }

        public int NpcCharisma { get; set; }

        public int NpcLuck { get; set; }

        public int NpcIntelligence { get; set; }

        public bool NpcIsDead { get; set; }

        public byte[] NpcImage { get; set; }

        [StringLength(5000, ErrorMessage = "O Sobrenome do NPC deve ter no máximo 5000 caracteres.")]
        public string NpcDescription { get; set; }

        public void CreateNpc(int BoardId, int CityId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                {
                    connection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("\r\n    INSERT INTO sgrpg.tblnpc \r\n    (BoardId, CityId, NpcFirstName, NpcLastName, NpcRace, NpcClass, NpcGender, NpcHp, NpcLevel, NpcEnergy, NpcIsDead, NpcStrength, NpcSpeed, NpcIntelligence, NpcCharisma, NpcLuck, NpcImage, NpcDescription) \r\n    VALUES \r\n    (@BoardId, @CityId, @NpcFirstName, @NpcLastName, @NpcRace, @NpcClass, @NpcGender, @NpcHp, @NpcLevel, @NpcEnergy, @NpcIsDead, @NpcStrength, @NpcSpeed, @NpcIntelligence, @NpcCharisma, @NpcLuck, @NpcImage, @NpcDescription)", connection);
                    mySqlCommand.Parameters.AddWithValue("@BoardId", (object)BoardId);
                    mySqlCommand.Parameters.AddWithValue("@CityId", (object)CityId);
                    mySqlCommand.Parameters.AddWithValue("@NpcFirstName", (object)this.NpcFirstName);
                    mySqlCommand.Parameters.AddWithValue("@NpcLastName", (object)this.NpcLastName);
                    mySqlCommand.Parameters.AddWithValue("@NpcRace", (object)this.NpcRace);
                    mySqlCommand.Parameters.AddWithValue("@NpcClass", (object)this.NpcCls);
                    mySqlCommand.Parameters.AddWithValue("@NpcGender", (object)this.NpcGender);
                    mySqlCommand.Parameters.AddWithValue("@NpcHp", (object)this.NpcHp);
                    mySqlCommand.Parameters.AddWithValue("@NpcLevel", (object)this.NpcLevel);
                    mySqlCommand.Parameters.AddWithValue("@NpcEnergy", (object)this.NpcEnergy);
                    mySqlCommand.Parameters.AddWithValue("@NpcIsDead", (object)this.NpcIsDead);
                    mySqlCommand.Parameters.AddWithValue("@NpcStrength", (object)this.NpcStrength);
                    mySqlCommand.Parameters.AddWithValue("@NpcSpeed", (object)this.NpcSpeed);
                    mySqlCommand.Parameters.AddWithValue("@NpcIntelligence", (object)this.NpcIntelligence);
                    mySqlCommand.Parameters.AddWithValue("@NpcCharisma", (object)this.NpcCharisma);
                    mySqlCommand.Parameters.AddWithValue("@NpcLuck", (object)this.NpcLuck);
                    mySqlCommand.Parameters.AddWithValue("@NpcImage", (object)this.NpcImage);
                    mySqlCommand.Parameters.AddWithValue("@NpcDescription", (object)this.NpcDescription);
                    mySqlCommand.ExecuteNonQuery();
                    int num = (int)MessageBox.Show("Inclusão de NPC realizada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("ERRO: " + ex.Message, "Ocorreu um erro: SQL", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public void UpdateNpc()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                {
                    connection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("\r\n                                    UPDATE sgrpg.tblnpc \r\n                                    SET \r\n                                        NpcFirstName = @NpcFirstName, \r\n                                        NpcLastName = @NpcLastName, \r\n                                        NpcRace = @NpcRace, \r\n                                        NpcClass = @NpcClass, \r\n                                        NpcGender = @NpcGender, \r\n                                        NpcHp = @NpcHp, \r\n                                        NpcLevel = @NpcLevel, \r\n                                        NpcEnergy = @NpcEnergy, \r\n                                        NpcIsDead = @NpcIsDead, \r\n                                        NpcStrength = @NpcStrength, \r\n                                        NpcSpeed = @NpcSpeed, \r\n                                        NpcIntelligence = @NpcIntelligence, \r\n                                        NpcCharisma = @NpcCharisma, \r\n                                        NpcLuck = @NpcLuck, \r\n                                        NpcImage = @NpcImage, \r\n                                        NpcDescription = @NpcDescription \r\n                                    WHERE \r\n                                        NpcId = @NpcId", connection);
                    mySqlCommand.Parameters.AddWithValue("@NpcFirstName", (object)this.NpcFirstName);
                    mySqlCommand.Parameters.AddWithValue("@NpcLastName", (object)this.NpcLastName);
                    mySqlCommand.Parameters.AddWithValue("@NpcRace", (object)this.NpcRace);
                    mySqlCommand.Parameters.AddWithValue("@NpcClass", (object)this.NpcCls);
                    mySqlCommand.Parameters.AddWithValue("@NpcGender", (object)this.NpcGender);
                    mySqlCommand.Parameters.AddWithValue("@NpcHp", (object)this.NpcHp);
                    mySqlCommand.Parameters.AddWithValue("@NpcLevel", (object)this.NpcLevel);
                    mySqlCommand.Parameters.AddWithValue("@NpcEnergy", (object)this.NpcEnergy);
                    mySqlCommand.Parameters.AddWithValue("@NpcIsDead", (object)this.NpcIsDead);
                    mySqlCommand.Parameters.AddWithValue("@NpcStrength", (object)this.NpcStrength);
                    mySqlCommand.Parameters.AddWithValue("@NpcSpeed", (object)this.NpcSpeed);
                    mySqlCommand.Parameters.AddWithValue("@NpcIntelligence", (object)this.NpcIntelligence);
                    mySqlCommand.Parameters.AddWithValue("@NpcCharisma", (object)this.NpcCharisma);
                    mySqlCommand.Parameters.AddWithValue("@NpcLuck", (object)this.NpcLuck);
                    mySqlCommand.Parameters.AddWithValue("@NpcImage", (object)this.NpcImage);
                    mySqlCommand.Parameters.AddWithValue("@NpcDescription", (object)this.NpcDescription);
                    mySqlCommand.Parameters.AddWithValue("@NpcId", (object)this.NpcId);
                    mySqlCommand.ExecuteNonQuery();
                    int num = (int)MessageBox.Show("Alteração de NPC realizada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("ERRO: " + ex.Message, "Ocorreu um erro: SQL", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public void DeleteNpc(int npcId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                {
                    connection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("DELETE FROM sgrpg.tblnpc WHERE NpcId = @NpcId", connection);
                    mySqlCommand.Parameters.AddWithValue("@NpcId", (object)this.NpcId);
                    mySqlCommand.ExecuteNonQuery();
                    int num = (int)MessageBox.Show("Exclusão de NPC realizada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("ERRO: " + ex.Message, "Ocorreu um erro: SQL", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public static DataTable GetNpc(bool ativos, int readCityId)
        {
            DataTable dataTable = new DataTable();
            string selectCommandText = "SELECT NpcId, CityId, BoardId, CONCAT(NpcFirstName, ' ', NpcLastName) AS NpcFullName, NpcGender, NpcClass, NpcRace, NpcLevel, NpcHp, NpcEnergy, NpcIsDead, NpcStrength, NpcSpeed, NpcCharisma, NpcLuck, NpcIntelligence, NpcImage, NpcDescription " + string.Format("FROM sgrpg.tblnpc WHERE CityId = {0}", (object)readCityId);
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                {
                    connection.Open();
                    using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(selectCommandText, connection))
                        mySqlDataAdapter.Fill(dataTable);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
            return dataTable;
        }

        public async Task MatarRessucitarNPC(int npcId, bool newValue)
        {
            string sql = "UPDATE sgrpg.tblnpc SET NpcIsDead = @newValue WHERE NpcId = @npcId";
            try
            {
                using (MySqlConnection cn = new MySqlConnection(ConexaoSQLClass.ConnString))
                {
                    await cn.OpenAsync();
                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@newValue", (object)newValue);
                        cmd.Parameters.AddWithValue("@npcId", (object)npcId);
                        int num = await cmd.ExecuteNonQueryAsync();
                    }
                    await cn.CloseAsync();
                }
                sql = (string)null;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("Erro ao atualizar o status: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                sql = (string)null;
            }
        }
    }
}
