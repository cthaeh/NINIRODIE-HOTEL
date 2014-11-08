namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class BuscarCliente
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
            this.mailLabel = new System.Windows.Forms.Label();
            this.NumeroLabel = new System.Windows.Forms.Label();
            this.mailTextBox = new System.Windows.Forms.TextBox();
            this.NumeroTextBox = new System.Windows.Forms.TextBox();
            this.tipoIdComboBox = new System.Windows.Forms.ComboBox();
            this.tipoDocumentoLabel = new System.Windows.Forms.Label();
            this.filtroDeBusquedaGroupBox = new System.Windows.Forms.GroupBox();
            this.BuscarBoton = new System.Windows.Forms.Button();
            this.AceptarBoton = new System.Windows.Forms.Button();
            this.clienteDataGridView = new System.Windows.Forms.DataGridView();
            this.CancelarBoton = new System.Windows.Forms.Button();
            this.filtroDeBusquedaGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clienteDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mailLabel
            // 
            this.mailLabel.AutoSize = true;
            this.mailLabel.Location = new System.Drawing.Point(8, 61);
            this.mailLabel.Name = "mailLabel";
            this.mailLabel.Size = new System.Drawing.Size(26, 13);
            this.mailLabel.TabIndex = 23;
            this.mailLabel.Text = "Mail";
            // 
            // NumeroLabel
            // 
            this.NumeroLabel.AutoSize = true;
            this.NumeroLabel.Location = new System.Drawing.Point(217, 24);
            this.NumeroLabel.Name = "NumeroLabel";
            this.NumeroLabel.Size = new System.Drawing.Size(44, 13);
            this.NumeroLabel.TabIndex = 22;
            this.NumeroLabel.Text = "Número";
            // 
            // mailTextBox
            // 
            this.mailTextBox.Location = new System.Drawing.Point(40, 58);
            this.mailTextBox.Name = "mailTextBox";
            this.mailTextBox.Size = new System.Drawing.Size(389, 20);
            this.mailTextBox.TabIndex = 21;
            // 
            // NumeroTextBox
            // 
            this.NumeroTextBox.Location = new System.Drawing.Point(272, 19);
            this.NumeroTextBox.Name = "NumeroTextBox";
            this.NumeroTextBox.Size = new System.Drawing.Size(157, 20);
            this.NumeroTextBox.TabIndex = 20;
            // 
            // tipoIdComboBox
            // 
            this.tipoIdComboBox.FormattingEnabled = true;
            this.tipoIdComboBox.Location = new System.Drawing.Point(95, 18);
            this.tipoIdComboBox.Name = "tipoIdComboBox";
            this.tipoIdComboBox.Size = new System.Drawing.Size(116, 21);
            this.tipoIdComboBox.TabIndex = 24;
            // 
            // tipoDocumentoLabel
            // 
            this.tipoDocumentoLabel.AutoSize = true;
            this.tipoDocumentoLabel.Location = new System.Drawing.Point(7, 23);
            this.tipoDocumentoLabel.Name = "tipoDocumentoLabel";
            this.tipoDocumentoLabel.Size = new System.Drawing.Size(86, 13);
            this.tipoDocumentoLabel.TabIndex = 25;
            this.tipoDocumentoLabel.Text = "Tipo Documento";
            // 
            // filtroDeBusquedaGroupBox
            // 
            this.filtroDeBusquedaGroupBox.Controls.Add(this.tipoDocumentoLabel);
            this.filtroDeBusquedaGroupBox.Controls.Add(this.tipoIdComboBox);
            this.filtroDeBusquedaGroupBox.Controls.Add(this.mailLabel);
            this.filtroDeBusquedaGroupBox.Controls.Add(this.NumeroLabel);
            this.filtroDeBusquedaGroupBox.Controls.Add(this.mailTextBox);
            this.filtroDeBusquedaGroupBox.Controls.Add(this.NumeroTextBox);
            this.filtroDeBusquedaGroupBox.Location = new System.Drawing.Point(4, 8);
            this.filtroDeBusquedaGroupBox.Name = "filtroDeBusquedaGroupBox";
            this.filtroDeBusquedaGroupBox.Size = new System.Drawing.Size(436, 92);
            this.filtroDeBusquedaGroupBox.TabIndex = 26;
            this.filtroDeBusquedaGroupBox.TabStop = false;
            this.filtroDeBusquedaGroupBox.Text = "Filtro de Búsqueda";
            // 
            // BuscarBoton
            // 
            this.BuscarBoton.Location = new System.Drawing.Point(180, 112);
            this.BuscarBoton.Name = "BuscarBoton";
            this.BuscarBoton.Size = new System.Drawing.Size(85, 30);
            this.BuscarBoton.TabIndex = 27;
            this.BuscarBoton.Text = "Buscar";
            this.BuscarBoton.UseVisualStyleBackColor = true;
            this.BuscarBoton.Click += new System.EventHandler(this.BuscarBoton_Click);
            // 
            // AceptarBoton
            // 
            this.AceptarBoton.Location = new System.Drawing.Point(115, 242);
            this.AceptarBoton.Name = "AceptarBoton";
            this.AceptarBoton.Size = new System.Drawing.Size(85, 30);
            this.AceptarBoton.TabIndex = 28;
            this.AceptarBoton.Text = "Aceptar";
            this.AceptarBoton.UseVisualStyleBackColor = true;
            this.AceptarBoton.Click += new System.EventHandler(this.AceptarBoton_Click);
            // 
            // clienteDataGridView
            // 
            this.clienteDataGridView.AllowUserToAddRows = false;
            this.clienteDataGridView.AllowUserToDeleteRows = false;
            this.clienteDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.clienteDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.clienteDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clienteDataGridView.Location = new System.Drawing.Point(4, 144);
            this.clienteDataGridView.MultiSelect = false;
            this.clienteDataGridView.Name = "clienteDataGridView";
            this.clienteDataGridView.ReadOnly = true;
            this.clienteDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.clienteDataGridView.Size = new System.Drawing.Size(436, 90);
            this.clienteDataGridView.TabIndex = 29;
            // 
            // CancelarBoton
            // 
            this.CancelarBoton.Location = new System.Drawing.Point(244, 242);
            this.CancelarBoton.Name = "CancelarBoton";
            this.CancelarBoton.Size = new System.Drawing.Size(85, 30);
            this.CancelarBoton.TabIndex = 30;
            this.CancelarBoton.Text = "Cancelar";
            this.CancelarBoton.UseVisualStyleBackColor = true;
            this.CancelarBoton.Click += new System.EventHandler(this.CancelarBoton_Click);
            // 
            // BuscarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(445, 283);
            this.Controls.Add(this.CancelarBoton);
            this.Controls.Add(this.clienteDataGridView);
            this.Controls.Add(this.AceptarBoton);
            this.Controls.Add(this.BuscarBoton);
            this.Controls.Add(this.filtroDeBusquedaGroupBox);
            this.Name = "BuscarCliente";
            this.Text = "BuscarCliente";
            this.filtroDeBusquedaGroupBox.ResumeLayout(false);
            this.filtroDeBusquedaGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clienteDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label mailLabel;
        private System.Windows.Forms.Label NumeroLabel;
        private System.Windows.Forms.TextBox mailTextBox;
        private System.Windows.Forms.TextBox NumeroTextBox;
        private System.Windows.Forms.ComboBox tipoIdComboBox;
        private System.Windows.Forms.Label tipoDocumentoLabel;
        private System.Windows.Forms.GroupBox filtroDeBusquedaGroupBox;
        private System.Windows.Forms.Button BuscarBoton;
        private System.Windows.Forms.Button AceptarBoton;
        private System.Windows.Forms.DataGridView clienteDataGridView;
        private System.Windows.Forms.Button CancelarBoton;
    }
}