namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class ModificarReserva
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
            this.HabitacionesDisponiblesDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.HabitacionesDisponiblesDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // HabitacionesDisponiblesDataGrid
            // 
            this.HabitacionesDisponiblesDataGrid.AllowUserToAddRows = false;
            this.HabitacionesDisponiblesDataGrid.AllowUserToDeleteRows = false;
            this.HabitacionesDisponiblesDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.HabitacionesDisponiblesDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.HabitacionesDisponiblesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HabitacionesDisponiblesDataGrid.Location = new System.Drawing.Point(12, 135);
            this.HabitacionesDisponiblesDataGrid.Name = "HabitacionesDisponiblesDataGrid";
            this.HabitacionesDisponiblesDataGrid.ReadOnly = true;
            this.HabitacionesDisponiblesDataGrid.Size = new System.Drawing.Size(669, 144);
            this.HabitacionesDisponiblesDataGrid.TabIndex = 13;
            // 
            // ModificarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(693, 318);
            this.Controls.Add(this.HabitacionesDisponiblesDataGrid);
            this.Name = "ModificarReserva";
            this.Text = "Modificar Reserva";
            ((System.ComponentModel.ISupportInitialize)(this.HabitacionesDisponiblesDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView HabitacionesDisponiblesDataGrid;
    }
}