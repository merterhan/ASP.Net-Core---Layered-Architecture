using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARCH.Core.Entities;
using ARCH.Entities.Concrete;
using ARCH.Web.Entities;
using ARCH.Web.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ARCH.Web.TagHelpers
{
    [HtmlTargetElement("pager")]
    public class PagingTagHelper : TagHelper
    {
        [HtmlAttributeName("page-size")]
        public int PageSize { get; set; }
        [HtmlAttributeName("page-count")]
        public int PageCount { get; set; }
        [HtmlAttributeName("current-page")]
        public int CurrentPage { get; set; }
        [HtmlAttributeName("route")]
        public string Route { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 1; i <= PageCount; i++)
            {
                stringBuilder.AppendFormat("<a href={0} class={1}>{2}</a>", Route + "?page=" + i,
                    i == CurrentPage ? "btn btn-default active" : "btn btn-default", i);
            }

            output.Content.SetHtmlContent(stringBuilder.ToString());

            base.Process(context, output);
        }
    }
}
