namespace ChangePassword
{
    partial class ChangePassword
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCPempID = new System.Windows.Forms.Label();
            this.lblCPempName = new System.Windows.Forms.Label();
            this.txtCPConfirm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCP = new System.Windows.Forms.Button();
            this.txtCPCurrentP = new System.Windows.Forms.TextBox();
            this.txtCPNewPass = new System.Windows.Forms.TextBox();
            this.lblCPiD = new System.Windows.Forms.Label();
            this.lblCPname = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblCPempID);
            this.panel1.Controls.Add(this.lblCPempName);
            this.panel1.Controls.Add(this.txtCPConfirm);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnCP);
            this.panel1.Controls.Add(this.txtCPCurrentP);
            this.panel1.Controls.Add(this.txtCPNewPass);
            this.panel1.Controls.Add(this.lblCPiD);
            this.panel1.Controls.Add(this.lblCPname);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(593, 502);
            this.panel1.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(227, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(195, 25);
            this.label8.TabIndex = 12;
            this.label8.Text = "Password Changer";
            // 
            // lblCPempID
            // 
            this.lblCPempID.AutoSize = true;
            this.lblCPempID.Location = new System.Drawing.Point(214, 160);
            this.lblCPempID.Name = "lblCPempID";
            this.lblCPempID.Size = new System.Drawing.Size(0, 17);
            this.lblCPempID.TabIndex = 11;
            // 
            // lblCPempName
            // 
            this.lblCPempName.AutoSize = true;
            this.lblCPempName.Location = new System.Drawing.Point(214, 230);
            this.lblCPempName.Name = "lblCPempName";
            this.lblCPempName.Size = new System.Drawing.Size(0, 17);
            this.lblCPempName.TabIndex = 9;
            // 
            // txtCPConfirm
            // 
            this.txtCPConfirm.Location = new System.Drawing.Point(217, 414);
            this.txtCPConfirm.Name = "txtCPConfirm";
            this.txtCPConfirm.PasswordChar = '*';
            this.txtCPConfirm.Size = new System.Drawing.Size(214, 22);
            this.txtCPConfirm.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Current Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 352);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "New Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 416);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Confirm Password";
            // 
            // btnCP
            // 
            this.btnCP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnCP.Location = new System.Drawing.Point(436, 459);
            this.btnCP.Name = "btnCP";
            this.btnCP.Size = new System.Drawing.Size(139, 31);
            this.btnCP.TabIndex = 4;
            this.btnCP.Text = "Change Password";
            this.btnCP.UseVisualStyleBackColor = false;
            this.btnCP.Click += new System.EventHandler(this.btnCP_Click);
            // 
            // txtCPCurrentP
            // 
            this.txtCPCurrentP.Location = new System.Drawing.Point(217, 290);
            this.txtCPCurrentP.Name = "txtCPCurrentP";
            this.txtCPCurrentP.PasswordChar = '*';
            this.txtCPCurrentP.Size = new System.Drawing.Size(214, 22);
            this.txtCPCurrentP.TabIndex = 3;
            // 
            // txtCPNewPass
            // 
            this.txtCPNewPass.Location = new System.Drawing.Point(217, 352);
            this.txtCPNewPass.Name = "txtCPNewPass";
            this.txtCPNewPass.PasswordChar = '*';
            this.txtCPNewPass.Size = new System.Drawing.Size(214, 22);
            this.txtCPNewPass.TabIndex = 2;
            // 
            // lblCPiD
            // 
            this.lblCPiD.AutoSize = true;
            this.lblCPiD.Location = new System.Drawing.Point(74, 160);
            this.lblCPiD.Name = "lblCPiD";
            this.lblCPiD.Size = new System.Drawing.Size(115, 17);
            this.lblCPiD.TabIndex = 1;
            this.lblCPiD.Text = "Employee ID      :";
            // 
            // lblCPname
            // 
            this.lblCPname.AutoSize = true;
            this.lblCPname.Location = new System.Drawing.Point(74, 224);
            this.lblCPname.Name = "lblCPname";
            this.lblCPname.Size = new System.Drawing.Size(119, 17);
            this.lblCPname.TabIndex = 0;
            this.lblCPname.Text = "Employee Name :";
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 527);
            this.Controls.Add(this.panel1);
            this.Name = "ChangePassword";
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCPempID;
        private System.Windows.Forms.Label lblCPempName;
        private System.Windows.Forms.TextBox txtCPConfirm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCP;
        private System.Windows.Forms.TextBox txtCPCurrentP;
        private System.Windows.Forms.TextBox txtCPNewPass;
        private System.Windows.Forms.Label lblCPiD;
        private System.Windows.Forms.Label lblCPname;
    }
}

