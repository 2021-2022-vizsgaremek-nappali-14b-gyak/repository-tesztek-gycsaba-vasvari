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
    public class TeacherTestsIsSameWhenSorting
    {
        [TestMethod()]
        public void IsSameWhenSortingTestTeacherAreEqual()
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
            bool expected = true;

            // act
            bool actual = teacher.IsSameWhenSorting(other);
            // assert
            Assert.AreEqual(expected, actual, "A két tanár  megegyzik, az összasonlítás nem true-val tér vissza");
        }

        [TestMethod()]
        public void IsSameWhenSortingTestTeacherFirstNameAreDifferent()
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
                FirstName = "NemÚj",
                LastName = "Tanár",
                Password = "2jelszó",
                Meal = false,
                Emploeyment = EmploymentValue.LECTURER,
            };
            bool expected = false;

            // act
            bool actual = teacher.IsSameWhenSorting(other);
            // assert
            Assert.AreEqual(expected, actual, "A név nem egyezik, az összasonlítás nem false-val tér vissza");
        }

        [TestMethod()]
        public void IsSameWhenSortingTestTeacherLastNameAreDifferent()
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
                Password = "2jelszó",
                Meal = false,
                Emploeyment = EmploymentValue.LECTURER,
            };
            bool expected = false;

            // act
            bool actual = teacher.IsSameWhenSorting(other);
            // assert
            Assert.AreEqual(expected, actual, "A vezetéknév nem egyezik, az összasonlítás nem false-val tér vissza");
        }

        [TestMethod()]
        public void IsSameWhenSortingTestTeacherIdAreDifferent()
        {
            // arrange 
            Teacher teacher = new Teacher()
            {
                Id = "2020222222",
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
                Password = "2jelszó",
                Meal = false,
                Emploeyment = EmploymentValue.LECTURER,
            };
            bool expected = false;

            // act
            bool actual = teacher.IsSameWhenSorting(other);
            // assert
            Assert.AreEqual(expected, actual, "A vezetéknév nem egyezik, az összasonlítás nem false-val tér vissza");
        }
    }
}