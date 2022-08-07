using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GradesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Init()
        {
            GradesPrototype.Data.DataSource.CreateData();
        }

        [TestMethod]
        public void TestValidGrade()
        {
            GradesPrototype.Data.Grade grade = new GradesPrototype.Data.Grade(1, "01/08/2022", "Math", "A-", "Very good");

            Assert.AreEqual(grade.AssessmentDate, "01/08/2022");
            Assert.AreEqual(grade.SubjectName, "Math");
            Assert.AreEqual(grade.Assessment, "A-");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestBadDate()
        {
            GradesPrototype.Data.Grade grade = new GradesPrototype.Data.Grade(1, "07/08/2023", "Math", "assesment", "Comments");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDateNotRecognized()
        {
            GradesPrototype.Data.Grade grade = new GradesPrototype.Data.Grade(1, "0108/2022", "Math", "assesment", "Comments");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestBadAssessment()
        {
            GradesPrototype.Data.Grade grade = new GradesPrototype.Data.Grade(1, "01/08/2022", "Math", "assesment", "Comments");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestBadSubject()
        {
            GradesPrototype.Data.Grade grade = new GradesPrototype.Data.Grade(1, "0108/2022", "Test", "assesment", "Comments");

            Assert.AreEqual(grade.Assessment, "assesment");
        }
    }
}
