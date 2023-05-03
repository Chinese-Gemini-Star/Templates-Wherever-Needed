using System.Diagnostics;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Templates_Wherever_Needed.Models;
using Templates_Wherever_Needed.Views;

namespace Templates_Wherever_Needed.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty] private string _get_text = @"更改路径";
    [ObservableProperty] private string _get_hint = @"更改存放在本地的板子的路径";
    [ObservableProperty] private string _add_text = @"新建";
    [ObservableProperty] private string _add_hint = @"新建一个板子文件";
    [ObservableProperty] private Templates _templates;

    public async Task Init()
    {
        // 尝试获取配置文件中保存的路径
        var uri = Preferences.Default.Get("uri", "");

        // 如果不存在已设置的路径,要求用户给出一个路径(为了用户体验,允许取消)
        if (string.IsNullOrEmpty(uri))
        {
            // await Get(); // 存在bug,无法在页面刚初始化完成时弹出弹窗
        }
        else
        {
            await _read(uri, true);
        }
    }

    /**
     * 获取板子所在的目录
     */
    [RelayCommand]
    private async Task Get()
    {
        var uri = await App.Current.MainPage.DisplayPromptAsync("读取板子",
            "请指定板子存放位置,框架存在bug,安卓下不可使用",
            accept: "选择",
            cancel: "取消",
            placeholder: "只允许给出文件夹,如果不存在会自动创建");
        if (!string.IsNullOrEmpty(uri))
        {
            await _read(uri,true);
        }
    }

    /**
     * 读取板子所在的目录
     */
    private async Task _read(string uri,bool isRoot)
    {
        try
        {
            // 生成板子集
            Templates = new Templates(uri);
            Templates.Init();
            Debug.WriteLine("已读取路径:" + uri);
            if (isRoot)
            {
                Preferences.Default.Set("uri", uri);
            }
        }
        catch (DirectoryNotFoundException)
        {
            // 路径不合法
            await App.Current.MainPage.DisplayAlert("非法行为", "请给出正确的板子存放位置", "好的");
        }
        catch (UnauthorizedAccessException)
        {
            // 路径不合法或无管理员权限
            await App.Current.MainPage.DisplayAlert("非法行为", "路径不合法或无管理员权限", "好的");
        }
    }

    [RelayCommand]
    private void Select()
    {

    }

    [RelayCommand]
    private void Add()
    {
        Debug.WriteLine("新建板子");
    }
}