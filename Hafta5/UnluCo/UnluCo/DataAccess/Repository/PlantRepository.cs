using Paging.Models.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.Entities;

namespace UnluCo.DataAccess.Repository
{
    public class PlantRepository : IPlantRepository
    {
        private readonly UnluDbContext _context;

        public PlantRepository(UnluDbContext context)
        {
            _context = context;
        }
        public PagingResultModel<Plant> GetAll(PagingQueryParams pagingQuery)
        {
            PagingResultModel<Plant> plants = new PagingResultModel<Plant>(pagingQuery);

            plants.GetData(_context.Plants);

            return plants;
        }
    }
}
