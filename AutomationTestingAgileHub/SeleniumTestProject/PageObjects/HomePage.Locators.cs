﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.PageObjects
{
    partial class HomePage
    {
        private IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement AuthenticationButton => _driver.FindElement(By.XPath("//a[text()='Autentificare']"));
        private IWebElement SignUpButton => _driver.FindElement(By.XPath("//a[text()='Înscriere']"));



    }
}
