using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using System.Data;
using System.Data.SqlClient;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace seleniumTrendyol
{
    
    

    class Program
    {


        public IWebDriver driver;
        //ExtentReports extent = null;
        //ExtentTest extentTest = null;

        static void Main(string[] args)
        {
            

            Program test = new Program();
            

            DateTime StartTime = DateTime.Now;
            string m_OpenBrowser            = test.OpenBrowser();
            string m_GoToPage               = test.GoToPage("https://www.trendyol.com/","Trendyol");
            string m_HomePopupClose         = test.HomePopupClose();
            string m_BtnNavbarUserLogin     = test.BtnNavbarUserLogin();
            string m_UserInformation        = test.UserInformation("beraat.koyuncu@yandex.com", "beraat123");
            string m_BtnLogin               = test.BtnLogin();
            string m_NotificationPopupClose = test.NotificationPopupClose();
            string m_ClearBasket            = test.ClearBasket();
            string m_SearchBox              = test.SearchBox("samsung galaxy s20");
            string m_Select                 = test.Select();
            string m_AddBasket              = test.AddBasket();
            string m_GoToBasket             = test.GoToBasket();
            
            DateTime FinishTime = DateTime.Now;
            TimeSpan span = FinishTime.Subtract(StartTime);
            
            test.DataBase(StartTime,span,m_OpenBrowser, m_GoToPage, m_HomePopupClose, m_BtnNavbarUserLogin, m_UserInformation, m_BtnLogin, m_NotificationPopupClose, m_ClearBasket, m_SearchBox, m_Select, m_AddBasket, m_GoToBasket);

            test.TestQuit();
        }


        

        //public void ExtentStart()
        //{
        //    extent = new ExtentReports();
        //    ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(@"C:\Users\beraa\OneDrive\Masaüstü\seleniumTrendyol\ExtentReports\Program.html");
        //    extent.AttachReporter(htmlReporter);
        //}


        //public void ExtentClose()
        //{
        //    extent.Flush();
        //}
        
         
        public void DataBase(DateTime time,TimeSpan timer, string m_ob, string m_gtp, string m_hpc, string m_bnul, string m_ui, string m_bl, string m_npc, string m_cb, string m_sb, string m_se, string m_ab, string m_gtb)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-Q9BA0JM;Initial Catalog=TrendyolSelenium;Integrated Security=True");
            SqlCommand command = new SqlCommand("insert into Tests (c_DateTime,c_Timer, c_OpenBrowser, c_GoToPage, c_HomePopupClose,c_BtnNavbarUserLogin,c_UserInformation,c_BtnLogin,c_NotificationPopupClose, c_ClearBasket, c_SearchBox, c_Select,c_AddBasket,c_GoToBasket) values('" + time + "','" + timer + "','" + m_ob + "','" + m_gtp + "','" + m_hpc + "','" + m_bnul + "','" + m_ui + "','" + m_bl + "','" + m_npc + "','" + m_cb + "', '"+m_sb+ "','" + m_se + "','" + m_ab + "','" + m_gtb + "') ", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            
        }

        
        public string OpenBrowser()
        {
            
            
            
            try
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                //extentTest./Log(Status.Info, "Chrome browser başlatıldı.");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Chrome browser başlatıldı.");
                return "SUCCESSFUL Chrome browser başlatıldı.";
                //extentTest.Log(Status.Pass, "OpenBrowser passed ");


            }
            catch (Exception ex)
            {

                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("**HATA** Chrome browser başlatılamadı : " + ex.Message);
                return "ERROR Chrome browser başlatılamadı : ";
                
            }

            

        }


        public string GoToPage(string url, string page)
        {

            try
            {
                driver.Navigate().GoToUrl(url);
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine(page + " sayfasına gidildi.");
                return "SUCCESSFUL " + page + " sayfasına gidildi.";

            }
            catch (Exception ex)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("**HATA** " + page + " sayfasına gidilemedi : " + ex.Message);
                return "ERROR " + page + " sayfasına gidilemedi : " + ex.Message;

            }

            
        }


        public string HomePopupClose()
        {

            try
            {
                PageLoadWait(1000);
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector(".fancybox-item.fancybox-close")).Click();
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Popup kapatıldı.");
                return "SUCCESSFUL Popup kapatıldı.";
                

            }
            catch (Exception ex)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("**HATA** Popup kapatılamadı : " + ex.Message);
                return "ERROR Popup kapatılamadı : " + ex.Message;
            }

            
        }


        public string BtnNavbarUserLogin()
        {
            try
            {
                PageLoadWait(1000);
                driver.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]")).Click();
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Giriş sayfasına gidildi.");
                return "SUCCESSFUL Giriş sayfasına gidildi.";
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("**HATA** Giriş sayfasına gidilemedi : " + ex.Message);
                return "ERROR Giriş sayfasına gidilemedi : " + ex.Message;
            }

            
        }


        public string UserInformation(string username, string userpassword)
        {

            try
            {
                PageLoadWait(1000);
                driver.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[3]/div[1]/form[1]/div[1]/input[1]")).SendKeys(username);
                driver.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[3]/div[1]/form[1]/div[2]/div[1]/div[1]/input[1]")).SendKeys(userpassword);
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Kullanıcı bilgileri girildi.");
                return "SUCCESSFUL Kullanıcı bilgileri girildi.";

            }
            catch (Exception ex)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("**HATA** Kullanıcı bilgileri girilemedi : " + ex.Message);
                return "ERROR Kullanıcı bilgileri girilemedi : " + ex.Message;
            }

            
        }


        public string BtnLogin()
        {

            try
            {
                PageLoadWait(1000);
                driver.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[3]/div[1]/form[1]/button[1]")).Click();
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Giriş Yap butonuna tıklandı.");
                return "SUCCESSFUL Kullanıcı bilgileri girildi.";

            }
            catch (Exception ex)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("**HATA** Giriş Yap butonuna tıklanamadı : " + ex.Message);
                return "ERROR Giriş Yap butonuna tıklanamadı : " + ex.Message;
            }

            
        }


        public string NotificationPopupClose()
        {

            try
            {
                PageLoadWait(4000);
                driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div/div/div/div/div[1]")).Click();
                //driver.FindElement(By.CssSelector(".modal-close")).Click();
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Popup kapatıldı.");
                return "SUCCESSFUL Popup kapatıldı.";





                //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
                //driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div/div/div/div/div[1]")).Click();


            }
            catch (Exception ex)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("**HATA** Popup kapatılamadı : " + ex.Message);
                return "ERROR Popup kapatılamadı : " + ex.Message;
            }
            
        }
        

        public string ClearBasket()
        {

            try
            {
                PageLoadWait(1000);
                driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div/div[2]/div/div[3]/div/div/div[2]")).Click();
                PageLoadWait(1000);
                driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/section/section[1]/div[2]/div/div/div[2]/div[2]/div[3]/button")).Click();
                PageLoadWait(1000);
                driver.FindElement(By.XPath("/html/body/div[10]/div[2]/form/div/div[2]/div/div[1]/button[2]")).Click();
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Sepet Temizlendi.");
                return "SUCCESSFUL Sepet Temizlendi.";
            }
            catch (Exception)
            {

                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Sepet Temizlendi.");
                return "SUCCESSFUL Sepet Temizlendi.";
            }

            
        }


        public string SearchBox(string searchtext)
        {

            try
            {
                PageLoadWait(1500);
                IWebElement search = driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div/div[2]/div[2]/div/div/div/input"));
                search.SendKeys(searchtext);
                search.SendKeys(Keys.Enter);
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine(searchtext + " aratıldı.");
                return "SUCCESSFUL" + searchtext + " aratıldı.";

            }
            catch (Exception ex)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("**HATA**" + searchtext + " aratılamadı : " + ex.Message);
                return "ERROR" +searchtext + " aratılamadı : " + ex.Message;
            }

            
        }


        public string Select()
        {
            try
            {
                PageLoadWait(1000);
                driver.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/select[1]/option[2]")).Click();
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("En düşük fiyata göre sıralama yapıldı.");
                return "SUCCESSFUL En düşük fiyata göre sıralama yapıldı.";
            }
            catch (Exception ex)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("**HATA** En düşük fiyata göre sıralama yapılamadı : " + ex.Message);
                return "ERROR En düşük fiyata göre sıralama yapılamadı : " + ex.Message;
            }
        }


        public string AddBasket()
        {

            try
            {
                PageLoadWait(2000);
                driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div[2]/div[3]/div/div[1]/div[1]/div[2]/button/div[1]")).Click();
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("En düşük fiyatlı ürün sepete eklendi.");
                return "SUCCESSFUL En düşük fiyatlı ürün sepete eklendi.";
            }

            catch (NoSuchElementException)
            {
                driver.Navigate().Refresh();
                PageLoadWait(2000);
                driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div[2]/div[3]/div/div[1]/div[1]/div[2]/button/div[1]")).Click();
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("En düşük fiyatlı ürün sepete eklendi.");
                return "SUCCESSFUL En düşük fiyatlı ürün sepete eklendi.";
            }

            catch (Exception ex)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("**HATA** En düşük fiyatlı ürün sepete eklenemedi : " + ex.Message);
                return "ERROR En düşük fiyatlı ürün sepete eklenemedi : " + ex.Message;
               
            }
        }


        public string GoToBasket()
        {

            try
            {
                PageLoadWait(3000);
                driver.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[3]/div[1]/div[1]/div[2]/a[1]")).Click();
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Sepetteki ürünler görüntülendi.");
                return "SUCCESSFUL Sepetteki ürünler görüntülendi.";
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("**HATA**Sepetteki ürünler görüntülenemedi : " + ex.Message);
                return "ERROR Sepetteki ürünler görüntülenemedi : " + ex.Message;
                
            }

        }


        public void PageLoadWait(int ms)
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            Thread.Sleep(ms);
        }


        public void TestQuit()
        {
            driver.Quit();
        }


    }

    


}



