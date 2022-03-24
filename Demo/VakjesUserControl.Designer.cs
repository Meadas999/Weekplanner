namespace WeekplannerClassesLibrary
{
    partial class VakjesUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UserCtrlLBL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UserCtrlLBL
            // 
            this.UserCtrlLBL.AutoSize = true;
            this.UserCtrlLBL.Location = new System.Drawing.Point(60, 34);
            this.UserCtrlLBL.Name = "UserCtrlLBL";
            this.UserCtrlLBL.Size = new System.Drawing.Size(0, 15);
            this.UserCtrlLBL.TabIndex = 0;
            // 
            // VakjesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UserCtrlLBL);
            this.Name = "VakjesUserControl";
            this.Size = new System.Drawing.Size(184, 91);
            this.Load += new System.EventHandler(this.VakjesUserControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label UserCtrlLBL;
    }
}
