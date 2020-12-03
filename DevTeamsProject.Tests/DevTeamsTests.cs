using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevTeamsProject.Tests
{
    [TestClass]
    public class DevTeamsTests
    {
        [TestMethod]
        public void DeveloperTests()
        {
            Developer developer = new Developer();
            developer.DeveloperName = "Charles Lucas";
            developer.DevID = 100;
            developer.HasAccessToPluralsight = false;
        }
    }
}
