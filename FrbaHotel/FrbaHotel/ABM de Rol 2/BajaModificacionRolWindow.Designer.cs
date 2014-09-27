namespace FrbaHotel.ABM_Rol
{
    partial class BajaModificacionRolWindow
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
            this.botonEditar = new System.Windows.Forms.Button();
            this.grillaRoles = new System.Windows.Forms.DataGridView();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.salirBoton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grillaRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // botonEditar
            // 
            this.botonEditar.Location = new System.Drawing.Point(104, 222);
            this.botonEditar.Name = "botonEditar";
            this.botonEditar.Size = new System.Drawing.Size(75, 24);
            this.botonEditar.TabIndex = 17;
            this.botonEditar.Text = "Editar";
            this.botonEditar.UseVisualStyleBackColor = true;
            // 
            // grillaRoles
            // 
            this.grillaRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaRoles.EnableHeadersVisualStyles = false;
            this.grillaRoles.Location = new System.Drawing.Point(21, 86);
            this.grillaRoles.MultiSelect = false;
            this.grillaRoles.Name = "grillaRoles";
            this.grillaRoles.ReadOnly = true;
            this.grillaRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaRoles.Size = new System.Drawing.Size(243, 120);
            this.grillaRoles.TabIndex = 15;
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(183, 53);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(81, 27);
            this.botonLimpiar.TabIndex = 14;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.botonLimpiar_Click);
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(82, 25);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(183, 20);
            this.textNombre.TabIndex = 13;
            this.textNombre.TextChanged += new System.EventHandler(this.textNombre_TextChanged);
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(19, 32);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(44, 13);
            this.labelNombre.TabIndex = 12;
            this.labelNombre.Text = "Nombre";
            // 
            // salirBoton
            // 
            this.salirBoton.Location = new System.Drawing.Point(189, 222);
            this.salirBoton.Name = "salirBoton";
            this.salirBoton.Size = new System.Drawing.Size(75, 24);
            this.salirBoton.TabIndex = 18;
            this.salirBoton.Text = "Salir";
            this.salirBoton.UseVisualStyleBackColor = true;
            this.salirBoton.Click += new System.EventHandler(this.salirBoton_Click);
            // 
            // BajaModificacionRolWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.salirBoton);
            this.Controls.Add(this.botonEditar);
            this.Controls.Add(this.grillaRoles);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.labelNombre);
            this.Name = "BajaModificacionRolWindow";
            this.Text = "BajaModificacionRolWindow";
            ((System.ComponentModel.ISupportInitialize)(this.grillaRoles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonEditar;
        private System.Windows.Forms.DataGridView grillaRoles;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Button salirBoton;
    }
}