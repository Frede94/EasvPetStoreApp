using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.PetStore.Core.Entity
{
    public class Owner
    {
        public int OwnerId { get; set; }

        public string First_name { get; set; }

        public string Last_name { get; set; }

        public string Adress { get; set; }

        //public Pet Pets { get; set; }

        public List<Pet> Pets { get; set; }

    }
}
