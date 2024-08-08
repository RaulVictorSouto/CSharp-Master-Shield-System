namespace Master_Shield_System.Formularios.City
{
    partial class CityDataUpdate
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

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Cbb_Bioma = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_NomeCidade = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Btn_IncluirImagem = new System.Windows.Forms.Button();
            this.Btn_ApagarImagem = new System.Windows.Forms.Button();
            this.Pcb_ImagemCidade = new System.Windows.Forms.PictureBox();
            this.Btn_GerarDescricao = new System.Windows.Forms.Button();
            this.Txt_descricao = new System.Windows.Forms.RichTextBox();
            this.Btn_Limpar = new System.Windows.Forms.Button();
            this.Btn_Atualizar = new System.Windows.Forms.Button();
            this.Btn_Retornar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pcb_ImagemCidade)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Cbb_Bioma);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Txt_NomeCidade);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1288, 95);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // Cbb_Bioma
            // 
            this.Cbb_Bioma.FormattingEnabled = true;
            this.Cbb_Bioma.Items.AddRange(new object[] {
            "Campos",
            "Caverna",
            "Deserto",
            "Estepes",
            "Floresta",
            "Gélido",
            "Litoral",
            "Manguezal",
            "Marinha",
            "Montanha",
            "Planaltos",
            "Planície",
            "Pântano",
            "Savana",
            "Selva",
            "Subterrâneo",
            "Taiga",
            "Tundra",
            "Tropical",
            "Vulcânico",
            "Outro"});
            this.Cbb_Bioma.Location = new System.Drawing.Point(738, 38);
            this.Cbb_Bioma.Name = "Cbb_Bioma";
            this.Cbb_Bioma.Size = new System.Drawing.Size(544, 21);
            this.Cbb_Bioma.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(734, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Bioma";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nome da Cidade";
            // 
            // Txt_NomeCidade
            // 
            this.Txt_NomeCidade.Location = new System.Drawing.Point(10, 39);
            this.Txt_NomeCidade.Name = "Txt_NomeCidade";
            this.Txt_NomeCidade.Size = new System.Drawing.Size(708, 20);
            this.Txt_NomeCidade.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.Btn_IncluirImagem);
            this.groupBox2.Controls.Add(this.Btn_ApagarImagem);
            this.groupBox2.Controls.Add(this.Pcb_ImagemCidade);
            this.groupBox2.Controls.Add(this.Btn_GerarDescricao);
            this.groupBox2.Controls.Add(this.Txt_descricao);
            this.groupBox2.Location = new System.Drawing.Point(13, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1288, 403);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            // 
            // Btn_IncluirImagem
            // 
            this.Btn_IncluirImagem.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_IncluirImagem.ForeColor = System.Drawing.Color.Black;
            this.Btn_IncluirImagem.Location = new System.Drawing.Point(1180, 359);
            this.Btn_IncluirImagem.Name = "Btn_IncluirImagem";
            this.Btn_IncluirImagem.Size = new System.Drawing.Size(102, 29);
            this.Btn_IncluirImagem.TabIndex = 16;
            this.Btn_IncluirImagem.Text = "Alterar imagem";
            this.Btn_IncluirImagem.UseVisualStyleBackColor = true;
            this.Btn_IncluirImagem.Click += new System.EventHandler(this.Btn_IncluirImagem_Click);
            // 
            // Btn_ApagarImagem
            // 
            this.Btn_ApagarImagem.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ApagarImagem.ForeColor = System.Drawing.Color.Black;
            this.Btn_ApagarImagem.Image = global::Master_Shield_System.Properties.Resources.excluir1;
            this.Btn_ApagarImagem.Location = new System.Drawing.Point(1130, 359);
            this.Btn_ApagarImagem.Name = "Btn_ApagarImagem";
            this.Btn_ApagarImagem.Size = new System.Drawing.Size(44, 29);
            this.Btn_ApagarImagem.TabIndex = 15;
            this.Btn_ApagarImagem.UseVisualStyleBackColor = true;
            this.Btn_ApagarImagem.Click += new System.EventHandler(this.Btn_ApagarImagem_Click);
            // 
            // Pcb_ImagemCidade
            // 
            this.Pcb_ImagemCidade.Location = new System.Drawing.Point(630, 39);
            this.Pcb_ImagemCidade.Name = "Pcb_ImagemCidade";
            this.Pcb_ImagemCidade.Size = new System.Drawing.Size(652, 314);
            this.Pcb_ImagemCidade.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pcb_ImagemCidade.TabIndex = 14;
            this.Pcb_ImagemCidade.TabStop = false;
            // 
            // Btn_GerarDescricao
            // 
            this.Btn_GerarDescricao.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_GerarDescricao.ForeColor = System.Drawing.Color.Black;
            this.Btn_GerarDescricao.Location = new System.Drawing.Point(511, 359);
            this.Btn_GerarDescricao.Name = "Btn_GerarDescricao";
            this.Btn_GerarDescricao.Size = new System.Drawing.Size(113, 29);
            this.Btn_GerarDescricao.TabIndex = 13;
            this.Btn_GerarDescricao.Text = "Gerar Descrição";
            this.Btn_GerarDescricao.UseVisualStyleBackColor = true;
            this.Btn_GerarDescricao.Click += new System.EventHandler(this.Btn_GerarDescricao_Click);
            // 
            // Txt_descricao
            // 
            this.Txt_descricao.Location = new System.Drawing.Point(10, 39);
            this.Txt_descricao.Name = "Txt_descricao";
            this.Txt_descricao.Size = new System.Drawing.Size(614, 314);
            this.Txt_descricao.TabIndex = 0;
            this.Txt_descricao.Text = "";
            // 
            // Btn_Limpar
            // 
            this.Btn_Limpar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Limpar.ForeColor = System.Drawing.Color.Black;
            this.Btn_Limpar.Location = new System.Drawing.Point(1113, 570);
            this.Btn_Limpar.Name = "Btn_Limpar";
            this.Btn_Limpar.Size = new System.Drawing.Size(91, 29);
            this.Btn_Limpar.TabIndex = 25;
            this.Btn_Limpar.Text = "Limpar";
            this.Btn_Limpar.UseVisualStyleBackColor = true;
            this.Btn_Limpar.Click += new System.EventHandler(this.Btn_Limpar_Click);
            // 
            // Btn_Atualizar
            // 
            this.Btn_Atualizar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Atualizar.ForeColor = System.Drawing.Color.Black;
            this.Btn_Atualizar.Location = new System.Drawing.Point(1210, 570);
            this.Btn_Atualizar.Name = "Btn_Atualizar";
            this.Btn_Atualizar.Size = new System.Drawing.Size(91, 29);
            this.Btn_Atualizar.TabIndex = 24;
            this.Btn_Atualizar.Text = "Atualizar";
            this.Btn_Atualizar.UseVisualStyleBackColor = true;
            this.Btn_Atualizar.Click += new System.EventHandler(this.Btn_Atualizar_Click);
            // 
            // Btn_Retornar
            // 
            this.Btn_Retornar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Retornar.ForeColor = System.Drawing.Color.Black;
            this.Btn_Retornar.Location = new System.Drawing.Point(13, 570);
            this.Btn_Retornar.Name = "Btn_Retornar";
            this.Btn_Retornar.Size = new System.Drawing.Size(91, 29);
            this.Btn_Retornar.TabIndex = 23;
            this.Btn_Retornar.Text = "Retornar";
            this.Btn_Retornar.UseVisualStyleBackColor = true;
            this.Btn_Retornar.Click += new System.EventHandler(this.Btn_Retornar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Descrição";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(630, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Imagem da Cidade";
            // 
            // CityDataUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Btn_Limpar);
            this.Controls.Add(this.Btn_Atualizar);
            this.Controls.Add(this.Btn_Retornar);
            this.Name = "CityDataUpdate";
            this.Size = new System.Drawing.Size(1336, 641);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pcb_ImagemCidade)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox Cbb_Bioma;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_NomeCidade;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Btn_IncluirImagem;
        private System.Windows.Forms.Button Btn_ApagarImagem;
        private System.Windows.Forms.PictureBox Pcb_ImagemCidade;
        private System.Windows.Forms.Button Btn_GerarDescricao;
        private System.Windows.Forms.RichTextBox Txt_descricao;
        private System.Windows.Forms.Button Btn_Limpar;
        private System.Windows.Forms.Button Btn_Atualizar;
        private System.Windows.Forms.Button Btn_Retornar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
