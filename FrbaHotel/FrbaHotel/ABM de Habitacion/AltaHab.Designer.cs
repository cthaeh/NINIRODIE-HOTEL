﻿namespace FrbaHotel.ABM_de_Habitacion
{
    partial class AltaHab
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
            this.textBoxnro = new System.Windows.Forms.TextBox();
            this.textBoxhot = new System.Windows.Forms.TextBox();
            this.textBoxpis = new System.Windows.Forms.TextBox();
            this.textBoxper = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.checkBoxext = new System.Windows.Forms.CheckBox();
            this.checkBoxint = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxnro
            // 
            this.textBoxnro.Location = new System.Drawing.Point(106, 12);
            this.textBoxnro.Name = "textBoxnro";
            this.textBoxnro.Size = new System.Drawing.Size(100, 20);
            this.textBoxnro.TabIndex = 0;
            this.textBoxnro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxnro_KeyPress);
            // 
            // textBoxhot
            // 
            this.textBoxhot.Location = new System.Drawing.Point(106, 38);
            this.textBoxhot.Name = "textBoxhot";
            this.textBoxhot.Size = new System.Drawing.Size(100, 20);
            this.textBoxhot.TabIndex = 1;
            // 
            // textBoxpis
            // 
            this.textBoxpis.Location = new System.Drawing.Point(106, 65);
            this.textBoxpis.Name = "textBoxpis";
            this.textBoxpis.Size = new System.Drawing.Size(100, 20);
            this.textBoxpis.TabIndex = 2;
            this.textBoxpis.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxpis_KeyPress);
            // 
            // textBoxper
            // 
            this.textBoxper.Location = new System.Drawing.Point(106, 91);
            this.textBoxper.Name = "textBoxper";
            this.textBoxper.Size = new System.Drawing.Size(100, 20);
            this.textBoxper.TabIndex = 3;
            this.textBoxper.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxper_KeyPress);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(106, 118);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(198, 96);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // checkBoxext
            // 
            this.checkBoxext.AutoSize = true;
            this.checkBoxext.Location = new System.Drawing.Point(289, 39);
            this.checkBoxext.Name = "checkBoxext";
            this.checkBoxext.Size = new System.Drawing.Size(15, 14);
            this.checkBoxext.TabIndex = 5;
            this.checkBoxext.UseVisualStyleBackColor = true;
            this.checkBoxext.CheckedChanged += new System.EventHandler(this.checkBoxext_CheckedChanged);
            // 
            // checkBoxint
            // 
            this.checkBoxint.AutoSize = true;
            this.checkBoxint.Location = new System.Drawing.Point(289, 65);
            this.checkBoxint.Name = "checkBoxint";
            this.checkBoxint.Size = new System.Drawing.Size(15, 14);
            this.checkBoxint.TabIndex = 6;
            this.checkBoxint.UseVisualStyleBackColor = true;
            this.checkBoxint.CheckedChanged += new System.EventHandler(this.checkBoxint_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ubicacion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Externa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Interna";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Descripcion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Cantidad Personas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Piso";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Hotel";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Numero";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(52, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(170, 227);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AltaHab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(316, 262);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxint);
            this.Controls.Add(this.checkBoxext);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBoxper);
            this.Controls.Add(this.textBoxpis);
            this.Controls.Add(this.textBoxhot);
            this.Controls.Add(this.textBoxnro);
            this.Name = "AltaHab";
            this.Text = "Alta Habitacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxnro;
        private System.Windows.Forms.TextBox textBoxhot;
        private System.Windows.Forms.TextBox textBoxpis;
        private System.Windows.Forms.TextBox textBoxper;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox checkBoxext;
        private System.Windows.Forms.CheckBox checkBoxint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}