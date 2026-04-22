namespace SearchSnippetApp;

partial class Form1
{

    private System.ComponentModel.IContainer components = null;


    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows 窗体设计器生成的代码

    /// <summary>
    ///  设计器支持所需的方法 - 不要使用代码编辑器修改
    ///  此方法的内容。
    /// </summary>
    private void InitializeComponent()
    {
        lblKeyword = new Label();
        txtKeyword = new TextBox();
        btnSearch = new Button();
        lblBaidu = new Label();
        lblBing = new Label();
        txtBaiduResult = new TextBox();
        txtBingResult = new TextBox();
        SuspendLayout();
        // 
        // lblKeyword
        // 
        lblKeyword.AutoSize = true;
        lblKeyword.Location = new Point(24, 26);
        lblKeyword.Name = "lblKeyword";
        lblKeyword.Size = new Size(68, 24);
        lblKeyword.TabIndex = 0;
        lblKeyword.Text = "关键字";
        // 
        // txtKeyword
        // 
        txtKeyword.Location = new Point(101, 22);
        txtKeyword.Name = "txtKeyword";
        txtKeyword.Size = new Size(700, 30);
        txtKeyword.TabIndex = 1;
        // 
        // btnSearch
        // 
        btnSearch.Location = new Point(821, 20);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new Size(150, 35);
        btnSearch.TabIndex = 2;
        btnSearch.Text = "搜索";
        btnSearch.UseVisualStyleBackColor = true;
        btnSearch.Click += btnSearch_Click;
        // 
        // lblBaidu
        // 
        lblBaidu.AutoSize = true;
        lblBaidu.Location = new Point(24, 77);
        lblBaidu.Name = "lblBaidu";
        lblBaidu.Size = new Size(100, 24);
        lblBaidu.TabIndex = 3;
        lblBaidu.Text = "Baidu 结果";
        // 
        // lblBing
        // 
        lblBing.AutoSize = true;
        lblBing.Location = new Point(508, 77);
        lblBing.Name = "lblBing";
        lblBing.Size = new Size(88, 24);
        lblBing.TabIndex = 4;
        lblBing.Text = "Bing 结果";
        // 
        // txtBaiduResult
        // 
        txtBaiduResult.Location = new Point(28, 110);
        txtBaiduResult.Multiline = true;
        txtBaiduResult.Name = "txtBaiduResult";
        txtBaiduResult.ReadOnly = true;
        txtBaiduResult.ScrollBars = ScrollBars.Vertical;
        txtBaiduResult.Size = new Size(450, 480);
        txtBaiduResult.TabIndex = 5;
        // 
        // txtBingResult
        // 
        txtBingResult.Location = new Point(512, 110);
        txtBingResult.Multiline = true;
        txtBingResult.Name = "txtBingResult";
        txtBingResult.ReadOnly = true;
        txtBingResult.ScrollBars = ScrollBars.Vertical;
        txtBingResult.Size = new Size(450, 480);
        txtBingResult.TabIndex = 6;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(10F, 24F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1000, 620);
        Controls.Add(txtBingResult);
        Controls.Add(txtBaiduResult);
        Controls.Add(lblBing);
        Controls.Add(lblBaidu);
        Controls.Add(btnSearch);
        Controls.Add(txtKeyword);
        Controls.Add(lblKeyword);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "搜索结果文字摘抄（异步并行版）";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblKeyword;
    private TextBox txtKeyword;
    private Button btnSearch;
    private Label lblBaidu;
    private Label lblBing;
    private TextBox txtBaiduResult;
    private TextBox txtBingResult;
}
