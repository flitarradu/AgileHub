﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject
{
    public enum BrowserType
    {
        Chrome,
        Firefox
    }
    public class Hooks
    {
        private BrowserType _browserType;
        protected IWebDriver Driver;

        [SetUp]
        public void Setup()
        {

            var browserType = TestContext.Parameters.Get("Browser", "Chrome");
            _browserType = (BrowserType)Enum.Parse(typeof(BrowserType), browserType);
            ChooseDriverInstance(_browserType);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("http://demosite.casqad.org/");
        }

        public void ChooseDriverInstance(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    //var optionsChrome = new ChromeOptions();
                    //Driver = new RemoteWebDriver(new Uri(" http://localhost:4446/wd/hub"), optionsChrome);
                    Driver = new ChromeDriver();
                    break;
                case BrowserType.Firefox:
                    //var optionsFirefox = new FirefoxOptions();
                    //Driver = new RemoteWebDriver(new Uri(" http://localhost:4446/wd/hub"), optionsFirefox);
                    Driver = new FirefoxDriver();
                    break;
            }
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
