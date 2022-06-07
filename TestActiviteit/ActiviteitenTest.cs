using DALMemoryStore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using WeekplannerClassesLibrary;

namespace TestActiviteit
{
    [TestClass]
    public class ActiviteitenTest
    {
        ActiviteitContainer AC;
        [TestInitialize]
        public void TestInIt()
        {
            AC = new(new ActiviteitenMSDAL(7));
        }
        /// <summary>
        /// Hiermee controleer ik of de activiteit daadwerkelijk wordt toegevoegd. 
        /// En of de GetActiviteitById werkt.
        /// </summary>
        [TestMethod]
        public void AddActiviteitAndGetById()
        {
            //Act
            Activiteit actual = new(9,"Test", "Amier", "2", DateTime.Now);
            Activiteit expected;
            
            //Arrange
            AC.AddActivityToUserWTTime(1, actual);
            expected = AC.GetActivityById(9);

            //Assert
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
        }
        /// <summary>
        /// Hiermee test ik of de activiteit daadwerkelijk wordt verwijderd.
        /// </summary>
        [TestMethod]
        public void DeleteActiviteit()
        {
            //Act
            Activiteit test = new(10, "Test", "Amier", "2", DateTime.Now);
            Activiteit actual;
            //Arrange
            AC.AddActivityToUserWTTime(2, test);
            AC.DeleteActivityById(10);

            //Assert
            Assert.IsNull(AC.GetActivityById(10));
        }
        /// <summary>
        /// Hiermee test ik of de methode de juiste lijst teruggeeft.
        /// </summary>
        [TestMethod]
        public void GetAllListById()
        {
            //Act
            Activiteit test = new(11, "Test", "Amier", "2", DateTime.Now);
            List<Activiteit> lijst = new();
            //Arrange
            lijst = AC.GetAllEvents(13);
            //Assert
            Assert.AreEqual("Training2", lijst.Last().Name);

        }
    }
}