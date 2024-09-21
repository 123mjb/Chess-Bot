using Discord;
using Discord.WebSocket;

public class Program
{
    private static DiscordSocketClient _client;
    public static async Task Main()
    {
        _client = new DiscordSocketClient();

        _client.Log += Log;

        //  You can assign your bot token to a string, and pass that in to connect.
        //  This is, however, insecure, particularly if you plan to have your code hosted in a public repository.

        DotNetEnv.Env.Load();
        // Some alternative options would be to keep your token in an Environment Variable or a standalone file.
        var token = Environment.GetEnvironmentVariable("ChessDiscordBotToken");
        if (token == null)
        {
            Console.WriteLine("Give The Bot Token");
            Environment.SetEnvironmentVariable("ChessDiscordBotToken", Console.ReadLine());
            token = Environment.GetEnvironmentVariable("ChessDiscordBotToken");
        }
        // var token = File.ReadAllText("token.txt");
        // var token = JsonConvert.DeserializeObject<AConfigurationClass>(File.ReadAllText("config.json")).Token;

        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        // Block this task until the program is closed.
        await Task.Delay(-1);
    }
    private static Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }
}
