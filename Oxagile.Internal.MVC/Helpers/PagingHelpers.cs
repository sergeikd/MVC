using Oxagile.Internal.MVC.Models;
using System;
using System.Text;
using System.Web.Mvc;

namespace Oxagile.Internal.MVC.Helpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
            PageInfo pageInfo, Func<int, string> pageUrl)
        {
            var pageNum = pageInfo.PageNumber;
            var result = new StringBuilder();
            var buttons = new[]
            {
                new {Mark = "<<", Page = 1},
                new {Mark = "<", Page = pageNum <= 1 ? 1 : pageNum - 1},
                new {Mark = ">", Page = pageNum >= pageInfo.TotalPages ? pageInfo.TotalPages : pageNum + 1},
                new {Mark = ">>", Page = pageInfo.TotalPages}
            };
            foreach (var button in buttons)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(button.Page));
                tag.InnerHtml = button.Mark;
                tag.AddCssClass("btn btn-default");
                result.Append(tag);
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}