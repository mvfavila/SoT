﻿using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Repository;
using SoT.Infra.Data.Context;

namespace SoT.Infra.Data.Repositories
{
    public class CategoryRepository : BaseRepository<Category, SoTContext>, ICategoryRepository
    {
    }
}
