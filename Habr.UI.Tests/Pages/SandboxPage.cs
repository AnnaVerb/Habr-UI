﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Habr.UI.Tests.Pages
{
    public class SandboxPage : BasePage
    {

        public SandboxPage(IWebDriver driver) : base(driver)
        {

        }



        public IWebElement ButtonWritePostFirstElement//check new xpath
        {
            get
            {
                return Driver.FindElement(By.XPath("//h2[contains(text()='Как всё произойдет')]"));

                //Syntax: //tag[Syntax: //tag[contains(@attribute, ‘value‘)]
                //h2[text()='Как всё произойдет']
                //Example: //input[contains(@id, ‘er-messa’)] ‘value‘)]

                //Example: //input[contains(@id, ‘er-messa’)]
                //a[@href ='/ru/sandbox/add/']//following::h2[1]
                //By.XPath("//a[@href ='/ru/sandbox/add/']//ancestor::div[1]]"));
                //a[@href ='/ru/sandbox/add/']//ancestor::div[1]


            }
        }
        public IWebElement FieldPostList//check
        {
            get
            {
                return Driver.FindElement(By.XPath("//div[@class='posts_list']"));

                //By.XPath("/html/body/div[1]/div[3]/div/div/div[1]/div[2]/div/a[4]/h3");
            }
        }

        public void ClickButtonWritePostFirstElement()
        {
            ButtonWriteTopic.Click();
            ButtonWritePostFirstElement.Click();        
        
        }

        public void WriteTopicProcess()  //https://habr.com/ru/sandbox/start/
        {
            if (IsLogedIn)
            {
                ButtonWriteTopic.Click();
                Thread.Sleep(2000);

                Assert.IsTrue(ButtonWritePostFirstElement.Displayed);
                ButtonWritePostFirstElement.Click();

                //ElementMyPosts.Click();
                //Thread.Sleep(2000);
                //ButtonWritePostFirstElement.Click();
            }

            else
                //Home page = new Home(Driver); 
                Login();
        }


    }
}
