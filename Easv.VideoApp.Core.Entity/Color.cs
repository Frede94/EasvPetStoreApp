using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.PetStore.Core.Entity
{
    public class Color
    {
        public int ColorId { get; set; }

        public string Color_Name { get; set; }

        public List<Pet> Pets { get; set; }
    }
}
