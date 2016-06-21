namespace EntertainmentSystem.Web.Infrastructure.HtmlHelpers
{
    using System.Web.Mvc;

    public static class FontAwesomeHelpers
    {
        // <button class="commentBtn btn btn-dark pull-left">
        //     <i class="fa fa-fw fa-3x fa-comment"></i>
        //     <br/>
        //     <span>Name</span>
        // </button>
        public static MvcHtmlString FontAwesomeButton(this HtmlHelper helper, string value, string fontType, object htmlAttributes = null, int fontSize = 3)
        {
            var button = new TagBuilder("button");
            button.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            var buttonValue = new TagBuilder("span");
            buttonValue.InnerHtml = value;

            button.AddCssClass("btn btn-dark");

            var fontAwesome = new TagBuilder("i");
            fontAwesome.AddCssClass(string.Format("fa fa-fw fa-{0} fa-{1}x", fontType, fontSize));

            button.InnerHtml = string.Format("{0}{1}{2}", fontAwesome.ToString(), "<br/>", buttonValue.ToString());

            return new MvcHtmlString(button.ToString());
        }
    }
}
