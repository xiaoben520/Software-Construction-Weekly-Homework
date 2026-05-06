namespace sghw8._1_2026._5._6;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private Label lblTitle;
    private Label lblMeaningCaption;
    private Label lblMeaning;
    private Label lblAnswerCaption;
    private TextBox txtAnswer;
    private Label lblResult;
    private Label lblProgress;
    private Button btnRestart;
    private Button btnIDK;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitle = new Label();
        lblMeaningCaption = new Label();
        lblMeaning = new Label();
        lblAnswerCaption = new Label();
        txtAnswer = new TextBox();
        lblResult = new Label();
        lblProgress = new Label();
        btnRestart = new Button();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
        lblTitle.Location = new Point(24, 20);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(372, 38);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "小型背单词程序";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblMeaningCaption
        // 
        lblMeaningCaption.AutoSize = true;
        lblMeaningCaption.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
        lblMeaningCaption.Location = new Point(31, 79);
        lblMeaningCaption.Name = "lblMeaningCaption";
        lblMeaningCaption.Size = new Size(107, 20);
        lblMeaningCaption.TabIndex = 1;
        lblMeaningCaption.Text = "中文词义：";
        // 
        // lblMeaning
        // 
        lblMeaning.BorderStyle = BorderStyle.FixedSingle;
        lblMeaning.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        lblMeaning.Location = new Point(34, 108);
        lblMeaning.Name = "lblMeaning";
        lblMeaning.Size = new Size(362, 54);
        lblMeaning.TabIndex = 2;
        lblMeaning.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblAnswerCaption
        // 
        lblAnswerCaption.AutoSize = true;
        lblAnswerCaption.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
        lblAnswerCaption.Location = new Point(31, 179);
        lblAnswerCaption.Name = "lblAnswerCaption";
        lblAnswerCaption.Size = new Size(107, 20);
        lblAnswerCaption.TabIndex = 3;
        lblAnswerCaption.Text = "请输入英文：";
        // 
        // txtAnswer
        // 
        txtAnswer.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        txtAnswer.Location = new Point(34, 207);
        txtAnswer.Name = "txtAnswer";
        txtAnswer.Size = new Size(362, 28);
        txtAnswer.TabIndex = 4;
        txtAnswer.KeyDown += txtAnswer_KeyDown;
        // 
        // lblResult
        // 
        lblResult.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        lblResult.Location = new Point(34, 253);
        lblResult.Name = "lblResult";
        lblResult.Size = new Size(362, 28);
        lblResult.TabIndex = 5;
        lblResult.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblProgress
        // 
        lblProgress.AutoSize = true;
        lblProgress.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        lblProgress.Location = new Point(34, 296);
        lblProgress.Name = "lblProgress";
        lblProgress.Size = new Size(64, 17);
        lblProgress.TabIndex = 6;
        lblProgress.Text = "进度";
        // 
        // btnRestart
        // 
        btnRestart.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        btnRestart.Location = new Point(301, 287);
        btnRestart.Name = "btnRestart";
        btnRestart.Size = new Size(95, 31);
        btnRestart.TabIndex = 7;
        btnRestart.Text = "重新开始";
        btnRestart.UseVisualStyleBackColor = true;
        btnRestart.Click += btnRestart_Click;

        // 
        // btnIDK
        // 
        btnIDK = new Button();
        btnIDK.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        btnIDK.Location = new Point(194, 287);
        btnIDK.Name = "btnIDK";
        btnIDK.Size = new Size(95, 31);
        btnIDK.TabIndex = 8;
        btnIDK.Text = "我不会";
        btnIDK.UseVisualStyleBackColor = true;
        btnIDK.Click += btnIDK_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(428, 339);
        Controls.Add(btnRestart);
        Controls.Add(btnIDK);
        Controls.Add(lblProgress);
        Controls.Add(lblResult);
        Controls.Add(txtAnswer);
        Controls.Add(lblAnswerCaption);
        Controls.Add(lblMeaning);
        Controls.Add(lblMeaningCaption);
        Controls.Add(lblTitle);
        Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "背单词程序";
        Load += Form1_Load;
        ResumeLayout(false);
        PerformLayout();
    }
}