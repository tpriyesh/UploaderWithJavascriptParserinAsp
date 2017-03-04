using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using CmsApplication.Models;
using CmsApplication.Code;


namespace CmsApplication.Controllers
{
    public class CmsController : Controller
    {
        

        public ActionResult Index()
        {
            var directory = Server.MapPath("~/Config/");
            var test = 1;
            string[] getAllPathsToTheClient = Directory.GetDirectories(directory);
            List<string> getAllClientDirectories = new List<string>();
            foreach (var path in getAllPathsToTheClient)
            {
                string clientName = new DirectoryInfo(path).Name;
                getAllClientDirectories.Add(clientName);

            }

            ViewBag.ClientName = getAllClientDirectories;
            return View();
        
        }



     


        public ActionResult EditClient(string clientName)
        {
            ViewBag.Series = GetSeriesXml();

            ViewBag.Components = GetComponentXml();

            return View();
           
        
        }



        public ActionResult Create()
        {

            ViewBag.Series = GetSeriesXml();

            ViewBag.Components = GetComponentXml();
            return View();
        
        
        }


       

        private List<Series> GetSeriesXml()
        {

            var xmlDirectoryOfSeries = Server.MapPath("~/Xml/Series.xml");
            List<Series> getAllSeriesFromXml = new List<Series>();

            XmlTextReader seriesReader = new XmlTextReader(xmlDirectoryOfSeries);
            seriesReader.Read();
            // If the node has value
            while (seriesReader.Read())
            {
                if (seriesReader.IsStartElement())
                {
                    switch (seriesReader.Name)
                    {

                        case "SeriesName":

                            string attributeName = seriesReader["Name"];
                            string attributeShortName = seriesReader["ShortName"];
                            int attributeId = Convert.ToInt32(seriesReader["Id"]);




                            if (seriesReader.Read())
                            {

                                Series series = new Series();
                                series.Name = seriesReader.Value.Trim();
                                series.ShortName = attributeShortName;
                                series.Id = attributeId;
                                getAllSeriesFromXml.Add(series);
                            }
                            break;
                    }
                }
            }


            return getAllSeriesFromXml;


        
        }


      




        private List<Component> GetComponentXml()
        {

            var xmlDirectory = Server.MapPath("~/Xml/Component.xml");
            List<Component> getAllComponentsFromXml = new List<Component>();

            XmlTextReader reader = new XmlTextReader(xmlDirectory);
            reader.Read();
            // If the node has value
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    switch (reader.Name)
                    {

                        case "ComponentName":

                            if (reader.Read())
                            {

                                Component component = new Component();
                                component.ComponentName = reader.Value.Trim();
                                component.IsChecked = false;
                                getAllComponentsFromXml.Add(component);
                            }
                            break;
                    }
                }
            }

            return getAllComponentsFromXml;
        
        }










        [HttpPost]
        public ActionResult Save(CmsModel model)
        {
            var directory = "";

            string clientName = model.ClientName;
            if (model.hdnField == "0")
            {
                directory = Server.MapPath("~/Config/" + model.ClientName);

                Directory.CreateDirectory(directory);

            }
            else
            {
                directory = Server.MapPath("~/Config/" + model.ClientName);
            }

            //series string
            string seriesString="";

            if (model.Series.Count != 0)
            {

                seriesString = seriesString + "var seriesList = serieslist=[";

                int counter = model.Series.Count;
                int localCounter = 1;

                foreach (var s in model.Series)
                {



                    seriesString += "{Name:\"" + s.Name + "\",ShortName:\"" + s.ShortName + "\", Id:" + s.Id + "}";

                    if (counter != 1)
                    {
                        if (counter == localCounter)
                        {
                            seriesString += "";
                        }
                        else
                            seriesString += ",";
                    }


                    localCounter++;

                }
                seriesString += "];";

                //end of series string
            }
            else
            {
                seriesString = seriesString + "var seriesList = serieslist=[];";

            
            
            }


            //start adminParams string

           
            string adminString = "";



            string baseUrl = "\r\n/** Base Url For Fetching Feeds **/\r\nvar baseUrl=\"" + model.BaseUrl + "\"" + ";\r\n";

            if (model.Component.Count != 0)
            {

                adminString = adminString + "var adminParams={";


                var getComponent = GetComponentXml();

                List<Component> compToBeInserted = new List<Component>();


                bool standings = false;
                bool playerStats = false;
                bool news = false;
                bool commentary = false;
                bool Scorecard = false;
                bool MatchStats = false;
                bool lineUps = false;
                bool formGuide = false;
                bool dGoals = false;
                bool PrePrediction = false;
                bool Home = false;
                bool Venue = false;
                bool Stars = false;
                bool History = false;
                bool Teams = false;
                bool Videos = false;
                bool Gallery = false;
                int componentCount = model.Component.Count;
                foreach (var component in model.Component)
                {

                    switch (component)
                    {

                        case "Standings":
                            standings = true;
                            break;
                        case "PlayerStats":
                            playerStats = true;
                            break;
                        case "News":
                            news = true;
                            break;
                        case "FormGuide":
                            formGuide = true;
                            break;
                        case "Commentary":
                            commentary = true;
                            break;
                        case "LineUps":
                            lineUps = true;
                            break;
                        case "Scorecard":
                            Scorecard = true;
                            break;
                        case "MatchStats":
                            MatchStats = true;
                            break;
                        case "3dGoals":
                            dGoals = true;
                            break;

                        case "PrePrediction":
                            PrePrediction = true;
                            break;
                        case "Home":
                            Home = true;
                            break;
                        case "Venue":
                            Venue = true;
                            break;
                        case "Stars":
                            Stars = true;
                            break;
                        case "History":
                            History = true;
                            break;
                        case "Teams":
                            Teams = true;
                            break;
                        case "Videos":
                            Videos = true;
                            break;
                        case "Gallery":
                            Gallery = true;
                            break;





                    }
                }

                var isAfp = model.isAfp;
                adminString = adminString + "isAfp:" + isAfp + ",wants3dGoals:" + dGoals + ",wantsPrePrediction:" + PrePrediction + ",wantsHome:" + Home + ",wantsVenue:" + Venue + ",wantsStars:" + Stars + ",wantsHistory:" + History + ",wantsTeams:" + Teams + ",wantsVideos:" + Videos + ",wantsGallery:" + Gallery + ",wantsFormGuide:" + formGuide + ",wantsLineUps:" + lineUps + ",wantsCommentary:" + commentary + ",wantsScorecard:" + Scorecard + ",wantsMatchStats:" + MatchStats + ",wantsNews:" + news + ",wantsStandings:" + standings + ",wantsPlayerStats:" + playerStats;
                adminString = adminString + "};";
            }

            else
            {

                adminString = adminString + "var adminParams={";
                var isAfp = model.isAfp;
                adminString = adminString + "isAfp:" + isAfp + ",wants3dGoals:" + false + ",wantsPrePrediction:" + false + ",wantsHome:" + false + ",wantsVenue:" + false + ",wantsStars:" + false + ",wantsHistory:" + false + ",wantsTeams:" + false + ",wantsVideos:" + false + ",wantsGallery:" + false + ",wantsFormGuide:" + false + ",wantsLineUps:" + false + ",wantsCommentary:" + false + ",wantsScorecard:" + false + ",wantsMatchStats:" + false + ",wantsNews:" + false + ",wantsStandings:" + false + ",wantsPlayerStats:" + false;
                adminString = adminString + "};";
            
            
            
            }


            //end of admin param string

            //parms valueset
            string admin = "23";
            string header = "/*** COLOR CUSTOMIZATION ***/";

            string parameters = "/** OVERALL BODY BACKGROUND **/\r\nvar scoreboardBackgroundColor=\"" + model.scoreboardBackgroundColor + "\""+";\r\n" +
                "\r\n/** COLOR FOR TOP SERIES NAME **/\r\nvar seriesNameTextColor=\"" + model.seriesNameTextColor + "\""+";\r\n" + "\r\n/** LEFT AND RIGHT BUTTONS ON FIXTURE NAV AND BACK BUTTON ON SCORECARD **/\r\nvar navLeftRightButtonsColor=\"" +model.navLeftRightButtonsColor+"\""+";\r\n"+
                "\r\n/** Image Url **/\r\nvar footerImageUrl=\"" + model.FooterImageUrl + "\"" + ";\r\n" +
                "\r\n/** BACKGROUND COLOR FOR COMPONENT TITLE **/\r\nvar componentHeaderBackgroundColor=\"" + model.componentHeaderBackgroundColor + "\""+";\r\n" + "\r\n/** FOREGROUND COLOR FOR TOP COMPONENT e.g. MATCH SCORES< TEAM NAMES **/\r\nvar componentHeaderForegroundColorTopComponents=\"" +
                model.componentHeaderForegroundColorTopComponents + "\"" +";\r\n"+ "\r\n/** FOREGROUND COLOR FOR BOTTOM COMPONENTS e.g. FORMGUIDE , SCORECARD , MATCH STATS , NEWS **/\r\nvar componentHeaderForegroundColorBottomComponents=\"" +
                model.componentHeaderForegroundColorBottomComponents + "\""+";\r\n\r\n" + "var scoreboardheight=\"" + model.scoreboardheight +"\""+";\r\n\r\n" +
                "var scoreboardwidth=\"" + model.scoreboardwidth +"\""+";\r\n" + "\r\n/** FIXTURE ,STANDINGD,NEWS WHEN TAB IS NOT ACTIVE **/\r\nvar headerTabsForegroundColor=\"" + model.headerTabsForegroundColor +
                "\""+";\r\n" + "\r\n/** SCORECARD,LINE UP,ETC TABS IN MATCH AREA WHEN TAB IS NOT ACTIVE **/\r\nvar matchTabsForegroundColor=\"" + model.matchTabsForegroundColor + "\""+";\r\n" + "\r\n/** WHEN TAB IS IN SELECTED STATE **/\r\nvar TabsSelectedBackgroundColor=\"" +
                model.TabsSelectedBackgroundColor + "\""+";\r\n" + "var TabsSelectedForegroundColor=\"" + model.TabsSelectedForegroundColor +
                "\""+";\r\n" + "\r\n/** WHEN TAB IS IN HOVERED STATE **/\r\nvar TabsHoveredBackgroundColor=\"" + model.TabsHoveredBackgroundColor + "\""+";\r\n" + "var TabsHoveredForegroundColor=\"" +
                model.TabsHoveredForegroundColor + "\""+";\r\n\r\n" + "var MatchLocalTimeTextColor=\"" + model.MatchLocalTimeTextColor + "\""+";\r\n\r\n"+"var isAfp=\""+model.isAfp+"\""+";\r\n";


            parameters = parameters + "\r\nvar color1=\""+model.Color1+"\""+";\r\n";
            parameters = parameters + "\r\nvar color2=\"" + model.Color2 + "\"" + ";\r\n";

            parameters = parameters + "\r\nvar color3=\"" + model.Color3 + "\"" + ";\r\n";
            parameters = parameters + "\r\nvar color4=\"" + model.Color4 + "\"" + ";\r\n";
            parameters = parameters + "\r\nvar color5=\"" + model.Color5 + "\"" + ";\r\n";
            parameters = parameters + "\r\nvar color6=\"" + model.Color6 + "\"" + ";\r\n";
            parameters = parameters + "\r\nvar color7=\"" + model.Color7 + "\"" + ";\r\n";
            parameters = parameters + "\r\nvar color8=\"" + model.Color8 + "\"" + ";\r\n";
            parameters = parameters + "\r\nvar color9=\"" + model.Color9 + "\"" + ";\r\n";
            parameters = parameters + "\r\nvar color10=\"" + model.Color10 + "\"" + ";\r\n";
            parameters = parameters + "\r\nvar color11=\"" + model.Color11 + "\"" + ";\r\n";
            parameters = parameters + "\r\nvar color12=\"" + model.Color12 + "\"" + ";\r\n";
            parameters = parameters + "\r\nvar color13=\"" + model.Color13 + "\"" + ";\r\n";

            parameters = parameters + "\r\nvar color14=\"" + model.Color14 + "\"" + ";\r\n";
            parameters = parameters + "\r\nvar color15=\"" + model.Color15 + "\"" + ";\r\n";
            parameters = parameters + "\r\nvar color16=\"" + model.Color16 + "\"" + ";\r\n";
            parameters = parameters + "\r\nvar color17=\"" + model.Color17 + "\"" + ";\r\n";
            parameters = parameters + "\r\nvar color18=\"" + model.Color18 + "\"" + ";\r\n";
            parameters = parameters + "\r\nvar color19=\"" + model.Color19 + "\"" + ";\r\n";

            parameters = parameters + "\r\nvar color20=\"" + model.Color20 + "\"" + ";\r\n";
            parameters = parameters + "\r\nvar color21=\"" + model.Color21 + "\"" + ";\r\n";
            parameters = parameters + "\r\nvar color22=\"" + model.Color22 + "\"" + ";\r\n";
            parameters = parameters + "\r\nvar color23=\"" + model.Color23 + "\"" + ";\r\n";
            parameters = parameters + "\r\nvar color24=\"" + model.Color24 + "\"" + ";\r\n";
            parameters = parameters + "\r\nvar color25=\"" + model.Color25 + "\"" + ";\r\n";
            parameters = parameters + "\r\nvar color26=\"" + model.Color26 + "\"" + ";\r\n";

            parameters = parameters + "\r\nvar menuImageUrl=\"" + model.MenuImageUrl + "\"" + ";\r\n";

            parameters = parameters + "\r\nadminParams[\"closeImageUrl\"]=\"" + model.AdminParams + "\"" + ";\r\n";

            parameters = parameters + "\r\nvar prevArrowUrl=\"" + model.PrevArrowUrl + "\"" + ";\r\n";

            parameters = parameters + "\r\nvar nextArrowUrl=\"" + model.NextArrowUrl + "\"" + ";\r\n";


            

            string startPoint = "try{\r\nif(localStorage)\r\nlocalStorage.clear();\r\n}\r\ncatch(e){}\r\n";

            string gAnalytics = model.GAnalytics;


            //end of param value


           System.IO.File.WriteAllText(Path.Combine(directory, "clientconfig.js"), (startPoint+"\r\n\r\n"+seriesString+"\r\n\r\n"+baseUrl+"\r\n\r\n"+adminString+"\r\n\r\n"+header+"\r\n\r\n"+parameters+"\r\n\r\n"+gAnalytics));

          
           var obj = new
           {
               data = true,
               fileName = clientName

           };
           return Json(obj);
        
        }


        public JsonResult UploadFileToServer(string clientName)
        {
            FileUpload fU = new FileUpload();

            var directory = Server.MapPath("~/Config");
            var mainDirectory = directory+"\\" + clientName+"\\clientconfig.js";

            
           string statusCode= fU.FileUploader(mainDirectory,clientName);
           if (statusCode == null)
           {
               var obj = new
               {
                   status = 0


               };
               return Json(obj);
        
           }
           var obj1 = new
           {
               status = 1
              

           };
           return Json(obj1);
        

        }

        public JsonResult CheckClientNameAvailability(string clientName)
        {
            var directory = Server.MapPath("~/Config/");
            int check = 0;
            string[] getAllPathsToTheClient = Directory.GetDirectories(directory);
            List<string> getAllClientDirectories = new List<string>();
            foreach (var path in getAllPathsToTheClient)
            {
                string dirName = new DirectoryInfo(path).Name;
                getAllClientDirectories.Add(dirName);

            }

            foreach (var dirName in getAllClientDirectories)
            {
                if (dirName == clientName)
                {
                    check = 1;
                    break;
                }
            }
            if (check == 1)
            {
                var obj = new
                {
                    data = true

                };
                return Json(obj);
            }
            else
            {
                var obj = new
                {
                    data = false

                };
                return Json(obj);
            
            }

          
        
        }



        public JsonResult GetClientInformation(string clientName)
        {

            JsConfigFile jsConfig = null;
            JavaScriptParser js = new JavaScriptParser();
            string path = Server.MapPath("~/Config/"+clientName+"/clientconfig.js");
            js.ParseVariables(path,out jsConfig);
            jsConfig.ClientName = clientName;



            var obj=new {
            data=true
            
            };

            return Json(jsConfig);
        
        }


    }
}
