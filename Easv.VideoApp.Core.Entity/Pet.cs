
using System;
using System.Collections.Generic;

namespace Easv.PetStore.Core.Entity
{
    public class Pet
    {
        //ID: int
        //Name: string
        //Type: string or Enum
        //Birthdate: DateTime
        //SoldDate: DateTime
        //Color: string
        //PreviousOwner: string
        //Price: double

        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public DateTime Birthdate { get; set; }

        public DateTime SoldDate { get; set; }

        public string Color { get; set; }

        public string PrevOwner { get; set; }

        public double Price { get; set; }

        public Owner PetOwner { get; set; }

        //public List<Color> Colors { get; set; }
    }
}
