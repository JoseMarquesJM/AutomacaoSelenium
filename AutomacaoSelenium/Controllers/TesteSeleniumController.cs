using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomacaoSelenium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteSeleniumController : ControllerBase
    {
        private IWebDriver webDriver;

        public TesteSeleniumController()
        {
            webDriver = new ChromeDriver();
        }

        [HttpGet]
        public ActionResult Get()
        {
            // abrir url no navegador
            webDriver.Navigate().GoToUrl("https://www.google.com/");

            // encontrar elemento html na tela e inserir texto
            webDriver.FindElement(By.Name("q")).SendKeys("Josemarquesjm");

            // encontrar elemento html pelo xpath e clicar nele
            webDriver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[4]/center/input[1]")).Click();

            // encontar elemento na tela e pegar o texto
            var texto = webDriver.FindElement(By.XPath("//*[@id=\'rso\']/div[6]/div/div/div[1]/div/div/span/a/h3")).Text;
           
            return Ok(texto);
        }
    }
}
