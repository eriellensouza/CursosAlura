using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteAutomatizado.pages
{
    public class LeilaoPage
    {
        IWebDriver driver;

        public LeilaoPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public NovoLeilaoPage NovoLeilao()
        {
            driver.FindElement(By.LinkText("Novo Leilão")).Click();
            return new NovoLeilaoPage(driver);
        }

        public Boolean ExisteNaListagemLeilao(String nome, String valor)
        {
            return driver.PageSource.Contains(nome) && 
                   driver.PageSource.Contains(valor);
        }

        public void VisitaLeilao()
        {
            driver.Navigate().GoToUrl("http://localhost:8080/leiloes");
        }

    }
}

