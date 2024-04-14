﻿using System;
using Microsoft.AspNetCore.Mvc;
using petConnection.Backend.UnitOfWork.Implementations;
using petConnection.Backend.UnitOfWork.Interfaces;
using petConnection.Share.DTOs;
using petConnection.Share.Entitties;

namespace petConnection.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
	public class ArticlesController : GenericController<Article>
 	{
        private readonly IArticlesUnitOfWork _articleUnitOfWork;

        public ArticlesController(IGenericUnitOfWork<Article> unitOfWork, IArticlesUnitOfWork articleUnitOfWork) : base (unitOfWork) 
		{
            _articleUnitOfWork = articleUnitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
        {
            var response = await _articleUnitOfWork.GetAsync(pagination);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

        [HttpGet("totalPages")]
        public override async Task<IActionResult> GetPagesAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _articleUnitOfWork.GetTotalPagesAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
    }
}

