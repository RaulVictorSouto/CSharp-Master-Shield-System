using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Master_Shield_System.Formularios.Npc;

namespace Master_Shield_System
{
    public partial class RolarDadosForm : Form
    {
        public int resultado;
        public string historico;
        public string dice;
        public RolarDadosForm()
        {
            InitializeComponent();
            Txt_Resultado.Text = "";
            Rbtn_d20.Checked = true;
            this.Cbb_Modo.SelectedItem = (object)"Rolagem Normal";
        }

       private void Btn_Rolar_Click(object sender, EventArgs e)
       {
            string itemSelecionado = Cbb_Modo.SelectedItem?.ToString();

            switch (itemSelecionado)
            {
                case "Rolagem Normal":
                    #region Rolagem normal
                    if (Rbtn_d100.Checked)
                    {
                        dice = "d100";
                        resultado = SortearNumero(0, 100);
                    }
                    else if (Rbtn_d20.Checked)
                    {
                        dice = "d20";
                        resultado = SortearNumero(1, 20);
                    }
                    else if (Rbtn_d12.Checked)
                    {
                        dice = "d12";
                        resultado = SortearNumero(1, 12);
                    }
                    else if (Rbtn_d10.Checked)
                    {
                        dice = "d10";
                        resultado = SortearNumero(1, 10);
                    }
                    else if (Rbtn_d8.Checked)
                    {
                        dice = "d8";
                        resultado = SortearNumero(1, 8);
                    }
                    else if (Rbtn_d6.Checked)
                    {
                        dice = "d6";
                        resultado = SortearNumero(1, 6);
                    }
                    else if (Rbtn_d4.Checked)
                    {
                        dice = "d4";
                        resultado = SortearNumero(1, 4);
                    }
                    #endregion
                    break;

                case "Rolagem Favorável":
                    #region Rolagem favoravel

                    if (Rbtn_d100.Checked)
                    {
                        dice = "d100";
                        resultado = SortearNumero(60, 100);
                    }
                    else if (Rbtn_d20.Checked)
                    {
                        dice = "d20";
                        resultado = SortearNumero(16, 20);
                    }
                    else if (Rbtn_d12.Checked)
                    {
                        dice = "d12";
                        resultado = SortearNumero(8, 12);
                    }
                    else if (Rbtn_d10.Checked)
                    {
                        dice = "d10";
                        resultado = SortearNumero(7, 10);
                    }
                    else if (Rbtn_d8.Checked)
                    {
                        dice = "d8";
                        resultado = SortearNumero(5, 8);
                    }
                    else if (Rbtn_d6.Checked)
                    {
                        dice = "d6";
                        resultado = SortearNumero(4, 6);
                    }
                    else if (Rbtn_d4.Checked)
                    {
                        dice = "d4";
                        resultado = SortearNumero(3, 4);
                    }
                   

                    #endregion
                    break;

                case "Rolagem Desfavorável":
                    #region Rolagem desfavoravel

                    if (Rbtn_d100.Checked)
                    {
                        dice = "d100";
                        resultado = SortearNumero(0, 40);
                    }
                    else if (Rbtn_d20.Checked)
                    {
                        dice = "d20";
                        resultado = SortearNumero(1, 9);
                    }
                    else if (Rbtn_d12.Checked)
                    {
                        dice = "d12";
                        resultado = SortearNumero(1, 8);
                    }
                    else if (Rbtn_d10.Checked)
                    {
                        dice = "d10";
                        resultado = SortearNumero(1, 7);
                    }
                    else if (Rbtn_d8.Checked)
                    {
                        dice = "d8";
                        resultado = SortearNumero(1, 5);
                    }
                    else if (Rbtn_d6.Checked)
                    {
                        dice = "d6";
                        resultado = SortearNumero(1, 3);
                    }
                    else if (Rbtn_d4.Checked)
                    {
                        dice = "d4";
                        resultado = SortearNumero(1, 2);
                    }
                    
                    #endregion
                    break;
            }

            if (Rbtn_d2.Checked)
            {
                dice = "d2";
                resultado = SortearNumero(1, 2);
            }
            else if (Rbtn_escolher.Checked)
            {
                int num1 = Convert.ToInt32(Txt_Num1.Text);
                int num2 = Convert.ToInt32(Txt_Num2.Text);
                if (num1 <= num2)
                {
                    dice = $"Dado Customizado({num1}/{num2})";
                    resultado = SortearNumero(num1, num2);
                }
                else
                {
                    MessageBox.Show("O valor mínimo deve ser menor ou igual ao valor máximo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            Txt_Resultado.Text = resultado.ToString();
                DateTime agora = DateTime.Now;
                string dataHora = agora.ToString("dd-MM-yyyy HH:mm:ss");

                Txt_Historico.Text += $"[{dataHora}] {dice}: {resultado} \n";
        }

        public int SortearNumero(int numX, int numY) 
        {
            Random random = new Random();
            return random.Next(numX, numY + 1);
        }


        #region apenas numeros

        public static void IntNumber(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '-')
                return;
            e.Handled = true;
        }

        private void Txt_Num1_KeyPress(object sender, KeyPressEventArgs e)
        {
            NpcDataInsert.IntNumber(e);
            if (e.KeyChar != '-' || this.Txt_Num1.Text.IndexOf('-') <= -1 && this.Txt_Num1.SelectionStart == 0)
                return;
            e.Handled = true;
        }

        private void Txt_Num2_KeyPress(object sender, KeyPressEventArgs e)
        {
            NpcDataInsert.IntNumber(e);
            if (e.KeyChar != '-' || this.Txt_Num2.Text.IndexOf('-') <= -1 && this.Txt_Num2.SelectionStart == 0)
                return;
            e.Handled = true;
        }

        #endregion
    }
}
