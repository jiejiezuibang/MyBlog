using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace MyBlogMod
{
    public class BlogNews:BaseId
    {
        // 文章标题
        // 带中文用nvarchar比较好
        [SugarColumn(ColumnDataType = "nvarchar(30)")]
        public string Title { get; set; }
        // 文章内容
        [SugarColumn(ColumnDataType = "text")]
        public string Context { get; set; }
        // 文章时间
        public DateTime Time { get; set; }
        // 文章浏览量
        public int BrowseCount { get; set; }
        // 文章点赞量
        public int LikeCount { get; set; }
        // 文章类型
        public int TypeId { get; set; }
        // 作者Id
        public int WriterId { get; set; }
        // 类型:不映射到数据库
        [SugarColumn(IsIgnore = true)]
        public TypeInfo TypeInfo { get; set; }
        [SugarColumn(IsIgnore =true)]
        public WriterInfo writerInfo { get; set; }
    }
}
