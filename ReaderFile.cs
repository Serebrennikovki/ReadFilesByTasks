using System.Text.RegularExpressions;

namespace ReadFilesByTasks;

public class ReaderFile
{
    private readonly string _path;

    public ReaderFile(string path)
    {
        _path = path;
    }

    public async Task<int>ReadFileAsync()
    {
        using var sreamReader = new StreamReader(_path);
        var text = await sreamReader.ReadToEndAsync();
        var regex = new Regex(@" ");
        MatchCollection matches = regex.Matches(text);
        return matches.Count;
    }
}