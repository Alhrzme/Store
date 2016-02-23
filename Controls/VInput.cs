using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Store.Controls
{
    public class VInput : WebControl
    {
        private string nspace = "Store.Models";

        public string Namespace
        {
            get { return nspace; }
            set { nspace = value; }
        }
        public string ModelType
        {
            get;
            set;
        }

        public string Property { get; set; }

        protected override void RenderContents(HtmlTextWriter output)
        {

            output.AddAttribute(HtmlTextWriterAttribute.Id, Property.ToLower());
            output.AddAttribute(HtmlTextWriterAttribute.Name, Property.ToLower());

            Type modelType = Type.GetType(string.Format("{0}.{1}", Namespace, ModelType));
            PropertyInfo propInfo = modelType.GetProperty(Property);
            var requiredAttr = propInfo.GetCustomAttribute<RequiredAttribute>(false);
            if (requiredAttr != null)
            {
                output.AddAttribute("data-val", "true");
                output.AddAttribute("data-val-required", requiredAttr.ErrorMessage);
            }
            var regExAttr = propInfo.GetCustomAttribute<RegularExpressionAttribute>(false);
            if (regExAttr != null)
            {
                output.AddAttribute("data-val-regex", regExAttr.ErrorMessage);
                output.AddAttribute("data-val-regex-pattern", regExAttr.Pattern);
            }
            output.RenderBeginTag("input");
            output.RenderEndTag();
        }

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
        }
        public override void RenderEndTag(HtmlTextWriter writer)
        {
        }
    }
}
