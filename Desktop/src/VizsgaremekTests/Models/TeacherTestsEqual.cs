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
    public class TeacherTestsEqual
    {
        [TestMethod()]
        public void EqualTestTeacherAreEqual()
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
                Password = "jelszó",
                Meal = true,
                Emploeyment = EmploymentValue.DONEONCOMMISSION,
            };
            bool expected = true;

            // act
            bool actual = teacher.Equals(other);
            // assert
            Assert.AreEqual(expected, actual, "A két tanár  megegyzik, az összasonlítás nem true-val tér vissza");
        }

        [TestMethod()]
        public void EqualTestTeacherIdIsDifferent()
        {
            // arrange 
            Teacher teacher = new Teacher()
            {
                Id = "20101111111",
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
                Password = "jelszó",
                Meal = true,
                Emploeyment = EmploymentValue.DONEONCOMMISSION,
            };
            bool expected = false;

            // act
            bool actual = teacher.Equals(other);
            // assert
            Assert.AreEqual(expected, actual, "A két tanár  különbözik, az összasonlítás nem false-val tér vissza");
        }

        [TestMethod()]
        public void EqualTestTeacherIdFirstNameDifferent()
        {
            // arrange 
            Teacher teacher = new Teacher()
            {
                Id = "10101111111",
                FirstName = "NemÚj",
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
                Password = "jelszó",
                Meal = true,
                Emploeyment = EmploymentValue.DONEONCOMMISSION,
            };
            bool expected = false;

            // act
            bool actual = teacher.Equals(other);
            // assert
            Assert.AreEqual(expected, actual, "A két tanár  különbözik, az összasonlítás nem false-val tér vissza");
        }

        [TestMethod()]
        public void EqualTestTeacherIdLastNameDifferent()
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
                LastName = "NemTanár",
                Password = "jelszó",
                Meal = true,
                Emploeyment = EmploymentValue.DONEONCOMMISSION,
            };
            bool expected = false;

            // act
            bool actual = teacher.Equals(other);
            // assert
            Assert.AreEqual(expected, actual, "A két tanár  különbözik, az összasonlítás nem false-val tér vissza");
        }

        [TestMethod()]
        public void EqualTestTeacherPasswordDifferent()
        {
            // arrange 
            Teacher teacher = new Teacher()
            {
                Id = "10101111111",
                FirstName = "Új",
                LastName = "Tanár",
                Password = "NemJelszó",
                Meal = true,
                Emploeyment = EmploymentValue.DONEONCOMMISSION,
            };

            Teacher other = new Teacher()
            {
                Id = "10101111111",
                FirstName = "Új",
                LastName = "Tanár",
                Password = "jelszó",
                Meal = true,
                Emploeyment = EmploymentValue.DONEONCOMMISSION,
            };
            bool expected = false;

            // act
            bool actual = teacher.Equals(other);
            // assert
            Assert.AreEqual(expected, actual, "A két tanár  különbözik, az összasonlítás nem false-val tér vissza");
        }

        [TestMethod()]
        public void EqualTestTeacherMealDifferent()
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
                Password = "jelszó",
                Meal = false,
                Emploeyment = EmploymentValue.DONEONCOMMISSION,
            };
            bool expected = false;

            // act
            bool actual = teacher.Equals(other);
            // assert
            Assert.AreEqual(expected, actual, "A két tanár  különbözik, az összasonlítás nem false-val tér vissza");
        }

        [TestMethod()]
        public void EqualTestTeacherEmploeymentDifferent()
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
                Password = "jelszó",
                Meal = true,
                Emploeyment = EmploymentValue.LECTURER,
            };
            bool expected = false;

            // act
            bool actual = teacher.Equals(other);
            // assert
            Assert.AreEqual(expected, actual, "A két tanár  különbözik, az összasonlítás nem false-val tér vissza");
        }
    }
}