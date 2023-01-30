namespace Time_Clock.UI
{
    partial class frmPasswordChange
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
            this.lblID = new System.Windows.Forms.Label();
            this.OldPass = new System.Windows.Forms.Label();
            this.NewPass = new System.Windows.Forms.Label();
            this.NewPassAprove = new System.Windows.Forms.Label();
            this.txtOldPass = new System.Windows.Forms.TextBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.txtNewConfirm = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(353, 51);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(76, 16);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "תעודת זהות";
            // 
            // OldPass
            // 
            this.OldPass.AutoSize = true;
            this.OldPass.Location = new System.Drawing.Point(571, 126);
            this.OldPass.Name = "OldPass";
            this.OldPass.Size = new System.Drawing.Size(74, 16);
            this.OldPass.TabIndex = 1;
            this.OldPass.Text = "סיסמא ישנה";
            // 
            // NewPass
            // 
            this.NewPass.AutoSize = true;
            this.NewPass.Location = new System.Drawing.Point(571, 177);
            this.NewPass.Name = "NewPass";
            this.NewPass.Size = new System.Drawing.Size(80, 16);
            this.NewPass.TabIndex = 2;
            this.NewPass.Text = "סיסמא חדשה";
            // 
            // NewPassAprove
            // 
            this.NewPassAprove.AutoSize = true;
            this.NewPassAprove.Location = new System.Drawing.Point(571, 232);
            this.NewPassAprove.Name = "NewPassAprove";
            this.NewPassAprove.Size = new System.Drawing.Size(117, 16);
            this.NewPassAprove.TabIndex = 3;
            this.NewPassAprove.Text = "אישור סיסמא חדשה";
            // 
            // txtOldPass
            // 
            this.txtOldPass.Location = new System.Drawing.Point(427, 123);
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.Size = new System.Drawing.Size(100, 22);
            this.txtOldPass.TabIndex = 4;
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(427, 177);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(100, 22);
            this.txtNewPass.TabIndex = 5;
            // 
            // txtNewConfirm
            // 
            this.txtNewConfirm.Location = new System.Drawing.Point(427, 232);
            this.txtNewConfirm.Name = "txtNewConfirm";
            this.txtNewConfirm.Size = new System.Drawing.Size(100, 22);
            this.txtNewConfirm.TabIndex = 6;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(354, 300);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 7;
            this.OK.Text = "אישור";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // frmPasswordChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.txtNewConfirm);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.txtOldPass);
            this.Controls.Add(this.NewPassAprove);
            this.Controls.Add(this.NewPass);
            this.Controls.Add(this.OldPass);
            this.Controls.Add(this.lblID);
            this.Name = "frmPasswordChange";
            this.Text = "PasswordChange";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label OldPass;
        private System.Windows.Forms.Label NewPass;
        private System.Windows.Forms.Label NewPassAprove;
        private System.Windows.Forms.TextBox txtOldPass;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.TextBox txtNewConfirm;
        private System.Windows.Forms.Button OK;
    }
}