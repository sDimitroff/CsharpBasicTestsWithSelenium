
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;

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
        public void VerifySelectedOption()
        {


            // Select title
            SeleniumSetMethods.SelectDropDown("Id", "TitleId", "Mr.");

            //Enter some text
            SeleniumSetMethods.EnterText("Name", "Initial", "ExecuteAutomation");

            // Enter first name
            SeleniumSetMethods.EnterText("Name", "FirstName", "Ivan");

            //Enter middle name
            SeleniumSetMethods.EnterText("Name", "MiddleName", "Petkanov");

            SeleniumSetMethods.Click("Name", "Save");

            //First way:
            // var selectedTitleId = PropertiesCollection.driver.FindElement(By.XPath("//*[@id=\"TitleId\"]/option[2]"));
            // var selectedTitleIdText = selectedTitleId.Text;
            //Assert.That(selectedTitleIdText.Equals("Mr."));


            //Second way:
            //var selectedTitleId = PropertiesCollection.driver.FindElement(By.Id("TitleId"));
            //SelectElement selectDDl = new SelectElement(selectedTitleId);
            //var selectedTitleIdText = selectDDl.AllSelectedOptions.SingleOrDefault().Text;
            //Assert.That("Mr.", Is.EqualTo(selectedTitleIdText));


            // Third way:

            var selectedTitleIdText = SeleniumGetMethods.GetTextFromDDL("Id", "TitleId");

            Assert.That("Mr.", Is.EqualTo(selectedTitleIdText));

        }

        [Test]

        public void PrintTextFromDDL()
        {


            // Select title
            SeleniumSetMethods.SelectDropDown("Id", "TitleId", "Mr.");

            //Enter some text
            SeleniumSetMethods.EnterText("Name", "Initial", "ExecuteAutomation");

            // Enter first name
            SeleniumSetMethods.EnterText("Name", "FirstName", "Ivan");

            //Enter middle name
            SeleniumSetMethods.EnterText("Name", "MiddleName", "Ivanov");

            SeleniumSetMethods.Click("Name", "Save");

            //Get text from DDL
            Console.WriteLine("The value from my title is \n" + SeleniumGetMethods.GetTextFromDDL("Id", "TitleId"));
            
           
        }

        

        [Test]

        public void VerifyPageTitle()
        {
            //Verify page title
            var pageTitle = PropertiesCollection.driver.Title;
            Assert.That(pageTitle, Is.EqualTo("Execute Automation"));
        }
        [Test]
        public void HandlePopUpAlert()
        {
            //Handle pop-up alert

            PropertiesCollection.driver.FindElement(By.Name("generate")).Click();
            IAlert alert = PropertiesCollection.driver.SwitchTo().Alert();

            alert.Accept();
            alert.Accept();
        }
        [TearDown] 
        public void Teardown()
        {
          PropertiesCollection.driver.Close();
        }
    }
}
