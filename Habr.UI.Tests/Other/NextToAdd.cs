using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habr.UI.Tests.Other
{
    class NextToAdd 
    {


        //public void ClickUpPanelMenuNavigationLinksMyFeed_Success()
        //{
        //    Home page = new Home(Driver);
        //    page.GoHomePage();
        //    page.Login();

        //    //SetEnglishByBtnSettings();

        //    page.UpPanelMenuNavigationLinksMyFeed.Click();
        //    Thread.Sleep(2000);
        //    //WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        //    bool result = Driver.Url.Contains("habr.com/en/feed");
        //    Assert.IsTrue(result);

        //}

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

        //    page.ButtonWriteTopic.Click();
        //    Thread.Sleep(2000);
        //    SandboxPage page1 = new SandboxPage(Driver);
        //    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(4));

        //    //page1.ClickButtonWritePostFirstElement();


        //    Assert.IsTrue(Driver.Url.Contains("https://habr.com/ru/sandbox/add/"));


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

    }
}
