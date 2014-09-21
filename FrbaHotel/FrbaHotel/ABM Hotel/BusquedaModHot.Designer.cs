namespace FrbaHotel.ABM_Hotel
{
    partial class BusquedaModHot
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ciudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buscar = new System.Windows.Forms.Button();
            this.lab = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxpa = new System.Windows.Forms.TextBox();
            this.textBoxciu = new System.Windows.Forms.TextBox();
            this.textBoxcat = new System.Windows.Forms.TextBox();
            this.textBoxnomb = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Categoria,
            this.Pais,
            this.Ciudad});
            this.dataGridView1.Location = new System.Drawing.Point(14, 118);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(361, 150);
            this.dataGridView1.TabIndex = 36;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            // 
            // Pais
            // 
            this.Pais.HeaderText = "Pais";
            this.Pais.Name = "Pais";
            // 
            // Ciudad
            // 
            this.Ciudad.HeaderText = "Ciudad";
            this.Ciudad.Name = "Ciudad";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(221, 283);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 35;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(83, 283);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(142, 73);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(75, 23);
            this.buscar.TabIndex = 33;
            this.buscar.Text = "Buscar";
            this.buscar.UseVisualStyleBackColor = true;
            // 
            // lab
            // 
            this.lab.AutoSize = true;
            this.lab.Location = new System.Drawing.Point(190, 41);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(27, 13);
            this.lab.TabIndex = 32;
            this.lab.Text = "Pais";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Ciudad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Categoria";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Nombre";
            // 
            // textBoxpa
            // 
            this.textBoxpa.Location = new System.Drawing.Point(257, 38);
            this.textBoxpa.Name = "textBoxpa";
            this.textBoxpa.Size = new System.Drawing.Size(100, 20);
            this.textBoxpa.TabIndex = 28;
            this.textBoxpa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxpa_KeyPress);
            // 
            // textBoxciu
            // 
            this.textBoxciu.Location = new System.Drawing.Point(257, 12);
            this.textBoxciu.Name = "textBoxciu";
            this.textBoxciu.Size = new System.Drawing.Size(100, 20);
            this.textBoxciu.TabIndex = 27;
            this.textBoxciu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxciu_KeyPress);
            // 
            // textBoxcat
            // 
            this.textBoxcat.Location = new System.Drawing.Point(83, 38);
            this.textBoxcat.Name = "textBoxcat";
            this.textBoxcat.Size = new System.Drawing.Size(100, 20);
            this.textBoxcat.TabIndex = 26;
            this.textBoxcat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxcat_KeyPress);
            // 
            // textBoxnomb
            // 
            this.textBoxnomb.Location = new System.Drawing.Point(83, 12);
            this.textBoxnomb.Name = "textBoxnomb";
            this.textBoxnomb.Size = new System.Drawing.Size(100, 20);
            this.textBoxnomb.TabIndex = 25;
            this.textBoxnomb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxnomb_KeyPress);
            // 
            // BusquedaModHot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(402, 333);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buscar);
            this.Controls.Add(this.lab);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxpa);
            this.Controls.Add(this.textBoxciu);
            this.Controls.Add(this.textBoxcat);
            this.Controls.Add(this.textBoxnomb);
            this.Name = "BusquedaModHot";
            this.Text = "Busqueda Hotel";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pais;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ciudad;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.Label lab;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxpa;
        private System.Windows.Forms.TextBox textBoxciu;
        private System.Windows.Forms.TextBox textBoxcat;
        private System.Windows.Forms.TextBox textBoxnomb;
    }
}