using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.PetStore.Core.Entity
{
    public class Filter
    {
        public int CurrentPage { get; set; }
        public int ItemsPrPage { get; set; }
        public double Price { get; set; }
        public string PrevOwner { get; set; }
        public string Type { get; set; }
    }
}
