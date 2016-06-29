using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CmsApplication.Models
{
    public class JsConfigFile
    {
        public JsConfigFile()
        {
            component = new List<Component>();
            series = new List<Series>();
        }

        //new

        public string Color1 { get; set; }

        public string Color2 { get; set; }
        public string Color3 { get; set; }
        public string Color4 { get; set; }

        public string Color5 { get; set; }
        public string Color6 { get; set; }
        public string Color7 { get; set; }
        public string Color8 { get; set; }
        public string Color9 { get; set; }
        public string Color10 { get; set; }
        public string Color11 { get; set; }
        public string Color12 { get; set; }
        public string Color13 { get; set; }
        public string Color14 { get; set; }
        public string Color15 { get; set; }
        public string Color16 { get; set; }

        public string Color17 { get; set; }
        public string Color18 { get; set; }
        public string Color19 { get; set; }
        public string Color20 { get; set; }
        public string Color21 { get; set; }public string Color22 { get; set; }
        public string Color23 { get; set; }
        public string Color24 { get; set; }
        public string Color25 { get; set; }
        public string Color26 { get; set; }
        public string GAnalytics { get; set; }

        public string MenuImageUrl { get; set; }
        public string AdminParams { get; set; }

        public string PrevArrowUrl { get; set; }
        public string NextArrowUrl { get; set; }
        
        


        //end

        public string ClientName { get; set; }
        public string FooterImageUrl { get; set; }
        public string BaseUrl { get; set; }
        public string headerTabsForegroundColor { get; set; }
        public string matchTabsForegroundColor { get; set; }
        public string TabsSelectedBackgroundColor { get; set; }
        public string TabsSelectedForegroundColor { get; set; }
        public string TabsHoveredBackgroundColor { get; set; }
        public string TabsHoveredForegroundColor { get; set; }

        public string MatchLocalTimeTextColor { get; set; }
        public string scoreboardBackgroundColor { get; set; }
        public string seriesNameTextColor { get; set; }

        public string navLeftRightButtonsColor { get; set; }
        public string componentHeaderBackgroundColor { get; set; }
        public string componentHeaderForegroundColorTopComponents { get; set; }
        public string componentHeaderForegroundColorBottomComponents { get; set; }
        public bool isAfp { get; set; }
        public string scoreboardheight { get; set; }
        public string scoreboardwidth { get; set; }
        public string baseUrl { get; set; }
        public List<Component> component { get; set; }
        public List<Series> series { get; set; }



    }
}