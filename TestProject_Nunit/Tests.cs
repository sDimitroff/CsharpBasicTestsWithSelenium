using Microsoft.VisualBasic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit;
namespace TestProject_Nunit
{
    public class Tests
    {
          


        [SetUp]
        public void Setup()
        {
            
          
            PropertiesCollection.driver = new ChromeDriver();
            PropertiesCollection.driver.Navigate().GoToUrl("http://executeautomation.com/demosite/index.html?UserName=&Password=&Login=Login");
        }

        [Test]
        public void Test1()
        {
           

            // Select title
            SeleniumSetMethods.SelectDropDown("Id", "TitleId", "Mr.");

            //Enter some text
            SeleniumSetMethods.EnterText("Name", "Initial", "ExecuteAutomation");

            // Enter first name
            SeleniumSetMethods.EnterText("Name", "FirstName", "Ivan");

            //Enter middle name
            SeleniumSetMethods.EnterText("Name", "MiddleName", "Ivanov");

                    
            //Get text from DDL
            
            Console.WriteLine("The value from my title is \n" + SeleniumGetMethods.GetTextFromDDL("Id", "TitleId"));
            
            // Get text
            Console.WriteLine("The value from my title is \n" + SeleniumGetMethods.GetText("Name", "Initial"));

            SeleniumSetMethods.Click("Name", "Save");
            
            //Verify page title
            var pageTitle = PropertiesCollection.driver.Title;
            Assert.That(pageTitle, Is.EqualTo("Execute Automation"));

            Thread.Sleep(3000);

            //Generate JavaScript Alert
            SeleniumSetMethods.Click("Name", "generate");
          
            //Handle pop up alert
            IAlert alert = PropertiesCollection.driver.SwitchTo().Alert();

             alert.Accept();
             alert.Accept();

            Thread.Sleep(1000);
        }

        
        [TearDown] 
        public void Teardown()
        {
          PropertiesCollection.driver.Close();
        }
    }
}