namespace WeekplannerClassesLibrary
{
    partial class DagOverzicht
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
            this.activiteiten_LB = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // activiteiten_LB
            // 
            this.activiteiten_LB.FormattingEnabled = true;
            this.activiteiten_LB.ItemHeight = 15;
            this.activiteiten_LB.Location = new System.Drawing.Point(105, 60);
            this.activiteiten_LB.Name = "activiteiten_LB";
            this.activiteiten_LB.Size = new System.Drawing.Size(552, 334);
            this.activiteiten_LB.TabIndex = 0;
            this.activiteiten_LB.SelectedIndexChanged += new System.EventHandler(this.activiteiten_LB_SelectedIndexChanged);
            // 
            // DagOverzicht
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.activiteiten_LB);
            this.Name = "DagOverzicht";
            this.Text = "DagOverzicht";
            this.Load += new System.EventHandler(this.DagOverzicht_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox activiteiten_LB;
    }
}