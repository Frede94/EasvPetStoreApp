using Easv.PetStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.PetStore.Core.ApplicationService
{
    public interface IColorService
    {
        //Create
        Color NewColor(string color_name);
        Color CreateColor(Color c);
        //Read
        List<Color> FindColorByName(string searchValue);
        List<Color> SortByNumberOfPets();
        List<Color> GetAllColors();
        //List<Color> GetFilteredColors(Filter filter);
        //Update
        Color UpdateColor(Color colorUpdate);
        //Delete
        Color Delete(int idForDelete);
    }
}
