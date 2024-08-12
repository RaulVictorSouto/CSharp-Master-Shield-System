using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Master_Shield_System
{
    public partial class InstrucoesForm : Form
    {
        public InstrucoesForm()
        {
            InitializeComponent();
            this.linkLabel1.Links.Add(0, this.linkLabel1.Text.Length, (object)"https://ai.google.dev/gemini-api?hl=pt-br");
            this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = e.Link.LinkData as string,
                UseShellExecute = true
            });
        }
    }
}
