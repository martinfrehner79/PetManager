using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetManager {
    public class Pet
    {
        public string Name { get; set; }
        public string Breed { get; set; }


        public override int GetHashCode()
        {
            unchecked// Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + (this.Name != null ? this.Name.GetHashCode() : 0);
                hash = hash * 23 + (this.Breed != null ? this.Breed.GetHashCode() : 0);
                hash = hash * 23 + (this.Birthday != null ? this.Birthday.GetHashCode() : 0); 
                return hash;
            }
        }

        public DateTime Birthday { get; set; }
        public int Age
        {
            get
            {
                DateTime n = DateTime.Now; // To avoid a race condition around midnight
                int age = n.Year - Birthday.Year;
                if (n.Month < Birthday.Month || (n.Month == Birthday.Month && n.Day < Birthday.Day))
                    age--;
                return age;
            }
        }

        public Pet(DateTime birthday)
        {
            Birthday = birthday;
        }

        public Pet()
        {
            Birthday = DateTime.Now.Date;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Pet))
            {
                return object.Equals(obj, this);
            }

            var pet = (Pet)obj;
            return string.Equals(this.Name, pet.Name) && Birthday.Equals(pet.Birthday) && 
                   string.Equals(this.Breed, pet.Breed);
        }

    }
}
