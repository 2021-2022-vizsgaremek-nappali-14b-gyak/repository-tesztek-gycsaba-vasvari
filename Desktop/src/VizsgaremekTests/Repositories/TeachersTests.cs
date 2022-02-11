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
        }
    }
}