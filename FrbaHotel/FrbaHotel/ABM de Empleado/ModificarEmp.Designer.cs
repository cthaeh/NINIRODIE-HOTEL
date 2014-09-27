namespace FrbaHotel.ABM_de_Empleado
{
    partial class ModificarEmp
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBoxhot = new System.Windows.Forms.TextBox();
            this.textBoxtel = new System.Windows.Forms.TextBox();
            this.textBoxdir = new System.Windows.Forms.TextBox();
            this.textBoxmail = new System.Windows.Forms.TextBox();
            this.textBoxdni = new System.Windows.Forms.TextBox();
            this.textBoxap = new System.Windows.Forms.TextBox();
            this.textBoxnomb = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.nac = new System.Windows.Forms.Label();
            this.hot = new System.Windows.Forms.Label();
            this.tel = new System.Windows.Forms.Label();
            this.dir = new System.Windows.Forms.Label();
            this.meil = new System.Windows.Forms.Label();
            this.ro = new System.Windows.Forms.Label();
            this.dni = new System.Windows.Forms.Label();
            this.ape = new System.Windows.Forms.Label();
            this.nomb = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxnrocal = new System.Windows.Forms.TextBox();
            this.textBoxpis = new System.Windows.Forms.TextBox();
            this.textBoxdep = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Admin",
            "Recep"});
            this.comboBox1.Location = new System.Drawing.Point(92, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 46;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(334, 147);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 45;
            // 
            // textBoxhot
            // 
            this.textBoxhot.Location = new System.Drawing.Point(334, 120);
            this.textBoxhot.Name = "textBoxhot";
            this.textBoxhot.Size = new System.Drawing.Size(200, 20);
            this.textBoxhot.TabIndex = 44;
            // 
            // textBoxtel
            // 
            this.textBoxtel.Location = new System.Drawing.Point(334, 94);
            this.textBoxtel.Name = "textBoxtel";
            this.textBoxtel.Size = new System.Drawing.Size(200, 20);
            this.textBoxtel.TabIndex = 43;
            // 
            // textBoxdir
            // 
            this.textBoxdir.Location = new System.Drawing.Point(92, 61);
            this.textBoxdir.Name = "textBoxdir";
            this.textBoxdir.Size = new System.Drawing.Size(121, 20);
            this.textBoxdir.TabIndex = 42;
            // 
            // textBoxmail
            // 
            this.textBoxmail.Location = new System.Drawing.Point(334, 69);
            this.textBoxmail.Name = "textBoxmail";
            this.textBoxmail.Size = new System.Drawing.Size(200, 20);
            this.textBoxmail.TabIndex = 41;
            // 
            // textBoxdni
            // 
            this.textBoxdni.Location = new System.Drawing.Point(334, 43);
            this.textBoxdni.Name = "textBoxdni";
            this.textBoxdni.Size = new System.Drawing.Size(200, 20);
            this.textBoxdni.TabIndex = 40;
            // 
            // textBoxap
            // 
            this.textBoxap.Location = new System.Drawing.Point(334, 17);
            this.textBoxap.Name = "textBoxap";
            this.textBoxap.Size = new System.Drawing.Size(200, 20);
            this.textBoxap.TabIndex = 39;
            // 
            // textBoxnomb
            // 
            this.textBoxnomb.Location = new System.Drawing.Point(92, 35);
            this.textBoxnomb.Name = "textBoxnomb";
            this.textBoxnomb.Size = new System.Drawing.Size(121, 20);
            this.textBoxnomb.TabIndex = 38;
            this.textBoxnomb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxnomb_KeyPress);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(309, 184);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 37;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(151, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 36;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nac
            // 
            this.nac.AutoSize = true;
            this.nac.Location = new System.Drawing.Point(234, 147);
            this.nac.Name = "nac";
            this.nac.Size = new System.Drawing.Size(93, 13);
            this.nac.TabIndex = 35;
            this.nac.Text = "Fecha Nacimiento";
            // 
            // hot
            // 
            this.hot.AutoSize = true;
            this.hot.Location = new System.Drawing.Point(234, 120);
            this.hot.Name = "hot";
            this.hot.Size = new System.Drawing.Size(32, 13);
            this.hot.TabIndex = 34;
            this.hot.Text = "Hotel";
            // 
            // tel
            // 
            this.tel.AutoSize = true;
            this.tel.Location = new System.Drawing.Point(234, 94);
            this.tel.Name = "tel";
            this.tel.Size = new System.Drawing.Size(49, 13);
            this.tel.TabIndex = 33;
            this.tel.Text = "Telefono";
            // 
            // dir
            // 
            this.dir.AutoSize = true;
            this.dir.Location = new System.Drawing.Point(7, 64);
            this.dir.Name = "dir";
            this.dir.Size = new System.Drawing.Size(30, 13);
            this.dir.TabIndex = 32;
            this.dir.Text = "Calle";
            // 
            // meil
            // 
            this.meil.AutoSize = true;
            this.meil.Location = new System.Drawing.Point(234, 69);
            this.meil.Name = "meil";
            this.meil.Size = new System.Drawing.Size(26, 13);
            this.meil.TabIndex = 31;
            this.meil.Text = "Mail";
            // 
            // ro
            // 
            this.ro.AutoSize = true;
            this.ro.Location = new System.Drawing.Point(7, 12);
            this.ro.Name = "ro";
            this.ro.Size = new System.Drawing.Size(23, 13);
            this.ro.TabIndex = 30;
            this.ro.Text = "Rol";
            // 
            // dni
            // 
            this.dni.AutoSize = true;
            this.dni.Location = new System.Drawing.Point(234, 43);
            this.dni.Name = "dni";
            this.dni.Size = new System.Drawing.Size(46, 13);
            this.dni.TabIndex = 29;
            this.dni.Text = "Nro DNI";
            // 
            // ape
            // 
            this.ape.AutoSize = true;
            this.ape.Location = new System.Drawing.Point(234, 17);
            this.ape.Name = "ape";
            this.ape.Size = new System.Drawing.Size(44, 13);
            this.ape.TabIndex = 28;
            this.ape.Text = "Apellido";
            // 
            // nomb
            // 
            this.nomb.AutoSize = true;
            this.nomb.Location = new System.Drawing.Point(7, 38);
            this.nomb.Name = "nomb";
            this.nomb.Size = new System.Drawing.Size(44, 13);
            this.nomb.TabIndex = 27;
            this.nomb.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Nro Calle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "Piso";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Departamento";
            // 
            // textBoxnrocal
            // 
            this.textBoxnrocal.Location = new System.Drawing.Point(92, 88);
            this.textBoxnrocal.Name = "textBoxnrocal";
            this.textBoxnrocal.Size = new System.Drawing.Size(121, 20);
            this.textBoxnrocal.TabIndex = 50;
            this.textBoxnrocal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxnrocal_KeyPress);
            // 
            // textBoxpis
            // 
            this.textBoxpis.Location = new System.Drawing.Point(92, 115);
            this.textBoxpis.Name = "textBoxpis";
            this.textBoxpis.Size = new System.Drawing.Size(121, 20);
            this.textBoxpis.TabIndex = 51;
            this.textBoxpis.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxpis_KeyPress);
            // 
            // textBoxdep
            // 
            this.textBoxdep.Location = new System.Drawing.Point(92, 141);
            this.textBoxdep.Name = "textBoxdep";
            this.textBoxdep.Size = new System.Drawing.Size(121, 20);
            this.textBoxdep.TabIndex = 52;
            this.textBoxdep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxdep_KeyPress);
            // 
            // ModificarEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(568, 229);
            this.Controls.Add(this.textBoxdep);
            this.Controls.Add(this.textBoxpis);
            this.Controls.Add(this.textBoxnrocal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBoxhot);
            this.Controls.Add(this.textBoxtel);
            this.Controls.Add(this.textBoxdir);
            this.Controls.Add(this.textBoxmail);
            this.Controls.Add(this.textBoxdni);
            this.Controls.Add(this.textBoxap);
            this.Controls.Add(this.textBoxnomb);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nac);
            this.Controls.Add(this.hot);
            this.Controls.Add(this.tel);
            this.Controls.Add(this.dir);
            this.Controls.Add(this.meil);
            this.Controls.Add(this.ro);
            this.Controls.Add(this.dni);
            this.Controls.Add(this.ape);
            this.Controls.Add(this.nomb);
            this.Name = "ModificarEmp";
            this.Text = "Modificar Empleado";
            this.Load += new System.EventHandler(this.ModificarEmp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBoxhot;
        private System.Windows.Forms.TextBox textBoxtel;
        private System.Windows.Forms.TextBox textBoxdir;
        private System.Windows.Forms.TextBox textBoxmail;
        private System.Windows.Forms.TextBox textBoxdni;
        private System.Windows.Forms.TextBox textBoxap;
        private System.Windows.Forms.TextBox textBoxnomb;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label nac;
        private System.Windows.Forms.Label hot;
        private System.Windows.Forms.Label tel;
        private System.Windows.Forms.Label dir;
        private System.Windows.Forms.Label meil;
        private System.Windows.Forms.Label ro;
        private System.Windows.Forms.Label dni;
        private System.Windows.Forms.Label ape;
        private System.Windows.Forms.Label nomb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxnrocal;
        private System.Windows.Forms.TextBox textBoxpis;
        private System.Windows.Forms.TextBox textBoxdep;
    }
}