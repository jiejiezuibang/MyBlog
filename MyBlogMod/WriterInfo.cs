using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace MyBlogMod
{
    public class WriterInfo:BaseId
    {
        // 作者名称
        [SugarColumn(ColumnDataType ="nvarchar(12)")]
        public string Name { get; set; }
        [SugarColumn(ColumnDataType = "nvarchar(16)")]
        // 作者账号
        public string UserName { get; set; }
        // 作者账号密码
        [SugarColumn(ColumnDataType = "nvarchar(64)")]
        public string UserPwd { get; set; }
    }
}
