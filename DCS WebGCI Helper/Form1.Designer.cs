namespace DCS_WebGCI_Helper {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.chkArmed = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkArmed
            // 
            this.chkArmed.AutoSize = true;
            this.chkArmed.Checked = true;
            this.chkArmed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkArmed.Location = new System.Drawing.Point(151, 12);
            this.chkArmed.Name = "chkArmed";
            this.chkArmed.Size = new System.Drawing.Size(56, 17);
            this.chkArmed.TabIndex = 2;
            this.chkArmed.Text = "Armed";
            this.chkArmed.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 47);
            this.Controls.Add(this.chkArmed);
            this.Name = "Form1";
            this.Text = "DCS WebGCI Helper - Cyunide";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkArmed;
    }
}

