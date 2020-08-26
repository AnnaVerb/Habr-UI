using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habr.UI.Tests
{
    public class ProfileTests
    {



        [TestMethod]
        public void Login_Success()
        {

            HomePage page = new HomePage(Driver);
            page.GoHomePage();
        }





    }
