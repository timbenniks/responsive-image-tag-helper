using Microsoft.AspNetCore.Razor.TagHelpers;

namespace mvc.TagHelpers
{
    [HtmlTargetElement("responsive-image")]
    public class ResponsiveImageTagHelper : TagHelper
    {
        public string FallbackSize { get; set; }
        public string BaseImageUrl { get; set; }
        public string Sizes { get; set; }
        public string Srcset { get; set; }
        public string Lazy { get; set; }        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var src = Lazy == "true" ? "data-src" : "src";
            var srcset = Lazy == "true" ? "data-srcset" : "srcset";
            
            output.TagName = "img";

            output.Attributes.RemoveAll("base-image-url");
            output.Attributes.RemoveAll("srcset");
            output.Attributes.RemoveAll("sizes");
            output.Attributes.RemoveAll("lazy");
            output.Attributes.RemoveAll("fallback-size");

            output.Attributes.SetAttribute(src, createFallback());
            output.Attributes.SetAttribute(srcset, createSrcset());
            output.Attributes.SetAttribute("sizes", Sizes);
        }
        public string createSrcset(){
            var widths = Srcset.Split(',');
            var result = "";
            foreach (var width in widths)
            {
                result += $"{createUrl(BaseImageUrl, width)} {width}w,";
            }

            result = result.TrimEnd(',');

            return result;
        }
        public string createUrl(string url, string width){
            return $"{url}?as=1&w={width}&hash={getHash(width)}";
        }
        public string getHash(string width){
            return "78612378123867132786123867123786";
        }
        public string createFallback(){
            return createUrl(BaseImageUrl, FallbackSize);
        }
    }
}