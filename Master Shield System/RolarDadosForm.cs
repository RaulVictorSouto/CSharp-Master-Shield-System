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
        public RolarDadosForm()
        {
            InitializeComponent();
            Txt_Resultado.Text = "";
            Rbtn_d20.Checked = true;
        }

       private void Btn_Rolar_Click(object sender, EventArgs e)
       {
            
                if (Rbtn_d100.Checked)
                    resultado = SortearNumero(0, 100);
                else if (Rbtn_d20.Checked)
                    resultado = SortearNumero(1, 20);
                else if (Rbtn_d12.Checked)
                    resultado = SortearNumero(1, 12);
                else if (Rbtn_d10.Checked)
                    resultado = SortearNumero(1, 11);
                else if (Rbtn_d8.Checked)
                    resultado = SortearNumero(1, 8);
                else if (Rbtn_d6.Checked)
                    resultado = SortearNumero(1, 6);
                else if (Rbtn_d4.Checked)
                    resultado = SortearNumero(1, 4);
                else if (Rbtn_d2.Checked)
                    resultado = SortearNumero(1, 2);
                else if (Rbtn_escolher.Checked)
                {
                    int num1 = Convert.ToInt32(Txt_Num1.Text);
                    int num2 = Convert.ToInt32(Txt_Num2.Text);
                    if (num1 <= num2)
                    {
                        resultado = SortearNumero(num1, num2);
                    }
                    else
                    {
                        MessageBox.Show("O valor mínimo deve ser menor ou igual ao valor máximo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                Txt_Resultado.Text = resultado.ToString();
        }

        public int SortearNumero(int numX, int numY) 
        {
            Random random = new Random();
            return random.Next(numX, numY + 1);
        }


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
    }
}
