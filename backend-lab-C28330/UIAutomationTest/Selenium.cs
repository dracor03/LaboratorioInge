using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;

namespace UIAutomationTest
{
    public class Selenium
    {
        private IWebDriver _driver;


        [SetUp]
        public void Setup()
        {
            _driver = new EdgeDriver();
        }

        [Test]
        public void CrearPais_DeberiaMostrarMensajeExito()
        {
            string URL = "http://localhost:8080/";
            string nombre = "SeleniumLandia";
            string continente = "Asia";
            string idioma = "Selengués";

            _driver.Navigate().GoToUrl(URL);
            _driver.Manage().Window.Maximize();

            // Ir al formulario
            _driver.FindElement(By.CssSelector("a[href='/pais']")).Click();

            // Llenar el formulario
            _driver.FindElement(By.Id("name")).SendKeys(nombre);
            _driver.FindElement(By.Id("continente")).SendKeys(continente);
            _driver.FindElement(By.Id("idioma")).SendKeys(idioma);

            // Enviar el formulario
            _driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            // Esperar la alerta
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            bool alertAppeared = false;
            try
            {
                wait.Until(driver =>
                {
                    try
                    {
                        var alert = driver.SwitchTo().Alert();
                        alertAppeared = true;
                        alert.Accept(); // cerrar la alerta
                        return true;
                    }
                    catch (NoAlertPresentException)
                    {
                        return false;
                    }
                });
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("No se mostró la alerta esperada.");
            }

            Assert.IsTrue(alertAppeared, "No apareció la alerta de confirmación.");

        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
