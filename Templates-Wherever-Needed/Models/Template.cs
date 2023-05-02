namespace Templates_Wherever_Needed.Models;

public class Template : ITemplateLike
{
    public Template(string name, string lang, string classify)
    {
        Name = name;
        Lang = lang;
        Classify = classify;
    }

    // 板子名
    public string Name { get; set; }

    // 提示信息
    public string Description { get; set; } = "类型:";

    // 板子语言
    public string Lang { get; set; }

    // 板子分类
    public string Classify { get; set; }

    public string ICO { get; set; } = "note.png";
}