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
            try
            {
                teachers.Insert(newCanInsertTeacher);
            }
            catch (Exception e)
            {
                Assert.Fail("Repositories\\Teachers:Fevehető tanár esetén, az Insert kivételt dob.\n" + e.Message);
            }
            // Ha a tanár felvehető akkor a tanárok száma egyel kell hogy növekedjen
            int canInsertTeacherExpected = 7;
            int canInsertTeacherActaul = teachers.AllTeachers.Count();
            Assert.AreEqual(canInsertTeacherExpected, canInsertTeacherActaul, "Repositories\\Teachers:Felvehető tanár felvétele esetén nem növekszik a tanárok száma a repoban!");
            // A felvett tanár benne kell legyen a listába
            Teacher insertedTeacherExpected = newCanInsertTeacher;
            Teacher insertedTeacherActaul = teachers.AllTeachers.Find(teacher => teacher == newCanInsertTeacher);
            Assert.AreEqual(insertedTeacherExpected, insertedTeacherActaul, "\\Repositories\\Techers:A felvehető tanár, nem lett felvéve,  nincs a listában");

            //2. a tanár nem vehető fel
            try
            {
                teachers.Insert(newNotCanInsertTeacher);
            }
            catch (Exception e)
            {
                Assert.Fail("Repositories\\Teachers:Nem felvehető tanár esetén, az Insert kivételt dob.\n" + e.Message);
            }
            int numberOfTeacherWithIdExptected =
                teachers.AllTeachers.FindAll(teacher => teacher.Id == newNotCanInsertTeacher.Id).Count;
            int numberOfTeacherWithIdActual = 1;
            Assert.AreEqual(numberOfTeacherWithIdExptected, numberOfTeacherWithIdActual, "Repositories\\Teachers:Egy Id-ből több is van a listába amikor olyan tanár veszük fel, akinek az ID-je már szerepel a listába");
        }

        [TestMethod()]
        public void UpdateTest()
        {
            ApplicationStore applicationStore = new ApplicationStore();
            applicationStore.DbSource = DbSource.NONE;
            Teachers teachers = new Teachers(applicationStore);

            Assert.IsNotNull(teachers.AllTeachers, "Repositories\\Teachers.css:A tanár lista nincs példányosítva!");

            // 1. a keresett tanár nem található
            // "12345678901"
            string wrongId = "12345678901";
            // Teszt: módosítás után evvel az ID-val nincs tanár
            // FindAll-al keresünk wrongID-jü tanárt -> teszt: ilyen tanárok száma nulla
            int expectedWrongIdCount = 0;
            try
            {
                teachers.Update(wrongId, null);
            }
            catch { };
            int actualWrongIdCount = teachers.AllTeachers.FindAll(teacher => teacher.Id == wrongId).Count;
            Assert.AreEqual(expectedWrongIdCount, actualWrongIdCount, "Módosításkor a tanár id nem megfelelő, mégis lett ilyen id-vel tanár");

            // 2. a kereset tanár megtalálható
            // a) módosítás után megkeressük a módosított tanárt
            // b) minden adata meg kell egyezzen a módosításkor használt tanáradatokkal
            // arrange
            string updatedTeacherId = "10101111115";
            Teacher updatedTeacherData = new Teacher()
            {
                Id = "10101111115",
                FirstName = "Módosított",
                LastName = "Tanár",
                Password = "új jelszó",
                Meal = false,
                Emploeyment = EmploymentValue.INDENTUREDLABOURER,
            };
            try
            {
                teachers.Update(updatedTeacherId, updatedTeacherData);
            }
            catch(Exception) { }
            // Mit teszteljük
            //1. A tanárok száma nem változott
            int expected = 6;
            int actual = teachers.AllTeachers.Count;
            Assert.AreEqual(expected, actual, "Módostás után a tanárok száma változik!");
            //2. Létezik-e a tanár
            Teacher fondedTeacher = teachers.AllTeachers.Find(teacher => teacher.Id == updatedTeacherId);
            string expectedID = updatedTeacherId;
            string actualID = fondedTeacher.Id;
            int result = expectedID.CompareTo(actualID);
            if (result!=0)
                Assert.Fail("Módosított tanár id-ja megváltozott, vagy nincs ilyen tanár.");

            //3. Módosult-e a tanár 
            bool expectedEqual = true;
            bool actaulEqual = updatedTeacherData.Equals(fondedTeacher);
            Assert.AreEqual(expectedEqual, actaulEqual, "Módosítás után valamelyik adat nem módosult.");
        }
    }
}