namespace Bonaterra
{
    partial class FormMotivos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMotivos));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Lbl_titulo = new System.Windows.Forms.Label();
            this.txt_cuadro = new System.Windows.Forms.TextBox();
            this.btn_ingreso = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(62, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Lbl_titulo
            // 
            this.Lbl_titulo.AutoSize = true;
            this.Lbl_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_titulo.Location = new System.Drawing.Point(151, 12);
            this.Lbl_titulo.Name = "Lbl_titulo";
            this.Lbl_titulo.Size = new System.Drawing.Size(24, 31);
            this.Lbl_titulo.TabIndex = 1;
            this.Lbl_titulo.Text = "-";
            // 
            // txt_cuadro
            // 
            this.txt_cuadro.Location = new System.Drawing.Point(94, 85);
            this.txt_cuadro.Name = "txt_cuadro";
            this.txt_cuadro.Size = new System.Drawing.Size(241, 20);
            this.txt_cuadro.TabIndex = 2;
            // 
            // btn_ingreso
            // 
            this.btn_ingreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ingreso.Location = new System.Drawing.Point(157, 123);
            this.btn_ingreso.Name = "btn_ingreso";
            this.btn_ingreso.Size = new System.Drawing.Size(109, 36);
            this.btn_ingreso.TabIndex = 3;
            this.btn_ingreso.Text = "Agregar";
            this.btn_ingreso.UseVisualStyleBackColor = true;
            this.btn_ingreso.Click += new System.EventHandler(this.btn_ingreso_Click);
            // 
            // FormMotivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(405, 171);
            this.Controls.Add(this.btn_ingreso);
            this.Controls.Add(this.txt_cuadro);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Lbl_titulo);
            this.Name = "FormMotivos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormMotivos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_cuadro;
        private System.Windows.Forms.Button btn_ingreso;
        public System.Windows.Forms.Label Lbl_titulo;
    }
}