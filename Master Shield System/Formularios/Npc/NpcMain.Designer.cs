namespace Master_Shield_System.Formularios.Npc
{
    partial class NpcMain
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
            this.Cbb_CityFilter = new System.Windows.Forms.ComboBox();
            this.Cbb_Operadores = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Pesquisar = new System.Windows.Forms.Button();
            this.Txt_pesquisa = new System.Windows.Forms.TextBox();
            this.Dgv_Npc = new System.Windows.Forms.DataGridView();
            this.editar = new System.Windows.Forms.DataGridViewImageColumn();
            this.excluir = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Lbl_Sorte = new System.Windows.Forms.Label();
            this.Lbl_Carisma = new System.Windows.Forms.Label();
            this.Lbl_Inteligencia = new System.Windows.Forms.Label();
            this.Lbl_Velocidade = new System.Windows.Forms.Label();
            this.Lbl_Forca = new System.Windows.Forms.Label();
            this.Lbl_Energia = new System.Windows.Forms.Label();
            this.Lbl_Hp = new System.Windows.Forms.Label();
            this.Lbl_Nivel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Lbl_Status = new System.Windows.Forms.Label();
            this.Lbl_Genero = new System.Windows.Forms.Label();
            this.Lbl_Classe = new System.Windows.Forms.Label();
            this.Lbl_Raca = new System.Windows.Forms.Label();
            this.Lbl_Nome = new System.Windows.Forms.Label();
            this.Pcb_Imagem = new System.Windows.Forms.PictureBox();
            this.Txt_Descricao = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.Btn_Retornar = new System.Windows.Forms.Button();
            this.Btn_Incluir = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.Lbl_Alinhamento = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Npc)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pcb_Imagem)).BeginInit();
            this.SuspendLayout();
            // 
            // Cbb_CityFilter
            // 
            this.Cbb_CityFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbb_CityFilter.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cbb_CityFilter.FormattingEnabled = true;
            this.Cbb_CityFilter.Items.AddRange(new object[] {
            "Nome",
            "Nível",
            "Raça",
            "Classe",
            "Gênero",
            "HP",
            "Energia",
            "Força",
            "Velocidade",
            "Inteligência",
            "Carisma",
            "Sorte",
            "Morto",
            "Vivo"});
            this.Cbb_CityFilter.Location = new System.Drawing.Point(219, 39);
            this.Cbb_CityFilter.Name = "Cbb_CityFilter";
            this.Cbb_CityFilter.Size = new System.Drawing.Size(198, 24);
            this.Cbb_CityFilter.TabIndex = 19;
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
            this.Cbb_Operadores.Location = new System.Drawing.Point(79, 39);
            this.Cbb_Operadores.Name = "Cbb_Operadores";
            this.Cbb_Operadores.Size = new System.Drawing.Size(134, 24);
            this.Cbb_Operadores.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Filtros:";
            // 
            // Btn_Pesquisar
            // 
            this.Btn_Pesquisar.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Pesquisar.ForeColor = System.Drawing.Color.Black;
            this.Btn_Pesquisar.Location = new System.Drawing.Point(423, 10);
            this.Btn_Pesquisar.Name = "Btn_Pesquisar";
            this.Btn_Pesquisar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Pesquisar.TabIndex = 16;
            this.Btn_Pesquisar.Text = "Pesquisar";
            this.Btn_Pesquisar.UseVisualStyleBackColor = true;
            // 
            // Txt_pesquisa
            // 
            this.Txt_pesquisa.Location = new System.Drawing.Point(24, 13);
            this.Txt_pesquisa.Name = "Txt_pesquisa";
            this.Txt_pesquisa.Size = new System.Drawing.Size(393, 20);
            this.Txt_pesquisa.TabIndex = 15;
            // 
            // Dgv_Npc
            // 
            this.Dgv_Npc.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.Dgv_Npc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv_Npc.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Noto Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_Npc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Dgv_Npc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Npc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.editar,
            this.excluir});
            this.Dgv_Npc.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Dgv_Npc.Location = new System.Drawing.Point(24, 86);
            this.Dgv_Npc.Name = "Dgv_Npc";
            this.Dgv_Npc.Size = new System.Drawing.Size(1003, 276);
            this.Dgv_Npc.TabIndex = 20;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Lbl_Sorte);
            this.groupBox1.Controls.Add(this.Lbl_Carisma);
            this.groupBox1.Controls.Add(this.Lbl_Inteligencia);
            this.groupBox1.Controls.Add(this.Lbl_Velocidade);
            this.groupBox1.Controls.Add(this.Lbl_Forca);
            this.groupBox1.Controls.Add(this.Lbl_Energia);
            this.groupBox1.Controls.Add(this.Lbl_Hp);
            this.groupBox1.Controls.Add(this.Lbl_Nivel);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(1033, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 276);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // Lbl_Sorte
            // 
            this.Lbl_Sorte.AutoSize = true;
            this.Lbl_Sorte.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Sorte.Location = new System.Drawing.Point(125, 248);
            this.Lbl_Sorte.Name = "Lbl_Sorte";
            this.Lbl_Sorte.Size = new System.Drawing.Size(59, 18);
            this.Lbl_Sorte.TabIndex = 20;
            this.Lbl_Sorte.Text = "label14";
            this.Lbl_Sorte.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Lbl_Carisma
            // 
            this.Lbl_Carisma.AutoSize = true;
            this.Lbl_Carisma.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Carisma.Location = new System.Drawing.Point(125, 215);
            this.Lbl_Carisma.Name = "Lbl_Carisma";
            this.Lbl_Carisma.Size = new System.Drawing.Size(59, 18);
            this.Lbl_Carisma.TabIndex = 19;
            this.Lbl_Carisma.Text = "label14";
            this.Lbl_Carisma.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Lbl_Inteligencia
            // 
            this.Lbl_Inteligencia.AutoSize = true;
            this.Lbl_Inteligencia.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Inteligencia.Location = new System.Drawing.Point(125, 182);
            this.Lbl_Inteligencia.Name = "Lbl_Inteligencia";
            this.Lbl_Inteligencia.Size = new System.Drawing.Size(59, 18);
            this.Lbl_Inteligencia.TabIndex = 18;
            this.Lbl_Inteligencia.Text = "label14";
            this.Lbl_Inteligencia.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Lbl_Velocidade
            // 
            this.Lbl_Velocidade.AutoSize = true;
            this.Lbl_Velocidade.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Velocidade.Location = new System.Drawing.Point(125, 149);
            this.Lbl_Velocidade.Name = "Lbl_Velocidade";
            this.Lbl_Velocidade.Size = new System.Drawing.Size(59, 18);
            this.Lbl_Velocidade.TabIndex = 17;
            this.Lbl_Velocidade.Text = "label14";
            this.Lbl_Velocidade.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Lbl_Forca
            // 
            this.Lbl_Forca.AutoSize = true;
            this.Lbl_Forca.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Forca.Location = new System.Drawing.Point(125, 116);
            this.Lbl_Forca.Name = "Lbl_Forca";
            this.Lbl_Forca.Size = new System.Drawing.Size(59, 18);
            this.Lbl_Forca.TabIndex = 16;
            this.Lbl_Forca.Text = "label14";
            this.Lbl_Forca.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Lbl_Energia
            // 
            this.Lbl_Energia.AutoSize = true;
            this.Lbl_Energia.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Energia.Location = new System.Drawing.Point(125, 83);
            this.Lbl_Energia.Name = "Lbl_Energia";
            this.Lbl_Energia.Size = new System.Drawing.Size(59, 18);
            this.Lbl_Energia.TabIndex = 15;
            this.Lbl_Energia.Text = "label14";
            this.Lbl_Energia.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Lbl_Hp
            // 
            this.Lbl_Hp.AutoSize = true;
            this.Lbl_Hp.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Hp.Location = new System.Drawing.Point(125, 50);
            this.Lbl_Hp.Name = "Lbl_Hp";
            this.Lbl_Hp.Size = new System.Drawing.Size(59, 18);
            this.Lbl_Hp.TabIndex = 14;
            this.Lbl_Hp.Text = "label14";
            this.Lbl_Hp.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Lbl_Nivel
            // 
            this.Lbl_Nivel.AutoSize = true;
            this.Lbl_Nivel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Nivel.Location = new System.Drawing.Point(125, 17);
            this.Lbl_Nivel.Name = "Lbl_Nivel";
            this.Lbl_Nivel.Size = new System.Drawing.Size(59, 18);
            this.Lbl_Nivel.TabIndex = 13;
            this.Lbl_Nivel.Text = "label14";
            this.Lbl_Nivel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 247);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 19);
            this.label9.TabIndex = 7;
            this.label9.Text = "Sorte:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 214);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 19);
            this.label8.TabIndex = 6;
            this.label8.Text = "Carisma:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 19);
            this.label7.TabIndex = 5;
            this.label7.Text = "Inteligência:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 19);
            this.label6.TabIndex = 4;
            this.label6.Text = "Velocidade:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Força:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Energia:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "HP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nível:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Lbl_Alinhamento);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.Lbl_Status);
            this.groupBox2.Controls.Add(this.Lbl_Genero);
            this.groupBox2.Controls.Add(this.Lbl_Classe);
            this.groupBox2.Controls.Add(this.Lbl_Raca);
            this.groupBox2.Controls.Add(this.Lbl_Nome);
            this.groupBox2.Controls.Add(this.Pcb_Imagem);
            this.groupBox2.Controls.Add(this.Txt_Descricao);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label);
            this.groupBox2.Location = new System.Drawing.Point(24, 397);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1271, 226);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            // 
            // Lbl_Status
            // 
            this.Lbl_Status.AutoSize = true;
            this.Lbl_Status.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Status.Location = new System.Drawing.Point(755, 44);
            this.Lbl_Status.Name = "Lbl_Status";
            this.Lbl_Status.Size = new System.Drawing.Size(59, 18);
            this.Lbl_Status.TabIndex = 12;
            this.Lbl_Status.Text = "label14";
            // 
            // Lbl_Genero
            // 
            this.Lbl_Genero.AutoSize = true;
            this.Lbl_Genero.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Genero.Location = new System.Drawing.Point(531, 44);
            this.Lbl_Genero.Name = "Lbl_Genero";
            this.Lbl_Genero.Size = new System.Drawing.Size(59, 18);
            this.Lbl_Genero.TabIndex = 11;
            this.Lbl_Genero.Text = "label14";
            // 
            // Lbl_Classe
            // 
            this.Lbl_Classe.AutoSize = true;
            this.Lbl_Classe.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Classe.Location = new System.Drawing.Point(300, 44);
            this.Lbl_Classe.Name = "Lbl_Classe";
            this.Lbl_Classe.Size = new System.Drawing.Size(59, 18);
            this.Lbl_Classe.TabIndex = 10;
            this.Lbl_Classe.Text = "label14";
            // 
            // Lbl_Raca
            // 
            this.Lbl_Raca.AutoSize = true;
            this.Lbl_Raca.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Raca.Location = new System.Drawing.Point(79, 44);
            this.Lbl_Raca.Name = "Lbl_Raca";
            this.Lbl_Raca.Size = new System.Drawing.Size(59, 18);
            this.Lbl_Raca.TabIndex = 9;
            this.Lbl_Raca.Text = "label14";
            // 
            // Lbl_Nome
            // 
            this.Lbl_Nome.AutoSize = true;
            this.Lbl_Nome.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Nome.Location = new System.Drawing.Point(79, 16);
            this.Lbl_Nome.Name = "Lbl_Nome";
            this.Lbl_Nome.Size = new System.Drawing.Size(59, 18);
            this.Lbl_Nome.TabIndex = 8;
            this.Lbl_Nome.Text = "label14";
            // 
            // Pcb_Imagem
            // 
            this.Pcb_Imagem.Location = new System.Drawing.Point(1009, 16);
            this.Pcb_Imagem.Name = "Pcb_Imagem";
            this.Pcb_Imagem.Size = new System.Drawing.Size(256, 204);
            this.Pcb_Imagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pcb_Imagem.TabIndex = 7;
            this.Pcb_Imagem.TabStop = false;
            // 
            // Txt_Descricao
            // 
            this.Txt_Descricao.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Descricao.Location = new System.Drawing.Point(17, 66);
            this.Txt_Descricao.Name = "Txt_Descricao";
            this.Txt_Descricao.ReadOnly = true;
            this.Txt_Descricao.Size = new System.Drawing.Size(986, 156);
            this.Txt_Descricao.TabIndex = 6;
            this.Txt_Descricao.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(685, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 19);
            this.label13.TabIndex = 5;
            this.label13.Text = "Status:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(454, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 19);
            this.label12.TabIndex = 4;
            this.label12.Text = "Gênero:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(227, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 19);
            this.label11.TabIndex = 3;
            this.label11.Text = "Classe:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 19);
            this.label10.TabIndex = 2;
            this.label10.Text = "Raça:";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(13, 16);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(60, 19);
            this.label.TabIndex = 1;
            this.label.Text = "Nome:";
            // 
            // Btn_Retornar
            // 
            this.Btn_Retornar.ForeColor = System.Drawing.Color.Black;
            this.Btn_Retornar.Location = new System.Drawing.Point(24, 368);
            this.Btn_Retornar.Name = "Btn_Retornar";
            this.Btn_Retornar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Retornar.TabIndex = 0;
            this.Btn_Retornar.Text = "Retornar";
            this.Btn_Retornar.UseVisualStyleBackColor = true;
            // 
            // Btn_Incluir
            // 
            this.Btn_Incluir.ForeColor = System.Drawing.Color.Black;
            this.Btn_Incluir.Location = new System.Drawing.Point(933, 368);
            this.Btn_Incluir.Name = "Btn_Incluir";
            this.Btn_Incluir.Size = new System.Drawing.Size(94, 23);
            this.Btn_Incluir.TabIndex = 23;
            this.Btn_Incluir.Text = "Incluir NPC";
            this.Btn_Incluir.UseVisualStyleBackColor = true;
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
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(454, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 19);
            this.label14.TabIndex = 13;
            this.label14.Text = "Nome:";
            // 
            // Lbl_Alinhamento
            // 
            this.Lbl_Alinhamento.AutoSize = true;
            this.Lbl_Alinhamento.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Alinhamento.Location = new System.Drawing.Point(531, 16);
            this.Lbl_Alinhamento.Name = "Lbl_Alinhamento";
            this.Lbl_Alinhamento.Size = new System.Drawing.Size(59, 18);
            this.Lbl_Alinhamento.TabIndex = 14;
            this.Lbl_Alinhamento.Text = "label14";
            // 
            // NpcMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Btn_Incluir);
            this.Controls.Add(this.Btn_Retornar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Dgv_Npc);
            this.Controls.Add(this.Cbb_CityFilter);
            this.Controls.Add(this.Cbb_Operadores);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_Pesquisar);
            this.Controls.Add(this.Txt_pesquisa);
            this.Name = "NpcMain";
            this.Size = new System.Drawing.Size(1336, 641);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Npc)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pcb_Imagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Cbb_CityFilter;
        private System.Windows.Forms.ComboBox Cbb_Operadores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Pesquisar;
        private System.Windows.Forms.TextBox Txt_pesquisa;
        private System.Windows.Forms.DataGridView Dgv_Npc;
        private System.Windows.Forms.DataGridViewImageColumn editar;
        private System.Windows.Forms.DataGridViewImageColumn excluir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Btn_Retornar;
        private System.Windows.Forms.Button Btn_Incluir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.PictureBox Pcb_Imagem;
        private System.Windows.Forms.RichTextBox Txt_Descricao;
        private System.Windows.Forms.Label Lbl_Nome;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.Label Lbl_Sorte;
        private System.Windows.Forms.Label Lbl_Carisma;
        private System.Windows.Forms.Label Lbl_Inteligencia;
        private System.Windows.Forms.Label Lbl_Velocidade;
        private System.Windows.Forms.Label Lbl_Forca;
        private System.Windows.Forms.Label Lbl_Energia;
        private System.Windows.Forms.Label Lbl_Hp;
        private System.Windows.Forms.Label Lbl_Nivel;
        private System.Windows.Forms.Label Lbl_Status;
        private System.Windows.Forms.Label Lbl_Genero;
        private System.Windows.Forms.Label Lbl_Classe;
        private System.Windows.Forms.Label Lbl_Raca;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label Lbl_Alinhamento;
    }
}
