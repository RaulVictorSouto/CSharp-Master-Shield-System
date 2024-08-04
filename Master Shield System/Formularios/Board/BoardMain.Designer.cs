﻿namespace Master_Shield_System.Formularios.Board
{
    partial class BoardMain
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
            this.Txt_Pesquisa = new System.Windows.Forms.TextBox();
            this.Btn_Pesquisar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Cbb_BoardFilter = new System.Windows.Forms.ComboBox();
            this.Btn_Incluir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Dgv_Board = new System.Windows.Forms.DataGridView();
            this.editar = new System.Windows.Forms.DataGridViewImageColumn();
            this.excluir = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Board)).BeginInit();
            this.SuspendLayout();
            // 
            // Txt_Pesquisa
            // 
            this.Txt_Pesquisa.Location = new System.Drawing.Point(25, 14);
            this.Txt_Pesquisa.Name = "Txt_Pesquisa";
            this.Txt_Pesquisa.Size = new System.Drawing.Size(393, 20);
            this.Txt_Pesquisa.TabIndex = 0;
            // 
            // Btn_Pesquisar
            // 
            this.Btn_Pesquisar.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Pesquisar.ForeColor = System.Drawing.Color.Black;
            this.Btn_Pesquisar.Location = new System.Drawing.Point(424, 11);
            this.Btn_Pesquisar.Name = "Btn_Pesquisar";
            this.Btn_Pesquisar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Pesquisar.TabIndex = 1;
            this.Btn_Pesquisar.Text = "Pesquisar";
            this.Btn_Pesquisar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Filtro:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Cbb_BoardFilter
            // 
            this.Cbb_BoardFilter.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cbb_BoardFilter.FormattingEnabled = true;
            this.Cbb_BoardFilter.Items.AddRange(new object[] {
            "Campanha",
            "Mestre"});
            this.Cbb_BoardFilter.Location = new System.Drawing.Point(73, 59);
            this.Cbb_BoardFilter.Name = "Cbb_BoardFilter";
            this.Cbb_BoardFilter.Size = new System.Drawing.Size(345, 24);
            this.Cbb_BoardFilter.TabIndex = 4;
            this.Cbb_BoardFilter.Text = "Campanha";
            // 
            // Btn_Incluir
            // 
            this.Btn_Incluir.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Incluir.ForeColor = System.Drawing.Color.Black;
            this.Btn_Incluir.Location = new System.Drawing.Point(386, 566);
            this.Btn_Incluir.Name = "Btn_Incluir";
            this.Btn_Incluir.Size = new System.Drawing.Size(113, 23);
            this.Btn_Incluir.TabIndex = 5;
            this.Btn_Incluir.Text = "Incluir Campanha";
            this.Btn_Incluir.UseVisualStyleBackColor = true;
            this.Btn_Incluir.Click += new System.EventHandler(this.Btn_Incluir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(505, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(568, 455);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // Dgv_Board
            // 
            this.Dgv_Board.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Board.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.editar,
            this.excluir});
            this.Dgv_Board.Location = new System.Drawing.Point(25, 104);
            this.Dgv_Board.Name = "Dgv_Board";
            this.Dgv_Board.Size = new System.Drawing.Size(474, 456);
            this.Dgv_Board.TabIndex = 2;
            this.Dgv_Board.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // editar
            // 
            this.editar.HeaderText = "";
            this.editar.Image = global::Master_Shield_System.Properties.Resources.editar1;
            this.editar.Name = "editar";
            this.editar.ToolTipText = "Clique aqui para editar";
            // 
            // excluir
            // 
            this.excluir.HeaderText = "";
            this.excluir.Image = global::Master_Shield_System.Properties.Resources.excluir1;
            this.excluir.Name = "excluir";
            this.excluir.ToolTipText = "Clique aqui para excluir";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::Master_Shield_System.Properties.Resources.editar1;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ToolTipText = "Clique aqui para editar";
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::Master_Shield_System.Properties.Resources.excluir1;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ToolTipText = "Clique aqui para excluir";
            // 
            // BoardMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_Incluir);
            this.Controls.Add(this.Cbb_BoardFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Dgv_Board);
            this.Controls.Add(this.Btn_Pesquisar);
            this.Controls.Add(this.Txt_Pesquisa);
            this.Name = "BoardMain";
            this.Size = new System.Drawing.Size(1120, 641);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Board)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txt_Pesquisa;
        private System.Windows.Forms.Button Btn_Pesquisar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Cbb_BoardFilter;
        private System.Windows.Forms.Button Btn_Incluir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn excluir;
        private System.Windows.Forms.DataGridViewImageColumn editar;
        private System.Windows.Forms.DataGridView Dgv_Board;
    }
}
