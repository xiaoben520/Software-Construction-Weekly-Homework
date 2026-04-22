using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Web;

namespace SearchSnippetApp;

public partial class Form1 : Form
{
    private static readonly HttpClient HttpClient = new() { Timeout = TimeSpan.FromSeconds(10) };

    public Form1()
    {
        InitializeComponent();
    }

    /// <summary>
    /// 点击搜索按钮，异步并行搜索百度和必应，提取前200字
    /// </summary>
    private async void btnSearch_Click(object sender, EventArgs e)
    {
        string keyword = txtKeyword.Text.Trim();

        if (string.IsNullOrWhiteSpace(keyword))
        {
            MessageBox.Show("请输入关键字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        btnSearch.Enabled = false;
        txtBaiduResult.Text = "正在搜索...";
        txtBingResult.Text = "正在搜索...";

        try
        {
            // 并行搜索两个引擎
            var baiduTask = SearchAsync("baidu", keyword);
            var bingTask = SearchAsync("bing", keyword);

            await Task.WhenAll(baiduTask, bingTask);

            txtBaiduResult.Text = baiduTask.Result;
            txtBingResult.Text = bingTask.Result;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"搜索失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnSearch.Enabled = true;
        }
    }

    /// <summary>
    /// 异步搜索指定搜索引擎
    /// </summary>
    private async Task<string> SearchAsync(string engine, string keyword)
    {
        try
        {
            string url = engine switch
            {
                "baidu" => $"https://m.baidu.com/s?word={HttpUtility.UrlEncode(keyword)}",
                "bing" => $"https://www.bing.com/search?q={HttpUtility.UrlEncode(keyword)}&setlang=zh-cn",
                _ => throw new ArgumentException("不支持的搜索引擎")
            };

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("User-Agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/124.0 Safari/537.36");

            using var response = await HttpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string html = await response.Content.ReadAsStringAsync();

            // 检测拦截页面
            if (IsBlockedPage(html, engine))
                return "搜索引擎触发了访问限制，请稍后重试。";

            // 提取文本
            return engine switch
            {
                "baidu" => ExtractFromBaidu(html),
                "bing" => ExtractFromBing(html),
                _ => "提取失败"
            };
        }
        catch (TaskCanceledException)
        {
            return $"{engine} 请求超时，请稍后重试。";
        }
        catch (Exception ex)
        {
            return $"{engine} 搜索失败：{ex.Message}";
        }
    }

    /// <summary>
    /// 从百度搜索结果中提取前200字
    /// </summary>
    private static string ExtractFromBaidu(string html)
    {
        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        // 优先提取摘要 > 内容
        var snippets = doc.DocumentNode.SelectNodes("//div[@class='c-abstract']")
            ?? doc.DocumentNode.SelectNodes("//div[contains(@class, 'result-content')]")
            ?? new HtmlNodeCollection(null);

        if (snippets != null && snippets.Count > 0)
        {
            foreach (var node in snippets.Take(3))
            {
                string text = CleanText(HttpUtility.HtmlDecode(node.InnerText));
                if (text.Length > 50)
                    return TakeFirstNCharacters(text, 200);
            }
        }

        // 回退：提取所有文本前200字
        string allText = CleanText(doc.DocumentNode.InnerText);
        return TakeFirstNCharacters(allText, 200);
    }

    /// <summary>
    /// 从必应搜索结果中提取前200字
    /// </summary>
    private static string ExtractFromBing(string html)
    {
        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        // 优先提取搜索结果摘要
        var snippets = doc.DocumentNode.SelectNodes("//li[@class='b_algo']//div[@class='b_caption']/p")
            ?? doc.DocumentNode.SelectNodes("//div[@class='b_caption']/p")
            ?? new HtmlNodeCollection(null);

        if (snippets != null && snippets.Count > 0)
        {
            foreach (var node in snippets.Take(3))
            {
                string text = CleanText(HttpUtility.HtmlDecode(node.InnerText));
                if (text.Length > 50)
                    return TakeFirstNCharacters(text, 200);
            }
        }

        // 回退：提取所有文本前200字
        string allText = CleanText(doc.DocumentNode.InnerText);
        return TakeFirstNCharacters(allText, 200);
    }

    /// <summary>
    /// 检测是否被搜索引擎拦截
    /// </summary>
    private static bool IsBlockedPage(string html, string engine)
    {
        string text = html.ToLower();
        return engine == "baidu" && (text.Contains("验证码") || text.Contains("网络不给力"))
               || engine == "bing" && text.Contains("unusual traffic");
    }

    /// <summary>
    /// 清理空白和噪声
    /// </summary>
    private static string CleanText(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return string.Empty;

        // 移除导航词和常见噪声
        text = System.Text.RegularExpressions.Regex.Replace(text, @"(百度首页|登录|设置|网页|资讯|视频|图片|隐私声明|使用条款|cookie)", " ");
        text = System.Text.RegularExpressions.Regex.Replace(text, @"\s+", " ").Trim();
        return text;
    }

    /// <summary>
    /// 取前N个字符（排除空白）
    /// </summary>
    private static string TakeFirstNCharacters(string text, int count)
    {
        var result = new System.Text.StringBuilder();
        int visibleChars = 0;

        foreach (char ch in text)
        {
            if (!char.IsWhiteSpace(ch))
            {
                result.Append(ch);
                visibleChars++;
                if (visibleChars >= count) break;
            }
        }

        return result.ToString();
    }
}
