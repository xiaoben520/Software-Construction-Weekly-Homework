namespace sghw8._1_2026._5._6;

public partial class Form1 : Form
{
    private readonly WordRepository repository = new();
    private List<WordEntry> words;
    private readonly Random rng = new();
    private readonly System.Windows.Forms.Timer nextWordTimer = new() { Interval = 700 };
    private int currentIndex;
    private bool isWaiting = false;

    public Form1()
    {
        InitializeComponent();

        words = repository.GetAllWords().OrderBy(_ => rng.Next()).ToList();
        nextWordTimer.Tick += NextWordTimer_Tick;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        if (words.Count == 0)
        {
            lblMeaning.Text = "数据库中没有单词。";
            txtAnswer.Enabled = false;
            btnRestart.Enabled = false;
            return;
        }

        ShowCurrentWord();
    }

    private void txtAnswer_KeyDown(object sender, KeyEventArgs e)
    {
        if (isWaiting || e.KeyCode != Keys.Enter || !txtAnswer.Enabled || nextWordTimer.Enabled)
        {
            return;
        }

        e.SuppressKeyPress = true;
        CheckAnswer();
    }

    private void btnRestart_Click(object sender, EventArgs e)
    {
        currentIndex = 0;
        // 重新洗牌并从头开始
        words = repository.GetAllWords().OrderBy(_ => rng.Next()).ToList();
        txtAnswer.Clear();
        txtAnswer.Enabled = true;
        btnRestart.Enabled = true;
        lblResult.Text = string.Empty;
        ShowCurrentWord();
    }

    private void CheckAnswer()
    {
        var currentWord = words[currentIndex];
        var answer = txtAnswer.Text.Trim();
        var isCorrect = string.Equals(answer, currentWord.English, StringComparison.OrdinalIgnoreCase);

        if (isCorrect)
        {
            lblResult.Text = "正确";
            lblResult.ForeColor = Color.DarkGreen;
            txtAnswer.Enabled = false;
            // 快速进入下一题
            nextWordTimer.Interval = 700;
            isWaiting = true;
            nextWordTimer.Start();
        }
        else
        {
            lblResult.Text = $"错误，正确：{currentWord.English}";
            lblResult.ForeColor = Color.Firebrick;
            txtAnswer.Enabled = false;
            // 给用户 3 秒钟看正确答案
            nextWordTimer.Interval = 3000;
            isWaiting = true;
            nextWordTimer.Start();
        }
    }

    private void NextWordTimer_Tick(object? sender, EventArgs e)
    {
        nextWordTimer.Stop();
        currentIndex++;

        if (currentIndex >= words.Count)
        {
            lblMeaning.Text = "已完成所有单词练习。";
            lblProgress.Text = $"总计 {words.Count} 个单词";
            txtAnswer.Clear();
            txtAnswer.Enabled = false;
            btnRestart.Enabled = true;
            return;
        }

        txtAnswer.Clear();
        // 退出等待状态并允许输入
        isWaiting = false;
        txtAnswer.Enabled = true;
        lblResult.Text = string.Empty;
        ShowCurrentWord();
    }

    private void btnIDK_Click(object sender, EventArgs e)
    {
        if (words == null || words.Count == 0) return;

        var currentWord = words[currentIndex];
        lblResult.Text = $"不会，正确：{currentWord.English}";
        lblResult.ForeColor = Color.Firebrick;
        txtAnswer.Enabled = false;
        // 显示正确答案 3 秒后进入下一题
        nextWordTimer.Interval = 3000;
        isWaiting = true;
        nextWordTimer.Start();
    }

    private void ShowCurrentWord()
    {
        var currentWord = words[currentIndex];
        lblMeaning.Text = currentWord.ChineseMeaning;
        lblProgress.Text = $"第 {currentIndex + 1} / {words.Count} 个";
        lblResult.Text = string.Empty;
        lblResult.ForeColor = SystemColors.ControlText;
        txtAnswer.Focus();
    }
}