namespace FrbaHotel.ABM_Rol
{
    partial class ABMRol
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
            this.botonModificacion = new System.Windows.Forms.Button();
            this.botonBaja = new System.Windows.Forms.Button();
            this.botonAlta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botonModificacion
            // 
            this.botonModificacion.Location = new System.Drawing.Point(61, 122);
            this.botonModificacion.Name = "botonModificacion";
            this.botonModificacion.Size = new System.Drawing.Size(75, 23);
            this.botonModificacion.TabIndex = 5;
            this.botonModificacion.Text = "Modificacion";
            this.botonModificacion.UseVisualStyleBackColor = true;
            this.botonModificacion.Click += new System.EventHandler(this.botonModificacion_Click);
            // 
            // botonBaja
            // 
            this.botonBaja.Location = new System.Drawing.Point(61, 77);
            this.botonBaja.Name = "botonBaja";
            this.botonBaja.Size = new System.Drawing.Size(75, 23);
            this.botonBaja.TabIndex = 4;
            this.botonBaja.Text = "Baja";
            this.botonBaja.UseVisualStyleBackColor = true;
            this.botonBaja.Click += new System.EventHandler(this.botonBaja_Click);
            // 
            // botonAlta
            // 
            this.botonAlta.Location = new System.Drawing.Point(61, 29);
            this.botonAlta.Name = "botonAlta";
            this.botonAlta.Size = new System.Drawing.Size(75, 23);
            this.botonAlta.TabIndex = 3;
            this.botonAlta.Text = "Alta";
            this.botonAlta.UseVisualStyleBackColor = true;
            this.botonAlta.Click += new System.EventHandler(this.botonAlta_Click);
            // 
            // ABMRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(199, 185);
            this.Controls.Add(this.botonModificacion);
            this.Controls.Add(this.botonBaja);
            this.Controls.Add(this.botonAlta);
            this.Name = "ABMRol";
            this.Text = "ABM Rol";
            this.Load += new System.EventHandler(this.ABMRol_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botonModificacion;
        private System.Windows.Forms.Button botonBaja;
        private System.Windows.Forms.Button botonAlta;
    }
}