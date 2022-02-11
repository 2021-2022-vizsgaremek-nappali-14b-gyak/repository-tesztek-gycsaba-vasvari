using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vizsgaremek.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.Stores;
using Vizsgaremek.Models;

namespace Vizsgaremek.Repositories.Tests
{
    [TestClass()]
    public class TeachersTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            ApplicationStore applicationStore = new ApplicationStore();
            applicationStore.DbSource = DbSource.NONE;
            Teachers teachers = new Teachers(applicationStore);

            Assert.IsNotNull(teachers.AllTeachers, "Repositories\\Teachers.css:A tanár lista nincs példányosítva!");

            int expected = 6;
            int actaul = teachers.GetAll().Count;

            Assert.AreEqual(expected, actaul, "Repositories\\Teacher.css:A teszt adatok nem készülnek el megfelelő számban!");
        }

        [TestMethod()]
        public void InsertTest()
        {
            ApplicationStore applicationStore = new ApplicationStore();
            applicationStore.DbSource = DbSource.NONE;
            Teachers teachers = new Teachers(applicationStore);

            Assert.IsNotNull(teachers.AllTeachers, "Repositories\\Teachers.css:A tanár lista nincs példányosítva!");
            Teacher newCanInsertTeacher = new Teacher()
            {
                Id = "20101111111",
                FirstName = "Új",
                LastName = "Tanár",
                Password = "jelszó",
                Meal = true,
                Emploeyment = EmploymentValue.DONEONCOMMISSION,
            };
            Teacher newNotCanInsertTeacher = new Teacher()
            {
                Id = "10101111111",
                FirstName = "Nem Felvehető",
                LastName = "Tanár",
                Password = "jelszó",
                Meal = true,
                Emploeyment = EmploymentValue.DONEONCOMMISSION,
            };
            // Tesztelni kell, hogy az új tanár azonosítója rendbe van-e
            // 1. A tanár felvehető
            teachers.Insert(newCanInsertTeacher);
            int canInsertTeacherExpected = 7;
            int catInsertTeacherActaul = teachers.AllTeachers.Count();
            Assert.AreEqual(canInsertTeacherExpected, catInsertTeacherActaul, "Repositories\\Teachers:Felvehető tanár felvétele esetén nem növekszik a tanárok száma a repoban!");
            // 2. A tanár nem vehető fel
            teachers.Insert(newNotCanInsertTeacher);
            int numberOfTeacherWithIdExptected =
                teachers.AllTeachers.FindAll(teacher => teacher.Id == newCanInsertTeacher.Id).Count;
            int numberOfTeacherWithIdActual = 1;
            Assert.AreEqual(numberOfTeacherWithIdExptected, numberOfTeacherWithIdActual, "Repositories\\Teachers:Egy Id-ből több is van a listába amikor olyan tanár veszük fel, akinek az ID-je már szerepel a listába");

            // Felvesszük a tanár a listába és növekszik-e a tanárok száma

            // Úgy került bele az új tanár a listába, hogy minden adata megvan
        }
    }
}