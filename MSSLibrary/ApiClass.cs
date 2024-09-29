using System;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;

namespace MSSLibrary
{
    public class ApiClass
    {
        private static readonly HttpClient client = new HttpClient();

        public static string GeminiKey { get; set; }
        public static string TextoGerado { get; set; }

        public static async Task GerarTextoNpc(
            string apiKey,
            string nome,
            string sobrenome,
            string localizacao,
            string bioma,
            string raca,
            string classe,
            string genero,
            string moral,
            string nivel,
            string hp,
            string energia,
            string forca,
            string velocidade,
            string inteligencia,
            string carisma,
            string sorte)
        {
            ProgressForm progressForm = null;
            try
            {
                progressForm = new ProgressForm();
                progressForm.Show();
                Cursor.Current = Cursors.WaitCursor;

                string promptString = $"Crie uma descrição resumida para um NPC de RPG, separada pelos seguintes tópicos: backstory, características físicas e sidequest (além de suas recompensas). Para isso, siga os seguintes atributos: Nome: {nome}, Sobrenome: {sobrenome}, Localização: {localizacao} ({bioma}), Raça: {raca}, Classe: {classe}, Gênero: {genero}, Alinhamento Moral: {moral} Nível: {nivel}, HP: {hp}, Energia: {energia}, Força: {forca}, Velocidade: {velocidade}, Inteligência: {inteligencia}, Carisma: {carisma}, Sorte: {sorte}. Considere que, no que tange os atributos numéricos, -6 é horrível e 6 é ótimo";

                var jsonBody = new
                {
                    contents = new[]
                    {
                new
                {
                    role = "",
                    parts = new[]
                    {
                        new { text = promptString }
                    }
                }
            },
                    generationConfig = new
                    {
                        temperature = 0.5,
                        topK = 40,
                        topP = 0.9,
                        maxOutputTokens = 600
                    },
                    safetySettings = new[]
                    {
                new
                {
                    category = "HARM_CATEGORY_SEXUALLY_EXPLICIT",
                    threshold = "BLOCK_LOW_AND_ABOVE"
                }
            }
                };

                string jsonString = JsonConvert.SerializeObject(jsonBody);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key={apiKey}")
                {
                    Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
                };

                HttpClient client = new HttpClient();  // Adicionar instância de HttpClient
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<GeminiResponse>(responseBody);

                    if (responseObject?.candidates != null && responseObject.candidates.Length > 0 && responseObject.candidates[0].content.parts.Length > 0)
                    {
                        string generatedText = responseObject.candidates[0].content.parts[0].text;
                        ApiClass.TextoGerado = generatedText;
                        MessageBox.Show($"Descrição do NPC {nome} {sobrenome} adicionada com sucesso!", "Descrição adicionada", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        Console.WriteLine("Error: No candidates found in the response.");
                    }
                }
                else if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var errorResponse = JsonConvert.DeserializeObject<GeminiErrorResponse>(responseBody);
                    MessageBox.Show("Erro: Por gentileza, insira uma nova chave de API", "Ocorreu um erro: API Gemini", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    string str1 = response.StatusCode.ToString();
                    string str2 = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error: {str1} - {str2}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nTente novamente.", "Ocorreu um erro: API Gemini", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (progressForm != null)
                {
                    progressForm.Close();
                    progressForm.Dispose();
                }
                Cursor.Current = Cursors.Default;
            }
        }



        public static async Task GerarTextoCidade(string apiKey, string nome, string bioma)
        {
            ProgressForm progressForm = null;
            try
            {
                // Exibe o formulário de progresso
                progressForm = new ProgressForm();
                progressForm.Show();
                Cursor.Current = Cursors.WaitCursor;

                // Constrói o prompt para a geração de conteúdo
                string promptString = $"Crie uma descrição resumida para uma cidade/localização de RPG com as seguintes características: Nome: {nome}, Bioma: {bioma}.";

                // Cria o corpo da requisição JSON
                var jsonBody = new
                {
                    contents = new[]
                    {
                new
                {
                    role = "",
                    parts = new[]
                    {
                        new { text = promptString }
                    }
                }
            },
                    generationConfig = new
                    {
                        temperature = 0.7,
                        topK = 40,
                        topP = 0.9,
                        maxOutputTokens = 400
                    },
                    safetySettings = new[]
                    {
                new
                {
                    category = "HARM_CATEGORY_SEXUALLY_EXPLICIT",
                    threshold = "BLOCK_LOW_AND_ABOVE"
                }
            }
                };

                string jsonString = JsonConvert.SerializeObject(jsonBody);

                // Cria a requisição HTTP
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key={apiKey}")
                {
                    Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
                };

                // Envia a requisição
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<GeminiResponse>(responseBody);

                    if (responseObject?.candidates != null && responseObject.candidates.Length > 0 && responseObject.candidates[0].content.parts.Length > 0)
                    {
                        string generatedText = responseObject.candidates[0].content.parts[0].text;
                        ApiClass.TextoGerado = generatedText;
                        MessageBox.Show($"Descrição da cidade {nome} adicionada com sucesso!", "Descrição adicionada", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        Console.WriteLine("Erro: Nenhum candidato encontrado na resposta.");
                    }
                }
                else if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var errorResponse = JsonConvert.DeserializeObject<GeminiErrorResponse>(responseBody);
                    MessageBox.Show("Erro: Por gentileza, insira uma nova chave de API", "Ocorreu um erro: API Gemini", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    string statusCode = response.StatusCode.ToString();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Erro: {statusCode} - {responseBody}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocorreu um erro: API Gemini", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Fecha e descarta o formulário de progresso
                if (progressForm != null)
                {
                    progressForm.Close();
                    progressForm.Dispose();
                }
                Cursor.Current = Cursors.Default;
            }
        }



        public void UpdateKey()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                {
                    connection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("UPDATE sgrpg.tblapi SET ApiGeminiKey = @ApiGeminiKey WHERE ApiGeminiId = 1", connection);
                    mySqlCommand.Parameters.AddWithValue("@ApiGeminiKey", GeminiKey);
                    mySqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Inclusão de Chave realizada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message, "Ocorreu um erro: SQL", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public static void LoadApiKey()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConexaoSQLClass.ConnString))
                {
                    connection.Open();
                    object obj = new MySqlCommand("SELECT ApiGeminiKey FROM sgrpg.tblapi WHERE ApiGeminiId = 1", connection).ExecuteScalar();
                    if (obj != null)
                    {
                        GeminiKey = obj.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Chave de API não encontrada no banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message, "Ocorreu um erro: SQL", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public class GeminiResponse
        {
            public Candidate[] candidates { get; set; }
        }

        public class Candidate
        {
            public Content content { get; set; }
            public string finishReason { get; set; }
            public int index { get; set; }
            public SafetyRating[] safetyRatings { get; set; }
        }

        public class Content
        {
            public Part[] parts { get; set; }
            public string role { get; set; }
        }

        public class Part
        {
            public string text { get; set; }
        }

        public class SafetyRating
        {
            public string category { get; set; }
            public string probability { get; set; }
        }

        public class GeminiErrorResponse
        {
            public ErrorDetail error { get; set; }
        }

        public class ErrorDetail
        {
            public int code { get; set; }
            public string message { get; set; }
            public string status { get; set; }
        }
    }
}