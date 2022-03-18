using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.Models;
using Vizsgaremek.Stores;
using Vizsgaremek.Repositories.Interface;

namespace Vizsgaremek.Repositories
{
    public partial class Teachers : IRepositoryAPIStringId<Teacher>
    {
        private void InsertTeacherInTestData(Teacher teacher)
        {
            if (IsTeacherCanInsert(teacher))
            {
                teachers.Add(teacher);
            }
        }

        private void UpdateTeacherInTestData(string id, Teacher entity)
        {
            if (IsTeacherCanUpdate(id))
            {
                Teacher teacher = teachers.Find(teacher => teacher.Id == id);
                teacher.Set(entity);
            }

        }

        bool IsTeacherCanUpdate(string id)
        {
            if (FindTeacherWithId(id))
                return true;
            else
                return false;
            

        }

        bool IsTeacherCanInsert(Teacher teacher)
        {
            if (FindTeacherWithId(teacher.Id))
                return false;
            else
                return true;
        }

        private bool FindTeacherWithId(string id)
        {
            foreach (Teacher teacher in teachers)
            {
                if (teacher.Id.CompareTo(id) == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
