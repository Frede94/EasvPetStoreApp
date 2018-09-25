using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.PetStore.Core.Entity
{
    class OwnerFilter
    {
        public int CurrentPage { get; set; }
        public int ItemsPrPage { get; set; }
        public string FirstName { get; set; }
        public String LastName { get; set; }
    }
}
