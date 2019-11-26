using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TesteAutomatizado.pages
{
    public class UsuarioPage
    {
        IWebDriver driver;

        public UsuarioPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public NovoUsuarioPage Novo()
        {
            driver.FindElement(By.LinkText("Novo Usuário")).Click();
            return new NovoUsuarioPage(driver);
        }

        public Boolean ExisteNaListagem(string nome, string email)
        {

            return driver.PageSource.Contains(nome) && 
                   driver.PageSource.Contains(email);
        }

        public void Visita()
        {
            driver.Navigate().GoToUrl("http://localhost:8080/usuarios");
        }

        public void Exclui(int posicao)
        {

            driver.FindElements(By.TagName("button"))[posicao - 1].Click();

            //driver.FindElements(By.TagName("button"))[posicao-1].Click();
            // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            // pega o alert que está aberto
            IAlert alert = driver.SwitchTo().Alert();
            // confirma
            alert.Accept();

        }
    }
}
