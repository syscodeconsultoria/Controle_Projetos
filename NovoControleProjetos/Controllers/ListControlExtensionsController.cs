using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace System.Web.Mvc
{
    public static class ListControlExtensions
    {
        public static MvcHtmlString CheckBoxList(this HtmlHelper htmlHelper, string name,
                MultiSelectList listInfos, object htmlAttributes)
        {
            return CheckBoxList(htmlHelper, name, listInfos, Position.Vertical, htmlAttributes);
        }
        public static MvcHtmlString CheckBoxList(this HtmlHelper htmlHelper, string name,
                MultiSelectList listInfos, Position position, object htmlAttributes)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("This parameter cannot be null or empty!", "name");
            }
            if (listInfos == null)
            {
                throw new ArgumentException("This parameter cannot be null!", "listInfos");
            }
            //if (listInfos.Count<SelectListItem>() < 1)
            //{
            //    throw new ArgumentException("The count must be greater than 0!", "listInfos");
            //}
            List<string> selectedValues = (List<string>)listInfos.SelectedValues;
            StringBuilder sb = new StringBuilder();
            int lineNumber = 0;
            foreach (SelectListItem info in listInfos)
            {
                lineNumber++;
                

                TagBuilder builder = new TagBuilder("input");
                //TagBuilder builder2 = new TagBuilder("input");
                if (selectedValues.Contains(info.Value))
                {
                    builder.MergeAttribute("checked", "checked");
                }
                builder.MergeAttribute("type", "checkbox");
                builder.MergeAttribute("name", name);
                builder.MergeAttribute("value", info.Value);
                //builder.MergeAttribute("class", "form-control");
                builder.InnerHtml = info.Text;
                //builder2.InnerHtml = " inicio ";
                //builder2.MergeAttribute("type", "date");
                //builder2.MergeAttribute("class", "form-control");
                //sb.Append("<div class=\"col-md-3\">");
                sb.Append(builder.ToString(TagRenderMode.Normal));
                //sb.Append(builder2.ToString(TagRenderMode.Normal));
                
                if (position == Position.Vertical)
                {
                    sb.Append("<br />");
                }
                sb.Append(" ");
               


            }
            return new MvcHtmlString(sb.ToString());
        }


    }
    public enum Position
    {
        Vertical = 0,
        horizontal = 1
    }
}