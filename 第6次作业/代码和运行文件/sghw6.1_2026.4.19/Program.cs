namespace UrlRegexFinder;

static class Program
{
    /// <summary>
    ///  应用程序主入口。
    /// </summary>
    [STAThread]
    static void Main()
    {
        // 初始化 WinForms 全局配置（如 DPI、默认字体等）。
        ApplicationConfiguration.Initialize();

        // 启动主窗体。
        Application.Run(new Form1());
    }    
}