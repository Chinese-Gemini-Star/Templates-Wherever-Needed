namespace Templates_Wherever_Needed.Models;

public class Template : ITemplateLike
{
    private readonly string _uri;

    public Template(string uri, string lang, string classify)
    {
        _uri = uri;
        Name = Path.GetFileNameWithoutExtension(uri);
        Lang = lang;
        Classify = classify;
    }

    public string Text
    {
        get => File.ReadAllText(_uri);
        set => File.WriteAllText(_uri, value);
    }

    public string Uri => _uri;

    // 板子名
    public string Name { get; set; }

    // 提示信息
    public string Description { get; set; } = "类型:";

    // 板子语言
    public string Lang { get; set; }

    // 板子分类
    public string Classify { get; set; } = "";

    public string ICO { get; set; } = "note.png";
}