using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindeksScoresController : ControllerBase
    {
        IFindeksScoreService _findeksScoreService;

        public FindeksScoresController(IFindeksScoreService findeksScoreService)
        {
            _findeksScoreService = findeksScoreService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _findeksScoreService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int findeksScoreId)
        {
            var result = _findeksScoreService.GetById(findeksScoreId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(FindeksScore findeksScore)
        {
            var result = _findeksScoreService.Add(findeksScore);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(FindeksScore findeksScore)
        {
            var result = _findeksScoreService.Delete(findeksScore);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(FindeksScore findeksScore)
        {
            var result = _findeksScoreService.Update(findeksScore);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
