using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace Templates_Wherever_Needed.Models;

public class Templates : ObservableCollection<TemplateLike>, TemplateLike
{
    public Templates(string uri)
    {
        // 尝试粗略验证目录合法性
        Path.GetFullPath(uri);
        // 如果目录不存在则创建
        Directory.CreateDirectory(uri);
        // 读取所有根目录下的板子(即未分类的板子)
        _getTemplate(uri, null);
        // 读取所有根目录下的文件夹
        _getDirectory(uri);
    }

    public Templates(string uri, string name, string classify) : this(uri)
    {
        Name = name;
        Classify = classify;
        Lang = "Folder";
    }

    /**
     * 获取指定路径下的所有文件夹
     */
    private void _getDirectory(string uri)
    {
        var root = new DirectoryInfo(uri);
        // 遍历所有文件夹
        foreach (var dir in root.GetDirectories())
        {
            Debug.WriteLine(dir.FullName);
            // 将子目录添加到列表中
            Add(new Templates(dir.FullName,dir.Name,Classify)); // 分类记得改一下
        }
    }
    /**
     * 获取指定目录下的所有板子文件(.cpp和.c文件)
     */
    private void _getTemplate(string uri,string type)
    {
        var root = new DirectoryInfo(uri);
        
        // 读取所有CPP文件
        foreach (var f in root.GetFiles("*.cpp"))
        {
            Debug.WriteLine(f.FullName);
            Add(new Template(f.Name,"Cpp",Classify));
        }

        // 读取所有C文件
        foreach (var f in root.GetFiles("*.c"))
        {
            Debug.WriteLine(f.FullName);
            Add(new Template(f.Name, "C", Classify));
        }

        // 读取所有Py文件
        foreach (var f in root.GetFiles("*.py"))
        {
            Debug.Write(f.FullName);
            Add(new Template(f.Name, "Py", Classify));
        }
    }

    // 板子名
    public string Name
    {
        get; set;
    }

    // 板子语言
    public string Lang
    {
        get; set;
    }

    // 板子分类
    public string Classify
    {
        get; set;
    }
}