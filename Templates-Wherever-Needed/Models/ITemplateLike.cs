namespace Templates_Wherever_Needed.Models;

public interface ITemplateLike
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Lang { get; set; }
    public string Classify { get; set; }
    public string ICO { get; set; }
}

