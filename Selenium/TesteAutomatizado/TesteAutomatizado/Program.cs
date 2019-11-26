using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TesteAutomatizado.testes;

namespace TesteAutomatizado
{
    public class Program
    {
        static void Main(string[] args)
        {
            IWebDriver chrome = new ChromeDriver(@"C:\Program Files\chromedriver");
            var t = new UsuariosSystemTest();
            t.ExcluirUsuario();

            chrome.Navigate();

            chrome.Navigate().GoToUrl("http://www.google.com.br");

            IWebElement campoTexto = chrome.FindElement(By.Name("q"));

            campoTexto.SendKeys("Mastermaq Software");
            campoTexto.Submit();


            IWebDriver firefox = new FirefoxDriver();
            firefox.Navigate();

            firefox.Navigate().GoToUrl("http://www.google.com.br");

            IWebElement campoTextoF = firefox.FindElement(By.Name("q"));

            campoTextoF.SendKeys("Mastermaq Software");
            campoTextoF.Submit();



               



        }
    }
}
