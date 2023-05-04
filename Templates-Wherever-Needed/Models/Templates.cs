using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Templates_Wherever_Needed.Models;

public class Templates : ObservableCollection<ITemplateLike>, ITemplateLike
{
    // 当前文件夹
    private readonly DirectoryInfo _root;
    
    public Templates(string uri, string name, string classify) : this(uri, classify)
    {
        Name = name;
        Lang = "";
    }

    public Templates(string uri, string classify = "")
    {
        // 如果目录不存在则创建
        Directory.CreateDirectory(uri);
        // 打开当前路径
        _root = new DirectoryInfo(uri);
        // 非根目录设置当前分类名
        if (!string.IsNullOrEmpty(classify))
        {
            Classify = classify + "/" + _root.Name;
        }
    }

    public void Init()
    {
        // 防止重复添加
        Clear();
        // 读取所有当前目录下的板子(即未分类的板子)
        _getTemplate();
        // 读取所有当前目录下的文件夹
        _getDirectory();
    }

    /**
     * 获取指定路径下的所有文件夹
     */
    private void _getDirectory()
    {
        // 遍历所有文件夹
        foreach (var dir in _root.GetDirectories())
        {
            if((dir.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden) 
                continue;
            Debug.WriteLine(dir.FullName);
            // 将子目录添加到列表中
            Add(new Templates(dir.FullName,dir.Name,Classify));
        }
    }
    /**
     * 获取指定目录下的所有板子文件(.cpp和.c文件)
     */
    private void _getTemplate()
    {
        // 读取所有CPP文件
        _addTemplatesByLang("CPP", "*.cpp");

        // 读取所有H文件
        _addTemplatesByLang("H","*.h");

        // 读取所有C文件
        _addTemplatesByLang("C", "*.c");

        // 读取所有Py文件
        _addTemplatesByLang("Py", "*.py");
    }

    /**
     * 读取指定语言的板子
     */
    private void _addTemplatesByLang(string lang, string langType)
    {
        foreach (var f in _root.GetFiles(langType))
        {
            if ((f.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                continue;
            Debug.WriteLine(f.FullName);
            Add(new Template(f.FullName, lang, Classify));
        }
    }

    // 板子名
    public string Name { get; set; }

    // 提示信息
    public string Description { get; set; } = "子分类";

    // 板子语言
    public string Lang { get; set; }

    // 板子分类
    public string Classify { get; set; } = "";

    public string ICO { get; set; } = "folder.png";
}