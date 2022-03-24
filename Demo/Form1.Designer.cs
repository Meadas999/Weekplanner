namespace WeekplannerClassesLibrary
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.AgendaBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.ProfileBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.DayContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.MondayLbl = new System.Windows.Forms.Label();
            this.TuesdayLbl = new System.Windows.Forms.Label();
            this.Wednesday = new System.Windows.Forms.Label();
            this.ThursdayLbl = new System.Windows.Forms.Label();
            this.FridayLbl = new System.Windows.Forms.Label();
            this.SaturdayLbl = new System.Windows.Forms.Label();
            this.SundayLbl = new System.Windows.Forms.Label();
            this.PreviousBtn = new System.Windows.Forms.Button();
            this.NextBtn = new System.Windows.Forms.Button();
            this.YearMonthLBL = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AgendaBtn,
            this.ProfileBtn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1543, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // AgendaBtn
            // 
            this.AgendaBtn.Name = "AgendaBtn";
            this.AgendaBtn.Size = new System.Drawing.Size(60, 20);
            this.AgendaBtn.Text = "Agenda";
            // 
            // ProfileBtn
            // 
            this.ProfileBtn.Name = "ProfileBtn";
            this.ProfileBtn.Size = new System.Drawing.Size(53, 20);
            this.ProfileBtn.Text = "Profile";
            // 
            // DayContainer
            // 
            this.DayContainer.Location = new System.Drawing.Point(12, 121);
            this.DayContainer.Name = "DayContainer";
            this.DayContainer.Size = new System.Drawing.Size(1452, 647);
            this.DayContainer.TabIndex = 1;
            // 
            // MondayLbl
            // 
            this.MondayLbl.AutoSize = true;
            this.MondayLbl.Location = new System.Drawing.Point(76, 78);
            this.MondayLbl.Name = "MondayLbl";
            this.MondayLbl.Size = new System.Drawing.Size(51, 15);
            this.MondayLbl.TabIndex = 2;
            this.MondayLbl.Text = "Monday";
            // 
            // TuesdayLbl
            // 
            this.TuesdayLbl.AutoSize = true;
            this.TuesdayLbl.Location = new System.Drawing.Point(271, 78);
            this.TuesdayLbl.Name = "TuesdayLbl";
            this.TuesdayLbl.Size = new System.Drawing.Size(50, 15);
            this.TuesdayLbl.TabIndex = 3;
            this.TuesdayLbl.Text = "Tuesday";
            // 
            // Wednesday
            // 
            this.Wednesday.AutoSize = true;
            this.Wednesday.Location = new System.Drawing.Point(454, 78);
            this.Wednesday.Name = "Wednesday";
            this.Wednesday.Size = new System.Drawing.Size(68, 15);
            this.Wednesday.TabIndex = 4;
            this.Wednesday.Text = "Wednesday";
            // 
            // ThursdayLbl
            // 
            this.ThursdayLbl.AutoSize = true;
            this.ThursdayLbl.Location = new System.Drawing.Point(643, 78);
            this.ThursdayLbl.Name = "ThursdayLbl";
            this.ThursdayLbl.Size = new System.Drawing.Size(55, 15);
            this.ThursdayLbl.TabIndex = 5;
            this.ThursdayLbl.Text = "Thursday";
            // 
            // FridayLbl
            // 
            this.FridayLbl.AutoSize = true;
            this.FridayLbl.Location = new System.Drawing.Point(844, 78);
            this.FridayLbl.Name = "FridayLbl";
            this.FridayLbl.Size = new System.Drawing.Size(39, 15);
            this.FridayLbl.TabIndex = 6;
            this.FridayLbl.Text = "Friday";
            // 
            // SaturdayLbl
            // 
            this.SaturdayLbl.AutoSize = true;
            this.SaturdayLbl.Location = new System.Drawing.Point(1031, 78);
            this.SaturdayLbl.Name = "SaturdayLbl";
            this.SaturdayLbl.Size = new System.Drawing.Size(53, 15);
            this.SaturdayLbl.TabIndex = 7;
            this.SaturdayLbl.Text = "Saturday";
            // 
            // SundayLbl
            // 
            this.SundayLbl.AutoSize = true;
            this.SundayLbl.Location = new System.Drawing.Point(1227, 78);
            this.SundayLbl.Name = "SundayLbl";
            this.SundayLbl.Size = new System.Drawing.Size(46, 15);
            this.SundayLbl.TabIndex = 8;
            this.SundayLbl.Text = "Sunday";
            // 
            // PreviousBtn
            // 
            this.PreviousBtn.Location = new System.Drawing.Point(1277, 794);
            this.PreviousBtn.Name = "PreviousBtn";
            this.PreviousBtn.Size = new System.Drawing.Size(75, 23);
            this.PreviousBtn.TabIndex = 9;
            this.PreviousBtn.Text = "Previous";
            this.PreviousBtn.UseVisualStyleBackColor = true;
            this.PreviousBtn.Click += new System.EventHandler(this.PreviousBtn_Click);
            // 
            // NextBtn
            // 
            this.NextBtn.Location = new System.Drawing.Point(1399, 794);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(75, 23);
            this.NextBtn.TabIndex = 10;
            this.NextBtn.Text = "Next";
            this.NextBtn.UseVisualStyleBackColor = true;
            this.NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            // 
            // YearMonthLBL
            // 
            this.YearMonthLBL.AutoSize = true;
            this.YearMonthLBL.Location = new System.Drawing.Point(734, 31);
            this.YearMonthLBL.Name = "YearMonthLBL";
            this.YearMonthLBL.Size = new System.Drawing.Size(91, 15);
            this.YearMonthLBL.TabIndex = 11;
            this.YearMonthLBL.Text = "Year and month";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1543, 850);
            this.Controls.Add(this.YearMonthLBL);
            this.Controls.Add(this.NextBtn);
            this.Controls.Add(this.PreviousBtn);
            this.Controls.Add(this.SundayLbl);
            this.Controls.Add(this.SaturdayLbl);
            this.Controls.Add(this.FridayLbl);
            this.Controls.Add(this.ThursdayLbl);
            this.Controls.Add(this.Wednesday);
            this.Controls.Add(this.TuesdayLbl);
            this.Controls.Add(this.MondayLbl);
            this.Controls.Add(this.DayContainer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem AgendaBtn;
        private ToolStripMenuItem ProfileBtn;
        private FlowLayoutPanel DayContainer;
        private Label MondayLbl;
        private Label TuesdayLbl;
        private Label Wednesday;
        private Label ThursdayLbl;
        private Label FridayLbl;
        private Label SaturdayLbl;
        private Label SundayLbl;
        private Button PreviousBtn;
        private Button NextBtn;
        private Label YearMonthLBL;
    }
}