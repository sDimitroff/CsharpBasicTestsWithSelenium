using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;


namespace TestProject_Nunit
{
    internal class SeleniumSetMethods
    {



        public static void EnterText( string elementtype, string element, string value)
        {
            if (elementtype == "Id")
                PropertiesCollection.driver.FindElement(By.Id(element)).SendKeys(value);
            if (elementtype == "Name")
                PropertiesCollection.driver.FindElement(By.Name(element)).SendKeys(value);
        }



            public static void SelectDropDown( string elementtype, string element, string value)


        {

            if (elementtype == "Id")
                new SelectElement(PropertiesCollection.driver.FindElement(By.Id(element))).SelectByText(value);
            if (elementtype == "Name")
                new SelectElement(PropertiesCollection.driver.FindElement(By.Name(element))).SelectByText(value);

        }



        public static void Click(string elementtype, string element)
        
        {
            if (elementtype == "Id")
                PropertiesCollection.driver.FindElement(By.Id(element)).Click();

            if (elementtype == "Name")
                PropertiesCollection.driver.FindElement(By.Name(element)).Click();


        }








    }
}
