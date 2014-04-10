﻿using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pt12lolMvc4Application.Web.Controllers;

namespace pt12lolMvc4Application.UnitTests
{
    [TestClass]
    public class HomeControllerUnitTest
    {
        HomeController _controller = new HomeController();

        [TestMethod]
        public void IndexTest()
        {
            var result = _controller.Index() as ViewResult;
            Assert.AreEqual("", result.ViewName);
            Assert.AreEqual(null, result.Model);
        }

        [TestMethod]
        public void AboutTest()
        {
            var result = _controller.About() as ViewResult;
            Assert.AreEqual("", result.ViewName);
            Assert.AreEqual(null, result.Model);
        }

        [TestMethod]
        public void ContactTest()
        {
            var result = _controller.Contact() as ViewResult;
            Assert.AreEqual("", result.ViewName);
            Assert.AreEqual(null, result.Model);
        }
    }
}
