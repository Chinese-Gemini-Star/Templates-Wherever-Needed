using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Xml.Linq;
using Templates_Wherever_Needed.Models;

namespace Templates_Wherever_Needed.ViewModels;

public partial class TemplatePageViewModel : ObservableObject, IQueryAttributable
{
    private Template template;
    
    [ObservableProperty] private bool _isReadOnly = true;
    [ObservableProperty] private string _default = @"该板子暂时没有填写代码,可点击编辑后在此处填写,或者手动在本地修改后点击更新";
    [ObservableProperty] private string _text = "aaaaaaaaaa";
    [ObservableProperty] private string _editor_text = @"启用编辑";
    [ObservableProperty] private string _renew_text = @"从本地更新";

    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        template = new Template(query["uri"].ToString(), query["lang"].ToString(), query["classify"].ToString());
        Text = template.Text;
    }

    [RelayCommand]
    private void Editor()
    {
        if (IsReadOnly)
        {
            IsReadOnly = false;
            Editor_text = @"关闭编辑";
        }
        else
        {
            IsReadOnly = true;
            Editor_text = @"启用编辑";
        }
    }
    
    [RelayCommand]
    private void Renew()
    {
        Text = template.Text;
    }
}