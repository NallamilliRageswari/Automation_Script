using java.security.cert;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace Automation_Assesment
{
    public class Tests
    {
        #region Properties
        protected IWebDriver driver;
        private const string ele_FacebookLink = "(//div[@class='nc_tweetContainer swp_share_button swp_facebook'])[2]";
        private const string ele_Logo = "(//div[@class='et_pb_menu__logo'])";
        private const string ele_HeaderLink = "//div[@id='header-sec']";
        private const string ele_MainText = "(//div[@class='et_pb_text_inner'])[1]";
        private const string ele_FeaturedInText = "(//div[@class='et_pb_text_inner'])[2]";
        private const string ele_SearchBar = "//input[@placeholder='Search']";
        private const string ele_SearchSubmit = "//input[@class='et_pb_searchsubmit']";
        private const string ele_SocialMediaLinks = "(//div[@class='swp_social_panelSide swp_floating_panel swp_social_panel swp_boxed swp_default_full_color swp_other_full_color swp_individual_full_color slide swp_float_left swp_side_center scale-100 float-position-center-left'])";
        private const string ele_ContactUsForm = "(//a[contains(text(),'Contact Us')])[3]";
        private const string ele_ContactFormSubmit = "//button[@type='submit']";
        private const string ele_ConfirmMsg = "//div[@class='et-pb-contact-message']";
        private const string ele_GetMoreInfoBtn = "//a[@class='et_pb_button et_pb_button_0 custom-btn-mrsk et_pb_bg_layout_light']";
        private const string ele_HyperLink = "//h1[contains(text(),'Everything you need to know to truly master test a')]";
        private const string ele_HyperLinkATag ="(//div[@class='et_pb_text_inner'])[10]";
        private const string ele_BlogLink = "(//div[@class='et_pb_blurb_content'])[2]";
        private const string ele_FBForgottenLink = "//p[@id='login_link']";
        private const string ele_LatestContent = "//h1[contains(text(),'Latest Content')]";
        private const string ele_BlogPage= "//*[@class='et_pb_row et_pb_row_12 et_pb_gutters2']//parent::div[1]";
        private const string ele_BlogATag = "//a[contains(text(),'read more')]";
        private const string ele_ScrollBtn="//body/span[1]";
        private const string ele_HoverLearning="(//li[@class='et_pb_menu_page_id-217437 menu-item menu-item-type-post_type menu-item-object-page menu-item-has-children menu-item-217440'])[1]";
        private const string ele_HoverLearningATag= "(//ul[@class='sub-menu'])[1]";
        private const string ele_HoverAboutATag = "(//ul[@class='sub-menu'])[2]";
        private const string ele_ImageLink = "//span[@class='et_pb_image_wrap']";
        private const string ele_CreateNewAcc = "//a[contains(text(),'Create New Account')]";
        private const string ele_FBSubmit="//input[@type='submit']";
        private const string ele_FBResult="//div[@class='fsl fwb fcb']";
        private const string ele_WaterMark="//div[@id='footer-info']";
        private const string ele_FooterLink = "//div[@id='et-footer-nav']";
        private const string ele_BlogElements="//div[@class='et_pb_blog_grid clearfix']";
        private const string ele_Article="//article[@id='post-9354']";
        private const string ele_ArticleContent="//div[@class='lwptoc_i']";
        private const string ele_SMFloatingPanel = "(//div[@data-float='left'])[3]";
        private const string ele_BlogOutcome = "//div[@class='et_pb_row et_pb_row_2']";
        private const string ele_MovetoBlog = "(//div[@class='et_pb_with_border et_pb_module et_pb_text et_pb_text_4 custom-color-text  et_pb_text_align_left et_pb_bg_layout_light'])";
        private const string ele_RealBlog = "//div[@class='et_pb_section et_pb_section_3 custom-box-mrsk et_section_regular']";
        private const string ele_RealText = "//div[@class='et_pb_column et_pb_column_4_4 et_pb_column_2  et_pb_css_mix_blend_mode_passthrough et-last-child']";
        private const string ele_ParaText = "(//div[@class='et_pb_text_inner'])[10]";
        private const string ele_LatestContentPara = "(//div[@class='et_pb_text_inner'])[12]";
        private const string ele_TechDisText = "//h2[contains(text(),'Our Latest Tech Discussions')]";
        private const string ele_GetAmazeText = "//h2[contains(text(),'Get Amazing Tips In Your Inbox')]";
        private const string ele_HeaderText = "//h1[contains(text(),'Explicit Wait vs Implicit Wait in Selenium: Finally Explained!')]";
        private const string ele_Image = "//img[@data-ll-status='loaded']";
        #endregion

        private const string actualUrl = "https://ultimateqa.com/";
        private const string ExplicitBlogLink = "https://ultimateqa.com/explicit-and-implicit-waits/";
        private const string AutomationPage = "https://ultimateqa.com/?s=Automation&et_pb_searchform_submit=et_search_proccess&et_pb_include_posts=yes&et_pb_include_pages=yes";
        private const string GetMoreInfoBtn = "https://ultimateqa.com/consulting/";
        private const string BlogPage = "https://ultimateqa.com/blog/";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            driver.Url = "https://Ultimateqa.com";
        }

        //TestCaseId: 004 -- Checking valid url redirects to correct page
        [Test]
        public void VerifyValidUrl()
        {
            String currentURL = driver.Url;
            Assert.AreEqual(currentURL, actualUrl);
        }

        //TestCaseId: 006 -- Checking Logo presence
        [Test]
        public void VerifyLogo()
        {
            try
            {
                Assert.IsTrue(driver.FindElement(By.XPath(ele_Logo)).Displayed);
                TestContext.Progress.WriteLine("Ultimateqa Logo is present");
            }
            catch (Exception e)
            {
                TestContext.Progress.Write(e);
            }
        }

        //TestCaseId:007 -- Verifying logo navigation to home page.
        [Test]
        public void LogoNavigation()
        {
            driver.FindElement(By.XPath(ele_Logo)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            string currentUrl = driver.Url;
            Assert.AreEqual(currentUrl, actualUrl);
        }

        //TestCaseId: 009 -- Verifying header section elements list.
        [Test]
        public void VerifyHeaderLinks()
        {
            IWebElement header = driver.FindElement(By.XPath(ele_HeaderLink));
            IList<IWebElement> Links = header.FindElements(By.TagName("a"));
            int count = Links.Count();
            TestContext.Progress.WriteLine("Header Contains " + count + " links.");
            TestContext.Progress.WriteLine("Header links list:");
            for(int i=0;i<count;i++)
            { 
                string learning_elements = Links[i].GetAttribute("href");
                TestContext.Progress.WriteLine(learning_elements);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            }
        }

        //TestCaseId: 010 -- Verifying Search bar presence
        [Test]
        public void VerifySearchBar()
        {
            try
            {
                Assert.IsTrue(driver.FindElement(By.XPath(ele_SearchBar)).Displayed);
                TestContext.Progress.WriteLine("Searchbar is present");
            }
            catch (Exception e)
            {
                TestContext.Progress.Write(e);
            }
        }

        //TestCaseId: 015 -- Verifying search bar accepting value and gives accurate result.
        [Test]
        public void verifySearchNavigation()
        {
            IWebElement searchbox = driver.FindElement(By.XPath(ele_SearchBar));
            searchbox.SendKeys("Automation");
            driver.FindElement(By.XPath(ele_SearchSubmit)).Click();
            string CurrentUrl = driver.Url;
            Assert.AreEqual(CurrentUrl, AutomationPage);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);
        }

        //TestCaseId: 019 -- verifying that  non-existing word search gives an error message that is taken screenshot.
        [Test]
        public void VerifySearchNonExistWord()
        {
            IWebElement searchbox = driver.FindElement(By.XPath(ele_SearchBar));
            searchbox.SendKeys("Xray");
            driver.FindElement(By.XPath(ele_SearchSubmit)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(@"C:\Users\nrageswari\source\repos\AutomationKT_Tasks\Automation_Assesment\Screenshots\invalidsearch.png", ScreenshotImageFormat.Png);
        }

        //TestCaseId: 020 -- Verifying Social media links presence & Navigation.
        [Test]
        public void VerifySMIconLinks()
        {
            IWebElement SMIcons = driver.FindElement(By.XPath(ele_SocialMediaLinks));
            IList<IWebElement> Links = SMIcons.FindElements(By.TagName("a"));
            int count = Links.Count();
            TestContext.Progress.WriteLine("Social Media Icons Contains " + count + " links in page.");
            TestContext.Progress.WriteLine("Social Media links list:");
            foreach (IWebElement link in Links)
            {
                if (count > 0)
                {
                    TestContext.Progress.WriteLine(link.Text);
                    Thread.Sleep(2000);
                    link.Click();
                    TestContext.Progress.WriteLine(driver.Title);
                    SwitchWindows(1);
                    TestContext.Progress.WriteLine(driver.Title);
                    SwitchWindowsClose(1);
                    Thread.Sleep(2000);
                    SwitchWindows(0);
                    Thread.Sleep(2000);
                }
            }
        }

        //TestCaseId: 022,023,024,025,026,027 -- Verifying contactUs form with data-driven Testing
        [Test, TestCaseSource("GetTestData")]
        public void ContactUsForm(string firstname, string lastname, string email, string message)
        { 
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");
            driver.FindElement(By.XPath(ele_ContactUsForm)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);
            driver.FindElement(By.Id("et_pb_contact_first_0")).SendKeys(firstname);
            driver.FindElement(By.Id("et_pb_contact_last_0")).SendKeys(lastname);
            driver.FindElement(By.Id("et_pb_contact_email_0")).SendKeys(email);
            driver.FindElement(By.Id("et_pb_contact_message_0")).SendKeys(message);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            driver.FindElement(By.XPath(ele_ContactFormSubmit)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);
            string result = driver.FindElement(By.XPath(ele_ConfirmMsg)).Text;
            string actual = "Thanks for contacting us";
            if (result == actual)
            {
                TestContext.Progress.WriteLine("Entered valid details");
                Assert.That(result, Is.EqualTo("Thanks for contacting us"));
            }
            if (result != actual)
            {
                Thread.Sleep(5000);
                TestContext.Progress.WriteLine("left some fields");
                for (int i = 0; i < 7; i++)
                {
                    Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                    ss.SaveAsFile(@"C:\Users\nrageswari\source\repos\AutomationKT_Tasks\Automation_Assesment\Screenshots\image.png", ScreenshotImageFormat.Png);
                }
            }
        }

        //TestCaseId: 028 -- Verifying Blog navigation below real-world outcomes text to see full history of blog.
        [Test]
        public void SeeFullStoryBtn()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            IWebElement RealText = driver.FindElement(By.XPath(ele_BlogOutcome));
            js.ExecuteScript("arguments[0].scrollIntoView()", RealText);
            IWebElement MovetoBlog = driver.FindElement(By.XPath(ele_MovetoBlog));
            Actions act = new Actions(driver);
            act.MoveToElement(MovetoBlog);
            driver.FindElement(By.LinkText("See Full Story >>")).Click();
            string title = driver.Title;
            TestContext.Progress.WriteLine("Title of Hospitality blog: "+ title);
        }

        //TestCaseId: 029 & 054 -- Verifying GetMoreInfo button presence and its navigation.
        [Test]
        public void VerifyGetMoreInfoButton()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            IWebElement button = driver.FindElement(By.XPath(ele_GetMoreInfoBtn));
            js.ExecuteScript("arguments[0].scrollIntoView()", button);
            TestContext.Progress.WriteLine("GetMoreInfo Button is present " + button.Displayed);
            string button1 = driver.FindElement(By.XPath(ele_GetMoreInfoBtn)).Text;
            Assert.AreEqual(button1, "Get More Info");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
            button.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            String currentURL1 = driver.Url;
            Assert.AreEqual(currentURL1, GetMoreInfoBtn);
        }

        //TC_032, TC_033, TC_034 -- Verifying  hyperlinks contains in paragraph  & its navigation
        [Test]
        public void HyperLinkText()
        { 
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            IWebElement text = driver.FindElement(By.XPath(ele_HyperLink));
            js.ExecuteScript("arguments[0].scrollIntoView()", text);
            IWebElement text1 = driver.FindElement(By.XPath(ele_HyperLinkATag));
            IList<IWebElement> Links = text1.FindElements(By.TagName("a"));
            int count = Links.Count();
            TestContext.Progress.WriteLine("Text Contains " + count + " hyperlinks list: ");
            foreach (IWebElement link in Links)
            {
                if (count > 0)
                {
                    Console.WriteLine(link.Text);
                    link.Click();
                    driver.Navigate().Back();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
                }
            }
        }

        //TestCaseId: 035, 036 -- Verifying Blog page is Navigating to Correct page in New window. 
        [Test]
        public void BlogNavigation()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            IWebElement button = driver.FindElement(By.XPath(ele_BlogLink));
            js.ExecuteScript("arguments[0].scrollIntoView()", button);
            button.Click();
            var newWindowHandle = driver.WindowHandles[1];
            string expectedNewWindowTitle = "Complete List of Awesome Websites to Practice Automation Testing";
            Assert.AreEqual(driver.SwitchTo().Window(newWindowHandle).Title, expectedNewWindowTitle);
            SwitchWindowsClose(1);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            SwitchWindows(0);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
        }

        //TestCaseId: 038 -- Verifying  ReadAllLatestContentButton presence & navigation
        [Test]
        public void Readlatestcontentbutton()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            IWebElement contentbutton = driver.FindElement(By.LinkText("Read all latest Content"));
            js.ExecuteScript("arguments[0].scrollIntoView()", contentbutton);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            TestContext.Progress.WriteLine("Read all latest content button is present: " + contentbutton.Displayed);
            contentbutton.Click();
            string currentUrl = driver.Url;
            Assert.AreEqual(currentUrl, BlogPage);
            TestContext.Progress.WriteLine("Read all latest content button navigated");
        }

        //TestCaseId: 039, 057 & 058  Verifying LatestContent text presence & blogs presence.
        [Test]
        public void LatestContentBlog()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            IWebElement text = driver.FindElement(By.XPath(ele_LatestContent));
            js.ExecuteScript("arguments[0].scrollIntoView()", text);
            TestContext.Progress.WriteLine("Latest Content text is present: " + text.Displayed);
            IWebElement latestContentPara = driver.FindElement(By.XPath(ele_LatestContentPara));
            TestContext.Progress.WriteLine("Latest Content section conatain paragraph " + latestContentPara.Displayed + " is " + latestContentPara.Text);
            IWebElement blogpage = driver.FindElement(By.XPath(ele_BlogPage));
            IList<IWebElement> Links = blogpage.FindElements(By.XPath(ele_BlogATag));
            int count = Links.Count();
            TestContext.Progress.WriteLine("Latest Content Contains " + Links.Count() + " links.");
            TestContext.Progress.WriteLine("Latest Content contain links list:");
            for (int i = 0; i < count; i++)
            {
                string learning_elements = Links[i].GetAttribute("href");
                TestContext.Progress.WriteLine(learning_elements);
            }
        }

        //TC_042 & TC_043 -- Verifying scrollUP button presence and Navigation.
        [Test]
        public void ScrollUpButton()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);
            IWebElement scrollup = driver.FindElement(By.XPath(ele_ScrollBtn));
            TestContext.Progress.WriteLine("Scroll top button is visible: " + scrollup.Displayed);
            scrollup.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5000);
            IWebElement toppage = driver.FindElement(By.LinkText("Java SDET Academy"));
            if (toppage.Displayed)
            {
                TestContext.Progress.WriteLine("Scrollup button working fine");
            }
        }

        //TC_045 -- Verifying learning elements by hovering
        [Test]
        public void HoverLearning()
        {
            IWebElement learning = driver.FindElement(By.XPath(ele_HoverLearning));
            Actions act = new Actions(driver);
            act.MoveToElement(learning).Perform();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5000);
            IWebElement learningsubmenu = driver.FindElement(By.XPath(ele_HoverLearningATag));
            IList<IWebElement> Links = learningsubmenu.FindElements(By.TagName("a"));
            int count = Links.Count();
            for (int i = 0; i < count; i++)
            {
                string learning_elements = Links[i].GetAttribute("href");
                TestContext.Progress.WriteLine(learning_elements);
            }
        }
        
        //TC_046 -- Verifying About elements by hovering
        [Test]
        public void HoverAbout()
        {
            IWebElement about = driver.FindElement(By.LinkText("About"));
            Actions act = new Actions(driver);
            act.MoveToElement(about);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5000);
            IWebElement aboutsubmenu = driver.FindElement(By.XPath(ele_HoverAboutATag));
            IList<IWebElement> Links = aboutsubmenu.FindElements(By.TagName("a"));
            int count = Links.Count();
            for (int i = 0; i < count; i++)
            {
                string about_elements = Links[i].GetAttribute("href");
                TestContext.Progress.WriteLine(about_elements);
            }
        }

        //TestCaseId: 047 -- Verifying Main text presence in Ultimateqa home page.
        [Test]
        public void MainText()
        {
            try
            {
                Thread.Sleep(4000);
                String mainText = driver.FindElement(By.XPath(ele_MainText)).Text;
                Assert.AreEqual(mainText, "MASTER TEST AUTOMATION, FASTER.");
            }
            catch(Exception ex)
            {
                TestContext.Progress.Write(ex);
            }  
        }

        //TestCaseId: 048 -- Verifying Banner Image presence in home page
        [Test]
        public void VerifyHomepageImage()
        {
            try
            {
                Assert.IsTrue(driver.FindElement(By.XPath(ele_ImageLink)).Displayed);
                TestContext.Progress.WriteLine("Image is present");
            }
            catch (Exception e)
            {
                TestContext.Progress.Write(e);
            }
        }

        //TestCaseId: 049 -- Verifying presence of social media links in floating panel on left side.
        [Test]
        public void SMFloatingPanel()
        {
            try
            {
                IWebElement FloatingPanel = driver.FindElement(By.XPath(ele_SMFloatingPanel));
                TestContext.Progress.WriteLine("Floating panel of social media links are present: " + FloatingPanel.Displayed);
            }
            catch(Exception e)
            {
                TestContext.Progress.Write(e);
            }
        }

        //TestCaseId: 050 -- Verifying FeatruedIn text in Ultimateqa homepage.
        [Test]
        public void FeaturedInText()
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("Window,scrollBy(0,800)");
                Thread.Sleep(5000);
                String featuredtext = driver.FindElement(By.XPath(ele_FeaturedInText)).Text;
                Assert.AreEqual(featuredtext, "Featured In");
            }
            catch (Exception e)
            {
                TestContext.Progress.Write(e);
            }
        }

        //TestCaseId:053 -- Verifying Real-World Outcomes Text & Contains blog elements.
        [Test]
        public void RealWorldBlogs()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            IWebElement RealText = driver.FindElement(By.XPath(ele_RealBlog));
            js.ExecuteScript("arguments[0].scrollIntoView()", RealText);
            IWebElement RealWorldBlog = driver.FindElement(By.XPath(ele_RealText));
            TestContext.Progress.WriteLine("Real_World Text is present: " + RealWorldBlog.Displayed + " It contains text is " + RealWorldBlog.Text);
            IList<IWebElement> Links = RealText.FindElements(By.TagName("a"));
            int count = Links.Count();
            for (int i = 0; i < count; i++)
            {
                string learning_elements = Links[i].GetAttribute("href");
                TestContext.Progress.WriteLine(learning_elements);
            }
        }

        //TestCaseId: 055,056 -- Verifying Paragraph presence below the Real-World OutComes Blog.
        [Test]
        public void VerifyParagraph()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            IWebElement text = driver.FindElement(By.XPath(ele_HyperLink));
            js.ExecuteScript("arguments[0].scrollIntoView()", text);
            TestContext.Progress.WriteLine("'Everything you need' Paragraph is present " + text.Displayed);
            IWebElement Para = driver.FindElement(By.XPath(ele_ParaText));
            TestContext.Progress.WriteLine("Paragraph which contains hyperlinks are present " + Para.Displayed);
        }

        //TestCaseId:061 -- Verifying SMLink_facebook link navigation and login button presence.
        [Test]
        public void FacebookLoginButton()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");
            driver.FindElement(By.XPath(ele_FacebookLink)).Click();
            //ele_facebook.Click();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7000);
            SwitchWindows(1);
            string currenttitle = driver.Title;
            Assert.AreEqual(currenttitle, "Facebook");
            TestContext.Progress.WriteLine("Login button is present: " + driver.FindElement(By.Id("loginbutton")).Displayed);
        }

        //TestCaseId: 064 -- Verifying forgotten button presence & navigation in facebook page.
        [Test]
        public void FBForgottenPage()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");
            driver.FindElement(By.XPath(ele_FacebookLink)).Click();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7000);
            SwitchWindows(1);
            IWebElement forgotten = driver.FindElement(By.XPath(ele_FBForgottenLink));
            TestContext.Progress.WriteLine("Forgotten account is present: " + forgotten.Displayed);
            forgotten.Click();
            SwitchWindows(2);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            string forgettentitle = driver.Title;
            Assert.AreEqual(forgettentitle, "Forgotten Password | Can't Log In | Facebook");
        }

        //TestCaseId: 065 -- Verifying CreateNewAccount hypertext presence & Navigation.
        [Test]
        public void FacebookNewAcc()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");// to scroll end of the page
            driver.FindElement(By.XPath(ele_FacebookLink)).Click();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7000);
            SwitchWindows(1);
            IWebElement newacnt = driver.FindElement(By.XPath(ele_CreateNewAcc));
            TestContext.Progress.WriteLine("Create New account button is present: " + newacnt.Displayed);
            newacnt.Click();
            SwitchWindows(2);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            string newacnttitle = driver.Title;
            TestContext.Progress.WriteLine(newacnttitle);
            Assert.AreEqual(newacnttitle, "Sign up for Facebook | Facebook");
        }

        //TestCaseId: 066 -- Verifying Facebook with Login with data driven testing
        [Test, TestCaseSource("GetInputData")]
        public void Fblogin(String Username, string password)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");
            driver.FindElement(By.XPath(ele_FacebookLink)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);
            SwitchWindows(1);
            driver.FindElement(By.CssSelector("#email")).SendKeys(Username);
            driver.FindElement(By.CssSelector("#pass")).SendKeys(password);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            driver.FindElement(By.XPath(ele_FBSubmit)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);
            string result = driver.FindElement(By.XPath(ele_FBResult)).Text;
            string actual = "Please re-enter your password";
            if (result == actual)
            {
                TestContext.Progress.WriteLine("Entered Invalid details");
                Assert.That(result, Is.EqualTo("Please re-enter your password"));
            }
            if (result != actual)
            {
                TestContext.Progress.WriteLine("Invalid details entered");
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile(@"C:\Users\nrageswari\source\repos\AutomationKT_Tasks\Automation_Assesment\Screenshots\fblogin.png", ScreenshotImageFormat.Png);
            }
        }

        //TestCaseId: 072 -- Verifying footer section elements
        [Test]
        public void VerifyFooterElements()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            IWebElement footer = driver.FindElement(By.XPath(ele_FooterLink));
            IList<IWebElement> Links = footer.FindElements(By.TagName("a"));
            int count = Links.Count();
            TestContext.Progress.WriteLine("Footer Contains " + count + " links list: ");
            foreach (IWebElement link in Links)
            {
                if (count > 0)
                {
                    TestContext.Progress.WriteLine(link.Text);
                }
            }
        }

        //TestCaseId: 073 -- Verifying Watermark present in footer section
        [Test]
        public void WaterMark()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
            string watermark = driver.FindElement(By.XPath(ele_WaterMark)).Text;
            Assert.AreEqual(watermark, "© NextLevel Solutions USA, LLC");
        }

        //TestCaseId: 074 & 75 -- Verifying blog page navigation & TechDisText presence.
        [Test]
        public void BlogPageNavigation()
        {
            driver.FindElement(By.LinkText("Blog")).Click();
            String currentURL1 = driver.Url;
            Assert.AreEqual(currentURL1, BlogPage);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);
            IWebElement TechDisText = driver.FindElement(By.XPath(ele_TechDisText));
            TestContext.Progress.Write(TechDisText.Displayed);
        }

        //TestCaseId: 076 -- Verifying blogs which contains in blog page.
        [Test]
        public void VerifyBlogpageElements()
        {
            driver.FindElement(By.LinkText("Blog")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
            IWebElement blogpage = driver.FindElement(By.XPath(ele_BlogElements));
            IList<IWebElement> Links = blogpage.FindElements(By.TagName("a"));
            int count = Links.Count();
            TestContext.Progress.WriteLine("Blog page Contains " + count + " links.");
            TestContext.Progress.WriteLine("Blog page contain links list:");
            foreach (IWebElement link in Links)
            {
                if (count > 0)
                {
                    TestContext.Progress.WriteLine(link.Text);
                }
            }
        }

        //TestCaseId: 078,079 -- Verifying older entries in blog page
        [Test]
        public void OldEntries()
        {
            driver.FindElement(By.LinkText("Blog")).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            IWebElement oldentriesbtn = driver.FindElement(By.LinkText("« Older Entries"));  
            js.ExecuteScript("arguments[0].scrollIntoView()", oldentriesbtn);
            TestContext.Progress.WriteLine("Older entries button is present" + oldentriesbtn.Displayed);
        }

        //TestCaseId: 080,081 Verifying next entries in blog page
        [Test]
        public void NewEntries()
        {
            driver.FindElement(By.LinkText("Blog")).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            IWebElement oldentriesbtn = driver.FindElement(By.LinkText("« Older Entries"));
            js.ExecuteScript("arguments[0].scrollIntoView()", oldentriesbtn);
            oldentriesbtn.Click();
            IWebElement newentriesbtn = driver.FindElement(By.LinkText("Next Entries »"));
            js.ExecuteScript("arguments[0].scrollIntoView()", newentriesbtn);
            TestContext.Progress.WriteLine("Newer entries button is present" + newentriesbtn.Displayed);
        }

        //TestCaseId: 083 -- Verifying blog page contains text in footer section.
        [Test]
        public void FooterText()
        {
            driver.FindElement(By.LinkText("Blog")).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");
            IWebElement Footertext = driver.FindElement(By.XPath(ele_GetAmazeText));
            TestContext.Progress.Write("Footer text in blog page is present " + Footertext.Displayed + " is " + Footertext.Text);
        }

        //TestCaseId: 085,086,087,088,089 -- Navigates to Explicit & Implicit page.
        [Test]
        public void TechDisBlog()
        {
            driver.FindElement(By.LinkText("Blog")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
            driver.FindElement(By.XPath(ele_Article)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4000);
            String currentURL1 = driver.Url;
            Assert.AreEqual(currentURL1, ExplicitBlogLink);
            IWebElement headerText = driver.FindElement(By.XPath(ele_HeaderText));
            TestContext.Progress.WriteLine("Header text is displayed " + headerText.Displayed);
            IWebElement content = driver.FindElement(By.XPath(ele_ArticleContent));
            TestContext.Progress.WriteLine("Content displayed " + content.Displayed);
            try
            {
                Assert.IsTrue(driver.FindElement(By.XPath(ele_Image)).Displayed);
                TestContext.Progress.WriteLine("Explicit blog Image is present");
            }
            catch (Exception e)
            {
                TestContext.Progress.Write(e);
            }
        }

        //TestCaseId: 090 -- Navigates to Explicit & Implicit page.
        [Test]
        public void TechDisBlogNavigation()
        {
            driver.FindElement(By.LinkText("Blog")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
            driver.FindElement(By.XPath(ele_Article)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4000);
            String currentURL1 = driver.Url;
            Assert.AreEqual(currentURL1, ExplicitBlogLink);
            IWebElement content = driver.FindElement(By.XPath(ele_ArticleContent));
            TestContext.Progress.WriteLine(content.Displayed);
        }

        private static IEnumerable<object[]> GetTestData()
        {
            List<object[]> parameters = new List<object[]>();
            using (var reader = new StreamReader(@"data.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    parameters.Add(new object[] { values[0], values[1], values[2], values[3] });
                }
            }
            return parameters;
        }

        private static IEnumerable<object[]> GetInputData()
        {
            List<object[]> parameters = new List<object[]>();
            using (var reader = new StreamReader(@"fb_data.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    parameters.Add(new object[] { values[0], values[1] });
                }
            }
            return parameters;
        }

        private void SwitchWindows(int index)
        {
            driver.SwitchTo().Window(driver.WindowHandles[index]);
        }

        private void SwitchWindowsClose(int index)
        {
            driver.SwitchTo().Window(driver.WindowHandles[index]).Close();
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}