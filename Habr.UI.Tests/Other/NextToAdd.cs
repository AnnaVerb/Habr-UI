using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habr.UI.Tests.Other
{
    class NextToAdd 
    {


        ////public void WriteTopicProcessComplex_Success()//fix
        //{
        //    Home page = new Home(Driver);
        //    page.GoHomePage();
        //    page.Login();
        //    Thread.Sleep(2000);

        //    SandboxPage page1 = new SandboxPage(Driver);
        //    page1.WriteTopicProcess();
        //    var result = page1.FieldPostList.Text;
        //    Thread.Sleep(2000);

        //    Assert.IsNotNull(result);
        //    Assert.IsTrue(page1.ButtonWritePostFirstElement.Displayed);
        //    Assert.IsTrue(page1.ButtonWritePostFirstElement.Enabled);

        //    Thread.Sleep(2000);
        //    //Assert.AreEqual("https://habr.com/ru/sandbox/start/", page.Title);
        //}



        //public void CheckBookmarkCounter()

        //{
        //    //var newcounter = page.ButtonBookm arkPost512916Counter.Text;
        //    //Assert.AreNotEqual(counterbeforeremove, newcounter);
        //    //другой вариант проверки
        //    ////check that bookmark is removed => ищем post
        //    //UserMenu page1 = new UserMenu(Driver);
        //    //page.ButtonGreenUser.Click();
        //    //page1.ButtonZakladki.Click();
        //    //Thread.Sleep(2000);

        //    //if (!page.ElementPost_512916.Displayed)
        //    //{
        //    //    WebDriverWait wait2 = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));

        //    //    Assert.IsFalse(page.ElementPost_512916.Displayed);
        //    //}

        //    //else
        //    //{
        //    //    //post is not removed
        //    //    //CodeThrowExceptionStatement()
        //    //    page.GoToPostPage();

        //    //}
        //    //var counter = page.ButtonBookmarkPost512916Counter.Text.ToString();

        //    //if (!counter.Equals("0"))
        //    //{
        //    //    page.ButtonBookmarkPost512916.Click();
        //    //    Thread.Sleep(2000);

        //    //    //Assert.IsFalse(counter.Equals("0"));
        //    //}

        //    //var counterbeforeremove = page.ButtonBookmarkPost512916Counter.Text;

        //    //page.ButtonBookmarkPost512916.Click();
        //    //Thread.Sleep(2000);
        //    //Assert.AreNotEqual("add", a);
        //    //page.ButtonBookmarkPost512916.Click();
        //    //Assert.AreEqual("add", a);
        //}



        //public void CheckAddedPostByUserMenu_Success()
        //{
        //    Post page = new Post(Driver);
        //    page.GoToPostPage();
        //    page.Login();

        //    var post = "Яндекс отчитался о выручке на фоне";
        //    page.PostAddtoFavoriteBySearch(post);
        //    Thread.Sleep(2000);

        //    page.ButtonLogo.Click();
        //    Thread.Sleep(2000);

        //    page.ClickButtonGreenUser();
        //    //page.ButtonZakladki.Click();
        //    //page.ButtonBookmarkPost512916.Click();

        //    bool result = page.ElementTabsPublications.Displayed;
        //    bool result1 = page.ButtonBookmarkPost.Enabled;
        //    Assert.IsTrue(result);
        //    Assert.IsTrue(result1);

        //    //bool result2 = Driver.FindElement(By.XPath("//a[contains(@href,'512916') and @class='post__title_link']")).Displayed;
        //    //Assert.IsTrue(result2);

        //    //https://habr.com/ru/company/ruvds/blog/515544/
        //    //Assert.AreEqual("remove", page.ButtonBookmark.("data-action"));
        //    //page.ButtonLogo.Click();
        //    //Thread.Sleep(2000);
        //    //page.ClickButtonGreenUser();
        //    //page.ButtonZakladki.Click();


        //}

        //public void PostAddandRemoveFromFav512916()
        //{
        //    Post page = new Post(Driver);
        //    page.GoToPostPage();
        //    page.Login();

        //    SetALLOptionsContentByBtnSettings();
        //    //language Settings should be russian and english

        //    var post = "Яндекс отчитался о выручке на фоне";
        //    page.PostAddtoFavoriteBySearch(post);
        //    Thread.Sleep(2000);

        //    //remove post from favs
        //    string a = page.ButtonBookmarkPost.GetAttribute("data-action");

        //    if (page.ButtonBookmarkPost.Displayed && a == "remove")
        //    {
        //        page.ButtonBookmarkPost.Click();

        //        Assert.AreNotEqual("remove", a);
        //        Assert.AreEqual("add", a);

        //    }

        //    else
        //    {
        //        //post is not added
        //        page.GoToPostPage();
        //    }

        //}
        //




        //[TestMethod]
        //дополнить тест

        //public void ButtonWritePostFirstElement()
        //{
        //    Home page = new Home(Driver);
        //    page.GoHomePage();
        //    page.Login();


        //    //bool result = page.ButtonWritePostFirstElement.Displayed;

        //    //"https://habr.com/ru/sandbox/add/"
        //    //Assert.IsTrue(page.ButtonWritePostFirstElement.);
        //    //Assert.IsTrue(page.ButtonWritePostFirstElement.Enabled);

        //    //page.ButtonGreenUser.Click();

        //    //WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        //    //bool result = page.ButtonGreenUser.Displayed;
        //    //Assert.IsTrue(result);

        //}


        //[TestMethod]
        //add waits for visible btn
        //check xpaths

        //public void ClickButtonWritePostFirstElementOnPage()//Как всё произойдет
        //{
        //    BasePage page = new Home(Driver);
        //    page.ClickButtonCreateTopic();

        //    SandboxPage pagesand = new SandboxPage(Driver);
        //    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(4));

        //    Thread.Sleep(2000);

        //    if (ButtonWritePostFirstElement.Displayed)
        //    {
        //        //this one will scroll the element into view for interactions

        //        IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
        //        js.ExecuteScript("arguments[0].scrollIntoView(true);", ButtonWritePostFirstElement);

        //        //ButtonWritePostFirstElement.Click();//new button
        //        Driver.FindElement(By.XPath("//a[@href ='https://habr.com/en/feed/']")).Click();


        //        //          Message:
        //        //              Test method Habr.UI.Tests.HabrTests.ClickButtonWritePostFirstElementOnPage_Success threw exception:
        //        //              OpenQA.Selenium.ElementClickInterceptedException: element click intercepted: 
        //        //Element < a href = "/en/sandbox/add/" class="btn btn_medium btn_blue">...</a> is not clickable at point(256, 16).
        //        //Other element would receive the click: <a href = "https://habr.com/en/feed/" class="nav-links__item-link ">...</a>
        //        //    
        //        Thread.Sleep(2000);

        //    }
        //    else
        //    {
        //        page.ButtonLogo();
        //    }



        //    //Assert.AreEqual("https://habr.com/ru/sandbox/add/", Driver.Contains("https://habr.com/ru/sandbox/add/"));
        //    //ButtonWritePostFirstElement.SendKeys("Enter");
        //    //String tagname = Driver.FindElement(By.XPath("//*['Написать пост']//h2[text()='Как всё произойдет']")).GetAttribute("");
        //    //Assert.AreEqual("1", tagname);
        //    //element = driver.FindElement(By.LinkText("Click me using this link text!")); это наш батн
        //    //this will scroll the element and center it for interaction
        //    //var js = (IJavaScriptExecutor)Driver;
        //    //js.ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'})", element);

        //    ////this one will scroll the element into view for interactions
        //    //IJavaScriptExecutor je = (IJavaScriptExecutor)Driver;
        //    //je.ExecuteScript("arguments[0].scrollIntoView(false);", ButtonWritePostFirstElement);
        //    //wait.Until().ButtonWritePostFirstElement();
        //    //WebDriverWait wait = new WebDriverWait(driver, timeOut);

        //}

        //[Obsolete]
        //public void ClickLogInTwitterPage()
        //{
        //    Home page = new Home(Driver);
        //    //page.GoHomePage();

        //    ClickTwitterLinkFooter();

        //    Thread.Sleep(4000);
        //    //Driver.SwitchTo().Window("twitter.com");

        //    //проверка кнопки Follow, ее присутствие и кликабельность
        //    //span[text()='Follow']
        //    //Assert.IsTrue(BtnFollowTwitterPage.Displayed);
        //    //BtnFollowTwitterPage.Click();

        //    //click button Follow
        //    Thread.Sleep(2000);


        //    //проверка кнопки логина в всплывающем окне

        //    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(4000));
        //    _ = wait.Until(ExpectedConditions.ElementIsVisible((By)BtnLoginTwitterPage));

        //    BtnLoginTwitterPage.Click();
        //    Assert.IsTrue(Driver.Url.Equals("https://twitter.com/login"));


        }


    }

