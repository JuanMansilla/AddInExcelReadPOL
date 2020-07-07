namespace AddInExcelReadPOL
{
    partial class Configuracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuracion));
            this.label1 = new System.Windows.Forms.Label();
            this.TxtOrigen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtDestino = new System.Windows.Forms.TextBox();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnOpenDestino = new System.Windows.Forms.Button();
            this.BtnOpenOrigen = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ruta de origen:";
            // 
            // TxtOrigen
            // 
            this.TxtOrigen.Location = new System.Drawing.Point(16, 34);
            this.TxtOrigen.Name = "TxtOrigen";
            this.TxtOrigen.Size = new System.Drawing.Size(258, 20);
            this.TxtOrigen.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ruta de destino:";
            // 
            // TxtDestino
            // 
            this.TxtDestino.Location = new System.Drawing.Point(16, 93);
            this.TxtDestino.Name = "TxtDestino";
            this.TxtDestino.Size = new System.Drawing.Size(258, 20);
            this.TxtDestino.TabIndex = 1;
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Image = global::AddInExcelReadPOL.Properties.Resources.stop16;
            this.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCerrar.Location = new System.Drawing.Point(206, 134);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(68, 27);
            this.BtnCerrar.TabIndex = 3;
            this.BtnCerrar.Text = "&Cerrar";
            this.BtnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Image = global::AddInExcelReadPOL.Properties.Resources.save16;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardar.Location = new System.Drawing.Point(44, 134);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(78, 27);
            this.BtnGuardar.TabIndex = 3;
            this.BtnGuardar.Text = "&Guardar";
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnOpenDestino
            // 
            this.BtnOpenDestino.Image = global::AddInExcelReadPOL.Properties.Resources.folder_open16;
            this.BtnOpenDestino.Location = new System.Drawing.Point(277, 89);
            this.BtnOpenDestino.Name = "BtnOpenDestino";
            this.BtnOpenDestino.Size = new System.Drawing.Size(34, 26);
            this.BtnOpenDestino.TabIndex = 2;
            this.BtnOpenDestino.UseVisualStyleBackColor = true;
            this.BtnOpenDestino.Click += new System.EventHandler(this.BtnOpenDestino_Click);
            // 
            // BtnOpenOrigen
            // 
            this.BtnOpenOrigen.Image = global::AddInExcelReadPOL.Properties.Resources.folder_open16;
            this.BtnOpenOrigen.Location = new System.Drawing.Point(277, 30);
            this.BtnOpenOrigen.Name = "BtnOpenOrigen";
            this.BtnOpenOrigen.Size = new System.Drawing.Size(34, 26);
            this.BtnOpenOrigen.TabIndex = 2;
            this.BtnOpenOrigen.UseVisualStyleBackColor = true;
            this.BtnOpenOrigen.Click += new System.EventHandler(this.BtnOpenOrigen_Click);
            // 
            // Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(329, 174);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnOpenDestino);
            this.Controls.Add(this.BtnOpenOrigen);
            this.Controls.Add(this.TxtDestino);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtOrigen);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configuracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".:. Configuracion .:.                                               V0.5";
            this.Load += new System.EventHandler(this.Configuracion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtOrigen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtDestino;
        private System.Windows.Forms.Button BtnOpenOrigen;
        private System.Windows.Forms.Button BtnOpenDestino;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}