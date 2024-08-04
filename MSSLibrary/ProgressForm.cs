using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MSSLibrary
{
    public class ProgressForm : Form
    {
        private IContainer components = null;

        public ProgressForm()
        {
            this.InitializeComponent();
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Gerando Descrição...";
            this.Size = new Size(300, 100);

            Label label = new Label
            {
                AutoSize = true,
                Text = "Por favor, aguarde...",
                Location = new Point(80, 30)
            };
            this.Controls.Add(label);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(300, 100);
            this.Text = "ProgressForm";
        }
    }
}

