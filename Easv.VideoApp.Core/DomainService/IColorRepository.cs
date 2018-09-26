using Easv.PetStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.PetStore.Core.DomainService
{
    public interface IColorRepository
    {
        Color Create(Color color);

        Color ReadById(int id);

        IEnumerable<Color> ReadAll();

        Color Update(Color colorUpdate);

        Color Delete(int id);
    }
}
