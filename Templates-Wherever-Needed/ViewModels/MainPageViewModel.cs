using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Templates_Wherever_Needed.Models;
namespace Templates_Wherever_Needed.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty] private string _get_text = @"读取";
    [ObservableProperty] private string _get_hint = @"读取存放在本地的板子";
    [ObservableProperty] private string _add_text = @"新建";
    [ObservableProperty] private string _add_hint = @"新建一个板子文件";

    [RelayCommand]
    private async void Get()
    {
        var uri = await App.Current.MainPage.DisplayPromptAsync("读取板子",
            "请指定板子存放位置",
            accept: "选择",
            cancel: "取消",
            placeholder: "只允许给出文件夹,如果不存在会自动创建");
        if (string.IsNullOrEmpty(uri)) return;

        try
        {
            var templates = new Templates(uri);
        }
        catch (DirectoryNotFoundException)
        {
            // 路径不合法
            App.Current.MainPage.DisplayAlert("非法行为", "请给出正确的板子存放位置", "好的");
        }
        catch (UnauthorizedAccessException)
        {
            // 路径不合法或无管理员权限
            App.Current.MainPage.DisplayAlert("非法行为","路径不合法或无管理员权限","好的");
        }
    }

    [RelayCommand]
    private void Add() { }
}