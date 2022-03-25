namespace WeekplannerClassesLibrary
{
    partial class Activity
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
            this.TypeCB = new System.Windows.Forms.ComboBox();
            this.date_Picker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.time_Picker = new System.Windows.Forms.DateTimePicker();
            this.beschrijving_RTB = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.add_Btn = new System.Windows.Forms.Button();
            this.titel_Lbl = new System.Windows.Forms.Label();
            this.titel_TB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TypeCB
            // 
            this.TypeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeCB.FormattingEnabled = true;
            this.TypeCB.Items.AddRange(new object[] {
            "Activity",
            "Sport",
            "Afspraak"});
            this.TypeCB.Location = new System.Drawing.Point(107, 35);
            this.TypeCB.Name = "TypeCB";
            this.TypeCB.Size = new System.Drawing.Size(178, 23);
            this.TypeCB.TabIndex = 0;
            // 
            // date_Picker
            // 
            this.date_Picker.Location = new System.Drawing.Point(107, 217);
            this.date_Picker.Name = "date_Picker";
            this.date_Picker.Size = new System.Drawing.Size(200, 23);
            this.date_Picker.TabIndex = 1;
            this.date_Picker.Value = new System.DateTime(2022, 3, 21, 15, 23, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Time:";
            // 
            // time_Picker
            // 
            this.time_Picker.CustomFormat = "";
            this.time_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.time_Picker.Location = new System.Drawing.Point(107, 256);
            this.time_Picker.Name = "time_Picker";
            this.time_Picker.ShowUpDown = true;
            this.time_Picker.Size = new System.Drawing.Size(200, 23);
            this.time_Picker.TabIndex = 5;
            this.time_Picker.Value = new System.DateTime(2022, 3, 17, 10, 21, 0, 0);
            this.time_Picker.ValueChanged += new System.EventHandler(this.TimePicker_ValueChanged);
            // 
            // beschrijving_RTB
            // 
            this.beschrijving_RTB.Location = new System.Drawing.Point(107, 111);
            this.beschrijving_RTB.Name = "beschrijving_RTB";
            this.beschrijving_RTB.Size = new System.Drawing.Size(178, 96);
            this.beschrijving_RTB.TabIndex = 7;
            this.beschrijving_RTB.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Description:";
            // 
            // add_Btn
            // 
            this.add_Btn.Location = new System.Drawing.Point(151, 295);
            this.add_Btn.Name = "add_Btn";
            this.add_Btn.Size = new System.Drawing.Size(75, 23);
            this.add_Btn.TabIndex = 9;
            this.add_Btn.Text = "Add";
            this.add_Btn.UseVisualStyleBackColor = true;
            this.add_Btn.Click += new System.EventHandler(this.add_Btn_Click);
            // 
            // titel_Lbl
            // 
            this.titel_Lbl.AutoSize = true;
            this.titel_Lbl.Location = new System.Drawing.Point(31, 76);
            this.titel_Lbl.Name = "titel_Lbl";
            this.titel_Lbl.Size = new System.Drawing.Size(32, 15);
            this.titel_Lbl.TabIndex = 10;
            this.titel_Lbl.Text = "Titel:";
            // 
            // titel_TB
            // 
            this.titel_TB.Location = new System.Drawing.Point(110, 76);
            this.titel_TB.Name = "titel_TB";
            this.titel_TB.Size = new System.Drawing.Size(175, 23);
            this.titel_TB.TabIndex = 11;
            // 
            // Activity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 395);
            this.Controls.Add(this.titel_TB);
            this.Controls.Add(this.titel_Lbl);
            this.Controls.Add(this.add_Btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.beschrijving_RTB);
            this.Controls.Add(this.time_Picker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.date_Picker);
            this.Controls.Add(this.TypeCB);
            this.Name = "Activity";
            this.Text = "Activity";
            this.Load += new System.EventHandler(this.Activity_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox TypeCB;
        private DateTimePicker date_Picker;
        private Label label1;
        private Label label2;
        private Label label3;
        private DateTimePicker time_Picker;
        private RichTextBox beschrijving_RTB;
        private Label label4;
        private Button add_Btn;
        private Label titel_Lbl;
        private TextBox titel_TB;
    }
}