using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.IO;
using CmsApplication.Models;

namespace CmsApplication.Code
{
    public class JavaScriptParser
    {

        public void ParseVariables(string path,out JsConfigFile jsConfig)
        {
            Component component = new Component();
            jsConfig = new JsConfigFile();
            List<Series> lstSeries = new List<Series>();
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(path))
            {
                body = reader.ReadToEnd();
            }

            //Match m = Regex.Match(body, "^var headerTabsForegroundColor =.*;$");

            var headerTabsForegroundColor = new Regex(@"var\s+(headerTabsForegroundColor)\s*=\s*""([a-zA-Z0-9#]*)""");
            var headerTabsForegroundColorMatch = headerTabsForegroundColor.Match(body);
            var valueOfHeaderTabForegroundColorMatch = headerTabsForegroundColorMatch.Groups[2].Value;
            //var val = match.Groups[3].Value;
            jsConfig.headerTabsForegroundColor = valueOfHeaderTabForegroundColorMatch;



            var BaseUrl = new Regex(@"var\s+(baseUrl)\s*=\s*""([a-zA-Z0-9\.//:]*)""");
            var BaseUrlMatch = BaseUrl.Match(body);
            var valueOfBaseUrlMatch = BaseUrlMatch.Groups[2].Value;
            //var val = match.Groups[3].Value;
            jsConfig.BaseUrl = valueOfBaseUrlMatch;

            var FooterImageUrl = new Regex(@"var\s+(footerImageUrl)\s*=\s*""([a-zA-Z0-9\.//:]*)""");
            var FooterImageUrlMatch = FooterImageUrl.Match(body);
            var valueOfFooterImageUrlMatch = FooterImageUrlMatch.Groups[2].Value;
            //var val = match.Groups[3].Value;
            jsConfig.FooterImageUrl = valueOfFooterImageUrlMatch;



            var omps = 20;

           var matchTabsForegroundColor = new Regex(@"var\s+(matchTabsForegroundColor)\s*=\s*""([a-zA-Z0-9#]*)""");
           var matchTabsForegroundColorMatch = matchTabsForegroundColor.Match(body);
           var valueOfMatchTabsForegroundColorMatch = matchTabsForegroundColorMatch.Groups[2].Value;

           jsConfig.matchTabsForegroundColor = valueOfMatchTabsForegroundColorMatch;


            var TabsSelectedBackgroundColor = new Regex(@"var\s+(TabsSelectedBackgroundColor)\s*=\s*""([a-zA-Z0-9#]*)""");
            var TabsSelectedBackgroundColorMatch = TabsSelectedBackgroundColor.Match(body);
            var valueOfTabsSelectedBackgroundColorMatch = TabsSelectedBackgroundColorMatch.Groups[2].Value;
            jsConfig.TabsSelectedBackgroundColor = valueOfMatchTabsForegroundColorMatch;




            var TabsSelectedForegroundColor = new Regex(@"var\s+(TabsSelectedForegroundColor)\s*=\s*""([a-zA-Z0-9#]*)""");
            var TabsSelectedForegroundColorMatch = TabsSelectedForegroundColor.Match(body);
            var valueOfTabsSelectedForegroundColorMatch = TabsSelectedForegroundColorMatch.Groups[2].Value;

            jsConfig.TabsSelectedForegroundColor = valueOfTabsSelectedForegroundColorMatch;


            var TabsHoveredBackgroundColor = new Regex(@"var\s+(TabsHoveredBackgroundColor)\s*=\s*""([a-zA-Z0-9#]*)""");
            var TabsHoveredBackgroundColorMatch = TabsHoveredBackgroundColor.Match(body);
            var valueOfTabsHoveredBackgroundColorMatch = TabsHoveredBackgroundColorMatch.Groups[2].Value;

            jsConfig.TabsHoveredBackgroundColor = valueOfTabsHoveredBackgroundColorMatch;


            var TabsHoveredForegroundColor = new Regex(@"var\s+(TabsHoveredForegroundColor)\s*=\s*""([a-zA-Z0-9#]*)""");
            var TabsHoveredForegroundColorMatch = TabsHoveredForegroundColor.Match(body);
            var valueOfTabsHoveredForegroundColorMatch = TabsHoveredForegroundColorMatch.Groups[2].Value;

            jsConfig.TabsHoveredForegroundColor = valueOfTabsHoveredForegroundColorMatch;
            var MatchLocalTimeTextColor = new Regex(@"var\s+(MatchLocalTimeTextColor)\s*=\s*""([a-zA-Z0-9#]*)""");
            var MatchLocalTimeTextColorMatch = MatchLocalTimeTextColor.Match(body);
            var valueOfMatchLocalTimeTextColorMatch = MatchLocalTimeTextColorMatch.Groups[2].Value;

            jsConfig.MatchLocalTimeTextColor = valueOfMatchLocalTimeTextColorMatch;

            var scoreboardBackgroundColor = new Regex(@"var\s+(scoreboardBackgroundColor)\s*=\s*""([a-zA-Z0-9#]*)""");
            var scoreboardBackgroundColorMatch = scoreboardBackgroundColor.Match(body);
            var valueOfscoreboardBackgroundColorMatch = scoreboardBackgroundColorMatch.Groups[2].Value;
            jsConfig.scoreboardBackgroundColor = valueOfscoreboardBackgroundColorMatch;

            var seriesNameTextColor = new Regex(@"var\s+(seriesNameTextColor)\s*=\s*""([a-zA-Z0-9#]*)""");
            var seriesNameTextColorMatch = seriesNameTextColor.Match(body);
            var valueOfseriesNameTextColorMatch = seriesNameTextColorMatch.Groups[2].Value;

            jsConfig.seriesNameTextColor = valueOfseriesNameTextColorMatch;

            var navLeftRightButtonsColor = new Regex(@"var\s+(navLeftRightButtonsColor)\s*=\s*""([a-zA-Z0-9#]*)""");
            var navLeftRightButtonsColorMatch = navLeftRightButtonsColor.Match(body);
            var valueOfnavLeftRightButtonsColorMatch = navLeftRightButtonsColorMatch.Groups[2].Value;

            jsConfig.navLeftRightButtonsColor = valueOfnavLeftRightButtonsColorMatch;
            var componentHeaderBackgroundColor = new Regex(@"var\s+(componentHeaderBackgroundColor)\s*=\s*""([a-zA-Z0-9#]*)""");
            var componentHeaderBackgroundColorMatch = componentHeaderBackgroundColor.Match(body);
            var valueOfcomponentHeaderBackgroundColorMatch = componentHeaderBackgroundColorMatch.Groups[2].Value;

            jsConfig.componentHeaderBackgroundColor = valueOfcomponentHeaderBackgroundColorMatch;

            var componentHeaderForegroundColorTopComponents = new Regex(@"var\s+(componentHeaderForegroundColorTopComponents)\s*=\s*""([a-zA-Z0-9#]*)""");
            var componentHeaderForegroundColorTopComponentsMatch = componentHeaderForegroundColorTopComponents.Match(body);
            var valueOfcomponentHeaderForegroundColorTopComponentsMatch = componentHeaderForegroundColorTopComponentsMatch.Groups[2].Value;

            jsConfig.componentHeaderForegroundColorTopComponents = valueOfcomponentHeaderForegroundColorTopComponentsMatch;
            var componentHeaderForegroundColorBottomComponents = new Regex(@"var\s+(componentHeaderForegroundColorBottomComponents)\s*=\s*""([a-zA-Z0-9#]*)""");
            var componentHeaderForegroundColorBottomComponentsMatch = componentHeaderForegroundColorBottomComponents.Match(body);
            var valueOfcomponentHeaderForegroundColorBottomComponentsMatch = componentHeaderForegroundColorBottomComponentsMatch.Groups[2].Value;

            jsConfig.componentHeaderForegroundColorBottomComponents = valueOfcomponentHeaderForegroundColorBottomComponentsMatch;
          //  var adminParams = new Regex(@"var\s+(adminParams)\s*=\s*{\s* ([a-zA-z0-9]*)\s*:\s*([true|false])\s*}");

           // var adminParams = new Regex(@"{\s*(isAfp)\s*:\s*([a-zA-z]*)\s*,\s*(wantsFormGuide)\s*:\s*([a-zA-z]*)\s*,\s*(wantsLineUps)\s*:\s*([a-zA-z]*)\s*,\s*(wantsCommentary)\s*:\s*([a-zA-z]*)\s*,\s*(wantsScorecard)\s*:\s*([a-zA-z]*)\s*,\s*(wantsMatchStats)\s*:\s*([a-zA-z]*)\s*,\s*(wantsNews)\s*:\s*([a-zA-z]*),\s*(wantsStandings)\s*:\s*([a-zA-z]*)\s*,\s*(wantsPlayerStats)\s*:\s*([a-zA-z]*)\s*}");
            var adminParams = new Regex(@"{\s*(isAfp)\s*:\s*([a-zA-z]*)\s*,\s*(wants3dGoals)\s*:\s*([a-zA-z]*)\s*,\s*(wantsPrePrediction)\s*:\s*([a-zA-z]*)\s*,\s*(wantsHome)\s*:\s*([a-zA-z]*)\s*,\s*(wantsVenue)\s*:\s*([a-zA-z]*)\s*,\s*(wantsStars)\s*:\s*([a-zA-z]*)\s*,\s*(wantsHistory)\s*:\s*([a-zA-z]*)\s*,\s*(wantsTeams)\s*:\s*([a-zA-z]*)\s*,\s*(wantsVideos)\s*:\s*([a-zA-z]*)\s*,\s*(wantsGallery)\s*:\s*([a-zA-z]*)\s*,\s*(wantsFormGuide)\s*:\s*([a-zA-z]*)\s*,\s*(wantsLineUps)\s*:\s*([a-zA-z]*)\s*,\s*(wantsCommentary)\s*:\s*([a-zA-z]*)\s*,\s*(wantsScorecard)\s*:\s*([a-zA-z]*)\s*,\s*(wantsMatchStats)\s*:\s*([a-zA-z]*)\s*,\s*(wantsNews)\s*:\s*([a-zA-z]*),\s*(wantsStandings)\s*:\s*([a-zA-z]*)\s*,\s*(wantsPlayerStats)\s*:\s*([a-zA-z]*)\s*}");
           
            var adminParamsMatch = adminParams.Match(body);
             var adminisAfp = adminParamsMatch.Groups[2].Value;
             var goals = adminParamsMatch.Groups[4].Value;
             var prediction = adminParamsMatch.Groups[6].Value;
             var home = adminParamsMatch.Groups[8].Value;
             var venue = adminParamsMatch.Groups[10].Value;
             var stars = adminParamsMatch.Groups[12].Value;
             var history = adminParamsMatch.Groups[14].Value;
             var teams = adminParamsMatch.Groups[16].Value;
             var videos = adminParamsMatch.Groups[18].Value;

             var gallery = adminParamsMatch.Groups[20].Value;













             var wantsFormGuide = adminParamsMatch.Groups[22].Value;
             var wantsLineUps = adminParamsMatch.Groups[24].Value;
             var wantsCommentary = adminParamsMatch.Groups[26].Value;
             var wantsScorecard = adminParamsMatch.Groups[28].Value;
             var wantsMatchStats = adminParamsMatch.Groups[30].Value;
             var wantsNews = adminParamsMatch.Groups[32].Value;
             var wantsStandings = adminParamsMatch.Groups[34].Value;
             var wantsPlayerStats = adminParamsMatch.Groups[36].Value;



             jsConfig.component.Add(new Component
             {
                 ComponentName = "3dGoals",
                 IsChecked = Convert.ToBoolean(goals)

             });


             jsConfig.component.Add(new Component
             {
                 ComponentName = "PrePrediction",
                 IsChecked = Convert.ToBoolean(prediction)

             });


             jsConfig.component.Add(new Component
             {
                 ComponentName = "Home",
                 IsChecked = Convert.ToBoolean(home)

             });
             jsConfig.component.Add(new Component
             {
                 ComponentName = "Venue",
                 IsChecked = Convert.ToBoolean(venue)

             });

             jsConfig.component.Add(new Component
             {
                 ComponentName = "Stars",
                 IsChecked = Convert.ToBoolean(stars)

             });

             jsConfig.component.Add(new Component
             {
                 ComponentName = "History",
                 IsChecked = Convert.ToBoolean(history)

             });

             jsConfig.component.Add(new Component
             {
                 ComponentName = "Teams",
                 IsChecked = Convert.ToBoolean(teams)

             });

             jsConfig.component.Add(new Component
             {
                 ComponentName = "Videos",
                 IsChecked = Convert.ToBoolean(videos)

             });

             jsConfig.component.Add(new Component
             {
                 ComponentName = "Gallery",
                 IsChecked = Convert.ToBoolean(gallery)

             });
























             jsConfig.component.Add(new Component {
                 ComponentName = "FormGuide",
                 IsChecked=Convert.ToBoolean(wantsFormGuide)
             
             });

             jsConfig.component.Add(new Component
             {
                 ComponentName = "adminAfp",
                 IsChecked = Convert.ToBoolean(adminisAfp)

             });
             jsConfig.component.Add(new Component
             {
                 ComponentName = "Scorecard",
                 IsChecked = Convert.ToBoolean(wantsScorecard)

             });
             jsConfig.component.Add(new Component
             {
                 ComponentName = "LineUps",
                 IsChecked = Convert.ToBoolean(wantsLineUps)

             });
             jsConfig.component.Add(new Component
             {
                 ComponentName = "Commentary",
                 IsChecked = Convert.ToBoolean(wantsCommentary)

             });
           

             jsConfig.component.Add(new Component
             {
                 ComponentName = "MatchStats",
                 IsChecked = Convert.ToBoolean(wantsMatchStats)

             });
             jsConfig.component.Add(new Component
             {
                 ComponentName = "News",
                 IsChecked = Convert.ToBoolean(wantsNews)

             });
             jsConfig.component.Add(new Component
             {
                 ComponentName = "Standings",
                 IsChecked = Convert.ToBoolean(wantsStandings)

             });
             jsConfig.component.Add(new Component
             {
                 ComponentName = "PlayerStats",
                 IsChecked = Convert.ToBoolean(wantsPlayerStats)

             });

            var isAfp = new Regex(@"var\s+(isAfp)\s*=\s*""([a-zA-Z]*)""");
         var   isAfpMatch = isAfp.Match(body);
         var valueOfisAfpMatch = isAfpMatch.Groups[2].Value;
         jsConfig.isAfp = Convert.ToBoolean(valueOfisAfpMatch);

         var scoreboardheight = new Regex(@"var\s+(scoreboardheight)\s*=\s*""([\d+]*)""");
         var scoreboardheightMatch = scoreboardheight.Match(body);
         var valueOfscoreboardheightMatch = scoreboardheightMatch.Groups[2].Value;

         jsConfig.scoreboardheight = valueOfscoreboardheightMatch;

         var scoreboardwidth = new Regex(@"var\s+(scoreboardwidth)\s*=\s*""([\d+]*)""");
         var scoreboardwidthMatch = scoreboardwidth.Match(body);
         var valueOfscoreboardwidthMatch = scoreboardwidthMatch.Groups[2].Value;

         jsConfig.scoreboardwidth = valueOfscoreboardwidthMatch;

         var baseUrl = new Regex(@"var\s+(baseUrl)\s*=\s*'([a-zA-Z0-9/\s:\.]*)'");
        var baseUrlMatch = baseUrl.Match(body);

        var valueOfUrl = baseUrlMatch.Groups[2].Value;
        jsConfig.baseUrl = valueOfUrl;




            //color new


        var color1 = new Regex(@"var\s+(color1)\s*=\s*""([a-zA-Z0-9#]*)""");
        var color1Match = color1.Match(body);
        var valueOfColor1Match = color1Match.Groups[2].Value;

        jsConfig.Color1 = valueOfColor1Match;



        var color2 = new Regex(@"var\s+(color2)\s*=\s*""([a-zA-Z0-9#]*)""");
        var color2Match = color2.Match(body);
        var valueOfColor2Match = color2Match.Groups[2].Value;

        jsConfig.Color2 = valueOfColor2Match;




        var color3 = new Regex(@"var\s+(color3)\s*=\s*""([a-zA-Z0-9#]*)""");
        var color3Match = color3.Match(body);
        var valueOfColor3Match = color3Match.Groups[2].Value;

        jsConfig.Color3 = valueOfColor3Match;



        var color4 = new Regex(@"var\s+(color4)\s*=\s*""([a-zA-Z0-9#]*)""");
        var color4Match = color4.Match(body);
        var valueOfColor4Match = color4Match.Groups[2].Value;

        jsConfig.Color4 = valueOfColor4Match;


        var color5 = new Regex(@"var\s+(color5)\s*=\s*""([a-zA-Z0-9#]*)""");
        var color5Match = color5.Match(body);
        var valueOfColor5Match = color5Match.Groups[2].Value;

        jsConfig.Color5 = valueOfColor5Match;




        var color6 = new Regex(@"var\s+(color6)\s*=\s*""([a-zA-Z0-9#]*)""");
        var color6Match = color6.Match(body);
        var valueOfColor6Match = color6Match.Groups[2].Value;

        jsConfig.Color6 = valueOfColor6Match;


        var color7 = new Regex(@"var\s+(color7)\s*=\s*""([a-zA-Z0-9#]*)""");
        var color7Match = color7.Match(body);
        var valueOfColor7Match = color7Match.Groups[2].Value;

        jsConfig.Color7 = valueOfColor7Match;



        var color8 = new Regex(@"var\s+(color8)\s*=\s*""([a-zA-Z0-9#]*)""");
        var color8Match = color8.Match(body);
        var valueOfColor8Match = color8Match.Groups[2].Value;

        jsConfig.Color8 = valueOfColor8Match;





        var color9 = new Regex(@"var\s+(color9)\s*=\s*""([a-zA-Z0-9#]*)""");
        var color9Match = color9.Match(body);
        var valueOfColor9Match = color9Match.Groups[2].Value;

        jsConfig.Color9 = valueOfColor9Match;



        var color10 = new Regex(@"var\s+(color10)\s*=\s*""([a-zA-Z0-9#]*)""");
        var color10Match = color10.Match(body);
        var valueOfColor10Match = color10Match.Groups[2].Value;

        jsConfig.Color10 = valueOfColor10Match;





        var color11 = new Regex(@"var\s+(color11)\s*=\s*""([a-zA-Z0-9#]*)""");
        var color11Match = color11.Match(body);
        var valueOfColor11Match = color11Match.Groups[2].Value;

        jsConfig.Color11 = valueOfColor11Match;



        var color12 = new Regex(@"var\s+(color12)\s*=\s*""([a-zA-Z0-9#]*)""");
        var color12Match = color12.Match(body);
        var valueOfColor12Match = color12Match.Groups[2].Value;

        jsConfig.Color12 = valueOfColor12Match;



        var color13 = new Regex(@"var\s+(color13)\s*=\s*""([a-zA-Z0-9#]*)""");
        var color13Match = color13.Match(body);
        var valueOfColor13Match = color13Match.Groups[2].Value;

        jsConfig.Color13 = valueOfColor13Match;


        var color14 = new Regex(@"var\s+(color14)\s*=\s*""([a-zA-Z0-9#]*)""");
        var color14Match = color14.Match(body);
        var valueOfColor14Match = color14Match.Groups[2].Value;

        jsConfig.Color14 = valueOfColor14Match;





        var color15 = new Regex(@"var\s+(color15)\s*=\s*""([a-zA-Z0-9#]*)""");
        var color15Match = color15.Match(body);
        var valueOfColor15Match = color15Match.Groups[2].Value;

        jsConfig.Color15 = valueOfColor15Match;



        var color16 = new Regex(@"var\s+(color16)\s*=\s*""([a-zA-Z0-9#]*)""");
        var color16Match = color16.Match(body);
        var valueOfColor16Match = color16Match.Groups[2].Value;

        jsConfig.Color16 = valueOfColor16Match;



        var color17 = new Regex(@"var\s+(color17)\s*=\s*""([a-zA-Z0-9#]*)""");
        var color17Match = color17.Match(body);
        var valueOfColor17Match = color17Match.Groups[2].Value;

        jsConfig.Color17 = valueOfColor17Match;


        var color18 = new Regex(@"var\s+(color18)\s*=\s*""([a-zA-Z0-9#]*)""");
        var color18Match = color18.Match(body);
        var valueOfColor18Match = color18Match.Groups[2].Value;

        jsConfig.Color18 = valueOfColor18Match;



        var color19 = new Regex(@"var\s+(color19)\s*=\s*""([a-zA-Z0-9#]*)""");
        var color19Match = color19.Match(body);
        var valueOfColor19Match = color19Match.Groups[2].Value;

        jsConfig.Color19 = valueOfColor19Match;


        var color20 = new Regex(@"var\s+(color20)\s*=\s*""([a-zA-Z0-9#]*)""");
        var color20Match = color20.Match(body);
        var valueOfColor20Match = color20Match.Groups[2].Value;

        jsConfig.Color20 = valueOfColor20Match;




        var color21 = new Regex(@"var\s+(color21)\s*=\s*""([a-zA-Z0-9#]*)""");
        var color21Match = color21.Match(body);
        var valueOfColor21Match = color21Match.Groups[2].Value;

        jsConfig.Color21 = valueOfColor21Match;


        var color22 = new Regex(@"var\s+(color22)\s*=\s*""([a-zA-Z0-9#]*)""");
        var color22Match = color22.Match(body);
        var valueOfColor22Match = color22Match.Groups[2].Value;

        jsConfig.Color22 = valueOfColor22Match;


        var color23 = new Regex(@"var\s+(color23)\s*=\s*""([a-zA-Z0-9#]*)""");
        var color23Match = color23.Match(body);
        var valueOfColor23Match = color23Match.Groups[2].Value;

        jsConfig.Color23 = valueOfColor23Match;



        var color24 = new Regex(@"var\s+(color24)\s*=\s*""([a-zA-Z0-9#]*)""");
        var color24Match = color24.Match(body);
        var valueOfColor24Match = color24Match.Groups[2].Value;

        jsConfig.Color24 = valueOfColor24Match;

        var color25 = new Regex(@"var\s+(color25)\s*=\s*""([a-zA-Z0-9#]*)""");
        var color25Match = color25.Match(body);
        var valueOfColor25Match = color25Match.Groups[2].Value;

        jsConfig.Color25 = valueOfColor25Match;

        var color26 = new Regex(@"var\s+(color26)\s*=\s*""([a-zA-Z0-9#]*)""");
        var color26Match = color26.Match(body);
        var valueOfColor26Match = color26Match.Groups[2].Value;

        jsConfig.Color26 = valueOfColor26Match;

        var menuImageUrl = new Regex(@"var\s+(menuImageUrl)\s*=\s*""([a-zA-Z0-9#\./_]*)""");
        var menuImageUrlMatch = menuImageUrl.Match(body);
        var valueOfMenuImageUrlMatch = menuImageUrlMatch.Groups[2].Value;

        jsConfig.MenuImageUrl = valueOfMenuImageUrlMatch;





        var prevArrowUrl = new Regex(@"var\s+(prevArrowUrl)\s*=\s*""([a-zA-Z0-9#\./_]*)""");
        var prevArrowUrlMatch = prevArrowUrl.Match(body);
        var valueOfPrevArrowUrlMatch = prevArrowUrlMatch.Groups[2].Value;

        jsConfig.PrevArrowUrl = valueOfPrevArrowUrlMatch;


        var nextArrowUrl = new Regex(@"var\s+(nextArrowUrl)\s*=\s*""([a-zA-Z0-9#\./_]*)""");
        var nextArrowUrlMatch = nextArrowUrl.Match(body);
        var valueOfNextArrowUrlMatch = nextArrowUrlMatch.Groups[2].Value;

        jsConfig.NextArrowUrl = valueOfNextArrowUrlMatch;


        var adminParms = new Regex(@"adminParams\[""closeImageUrl""\]\s*=\s*""([a-zA-Z0-9#\./_]*)""");
        var adminParamsMatchNew = adminParms.Match(body);
        var valueOfAdminParamsMatch = adminParamsMatchNew.Groups[1].Value;

        jsConfig.AdminParams = valueOfAdminParamsMatch;


        var getGoogleAnalytics = new Regex(@"\(\s*function\s*\(\s*.*\);",RegexOptions.Multiline);
        var getGoogleAnalyticsMatchNew = getGoogleAnalytics.Match(body);
        var valueOfGoogleAnalytics = getGoogleAnalyticsMatchNew.Groups[0].Value;
        jsConfig.GAnalytics = valueOfGoogleAnalytics;










            //end
















         var seriesList = new Regex(@"{\s*(Name)\s*:\s*""([a-zA-z0-9/\s]*)""\s*,\s*(ShortName)\s*:\s*""([a-zA-z0-9/\s]*)""\s*,\s*(Id)\s*:\s*([\d+]*)\s*}");

         var seriesListMatch = seriesList.Matches(body);
         foreach (Match lstMatch in seriesListMatch)
         {
             int i = 1; 
             int k = 0;
             Series ser = new Series();
             foreach (Group g in lstMatch.Groups)
             {
                 
                 k = 1;

                 if (i == 3)
                 {
                     ser.Name = g.Value;
                 
                 }
                 if (i == 5)
                 {
                     ser.ShortName = g.Value;
                 }

                 if (i == 7)
                 {
                     ser.Id = Convert.ToInt16(g.Value);
                 }


                 i++;
             }
             if (k == 1)
             {
                 jsConfig.series.Add(ser);
             }
         
            

         
         }

         //  int h =body.IndexOf("headerTabsForegroundColor") ;
           
        }

  


    }
}