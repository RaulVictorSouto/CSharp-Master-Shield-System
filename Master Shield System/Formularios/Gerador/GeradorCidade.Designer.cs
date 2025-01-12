namespace Master_Shield_System.Formularios.Gerador
{
    partial class GeradorCidade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeradorCidade));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_Numero = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnl_biomas = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnl_reputacao = new System.Windows.Forms.Panel();
            this.chb_Biomas_MarcarTodos = new System.Windows.Forms.CheckBox();
            this.chb_Reputacao_MarcarTodos = new System.Windows.Forms.CheckBox();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Btn_Gerar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Geração de Cidades Aleatórias";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Número de Cidades";
            // 
            // Txt_Numero
            // 
            this.Txt_Numero.Location = new System.Drawing.Point(17, 85);
            this.Txt_Numero.Name = "Txt_Numero";
            this.Txt_Numero.Size = new System.Drawing.Size(135, 20);
            this.Txt_Numero.TabIndex = 2;
            this.Txt_Numero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Numero_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Biomas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(273, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Reputação";
            // 
            // pnl_biomas
            // 
            this.pnl_biomas.AutoScroll = true;
            this.pnl_biomas.Location = new System.Drawing.Point(6, 10);
            this.pnl_biomas.Name = "pnl_biomas";
            this.pnl_biomas.Size = new System.Drawing.Size(225, 282);
            this.pnl_biomas.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnl_biomas);
            this.groupBox1.Location = new System.Drawing.Point(17, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 298);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnl_reputacao);
            this.groupBox2.Location = new System.Drawing.Point(276, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(237, 298);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // pnl_reputacao
            // 
            this.pnl_reputacao.AutoScroll = true;
            this.pnl_reputacao.Location = new System.Drawing.Point(6, 10);
            this.pnl_reputacao.Name = "pnl_reputacao";
            this.pnl_reputacao.Size = new System.Drawing.Size(225, 282);
            this.pnl_reputacao.TabIndex = 7;
            // 
            // chb_Biomas_MarcarTodos
            // 
            this.chb_Biomas_MarcarTodos.AutoSize = true;
            this.chb_Biomas_MarcarTodos.Location = new System.Drawing.Point(166, 135);
            this.chb_Biomas_MarcarTodos.Name = "chb_Biomas_MarcarTodos";
            this.chb_Biomas_MarcarTodos.Size = new System.Drawing.Size(88, 17);
            this.chb_Biomas_MarcarTodos.TabIndex = 10;
            this.chb_Biomas_MarcarTodos.Text = "Marcar todos";
            this.chb_Biomas_MarcarTodos.UseVisualStyleBackColor = true;
            this.chb_Biomas_MarcarTodos.CheckedChanged += new System.EventHandler(this.chb_Biomas_MarcarTodos_CheckedChanged);
            // 
            // chb_Reputacao_MarcarTodos
            // 
            this.chb_Reputacao_MarcarTodos.AutoSize = true;
            this.chb_Reputacao_MarcarTodos.Location = new System.Drawing.Point(425, 135);
            this.chb_Reputacao_MarcarTodos.Name = "chb_Reputacao_MarcarTodos";
            this.chb_Reputacao_MarcarTodos.Size = new System.Drawing.Size(88, 17);
            this.chb_Reputacao_MarcarTodos.TabIndex = 11;
            this.chb_Reputacao_MarcarTodos.Text = "Marcar todos";
            this.chb_Reputacao_MarcarTodos.UseVisualStyleBackColor = true;
            this.chb_Reputacao_MarcarTodos.CheckedChanged += new System.EventHandler(this.chb_Reputacao_MarcarTodos_CheckedChanged);
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.Location = new System.Drawing.Point(17, 458);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancelar.TabIndex = 12;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // Btn_Gerar
            // 
            this.Btn_Gerar.Location = new System.Drawing.Point(438, 458);
            this.Btn_Gerar.Name = "Btn_Gerar";
            this.Btn_Gerar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Gerar.TabIndex = 13;
            this.Btn_Gerar.Text = "Gerar";
            this.Btn_Gerar.UseVisualStyleBackColor = true;
            this.Btn_Gerar.Click += new System.EventHandler(this.Btn_Gerar_Click);
            // 
            // GeradorCidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 497);
            this.Controls.Add(this.Btn_Gerar);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.chb_Reputacao_MarcarTodos);
            this.Controls.Add(this.chb_Biomas_MarcarTodos);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Txt_Numero);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GeradorCidade";
            this.Text = "Geração de Cidades";
            this.Load += new System.EventHandler(this.GeradorCidade_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt_Numero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnl_biomas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel pnl_reputacao;
        private System.Windows.Forms.CheckBox chb_Biomas_MarcarTodos;
        private System.Windows.Forms.CheckBox chb_Reputacao_MarcarTodos;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.Button Btn_Gerar;
    }
}