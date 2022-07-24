using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace MyBlogMod
{
    public class TypeInfo:BaseId
    {
        // 文章类型名称
        [SugarColumn(ColumnDataType ="nvarchar(20)")]
        public string Name { get; set; }
    }
}
