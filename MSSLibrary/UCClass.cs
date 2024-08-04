using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSSLibrary
{
    public class UCClass
    {
        // Método estático para adicionar um UserControl a um Panel
        public static void AddUserControl(Panel panelContainer, UserControl userControl)
        {
            // Define a propriedade Dock do UserControl para preencher todo o Panel
            userControl.Dock = DockStyle.Fill;

            // Limpa todos os controles atualmente no Panel
            panelContainer.Controls.Clear();

            // Adiciona o novo UserControl ao Panel
            panelContainer.Controls.Add((Control)userControl);

            // Traz o UserControl para frente
            userControl.BringToFront();
        }
    }
}

