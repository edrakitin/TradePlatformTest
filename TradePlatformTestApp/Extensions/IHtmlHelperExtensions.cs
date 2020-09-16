using System;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TradePlatformTestApp.Extensions
{
    public static class IHtmlHelperExtensions
    {
        public static IHtmlContent ValidationSummaryAlert(this IHtmlHelper htmlHelper, Type modelType, bool excludePropertyErrors = false)
        {
            if (htmlHelper == null)
            {
                throw new ArgumentNullException(nameof(htmlHelper));
            }

            var modelState = htmlHelper.ViewData.ModelState;

            if (modelState.IsValid)
            {
                return new HtmlString(string.Empty);
            }
            
            var summary = htmlHelper.ValidationSummary(
                excludePropertyErrors,
                message: null,
                htmlAttributes: null,
                tag: null);

            var div = new TagBuilder("div");
            div.AddCssClass("alert alert-danger");
            div.InnerHtml.SetHtmlContent(summary);
            return div;
        }
    }
}
