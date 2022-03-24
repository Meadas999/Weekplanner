namespace WeekplannerClassesLibrary
{
    partial class DayBoxUserControl
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
            this.DaysLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DaysLbl
            // 
            this.DaysLbl.AutoSize = true;
            this.DaysLbl.Location = new System.Drawing.Point(12, 9);
            this.DaysLbl.Name = "DaysLbl";
            this.DaysLbl.Size = new System.Drawing.Size(32, 15);
            this.DaysLbl.TabIndex = 0;
            this.DaysLbl.Text = "Days";
            // 
            // DayBoxUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.DaysLbl);
            this.Name = "DayBoxUserControl";
            this.Size = new System.Drawing.Size(184, 91);
            this.Load += new System.EventHandler(this.DayBoxUserControl_Load);
            this.DoubleClick += new System.EventHandler(this.DayBoxUserControl_DoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label DaysLbl;
    }
}
