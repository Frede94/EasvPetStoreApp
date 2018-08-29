﻿using Easv.PetStore.Core.Entity;
using System.Collections.Generic;

namespace Easv.PetStore.Core.DomainService
{
    public interface IPetRepository
    {
        Pet Create(Pet pet);

        Pet ReadById(int id);
        List<Pet> ReadAll();

        Pet Update(Pet petUpdate);

        Pet delete(int id);
    }
}
