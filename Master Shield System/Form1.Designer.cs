namespace Master_Shield_System
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelContainer = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voltarParaCampanhasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chaveDeAPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instruçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelContainer.Location = new System.Drawing.Point(0, 24);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1320, 637);
            this.panelContainer.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1320, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.voltarParaCampanhasToolStripMenuItem,
            this.chaveDeAPIToolStripMenuItem,
            this.instruçõesToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // voltarParaCampanhasToolStripMenuItem
            // 
            this.voltarParaCampanhasToolStripMenuItem.Name = "voltarParaCampanhasToolStripMenuItem";
            this.voltarParaCampanhasToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.voltarParaCampanhasToolStripMenuItem.Text = "Voltar para Campanhas";
            this.voltarParaCampanhasToolStripMenuItem.Click += new System.EventHandler(this.voltarParaCampanhasToolStripMenuItem_Click);
            // 
            // chaveDeAPIToolStripMenuItem
            // 
            this.chaveDeAPIToolStripMenuItem.Name = "chaveDeAPIToolStripMenuItem";
            this.chaveDeAPIToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.chaveDeAPIToolStripMenuItem.Text = "Chave de API";
            this.chaveDeAPIToolStripMenuItem.Click += new System.EventHandler(this.chaveDeAPIToolStripMenuItem_Click);
            // 
            // instruçõesToolStripMenuItem
            // 
            this.instruçõesToolStripMenuItem.Name = "instruçõesToolStripMenuItem";
            this.instruçõesToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.instruçõesToolStripMenuItem.Text = "Instruções ";
            this.instruçõesToolStripMenuItem.Click += new System.EventHandler(this.instruçõesToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 661);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Master Shield System";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem voltarParaCampanhasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chaveDeAPIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instruçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
    }
}

