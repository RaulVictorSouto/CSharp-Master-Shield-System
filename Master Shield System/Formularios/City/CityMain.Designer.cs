namespace Master_Shield_System.Formularios.City
{
    partial class CityMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Txt_Descricao = new System.Windows.Forms.RichTextBox();
            this.Pcb_City = new System.Windows.Forms.PictureBox();
            this.Btn_Incluir = new System.Windows.Forms.Button();
            this.Cbb_Operadores = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Pesquisar = new System.Windows.Forms.Button();
            this.Txt_pesquisa = new System.Windows.Forms.TextBox();
            this.Dgv_City = new System.Windows.Forms.DataGridView();
            this.editar = new System.Windows.Forms.DataGridViewImageColumn();
            this.excluir = new System.Windows.Forms.DataGridViewImageColumn();
            this.Cbb_CityFilter = new System.Windows.Forms.ComboBox();
            this.Btn_Selecionar = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pcb_City)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_City)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Txt_Descricao);
            this.groupBox1.Controls.Add(this.Pcb_City);
            this.groupBox1.Location = new System.Drawing.Point(739, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(553, 455);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // Txt_Descricao
            // 
            this.Txt_Descricao.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Descricao.Location = new System.Drawing.Point(6, 19);
            this.Txt_Descricao.Name = "Txt_Descricao";
            this.Txt_Descricao.ReadOnly = true;
            this.Txt_Descricao.Size = new System.Drawing.Size(538, 156);
            this.Txt_Descricao.TabIndex = 4;
            this.Txt_Descricao.Text = "";
            // 
            // Pcb_City
            // 
            this.Pcb_City.Location = new System.Drawing.Point(6, 181);
            this.Pcb_City.Name = "Pcb_City";
            this.Pcb_City.Size = new System.Drawing.Size(538, 268);
            this.Pcb_City.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pcb_City.TabIndex = 3;
            this.Pcb_City.TabStop = false;
            // 
            // Btn_Incluir
            // 
            this.Btn_Incluir.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Incluir.ForeColor = System.Drawing.Color.Black;
            this.Btn_Incluir.Location = new System.Drawing.Point(620, 564);
            this.Btn_Incluir.Name = "Btn_Incluir";
            this.Btn_Incluir.Size = new System.Drawing.Size(113, 23);
            this.Btn_Incluir.TabIndex = 12;
            this.Btn_Incluir.Text = "Incluir Cidade";
            this.Btn_Incluir.UseVisualStyleBackColor = true;
            this.Btn_Incluir.Click += new System.EventHandler(this.Btn_Incluir_Click);
            // 
            // Cbb_Operadores
            // 
            this.Cbb_Operadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbb_Operadores.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cbb_Operadores.FormattingEnabled = true;
            this.Cbb_Operadores.Items.AddRange(new object[] {
            "Igual a",
            "Maior do que",
            "Menor do que",
            "Maior ou igual a",
            "Menor ou igual a",
            "Diferente de"});
            this.Cbb_Operadores.Location = new System.Drawing.Point(79, 55);
            this.Cbb_Operadores.Name = "Cbb_Operadores";
            this.Cbb_Operadores.Size = new System.Drawing.Size(134, 24);
            this.Cbb_Operadores.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Filtros:";
            // 
            // Btn_Pesquisar
            // 
            this.Btn_Pesquisar.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Pesquisar.ForeColor = System.Drawing.Color.Black;
            this.Btn_Pesquisar.Location = new System.Drawing.Point(423, 9);
            this.Btn_Pesquisar.Name = "Btn_Pesquisar";
            this.Btn_Pesquisar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Pesquisar.TabIndex = 8;
            this.Btn_Pesquisar.Text = "Pesquisar";
            this.Btn_Pesquisar.UseVisualStyleBackColor = true;
            this.Btn_Pesquisar.Click += new System.EventHandler(this.Btn_Pesquisar_Click);
            // 
            // Txt_pesquisa
            // 
            this.Txt_pesquisa.Location = new System.Drawing.Point(24, 12);
            this.Txt_pesquisa.Name = "Txt_pesquisa";
            this.Txt_pesquisa.Size = new System.Drawing.Size(393, 20);
            this.Txt_pesquisa.TabIndex = 7;
            // 
            // Dgv_City
            // 
            this.Dgv_City.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.Dgv_City.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv_City.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Noto Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_City.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Dgv_City.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_City.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.editar,
            this.excluir});
            this.Dgv_City.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Dgv_City.Location = new System.Drawing.Point(24, 101);
            this.Dgv_City.Name = "Dgv_City";
            this.Dgv_City.Size = new System.Drawing.Size(709, 456);
            this.Dgv_City.TabIndex = 9;
            this.Dgv_City.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_City_CellClick_1);
            this.Dgv_City.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_City_CellContentClick);
            // 
            // editar
            // 
            this.editar.HeaderText = "";
            this.editar.Image = global::Master_Shield_System.Properties.Resources.editar1;
            this.editar.Name = "editar";
            this.editar.ToolTipText = "Clique aqui para editar";
            this.editar.Width = 25;
            // 
            // excluir
            // 
            this.excluir.HeaderText = "";
            this.excluir.Image = global::Master_Shield_System.Properties.Resources.excluir1;
            this.excluir.Name = "excluir";
            this.excluir.ToolTipText = "Clique aqui para excluir";
            this.excluir.Width = 25;
            // 
            // Cbb_CityFilter
            // 
            this.Cbb_CityFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbb_CityFilter.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cbb_CityFilter.FormattingEnabled = true;
            this.Cbb_CityFilter.Items.AddRange(new object[] {
            "Cidade",
            "Bioma",
            "População"});
            this.Cbb_CityFilter.Location = new System.Drawing.Point(219, 55);
            this.Cbb_CityFilter.Name = "Cbb_CityFilter";
            this.Cbb_CityFilter.Size = new System.Drawing.Size(198, 24);
            this.Cbb_CityFilter.TabIndex = 14;
            // 
            // Btn_Selecionar
            // 
            this.Btn_Selecionar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Selecionar.ForeColor = System.Drawing.Color.Black;
            this.Btn_Selecionar.Location = new System.Drawing.Point(1208, 564);
            this.Btn_Selecionar.Name = "Btn_Selecionar";
            this.Btn_Selecionar.Size = new System.Drawing.Size(84, 23);
            this.Btn_Selecionar.TabIndex = 15;
            this.Btn_Selecionar.Text = "Selecionar";
            this.Btn_Selecionar.UseVisualStyleBackColor = true;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::Master_Shield_System.Properties.Resources.editar1;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ToolTipText = "Clique aqui para editar";
            this.dataGridViewImageColumn1.Width = 25;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::Master_Shield_System.Properties.Resources.excluir1;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ToolTipText = "Clique aqui para excluir";
            this.dataGridViewImageColumn2.Width = 25;
            // 
            // CityMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Btn_Selecionar);
            this.Controls.Add(this.Cbb_CityFilter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_Incluir);
            this.Controls.Add(this.Cbb_Operadores);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_Pesquisar);
            this.Controls.Add(this.Txt_pesquisa);
            this.Controls.Add(this.Dgv_City);
            this.Name = "CityMain";
            this.Size = new System.Drawing.Size(1336, 641);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Pcb_City)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_City)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox Pcb_City;
        private System.Windows.Forms.Button Btn_Incluir;
        private System.Windows.Forms.ComboBox Cbb_Operadores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Pesquisar;
        private System.Windows.Forms.TextBox Txt_pesquisa;
        private System.Windows.Forms.DataGridView Dgv_City;
        private System.Windows.Forms.DataGridViewImageColumn editar;
        private System.Windows.Forms.DataGridViewImageColumn excluir;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.ComboBox Cbb_CityFilter;
        private System.Windows.Forms.RichTextBox Txt_Descricao;
        private System.Windows.Forms.Button Btn_Selecionar;
    }
}
