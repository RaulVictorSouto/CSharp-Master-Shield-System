namespace Master_Shield_System
{
    partial class ChaveApiForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_ChaveGemini = new System.Windows.Forms.TextBox();
            this.Btn_Sair = new System.Windows.Forms.Button();
            this.Btn_Confirmar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Chave Gemini";
            // 
            // Txt_ChaveGemini
            // 
            this.Txt_ChaveGemini.Location = new System.Drawing.Point(12, 41);
            this.Txt_ChaveGemini.Name = "Txt_ChaveGemini";
            this.Txt_ChaveGemini.Size = new System.Drawing.Size(538, 20);
            this.Txt_ChaveGemini.TabIndex = 11;
            // 
            // Btn_Sair
            // 
            this.Btn_Sair.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Sair.ForeColor = System.Drawing.Color.Red;
            this.Btn_Sair.Location = new System.Drawing.Point(12, 82);
            this.Btn_Sair.Name = "Btn_Sair";
            this.Btn_Sair.Size = new System.Drawing.Size(67, 29);
            this.Btn_Sair.TabIndex = 22;
            this.Btn_Sair.Text = "Sair";
            this.Btn_Sair.UseVisualStyleBackColor = true;
            this.Btn_Sair.Click += new System.EventHandler(this.Btn_Sair_Click);
            // 
            // Btn_Confirmar
            // 
            this.Btn_Confirmar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Confirmar.ForeColor = System.Drawing.Color.Black;
            this.Btn_Confirmar.Location = new System.Drawing.Point(454, 82);
            this.Btn_Confirmar.Name = "Btn_Confirmar";
            this.Btn_Confirmar.Size = new System.Drawing.Size(96, 29);
            this.Btn_Confirmar.TabIndex = 23;
            this.Btn_Confirmar.Text = "Confirmar";
            this.Btn_Confirmar.UseVisualStyleBackColor = true;
            this.Btn_Confirmar.Click += new System.EventHandler(this.Btn_Confirmar_Click);
            // 
            // ChaveApiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 132);
            this.Controls.Add(this.Btn_Confirmar);
            this.Controls.Add(this.Btn_Sair);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Txt_ChaveGemini);
            this.Name = "ChaveApiForm";
            this.Text = "Chave de API";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_ChaveGemini;
        private System.Windows.Forms.Button Btn_Sair;
        private System.Windows.Forms.Button Btn_Confirmar;
    }
}