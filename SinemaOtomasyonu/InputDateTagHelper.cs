using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SinemaOtomasyonu
{
        [HtmlTargetElement("input", Attributes = "is-accept-old-day")]
        public class InputDateTagHelper : TagHelper
        {
            [HtmlAttributeName("is-accept-old-day")]
            public bool OldDay { get; set; } = false;
            public override void Process(TagHelperContext context, TagHelperOutput output)
            {
                if (!OldDay)
                {

                    var dateTime = DateTime.Now;
                    var dd = dateTime.Day;
                    var mm = dateTime.Month;
                    var yyyy = dateTime.Year;

                    string newDay = Convert.ToString(dd);
                    string newMonth = Convert.ToString(mm);

                    if (dd < 10)
                    {
                        newDay = $"0{newDay}";
                    }
                    if (mm < 10)
                    {
                        newMonth = $"0{mm}";
                    }
                    var today = $"{yyyy}-{newMonth}-{newDay}";
                    output.Attributes.SetAttribute("min", today);
                }
            }
        }
    }
