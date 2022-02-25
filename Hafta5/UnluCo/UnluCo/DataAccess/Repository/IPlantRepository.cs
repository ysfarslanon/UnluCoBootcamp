using Paging.Models.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.Entities;

namespace UnluCo.DataAccess.Repository
{
    public interface IPlantRepository
    {
        PagingResultModel<Plant> GetAll(PagingQueryParams pagingQuery);
    }
}
