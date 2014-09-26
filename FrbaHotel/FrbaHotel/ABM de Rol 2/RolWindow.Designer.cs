namespace FrbaHotel.ABM_Rol
{
    partial class RolWindow
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
            this.botonCancelar = new System.Windows.Forms.Button();
            this.checkHabilitar = new System.Windows.Forms.CheckBox();
            this.labelHabilitar = new System.Windows.Forms.Label();
            this.grupoFunciones = new System.Windows.Forms.GroupBox();
            this.botonQuitar = new System.Windows.Forms.Button();
            this.botonAgregar = new System.Windows.Forms.Button();
            this.listFuncionesUtilizadas = new System.Windows.Forms.ListBox();
            this.listFuncionesDisponibles = new System.Windows.Forms.ListBox();
            this.botonAceptar = new System.Windows.Forms.Button();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.grupoFunciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // botonCancelar
            // 
            this.botonCancelar.Location = new System.Drawing.Point(266, 345);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(102, 30);
            this.botonCancelar.TabIndex = 17;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // checkHabilitar
            // 
            this.checkHabilitar.AutoSize = true;
            this.checkHabilitar.Location = new System.Drawing.Point(101, 72);
            this.checkHabilitar.Name = "checkHabilitar";
            this.checkHabilitar.Size = new System.Drawing.Size(15, 14);
            this.checkHabilitar.TabIndex = 16;
            this.checkHabilitar.UseVisualStyleBackColor = true;
            this.checkHabilitar.CheckedChanged += new System.EventHandler(this.checkHabilitar_CheckedChanged);
            // 
            // labelHabilitar
            // 
            this.labelHabilitar.AutoSize = true;
            this.labelHabilitar.Location = new System.Drawing.Point(21, 73);
            this.labelHabilitar.Name = "labelHabilitar";
            this.labelHabilitar.Size = new System.Drawing.Size(45, 13);
            this.labelHabilitar.TabIndex = 15;
            this.labelHabilitar.Text = "Habilitar";
            // 
            // grupoFunciones
            // 
            this.grupoFunciones.Controls.Add(this.botonQuitar);
            this.grupoFunciones.Controls.Add(this.botonAgregar);
            this.grupoFunciones.Controls.Add(this.listFuncionesUtilizadas);
            this.grupoFunciones.Controls.Add(this.listFuncionesDisponibles);
            this.grupoFunciones.Location = new System.Drawing.Point(14, 113);
            this.grupoFunciones.Name = "grupoFunciones";
            this.grupoFunciones.Size = new System.Drawing.Size(477, 200);
            this.grupoFunciones.TabIndex = 14;
            this.grupoFunciones.TabStop = false;
            this.grupoFunciones.Text = "Funciones";
            // 
            // botonQuitar
            // 
            this.botonQuitar.Location = new System.Drawing.Point(218, 116);
            this.botonQuitar.Name = "botonQuitar";
            this.botonQuitar.Size = new System.Drawing.Size(40, 32);
            this.botonQuitar.TabIndex = 8;
            this.botonQuitar.Text = "<-";
            this.botonQuitar.UseVisualStyleBackColor = true;
            this.botonQuitar.Click += new System.EventHandler(this.botonQuitar_Click);
            // 
            // botonAgregar
            // 
            this.botonAgregar.Location = new System.Drawing.Point(218, 51);
            this.botonAgregar.Name = "botonAgregar";
            this.botonAgregar.Size = new System.Drawing.Size(40, 32);
            this.botonAgregar.TabIndex = 7;
            this.botonAgregar.Text = "->";
            this.botonAgregar.UseVisualStyleBackColor = true;
            this.botonAgregar.Click += new System.EventHandler(this.botonAgregar_Click);
            // 
            // listFuncionesUtilizadas
            // 
            this.listFuncionesUtilizadas.FormattingEnabled = true;
            this.listFuncionesUtilizadas.Location = new System.Drawing.Point(264, 19);
            this.listFuncionesUtilizadas.Name = "listFuncionesUtilizadas";
            this.listFuncionesUtilizadas.Size = new System.Drawing.Size(202, 173);
            this.listFuncionesUtilizadas.TabIndex = 6;
            // 
            // listFuncionesDisponibles
            // 
            this.listFuncionesDisponibles.FormattingEnabled = true;
            this.listFuncionesDisponibles.Location = new System.Drawing.Point(10, 19);
            this.listFuncionesDisponibles.Name = "listFuncionesDisponibles";
            this.listFuncionesDisponibles.Size = new System.Drawing.Size(202, 173);
            this.listFuncionesDisponibles.TabIndex = 5;
            // 
            // botonAceptar
            // 
            this.botonAceptar.Location = new System.Drawing.Point(136, 345);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(102, 30);
            this.botonAceptar.TabIndex = 13;
            this.botonAceptar.Text = "Aceptar";
            this.botonAceptar.UseVisualStyleBackColor = true;
            this.botonAceptar.Click += new System.EventHandler(this.botonAceptar_Click);
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(90, 27);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(217, 20);
            this.textNombre.TabIndex = 12;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(21, 30);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(44, 13);
            this.labelNombre.TabIndex = 11;
            this.labelNombre.Text = "Nombre";
            // 
            // RolWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 392);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.checkHabilitar);
            this.Controls.Add(this.labelHabilitar);
            this.Controls.Add(this.grupoFunciones);
            this.Controls.Add(this.botonAceptar);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.labelNombre);
            this.Name = "RolWindow";
            this.Text = "Alta Rol";
            this.grupoFunciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.CheckBox checkHabilitar;
        private System.Windows.Forms.Label labelHabilitar;
        private System.Windows.Forms.GroupBox grupoFunciones;
        private System.Windows.Forms.Button botonQuitar;
        private System.Windows.Forms.Button botonAgregar;
        private System.Windows.Forms.ListBox listFuncionesUtilizadas;
        private System.Windows.Forms.ListBox listFuncionesDisponibles;
        private System.Windows.Forms.Button botonAceptar;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Label labelNombre;
    }
}