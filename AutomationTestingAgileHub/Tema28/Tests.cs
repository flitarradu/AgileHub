﻿using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tema28.PageObjects;

namespace Tema28
{
    [TestFixture]
    class Tests : Hooks
    {
        [Test]
        public void GoogleImagesTest()
        {
            Driver.Manage().Window.Maximize();


            Driver.Navigate().GoToUrl(TestObject.Input);
            // Arrange
            Homepage homePage = new Homepage(Driver);

            // Act
            Driver.SwitchTo().Frame(0);
            homePage.AcceptGoogleTerms();
            homePage.SearchGoogleImage(TestObject.Others);
            homePage.SelectGoogleImage();

            Driver.Navigate().Back();

            //Assert
            Assert.IsTrue(! homePage.imageFrame.Displayed);

        }

        [Test]
        public void DemoQATest()
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            // Arrange
            Homepage homePage = new Homepage(Driver);

            // Act
            homePage.FillDemoQAForm();

            
            //Assert
            Assert.IsTrue(homePage.thanksForm.Displayed);
        }

        [Test]
        public void DemoQAForm()
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://demoqa.com/text-box");

            //Arrange
            Homepage homePage = new Homepage(Driver);

            //Act
            homePage.DemoQATextBox();

            //Assert
            var element = Driver.FindElement(By.XPath("//*[@id='name']"));
            Assert.IsTrue(element.Displayed);


        }

        [Test]
        public void FindShow()
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://www.teatrulsicaalexandrescu.ro/?lang=en");

            // Arrange
            Homepage homePage = new Homepage(Driver);

            // Act
            homePage.TheatreShow();

            //Assert
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, 500)"); 
            Assert.IsTrue(homePage.showNameText.Displayed);
        }

        [Test]
        public void UntoldPage()
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://untold.com/");

            // Arrange
            Homepage homePage = new Homepage(Driver);

            // Act
            homePage.UntoldPage();

            // Assert
            Assert.IsTrue(Driver.FindElement(By.XPath("//*[@id='untold-wrap']/div[3]/div[1]")).Displayed);
        }


    }
}
