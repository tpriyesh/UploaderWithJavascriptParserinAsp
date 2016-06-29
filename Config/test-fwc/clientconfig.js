try{
if(localStorage)
localStorage.clear();
}
catch(e){}


var seriesList = serieslist=[{Name:"WORLDCUP",ShortName:"WORLDCUP_SHORT", Id:305},{Name:"ENGLISHPREMIERLEAGUE",ShortName:"ENGLISHPREMIERLEAGUE_SHORT", Id:339}];


/** Base Url For Fetching Feeds **/
var baseUrl="";


var adminParams={isAfp:True,wants3dGoals:False,wantsPrePrediction:False,wantsHome:True,wantsVenue:True,wantsStars:True,wantsHistory:True,wantsTeams:True,wantsVideos:True,wantsGallery:True,wantsFormGuide:True,wantsLineUps:True,wantsCommentary:True,wantsScorecard:True,wantsMatchStats:True,wantsNews:True,wantsStandings:True,wantsPlayerStats:True};

/*** COLOR CUSTOMIZATION ***/

/** OVERALL BODY BACKGROUND **/
var scoreboardBackgroundColor="";

/** COLOR FOR TOP SERIES NAME **/
var seriesNameTextColor="";

/** LEFT AND RIGHT BUTTONS ON FIXTURE NAV AND BACK BUTTON ON SCORECARD **/
var navLeftRightButtonsColor="";

/** Image Url **/
var footerImageUrl="";

/** BACKGROUND COLOR FOR COMPONENT TITLE **/
var componentHeaderBackgroundColor="";

/** FOREGROUND COLOR FOR TOP COMPONENT e.g. MATCH SCORES< TEAM NAMES **/
var componentHeaderForegroundColorTopComponents="";

/** FOREGROUND COLOR FOR BOTTOM COMPONENTS e.g. FORMGUIDE , SCORECARD , MATCH STATS , NEWS **/
var componentHeaderForegroundColorBottomComponents="";

var scoreboardheight="";

var scoreboardwidth="";

/** FIXTURE ,STANDINGD,NEWS WHEN TAB IS NOT ACTIVE **/
var headerTabsForegroundColor="";

/** SCORECARD,LINE UP,ETC TABS IN MATCH AREA WHEN TAB IS NOT ACTIVE **/
var matchTabsForegroundColor="";

/** WHEN TAB IS IN SELECTED STATE **/
var TabsSelectedBackgroundColor="";
var TabsSelectedForegroundColor="";

/** WHEN TAB IS IN HOVERED STATE **/
var TabsHoveredBackgroundColor="";
var TabsHoveredForegroundColor="";

var MatchLocalTimeTextColor="";

var isAfp="True";

var color1="#c75f5f";

var color2="#993d3d";

var color3="#872c2c";

var color4="#ad4c4c";

var color5="#ba2929";

var color6="#7d1e1e";

var color7="#8a2525";

var color8="#8f2f2f";

var color9="#913030";

var color10="#7a1010";

var color11="#ad5555";

var color12="#8f3232";

var color13="#b86464";

var color14="#ad3636";

var color15="#a14a4a";

var color16="#bd6666";

var color17="#943232";

var color18="#c25555";

var color19="#994949";

var color20="#732222";

var color21="#8c4040";

var color22="#471f1f";

var color23="#662525";

var color24="#944444";

var color25="#913f3f";

var color26="#804848";

var menuImageUrl="/img/a.png";

adminParams["closeImageUrl"]="img/b.gif";

var prevArrowUrl="img/al.png";

var nextArrowUrl="image/b.png";


(function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){ (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o), m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m) })(window,document,'script','//www.google-analytics.com/analytics.js','ga'); ga('create', 'UA-51069961-1', 'sportsflash.com.au'); ga('send', 'pageview');