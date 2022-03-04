using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vizsgaremek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgaremek.Models.Tests
{
    [TestClass()]
    public class TeacherTests
    {
        // 1. A két tanár megegyezik->0
        [TestMethod()]
        public void CompareToTestTeachersAreSame()
        {
            // arrange 
            Teacher teacher = new Teacher()
            {
                Id = "10101111111",
                FirstName = "Új",
                LastName = "Tanár",
                Password = "jelszó",
                Meal = true,
                Emploeyment = EmploymentValue.DONEONCOMMISSION,
            };

            Teacher other = new Teacher()
            {
                Id = "10101111111",
                FirstName = "Új",
                LastName = "Tanár",
                Password = "2jelszó",
                Meal = false,
                Emploeyment = EmploymentValue.LECTURER,
            };
            int expected = 0;

            // act
            int actual=teacher.CompareTo(other);
            // assert
            Assert.AreEqual(expected, actual, "A két tanár minden megegyzik, az összasonlítás nem 0-val tér vissza");

        }

        // 2. this vezetékneve megelőzi a másik vezetknevet ->-1
        [TestMethod()]
        public void CompareToTestTeachersThisLastName()
        {
            Teacher teacher = new Teacher()
            {
                Id = "10101111111",
                FirstName = "János",
                LastName = "Arany",
                Password = "jelszó",
                Meal = true,
                Emploeyment = EmploymentValue.DONEONCOMMISSION,
            };

            Teacher other = new Teacher()
            {
                Id = "20101111111",
                FirstName = "Sándor",
                LastName = "Petőfi",
                Password = "jelszó",
                Meal = true,
                Emploeyment = EmploymentValue.DONEONCOMMISSION,
            };
            int expected = 1;

            // act
            int actual = teacher.CompareTo(other);
            // assert
            Assert.AreEqual(expected, actual, "A this vezetéknév előbb van.");
        }

        // 3. this vezetéknév követi a másik vezetékneve -> +1
        [TestMethod()]
        public void CompareToTestTeachersOtherLastName()
        {
            Teacher teacher = new Teacher()
            {
                Id = "10101111111",
                FirstName = "Sándor",
                LastName = "Petőfi",
                Password = "jelszó",
                Meal = true,
                Emploeyment = EmploymentValue.DONEONCOMMISSION,
            };

            Teacher other = new Teacher()
            {
                Id = "20101111111",
                FirstName = "János",
                LastName = "Arany",
                Password = "jelszó",
                Meal = true,
                Emploeyment = EmploymentValue.DONEONCOMMISSION,
            };
            int expected = 1;

            // act
            int actual = teacher.CompareTo(other);
            // assert
            Assert.AreEqual(expected, actual, "Az other vezetéknév előbb van.");
        }

        // 4. vezetéknevek megegyeznek, this keresztnév megelőzi a másik keresztnevet ->-1
        [TestMethod()]
        public void CompareToTestTeachersLastNameSameThisFirstName()
        {
            Teacher teacher = new Teacher()
            {
                Id = "10101111111",
                FirstName = "András",
                LastName = "Petőfi",
                Password = "jelszó",
                Meal = true,
                Emploeyment = EmploymentValue.DONEONCOMMISSION,
            };

            Teacher other = new Teacher()
            {
                Id = "20101111111",
                FirstName = "Sándor",
                LastName = "Petőfi",
                Password = "jelszó",
                Meal = true,
                Emploeyment = EmploymentValue.DONEONCOMMISSION,
            };
            int expected = -1;

            // act
            int actual = teacher.CompareTo(other);
            // assert
            Assert.AreEqual(expected, actual, "Az other vezetéknév előbb van.");
        }

        // 5. vezetéknevek megegyeznek, this keresznév követi a másik keresztnevet -> +1
        [TestMethod()]
        public void CompareToTestTeachersLastNameSameOtherFirstName()
        {
            Teacher teacher = new Teacher()
            {
                Id = "10101111111",
                FirstName = "Sándor",
                LastName = "Petőfi",
                Password = "jelszó",
                Meal = true,
                Emploeyment = EmploymentValue.DONEONCOMMISSION,
            };

            Teacher other = new Teacher()
            {
                Id = "20101111111",
                FirstName = "András",
                LastName = "Petőfi",
                Password = "jelszó",
                Meal = true,
                Emploeyment = EmploymentValue.DONEONCOMMISSION,
            };
            int expected = +1;

            // act
            int actual = teacher.CompareTo(other);
            // assert
            Assert.AreEqual(expected, actual, "Az other vezetéknév előbb van.");
        }

        // 6. vezetéknév megegyezik, keresztnév megegyzik
        //    this id megelőzi másik id-t ->-1
        [TestMethod()]
        public void CompareToTestTeachersThisId()
        {
            Teacher teacher = new Teacher()
            {
                Id = "10101111111",
                FirstName = "Sándor",
                LastName = "Petőfi",
                Password = "jelszó",
                Meal = true,
                Emploeyment = EmploymentValue.DONEONCOMMISSION,
            };

            Teacher other = new Teacher()
            {
                Id = "20101111111",
                FirstName = "Sándor",
                LastName = "Petőfi",
                Password = "jelszó",
                Meal = true,
                Emploeyment = EmploymentValue.DONEONCOMMISSION,
            };
            int expected = -1;

            // act
            int actual = teacher.CompareTo(other);
            // assert
            Assert.AreEqual(expected, actual, "Az other vezetéknév előbb van.");
        }

        // 7. vezetéknév megegyzik, keresztnév megegyzik
        //    this id követi másik id-t->+1
        [TestMethod()]
        public void CompareToTestTeachersOtherId()
        {
            Teacher teacher = new Teacher()
            {
                Id = "20101111111",
                FirstName = "Sándor",
                LastName = "Petőfi",
                Password = "jelszó",
                Meal = true,
                Emploeyment = EmploymentValue.DONEONCOMMISSION,
            };

            Teacher other = new Teacher()
            {
                Id = "10101111111",
                FirstName = "Sándor",
                LastName = "Petőfi",
                Password = "jelszó",
                Meal = true,
                Emploeyment = EmploymentValue.DONEONCOMMISSION,
            };
            int expected = 1;

            // act
            int actual = teacher.CompareTo(other);
            // assert
            Assert.AreEqual(expected, actual, "Az other vezetéknév előbb van.");
        }
    }
}