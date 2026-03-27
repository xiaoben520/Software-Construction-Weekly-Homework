namespace MyAlarmClock
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
            lblTime = new Label();
            btnAdd = new Button();
            btnDelete = new Button();
            listAlarms = new ListBox();
            dtpAlarms = new DateTimePicker();
            SuspendLayout();
            // 
            // lblTime
            // 
            lblTime.Font = new Font("Microsoft YaHei UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTime.Location = new Point(73, 87);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(300, 81);
            lblTime.TabIndex = 0;
            lblTime.Text = "00:00:00";
            lblTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(83, 329);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "添加闹钟";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(261, 329);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "删除闹钟";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // listAlarms
            // 
            listAlarms.Font = new Font("Microsoft YaHei UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listAlarms.FormattingEnabled = true;
            listAlarms.Location = new Point(401, 12);
            listAlarms.Name = "listAlarms";
            listAlarms.Size = new Size(309, 389);
            listAlarms.TabIndex = 3;
            // 
            // dtpAlarms
            // 
            dtpAlarms.Font = new Font("Microsoft YaHei UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpAlarms.Format = DateTimePickerFormat.Time;
            dtpAlarms.Location = new Point(139, 261);
            dtpAlarms.Name = "dtpAlarms";
            dtpAlarms.Size = new Size(160, 42);
            dtpAlarms.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dtpAlarms);
            Controls.Add(listAlarms);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(lblTime);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label lblTime;
        private Button btnAdd;
        private Button btnDelete;
        private ListBox listAlarms;
        private DateTimePicker dtpAlarms;
    }
}
