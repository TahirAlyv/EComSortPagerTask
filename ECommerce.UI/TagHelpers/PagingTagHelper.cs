using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Data.SqlClient;
using System.Text;

namespace ECommerce.UI.TagHelpers
{

    [HtmlTargetElement("porduct-list-pager")]
    public class PagingTagHelper:TagHelper
    {

        [HtmlAttributeName("page-size")]
        public int PageSize { get; set; }

        [HtmlAttributeName("page-count")]
        public int PageCount { get; set; }

        [HtmlAttributeName("current-page")]
        public int CurrentPage {  get; set; }


        [HtmlAttributeName("current-category")]
        public int CurrentCategory { get; set; }



        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "section";
            var sb= new StringBuilder();


            if(PageCount > 0)
            {
                sb.AppendFormat("<ul class='pagination'>");
                sb.AppendFormat("<li class='{0}'>", CurrentPage > 1 ? "page-item active" : "page-item disabled");
                sb.AppendFormat("<a class='page-link' href='/product/index?page={0}&category={1}'>Prev</a>",
                                CurrentPage > 1 ? CurrentPage - 1 : 1,
                                CurrentCategory);
                sb.AppendFormat("</li>");

                for (int i = 1; i <= PageCount; i++)
                {
                    sb.AppendFormat("<li class='{0}'>", (i == CurrentPage) ? "page-item active" : "page-item");
                    sb.AppendFormat("<a class='page-link' href='/product/index?page={0}&category={1}'>{2}</a>", i, CurrentCategory,i);
                    sb.AppendFormat("<li>");
                }
                sb.AppendFormat("<li class='{0}'>", CurrentPage < PageCount ? "page-item active" : "page-item disabled");
                sb.AppendFormat("<a class='page-link' href='/product/index?page={0}&category={1}'>Next</a>",
                             CurrentPage < PageCount ? CurrentPage + 1 : CurrentPage,
                             CurrentCategory);

                sb.AppendFormat("</ul>");
            }

            output.Content.SetHtmlContent(sb.ToString());

        }


    }
}
