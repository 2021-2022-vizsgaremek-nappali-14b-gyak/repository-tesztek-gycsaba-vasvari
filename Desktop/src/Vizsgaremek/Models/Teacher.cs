using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgaremek.Models
{
    public enum EmploymentValue { LECTURER, INDENTUREDLABOURER, DONEONCOMMISSION }

    public class Teacher : IComparable
    {
        private string id;
        private string lastName;
        private string firstName;
        private string password;
        private bool meal;
        private EmploymentValue emploeyment;
        private string emploeymentName;

        public Teacher()
        {
            {
                this.Id = string.Empty;
                this.LastName = string.Empty;
                this.FirstName = string.Empty;
                this.Password = string.Empty;
                this.Meal = false;
                this.Emploeyment = EmploymentValue.DONEONCOMMISSION;
            }
        }
        public Teacher(string id, string lastname, string firstname, string password, bool meal, EmploymentValue emploeyment)
        {
            this.id = id;
            this.lastName = lastname;
            this.FirstName = firstname;
            this.Password = password;
            this.Meal = meal;
            this.Emploeyment = emploeyment;
        }

        public string Id { get => id; set => id = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string Password { get => password; set => password = value; }
        public bool Meal { get => meal; set => meal = value; }
        public EmploymentValue Emploeyment { get => emploeyment; set => emploeyment = value; }
        public string EmploeymentName
        {
            get
            {
                switch (emploeyment)
                {
                    case EmploymentValue.LECTURER:
                        return "óraadó";
                    case EmploymentValue.INDENTUREDLABOURER:
                        return "szerződéses alkalmazott";
                    case EmploymentValue.DONEONCOMMISSION:
                        return "állandó megbízásos rendelkező";
                }
                return string.Empty;
            }

            set
            {
                emploeymentName = value;
                if (emploeymentName == "óraadó")
                    emploeyment = EmploymentValue.LECTURER;
                else if (emploeymentName == "szerződéses alkalmazott")
                    emploeyment = EmploymentValue.INDENTUREDLABOURER;
                else
                    emploeyment = EmploymentValue.DONEONCOMMISSION;
            }
        }

        public int CompareTo(object obj)
        {
            if (obj is Teacher)
            {
                Teacher other = (Teacher)obj;
                // 0-át adunk vissza a this megegyezik az obj
                if ((other.id == this.id) &&
                    (other.firstName == this.firstName))
                    return 0;
                else
                {
                    // más esetben az elsődleges összehasonlítás legyen vezetéknév
                    // ha a vezetéknév megegyezik akkor keresztév
                    // ha az is megegyezik id
                    return -1;
                }
            }
            else
                return -1;
        }
    }
}
