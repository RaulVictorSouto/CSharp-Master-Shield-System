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

        public string NpcMoral { get; set; }

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
        public string NpcDescription { get; set; }

        public void CreateNpc(int BoardId, int CityId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                {
                    connection.Open();

                    string query = @"
                INSERT INTO sgrpg.tblnpc 
                (BoardId, CityId, NpcFirstName, NpcLastName, NpcRace, NpcClass, NpcGender, NpcMoralAlignment, NpcHp, NpcLevel, NpcEnergy, NpcIsDead, NpcStrength, NpcSpeed, NpcIntelligence, NpcCharisma, NpcLuck, NpcImage, NpcDescription) 
                VALUES 
                (@BoardId, @CityId, @NpcFirstName, @NpcLastName, @NpcRace, @NpcClass, @NpcGender, @NpcMoral, @NpcHp, @NpcLevel, @NpcEnergy, @NpcIsDead, @NpcStrength, @NpcSpeed, @NpcIntelligence, @NpcCharisma, @NpcLuck, @NpcImage, @NpcDescription)";

                    MySqlCommand mySqlCommand = new MySqlCommand(query, connection);

                    // Adicionando parâmetros
                    mySqlCommand.Parameters.AddWithValue("@BoardId", BoardId);
                    mySqlCommand.Parameters.AddWithValue("@CityId", CityId);
                    mySqlCommand.Parameters.AddWithValue("@NpcFirstName", this.NpcFirstName);
                    mySqlCommand.Parameters.AddWithValue("@NpcLastName", this.NpcLastName);
                    mySqlCommand.Parameters.AddWithValue("@NpcRace", this.NpcRace);
                    mySqlCommand.Parameters.AddWithValue("@NpcClass", this.NpcCls);
                    mySqlCommand.Parameters.AddWithValue("@NpcGender", this.NpcGender);
                    mySqlCommand.Parameters.AddWithValue("@NpcMoral", this.NpcMoral);
                    mySqlCommand.Parameters.AddWithValue("@NpcHp", this.NpcHp);
                    mySqlCommand.Parameters.AddWithValue("@NpcLevel", this.NpcLevel);
                    mySqlCommand.Parameters.AddWithValue("@NpcEnergy", this.NpcEnergy);
                    mySqlCommand.Parameters.AddWithValue("@NpcIsDead", this.NpcIsDead);
                    mySqlCommand.Parameters.AddWithValue("@NpcStrength", this.NpcStrength);
                    mySqlCommand.Parameters.AddWithValue("@NpcSpeed", this.NpcSpeed);
                    mySqlCommand.Parameters.AddWithValue("@NpcIntelligence", this.NpcIntelligence);
                    mySqlCommand.Parameters.AddWithValue("@NpcCharisma", this.NpcCharisma);
                    mySqlCommand.Parameters.AddWithValue("@NpcLuck", this.NpcLuck);
                    mySqlCommand.Parameters.AddWithValue("@NpcImage", this.NpcImage);
                    mySqlCommand.Parameters.AddWithValue("@NpcDescription", this.NpcDescription);

                    mySqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Inclusão de NPC realizada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message, "Ocorreu um erro: SQL", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }


        public void UpdateNpc()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                {
                    connection.Open();

                    string query = @"
                UPDATE sgrpg.tblnpc 
                SET 
                    NpcFirstName = @NpcFirstName, 
                    NpcLastName = @NpcLastName, 
                    NpcRace = @NpcRace, 
                    NpcClass = @NpcClass, 
                    NpcGender = @NpcGender, 
                    NpcMoralAlignment = @NpcMoralAlignment, 
                    NpcHp = @NpcHp, 
                    NpcLevel = @NpcLevel, 
                    NpcEnergy = @NpcEnergy, 
                    NpcIsDead = @NpcIsDead, 
                    NpcStrength = @NpcStrength, 
                    NpcSpeed = @NpcSpeed, 
                    NpcIntelligence = @NpcIntelligence, 
                    NpcCharisma = @NpcCharisma, 
                    NpcLuck = @NpcLuck, 
                    NpcImage = @NpcImage, 
                    NpcDescription = @NpcDescription 
                WHERE 
                    NpcId = @NpcId";

                    MySqlCommand mySqlCommand = new MySqlCommand(query, connection);

                    // Adicionando parâmetros
                    mySqlCommand.Parameters.AddWithValue("@NpcFirstName", this.NpcFirstName);
                    mySqlCommand.Parameters.AddWithValue("@NpcLastName", this.NpcLastName);
                    mySqlCommand.Parameters.AddWithValue("@NpcRace", this.NpcRace);
                    mySqlCommand.Parameters.AddWithValue("@NpcClass", this.NpcCls);
                    mySqlCommand.Parameters.AddWithValue("@NpcGender", this.NpcGender);
                    mySqlCommand.Parameters.AddWithValue("@NpcMoralAlignment", this.NpcMoral); 
                    mySqlCommand.Parameters.AddWithValue("@NpcHp", this.NpcHp);
                    mySqlCommand.Parameters.AddWithValue("@NpcLevel", this.NpcLevel);
                    mySqlCommand.Parameters.AddWithValue("@NpcEnergy", this.NpcEnergy);
                    mySqlCommand.Parameters.AddWithValue("@NpcIsDead", this.NpcIsDead);
                    mySqlCommand.Parameters.AddWithValue("@NpcStrength", this.NpcStrength);
                    mySqlCommand.Parameters.AddWithValue("@NpcSpeed", this.NpcSpeed);
                    mySqlCommand.Parameters.AddWithValue("@NpcIntelligence", this.NpcIntelligence);
                    mySqlCommand.Parameters.AddWithValue("@NpcCharisma", this.NpcCharisma);
                    mySqlCommand.Parameters.AddWithValue("@NpcLuck", this.NpcLuck);
                    mySqlCommand.Parameters.AddWithValue("@NpcImage", this.NpcImage);
                    mySqlCommand.Parameters.AddWithValue("@NpcDescription", this.NpcDescription);
                    mySqlCommand.Parameters.AddWithValue("@NpcId", this.NpcId);

                    mySqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Alteração de NPC realizada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message, "Ocorreu um erro: SQL", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }


        public void DeleteNpc(int npcId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                {
                    connection.Open();

                    // Comando SQL para deletar o NPC com o ID fornecido
                    string query = "DELETE FROM sgrpg.tblnpc WHERE NpcId = @NpcId";
                    using (MySqlCommand mySqlCommand = new MySqlCommand(query, connection))
                    {
                        // Adicionar o parâmetro ao comando
                        mySqlCommand.Parameters.AddWithValue("@NpcId", npcId);

                        // Executar o comando
                        mySqlCommand.ExecuteNonQuery();
                    }
                }

                // Mensagem de sucesso (pode ser movida para onde o método é chamado)
                MessageBox.Show("Exclusão de NPC realizada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                // Mensagem de erro
                MessageBox.Show("ERRO: " + ex.Message, "Ocorreu um erro: SQL", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }


        public static DataTable GetNpc(bool ativos, int readCityId)
        {
            DataTable dataTable = new DataTable();
            string selectCommandText = @"
        SELECT 
            NpcId, 
            CityId, 
            BoardId, 
            CONCAT(NpcFirstName, ' ', NpcLastName) AS NpcFullName, 
            NpcGender, 
            NpcClass, 
            NpcRace, 
            NpcMoralAlignment, 
            NpcLevel, 
            NpcHp, 
            NpcEnergy, 
            NpcIsDead, 
            NpcStrength, 
            NpcSpeed, 
            NpcCharisma, 
            NpcLuck, 
            NpcIntelligence, 
            NpcImage, 
            NpcDescription 
        FROM 
            sgrpg.tblnpc 
        WHERE 
            CityId = @CityId";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                {
                    connection.Open();
                    using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(selectCommandText, connection))
                    {
                        mySqlDataAdapter.SelectCommand.Parameters.AddWithValue("@CityId", readCityId);
                        mySqlDataAdapter.Fill(dataTable);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
