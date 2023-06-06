namespace Practica2
{
    partial class FrmMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gpBotonsPing = new System.Windows.Forms.GroupBox();
            this.btnferPing = new System.Windows.Forms.Button();
            this.tbFinalRang = new System.Windows.Forms.TextBox();
            this.tbPrincipiRang = new System.Windows.Forms.TextBox();
            this.lbfinalRang = new System.Windows.Forms.Label();
            this.lbPrincipiRang = new System.Windows.Forms.Label();
            this.gpBotonsPing.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpBotonsPing
            // 
            this.gpBotonsPing.Controls.Add(this.btnferPing);
            this.gpBotonsPing.Controls.Add(this.tbFinalRang);
            this.gpBotonsPing.Controls.Add(this.tbPrincipiRang);
            this.gpBotonsPing.Controls.Add(this.lbfinalRang);
            this.gpBotonsPing.Controls.Add(this.lbPrincipiRang);
            this.gpBotonsPing.Location = new System.Drawing.Point(13, 13);
            this.gpBotonsPing.Name = "gpBotonsPing";
            this.gpBotonsPing.Size = new System.Drawing.Size(421, 247);
            this.gpBotonsPing.TabIndex = 0;
            this.gpBotonsPing.TabStop = false;
            this.gpBotonsPing.Text = "Botons Ping";
            // 
            // btnferPing
            // 
            this.btnferPing.Location = new System.Drawing.Point(87, 170);
            this.btnferPing.Name = "btnferPing";
            this.btnferPing.Size = new System.Drawing.Size(264, 44);
            this.btnferPing.TabIndex = 4;
            this.btnferPing.Text = "Fer Ping!";
            this.btnferPing.UseVisualStyleBackColor = true;
            this.btnferPing.Click += new System.EventHandler(this.btnferPing_Click);
            // 
            // tbFinalRang
            // 
            this.tbFinalRang.Location = new System.Drawing.Point(118, 111);
            this.tbFinalRang.Name = "tbFinalRang";
            this.tbFinalRang.Size = new System.Drawing.Size(233, 22);
            this.tbFinalRang.TabIndex = 3;
            // 
            // tbPrincipiRang
            // 
            this.tbPrincipiRang.Location = new System.Drawing.Point(118, 50);
            this.tbPrincipiRang.Name = "tbPrincipiRang";
            this.tbPrincipiRang.Size = new System.Drawing.Size(233, 22);
            this.tbPrincipiRang.TabIndex = 2;
            // 
            // lbfinalRang
            // 
            this.lbfinalRang.AutoSize = true;
            this.lbfinalRang.Location = new System.Drawing.Point(40, 114);
            this.lbfinalRang.Name = "lbfinalRang";
            this.lbfinalRang.Size = new System.Drawing.Size(72, 16);
            this.lbfinalRang.TabIndex = 1;
            this.lbfinalRang.Text = "Final Rang";
            // 
            // lbPrincipiRang
            // 
            this.lbPrincipiRang.AutoSize = true;
            this.lbPrincipiRang.Location = new System.Drawing.Point(25, 53);
            this.lbPrincipiRang.Name = "lbPrincipiRang";
            this.lbPrincipiRang.Size = new System.Drawing.Size(87, 16);
            this.lbPrincipiRang.TabIndex = 0;
            this.lbPrincipiRang.Text = "Principi Rang";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(446, 271);
            this.Controls.Add(this.gpBotonsPing);
            this.Name = "FrmMain";
            this.Text = "Activitat Ping";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.gpBotonsPing.ResumeLayout(false);
            this.gpBotonsPing.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpBotonsPing;
        private System.Windows.Forms.TextBox tbFinalRang;
        private System.Windows.Forms.TextBox tbPrincipiRang;
        private System.Windows.Forms.Label lbfinalRang;
        private System.Windows.Forms.Label lbPrincipiRang;
        private System.Windows.Forms.Button btnferPing;
    }
}

