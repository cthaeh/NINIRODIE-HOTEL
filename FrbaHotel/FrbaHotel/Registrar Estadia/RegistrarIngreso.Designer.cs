namespace FrbaHotel.Registrar_Estadia
{
    partial class RegistrarIngreso
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
            this.BuscarClienteBoton = new System.Windows.Forms.Button();
            this.NuevoClienteBoton = new System.Windows.Forms.Button();
            this.RegistrarIngresoBoton = new System.Windows.Forms.Button();
            this.HabitacionesDataGrid = new System.Windows.Forms.DataGridView();
            this.ReservaDataGrid = new System.Windows.Forms.DataGridView();
            this.ReservaGroupBox = new System.Windows.Forms.GroupBox();
            this.HabitacionesGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.HabitacionesDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReservaDataGrid)).BeginInit();
            this.ReservaGroupBox.SuspendLayout();
            this.HabitacionesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // BuscarClienteBoton
            // 
            this.BuscarClienteBoton.Location = new System.Drawing.Point(229, 280);
            this.BuscarClienteBoton.Name = "BuscarClienteBoton";
            this.BuscarClienteBoton.Size = new System.Drawing.Size(101, 30);
            this.BuscarClienteBoton.TabIndex = 34;
            this.BuscarClienteBoton.Text = "Buscar Cliente";
            this.BuscarClienteBoton.UseVisualStyleBackColor = true;
            this.BuscarClienteBoton.Click += new System.EventHandler(this.BuscarClienteBoton_Click);
            // 
            // NuevoClienteBoton
            // 
            this.NuevoClienteBoton.Location = new System.Drawing.Point(336, 280);
            this.NuevoClienteBoton.Name = "NuevoClienteBoton";
            this.NuevoClienteBoton.Size = new System.Drawing.Size(101, 30);
            this.NuevoClienteBoton.TabIndex = 33;
            this.NuevoClienteBoton.Text = "Nuevo Cliente";
            this.NuevoClienteBoton.UseVisualStyleBackColor = true;
            this.NuevoClienteBoton.Click += new System.EventHandler(this.NuevoClienteBoton_Click);
            // 
            // RegistrarIngresoBoton
            // 
            this.RegistrarIngresoBoton.Location = new System.Drawing.Point(122, 280);
            this.RegistrarIngresoBoton.Name = "RegistrarIngresoBoton";
            this.RegistrarIngresoBoton.Size = new System.Drawing.Size(101, 30);
            this.RegistrarIngresoBoton.TabIndex = 35;
            this.RegistrarIngresoBoton.Text = "Registrar Ingreso";
            this.RegistrarIngresoBoton.UseVisualStyleBackColor = true;
            this.RegistrarIngresoBoton.Click += new System.EventHandler(this.RegistrarIngresoBoton_Click);
            // 
            // HabitacionesDataGrid
            // 
            this.HabitacionesDataGrid.AllowUserToAddRows = false;
            this.HabitacionesDataGrid.AllowUserToDeleteRows = false;
            this.HabitacionesDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.HabitacionesDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.HabitacionesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HabitacionesDataGrid.Location = new System.Drawing.Point(5, 18);
            this.HabitacionesDataGrid.Name = "HabitacionesDataGrid";
            this.HabitacionesDataGrid.ReadOnly = true;
            this.HabitacionesDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.HabitacionesDataGrid.Size = new System.Drawing.Size(531, 110);
            this.HabitacionesDataGrid.TabIndex = 36;
            // 
            // ReservaDataGrid
            // 
            this.ReservaDataGrid.AllowUserToAddRows = false;
            this.ReservaDataGrid.AllowUserToDeleteRows = false;
            this.ReservaDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ReservaDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ReservaDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReservaDataGrid.Location = new System.Drawing.Point(6, 18);
            this.ReservaDataGrid.MultiSelect = false;
            this.ReservaDataGrid.Name = "ReservaDataGrid";
            this.ReservaDataGrid.ReadOnly = true;
            this.ReservaDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ReservaDataGrid.Size = new System.Drawing.Size(530, 47);
            this.ReservaDataGrid.TabIndex = 37;
            // 
            // ReservaGroupBox
            // 
            this.ReservaGroupBox.Controls.Add(this.ReservaDataGrid);
            this.ReservaGroupBox.Location = new System.Drawing.Point(5, 23);
            this.ReservaGroupBox.Name = "ReservaGroupBox";
            this.ReservaGroupBox.Size = new System.Drawing.Size(542, 78);
            this.ReservaGroupBox.TabIndex = 38;
            this.ReservaGroupBox.TabStop = false;
            this.ReservaGroupBox.Text = "Reserva";
            // 
            // HabitacionesGroupBox
            // 
            this.HabitacionesGroupBox.Controls.Add(this.HabitacionesDataGrid);
            this.HabitacionesGroupBox.Location = new System.Drawing.Point(5, 117);
            this.HabitacionesGroupBox.Name = "HabitacionesGroupBox";
            this.HabitacionesGroupBox.Size = new System.Drawing.Size(542, 141);
            this.HabitacionesGroupBox.TabIndex = 39;
            this.HabitacionesGroupBox.TabStop = false;
            this.HabitacionesGroupBox.Text = "Habitaciones";
            // 
            // RegistrarIngreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(559, 322);
            this.Controls.Add(this.HabitacionesGroupBox);
            this.Controls.Add(this.ReservaGroupBox);
            this.Controls.Add(this.RegistrarIngresoBoton);
            this.Controls.Add(this.BuscarClienteBoton);
            this.Controls.Add(this.NuevoClienteBoton);
            this.Name = "RegistrarIngreso";
            this.Text = "Registrar Ingreso";
            ((System.ComponentModel.ISupportInitialize)(this.HabitacionesDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReservaDataGrid)).EndInit();
            this.ReservaGroupBox.ResumeLayout(false);
            this.HabitacionesGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BuscarClienteBoton;
        private System.Windows.Forms.Button NuevoClienteBoton;
        private System.Windows.Forms.Button RegistrarIngresoBoton;
        private System.Windows.Forms.DataGridView HabitacionesDataGrid;
        private System.Windows.Forms.DataGridView ReservaDataGrid;
        private System.Windows.Forms.GroupBox ReservaGroupBox;
        private System.Windows.Forms.GroupBox HabitacionesGroupBox;
    }
}