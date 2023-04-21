using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templates_Wherever_Needed.Models
{
    internal class About
    {
        public string Title => @"哪里需要哪里板";
        public string Version => AppInfo.VersionString;
        public string Description => @"一个兴趣使然的针对算法竞赛所使用的板子的管理平台.
更多功能正在陆续上线中.";
    }
}
