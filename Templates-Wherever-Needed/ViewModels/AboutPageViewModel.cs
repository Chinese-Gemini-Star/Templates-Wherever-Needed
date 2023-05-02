using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Templates_Wherever_Needed.ViewModels;

public partial class AboutPageViewModel : ObservableObject
{
    [ObservableProperty] private string _title = @"哪里需要哪里板";
    [ObservableProperty] private string _version = AppInfo.VersionString;
    [ObservableProperty] private string _description = @"一个兴趣使然的针对算法竞赛所使用的板子的管理平台.";
    [ObservableProperty] private string _other = @"更多功能正在陆续上线中.";
}