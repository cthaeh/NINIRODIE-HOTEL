namespace FrbaHotel.ABM_Rol
{
    partial class Alta
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
            this.existenteBoton = new System.Windows.Forms.Button();
            this.nuevoBoton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // existenteBoton
            // 
            this.existenteBoton.Location = new System.Drawing.Point(42, 104);
            this.existenteBoton.Name = "existenteBoton";
            this.existenteBoton.Size = new System.Drawing.Size(81, 27);
            this.existenteBoton.TabIndex = 15;
            this.existenteBoton.Text = "Existente";
            this.existenteBoton.UseVisualStyleBackColor = true;
            this.existenteBoton.Click += new System.EventHandler(this.existenteBoton_Click);
            // 
            // nuevoBoton
            // 
            this.nuevoBoton.Location = new System.Drawing.Point(42, 44);
            this.nuevoBoton.Name = "nuevoBoton";
            this.nuevoBoton.Size = new System.Drawing.Size(81, 27);
            this.nuevoBoton.TabIndex = 16;
            this.nuevoBoton.Text = "Nuevo";
            this.nuevoBoton.UseVisualStyleBackColor = true;
            this.nuevoBoton.Click += new System.EventHandler(this.nuevoBoton_Click);
            // 
            // Alta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(164, 175);
            this.Controls.Add(this.nuevoBoton);
            this.Controls.Add(this.existenteBoton);
            this.Name = "Alta";
            this.Text = "Alta";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button existenteBoton;
        private System.Windows.Forms.Button nuevoBoton;

    }
}