using Microsoft.Data.Sqlite;

namespace sghw8._1_2026._5._6;

internal sealed class WordRepository
{
    private static readonly string DatabasePath = Path.Combine(AppContext.BaseDirectory, "words.db");
    private static readonly string ConnectionString = new SqliteConnectionStringBuilder
    {
        DataSource = DatabasePath
    }.ToString();

    public WordRepository()
    {
        InitializeDatabase();
    }

    public IReadOnlyList<WordEntry> GetAllWords()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT Id, English, ChineseMeaning FROM Words ORDER BY Id;";

        var words = new List<WordEntry>();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            words.Add(new WordEntry
            {
                Id = reader.GetInt32(0),
                English = reader.GetString(1),
                ChineseMeaning = reader.GetString(2)
            });
        }

        return words;
    }

    private static void InitializeDatabase()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var createTableCommand = connection.CreateCommand();
        createTableCommand.CommandText = """
            CREATE TABLE IF NOT EXISTS Words (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                English TEXT NOT NULL UNIQUE,
                ChineseMeaning TEXT NOT NULL
            );
            """;
        createTableCommand.ExecuteNonQuery();

        using var countCommand = connection.CreateCommand();
        countCommand.CommandText = "SELECT COUNT(*) FROM Words;";
        var count = Convert.ToInt32(countCommand.ExecuteScalar());

        if (count > 0)
        {
            return;
        }

        var seedWords = new (string English, string ChineseMeaning)[]
        {
            ("apple", "苹果"),
            ("banana", "香蕉"),
            ("computer", "电脑"),
            ("student", "学生"),
            ("library", "图书馆"),
            ("teacher", "老师"),
            ("beautiful", "美丽的"),
            ("friend", "朋友"),
            ("travel", "旅行"),
            ("knowledge", "知识"),
            ("language", "语言"),
            ("weather", "天气"),
            ("music", "音乐"),
            ("holiday", "假期"),
            ("window", "窗户"),
            ("garden", "花园"),
            ("picture", "图片"),
            ("important", "重要的"),
            ("morning", "早晨"),
            ("happiness", "幸福")
        };

        using var transaction = connection.BeginTransaction();
        foreach (var word in seedWords)
        {
            using var insertCommand = connection.CreateCommand();
            insertCommand.Transaction = transaction;
            insertCommand.CommandText = "INSERT INTO Words (English, ChineseMeaning) VALUES ($english, $meaning);";
            insertCommand.Parameters.AddWithValue("$english", word.English);
            insertCommand.Parameters.AddWithValue("$meaning", word.ChineseMeaning);
            insertCommand.ExecuteNonQuery();
        }

        transaction.Commit();
    }
}