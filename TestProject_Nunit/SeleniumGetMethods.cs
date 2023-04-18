using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestProject_Nunit
{
    internal class SeleniumGetMethods
    {


        public static string GetText(string elementtype, string element)

        {
            if (elementtype == "Id")
                return PropertiesCollection.driver.FindElement(By.Id(element)).GetAttribute("value");
            if (elementtype == "Name")
                return PropertiesCollection.driver.FindElement(By.Name(element)).GetAttribute("value");
            else return String.Empty;

        }

        public static string GetTextFromDDL(string elementtype, string element)

        {
            if (elementtype == "Id")
                return new SelectElement(PropertiesCollection.driver.FindElement(By.Id(element))).AllSelectedOptions.SingleOrDefault().Text;
            if (elementtype == "Name")
                return new SelectElement(PropertiesCollection.driver.FindElement(By.Name(element))).AllSelectedOptions.SingleOrDefault().Text;
            else return String.Empty;

        }

    }
}
