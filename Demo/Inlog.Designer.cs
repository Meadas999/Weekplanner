namespace WeekplannerClassesLibrary
{
    partial class Inlog
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
            this.Inlogbtn = new System.Windows.Forms.Button();
            this.username_TB = new System.Windows.Forms.TextBox();
            this.password_Tb = new System.Windows.Forms.TextBox();
            this.UserLbl = new System.Windows.Forms.Label();
            this.PasswLBL = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.register_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Inlogbtn
            // 
            this.Inlogbtn.Location = new System.Drawing.Point(272, 256);
            this.Inlogbtn.Name = "Inlogbtn";
            this.Inlogbtn.Size = new System.Drawing.Size(75, 23);
            this.Inlogbtn.TabIndex = 0;
            this.Inlogbtn.Text = "Log in!";
            this.Inlogbtn.UseVisualStyleBackColor = true;
            this.Inlogbtn.Click += new System.EventHandler(this.Inlogbtn_Click);
            // 
            // username_TB
            // 
            this.username_TB.Location = new System.Drawing.Point(268, 164);
            this.username_TB.Name = "username_TB";
            this.username_TB.Size = new System.Drawing.Size(286, 23);
            this.username_TB.TabIndex = 1;
            // 
            // password_Tb
            // 
            this.password_Tb.Location = new System.Drawing.Point(268, 212);
            this.password_Tb.Name = "password_Tb";
            this.password_Tb.Size = new System.Drawing.Size(286, 23);
            this.password_Tb.TabIndex = 2;
            // 
            // UserLbl
            // 
            this.UserLbl.AutoSize = true;
            this.UserLbl.Location = new System.Drawing.Point(272, 142);
            this.UserLbl.Name = "UserLbl";
            this.UserLbl.Size = new System.Drawing.Size(100, 15);
            this.UserLbl.TabIndex = 3;
            this.UserLbl.Text = "Username(email):";
            // 
            // PasswLBL
            // 
            this.PasswLBL.AutoSize = true;
            this.PasswLBL.Location = new System.Drawing.Point(272, 194);
            this.PasswLBL.Name = "PasswLBL";
            this.PasswLBL.Size = new System.Drawing.Size(60, 15);
            this.PasswLBL.TabIndex = 4;
            this.PasswLBL.Text = "Password:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(455, 238);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(99, 15);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Forget password?";
            // 
            // register_btn
            // 
            this.register_btn.Location = new System.Drawing.Point(479, 256);
            this.register_btn.Name = "register_btn";
            this.register_btn.Size = new System.Drawing.Size(75, 23);
            this.register_btn.TabIndex = 6;
            this.register_btn.Text = "Sign Up!";
            this.register_btn.UseVisualStyleBackColor = true;
            this.register_btn.Click += new System.EventHandler(this.register_btn_Click);
            // 
            // Inlog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.register_btn);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.PasswLBL);
            this.Controls.Add(this.UserLbl);
            this.Controls.Add(this.password_Tb);
            this.Controls.Add(this.username_TB);
            this.Controls.Add(this.Inlogbtn);
            this.Name = "Inlog";
            this.Text = "Inlog";
            this.Load += new System.EventHandler(this.Inlog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Inlogbtn;
        private TextBox username_TB;
        private TextBox password_Tb;
        private Label UserLbl;
        private Label PasswLBL;
        private LinkLabel linkLabel1;
        private Button register_btn;
    }
}