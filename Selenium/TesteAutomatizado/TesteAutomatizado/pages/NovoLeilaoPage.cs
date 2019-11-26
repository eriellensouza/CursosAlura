using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TesteAutomatizado.pages
{
    public class NovoLeilaoPage
    {
        IWebDriver driver;

        public NovoLeilaoPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void CadastraLeilao(String nome, String valor, String usuario)
        {

            driver.FindElement(By.Name("leilao.nome")).SendKeys(nome);
            driver.FindElement(By.Name("leilao.valorInicial")).SendKeys(valor);

            SelectElement oSelect = new SelectElement(driver.FindElement(By.Name("leilao.usuario.id")));
            oSelect.SelectByText(usuario);
            driver.FindElement(By.TagName("button")).Click();

        }

    }
}