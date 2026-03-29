namespace sghw4._1_20260329
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
            btnSelect1 = new Button();
            btnSelect2 = new Button();
            btnMerge = new Button();
            lblFile1 = new Label();
            lblFile2 = new Label();
            SuspendLayout();
            // 
            // btnSelect1
            // 
            btnSelect1.Location = new Point(64, 297);
            btnSelect1.Name = "btnSelect1";
            btnSelect1.Size = new Size(128, 51);
            btnSelect1.TabIndex = 0;
            btnSelect1.Text = "选择文件1";
            btnSelect1.UseVisualStyleBackColor = true;
            btnSelect1.Click += btnSelect1_Click;
            // 
            // btnSelect2
            // 
            btnSelect2.Location = new Point(244, 297);
            btnSelect2.Name = "btnSelect2";
            btnSelect2.Size = new Size(128, 51);
            btnSelect2.TabIndex = 1;
            btnSelect2.Text = "选择文件2";
            btnSelect2.UseVisualStyleBackColor = true;
            btnSelect2.Click += btnSelect2_Click;
            // 
            // btnMerge
            // 
            btnMerge.BackColor = SystemColors.ActiveCaption;
            btnMerge.Location = new Point(489, 297);
            btnMerge.Name = "btnMerge";
            btnMerge.Size = new Size(135, 51);
            btnMerge.TabIndex = 2;
            btnMerge.Text = "开始合并";
            btnMerge.UseVisualStyleBackColor = false;
            btnMerge.Click += btnMerge_Click;
            // 
            // lblFile1
            // 
            lblFile1.AutoSize = true;
            lblFile1.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFile1.Location = new Point(54, 234);
            lblFile1.Name = "lblFile1";
            lblFile1.Size = new Size(154, 32);
            lblFile1.TabIndex = 3;
            lblFile1.Text = "未选择文件1";
            // 
            // lblFile2
            // 
            lblFile2.AutoSize = true;
            lblFile2.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFile2.Location = new Point(244, 234);
            lblFile2.Name = "lblFile2";
            lblFile2.Size = new Size(154, 32);
            lblFile2.TabIndex = 4;
            lblFile2.Text = "未选择文件2";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblFile2);
            Controls.Add(lblFile1);
            Controls.Add(btnMerge);
            Controls.Add(btnSelect2);
            Controls.Add(btnSelect1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSelect1;
        private Button btnSelect2;
        private Button btnMerge;
        private Label lblFile1;
        private Label lblFile2;
    }
}
