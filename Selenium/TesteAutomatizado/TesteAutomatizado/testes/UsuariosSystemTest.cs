using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using TesteAutomatizado.pages;


namespace TesteAutomatizado.testes
{
    [TestFixture]
    class UsuariosSystemTest
    {

        private IWebDriver driver;
        private UsuarioPage usuarios;
        private LeilaoPage leilao;
        private NovoUsuarioPage usuarioNovo;

        public UsuariosSystemTest()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Program Files\chromedriver");
            usuarios = new UsuarioPage(driver);
            leilao = new LeilaoPage(driver);
            usuarioNovo = new NovoUsuarioPage(driver);
        }

        [SetUp]
        public void AntesDoTeste()
        {
            driver = new ChromeDriver(@"C:\Program Files\chromedriver");
        }

        [TearDown]
        public void DepoisDoTeste()
        {
            driver.Close();
        }

        [Test]
        public void DeveCadastrarUmUsuario()
        {
            usuarios.Visita();
            usuarios.Novo().Cadastra("eriellen", "eriellensouza@mastermaq.com.br");

            Assert.IsTrue(usuarios.ExisteNaListagem("eriellen", "eriellensouza@mastermaq.com.br"));
        }

        [Test]
        public void TesteUsuarioSemNomeEmail()
        {
            usuarios.Visita();
            usuarios.Novo().Cadastra("","");
            IWebElement botaoSalvar = driver.FindElement(By.Id("btnSalvar"));
            botaoSalvar.Click();
            
            Assert.IsTrue(driver.PageSource.Contains("Nome obrigatorio!"), "Text not found!");
            Assert.IsTrue(driver.PageSource.Contains("E-mail obrigatorio!"), "Text not found!");
            
        }

        [Test]
        public void DeveCadastrarLeilao()
        {
            leilao.VisitaLeilao();
            leilao.NovoLeilao().CadastraLeilao("Casa T", "5000000", "Ellen");
            Assert.IsTrue(leilao.ExisteNaListagemLeilao("Casa T", "5000000"));

        }

        [Test]
        public void ExcluirUsuario()
        {
            usuarios.Visita();
            usuarios.Exclui(2);
        }
    }
}
