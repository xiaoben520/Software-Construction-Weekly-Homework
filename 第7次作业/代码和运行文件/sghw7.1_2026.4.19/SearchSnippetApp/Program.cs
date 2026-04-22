namespace SearchSnippetApp;

static class Program
{

    [STAThread]
    static void Main()
    {
        // 初始化应用程序配置
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}
