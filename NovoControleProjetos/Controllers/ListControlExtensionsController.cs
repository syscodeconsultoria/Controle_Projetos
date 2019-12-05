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
                MultiSelectList listInfos, object htmlAttributes, int? qtdDatas)
        {
            return CheckBoxList(htmlHelper, name, listInfos, Position.Vertical, htmlAttributes, qtdDatas);
        }
        public static MvcHtmlString CheckBoxList(this HtmlHelper htmlHelper, string name, MultiSelectList listInfos, Position position, object htmlAttributes, int? qtdDatas)
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

                StringBuilder htmlStr = new StringBuilder("");
                TagBuilder builder = new TagBuilder("input");
               TagBuilder builder2 = new TagBuilder("input");
                if (selectedValues.Contains(info.Value))
                {
                    builder.MergeAttribute("checked", "checked");
                }

                
                builder.MergeAttribute("type", "checkbox");
                builder.MergeAttribute("name", name);
                builder.MergeAttribute("value", info.Value);
                //builder.MergeAttribute("class", "form-control");
                builder.InnerHtml = info.Text;
                
                if(qtdDatas == 2) { 
                builder2.MergeAttribute("type", "text");
                builder2.MergeAttribute("class", "form-control");
                builder2.MergeAttribute("onkeypress", "mascara(this, mdata)");
                builder2.MergeAttribute("size", "14");
                builder2.MergeAttribute("maxlength", "10");
                builder2.MergeAttribute("placeholder", "DD/MM/AAAA");
                }

                //builder2.AddCssClass("style");
                //builder2.InnerHtml = " inicio ";
                //sb.Append("<div class=\"col-md-3\">");

                sb.Append("<div class='row'>");

                sb.Append("<div class='col-md-3' id='div" + info.Text + "'>");
                sb.Append(builder.ToString(TagRenderMode.Normal));
                sb.Append("</div>");

                if(qtdDatas == 2) { 
                sb.Append("<div class='col-md-3' id='sbDataInicio" + info.Text + "'>");
                sb.Append(builder2.ToString(TagRenderMode.Normal));              
                sb.Append("</div>");
                sb.Append("<div class='col-md-3' id='sbDataFim" + info.Text + "'>");
                sb.Append(builder2.ToString(TagRenderMode.Normal));
                sb.Append("</div>");
                }

                sb.Append("</div>");

                //if (position == Position.Vertical)
                //{
                //    sb.Append("<br />");
                //}




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