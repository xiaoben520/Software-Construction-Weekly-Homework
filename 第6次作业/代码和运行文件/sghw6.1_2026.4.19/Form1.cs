using System.Net.Http;
using System.Text.RegularExpressions;

namespace UrlRegexFinder;

public partial class Form1 : Form
{
    // 复用 HttpClient，避免频繁创建带来的资源开销。
    private static readonly HttpClient HttpClient = new();

    private readonly TextBox _txtUrl = new();
    private readonly Button _btnFetch = new();
    private readonly Label _lblStatus = new();
    private readonly TextBox _txtPhones = new();
    private readonly TextBox _txtEmails = new();

    public Form1()
    {
        InitializeComponent();
        InitializeUi();
    }

    private void InitializeUi()
    {
        Text = "URL 页面手机号与邮箱提取器";
        StartPosition = FormStartPosition.CenterScreen;
        ClientSize = new Size(950, 620);

        var lblUrl = new Label
        {
            Text = "URL:",
            AutoSize = true,
            Location = new Point(20, 23)
        };

        _txtUrl.Location = new Point(65, 20);
        _txtUrl.Size = new Size(700, 27);
        _txtUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        _txtUrl.Text = "https://example.com";

        _btnFetch.Text = "获取并提取";
        _btnFetch.Location = new Point(780, 18);
        _btnFetch.Size = new Size(140, 32);
        _btnFetch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        _btnFetch.Click += BtnFetch_ClickAsync;

        _lblStatus.Text = "请输入 URL 后点击“获取并提取”。";
        _lblStatus.AutoSize = true;
        _lblStatus.Location = new Point(20, 60);
        _lblStatus.ForeColor = Color.DimGray;

        var lblPhones = new Label
        {
            Text = "手机号：",
            AutoSize = true,
            Location = new Point(20, 95)
        };

        _txtPhones.Location = new Point(20, 120);
        _txtPhones.Size = new Size(430, 470);
        _txtPhones.Multiline = true;
        _txtPhones.ScrollBars = ScrollBars.Vertical;
        _txtPhones.ReadOnly = true;
        _txtPhones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;

        var lblEmails = new Label
        {
            Text = "邮箱：",
            AutoSize = true,
            Location = new Point(480, 95)
        };

        _txtEmails.Location = new Point(480, 120);
        _txtEmails.Size = new Size(440, 470);
        _txtEmails.Multiline = true;
        _txtEmails.ScrollBars = ScrollBars.Vertical;
        _txtEmails.ReadOnly = true;
        _txtEmails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

        Controls.Add(lblUrl);
        Controls.Add(_txtUrl);
        Controls.Add(_btnFetch);
        Controls.Add(_lblStatus);
        Controls.Add(lblPhones);
        Controls.Add(_txtPhones);
        Controls.Add(lblEmails);
        Controls.Add(_txtEmails);
    }

    private async void BtnFetch_ClickAsync(object? sender, EventArgs e)
    {
        var url = _txtUrl.Text.Trim();
        // 仅允许 http/https 绝对地址。
        if (!Uri.TryCreate(url, UriKind.Absolute, out var uri)
            || (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
        {
            MessageBox.Show("请输入合法的 http/https URL。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        ToggleUi(false);
        _lblStatus.Text = "正在请求页面...";
        _lblStatus.ForeColor = Color.DodgerBlue;
        _txtPhones.Clear();
        _txtEmails.Clear();

        try
        {
            // 下载网页源码。
            var html = await HttpClient.GetStringAsync(uri);

            // 中国大陆手机号（可带 +86 或 86 前缀）与常见邮箱格式。
            var phonePattern = @"(?<!\d)(?:\+?86[-\s]?)?1[3-9]\d{9}(?!\d)";
            var emailPattern = @"\b[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}\b";

            // 提取、去重并排序。
            var phones = Regex.Matches(html, phonePattern)
                .Select(m => m.Value)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(x => x)
                .ToList();

            var emails = Regex.Matches(html, emailPattern)
                .Select(m => m.Value)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(x => x)
                .ToList();

            // 将结果显示到界面。
            _txtPhones.Lines = phones.Count > 0 ? phones.ToArray() : ["（未找到手机号）"];
            _txtEmails.Lines = emails.Count > 0 ? emails.ToArray() : ["（未找到邮箱）"];

            _lblStatus.Text = $"提取完成：手机号 {phones.Count} 条，邮箱 {emails.Count} 条。";
            _lblStatus.ForeColor = Color.ForestGreen;
        }
        catch (Exception ex)
        {
            _lblStatus.Text = "请求失败。";
            _lblStatus.ForeColor = Color.IndianRed;
            MessageBox.Show($"获取页面失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            ToggleUi(true);
        }
    }

    private void ToggleUi(bool enabled)
    {
        _btnFetch.Enabled = enabled;
        _txtUrl.Enabled = enabled;
    }
}
