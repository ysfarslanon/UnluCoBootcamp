using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paging.Models.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.DataAccess.Repository;

namespace UnluCo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private readonly IPlantRepository _repository;

        public PlantsController(IPlantRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] PagingQueryParams pagingQuery)
        {
            var list = _repository.GetAll(pagingQuery);
            return Ok(list);
        }
    }
}
