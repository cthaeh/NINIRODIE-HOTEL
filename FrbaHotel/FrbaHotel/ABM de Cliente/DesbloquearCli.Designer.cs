namespace FrbaHotel.ABM_de_Cliente
{
    partial class DesbloquearCli
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxdes = new System.Windows.Forms.CheckBox();
            this.checkBoxhab = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(137, 93);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxdes
            // 
            this.checkBoxdes.AutoSize = true;
            this.checkBoxdes.Location = new System.Drawing.Point(171, 46);
            this.checkBoxdes.Name = "checkBoxdes";
            this.checkBoxdes.Size = new System.Drawing.Size(15, 14);
            this.checkBoxdes.TabIndex = 15;
            this.checkBoxdes.UseVisualStyleBackColor = true;
            this.checkBoxdes.CheckedChanged += new System.EventHandler(this.checkBoxdes_CheckedChanged);
            // 
            // checkBoxhab
            // 
            this.checkBoxhab.AutoSize = true;
            this.checkBoxhab.Location = new System.Drawing.Point(171, 9);
            this.checkBoxhab.Name = "checkBoxhab";
            this.checkBoxhab.Size = new System.Drawing.Size(15, 14);
            this.checkBoxhab.TabIndex = 14;
            this.checkBoxhab.UseVisualStyleBackColor = true;
            this.checkBoxhab.CheckedChanged += new System.EventHandler(this.checkBoxhab_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Bloquear";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Des Bloquear";
            // 
            // DesbloquearCli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(254, 143);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBoxdes);
            this.Controls.Add(this.checkBoxhab);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DesbloquearCli";
            this.Text = "Desbloquear";
            this.Load += new System.EventHandler(this.DesbloquearCli_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxdes;
        private System.Windows.Forms.CheckBox checkBoxhab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}