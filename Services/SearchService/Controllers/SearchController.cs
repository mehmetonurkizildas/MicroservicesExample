﻿using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using SearchService.Helpers;
using SearchService.Models;

namespace SearchService.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<Product>>> SearchProducts([FromQuery] SearchParams searchParams)
        {
            var query = DB.PagedSearch<Product, Product>();

            if (!string.IsNullOrEmpty(searchParams.SearchTerm))
            {
                query.Match(Search.Full, searchParams.SearchTerm).SortByTextScore();
            }

            // Sort by parameters
            query = searchParams.OrderBy switch
            {
                "price" => query.Sort(x => x.Ascending(y => y.Price)),
                _ => query.Sort(x => x.Ascending(y => y.CreatedAt)),
            };

            // Filter by parameters
            query = searchParams.FilterBy switch
            {
                "instock" => query.Match(x => x.StockStatus == "InStock"),
                "outofstock" => query.Match(x => x.StockStatus == "OutOfStock"),
                "limitedstock" => query.Match(x => x.StockStatus == "LimitedStock"),
                "discontinued" => query.Match(x => x.StockStatus == "Discontinued"),
                _ => query.Sort(x => x.Ascending(y => y.CreatedAt)),
            };

           
            if (!string.IsNullOrEmpty(searchParams.Brand))
            {
                query.Match(x => x.Brand == searchParams.Brand);
            }


            query.PageNumber(searchParams.PageNumber);
            query.PageSize(searchParams.PageSize);

            var result = await query.ExecuteAsync();

            return Ok(new
            {
                results = result.Results,
                pageCount = result.PageCount,
                totalCount = result.TotalCount
            });
        }
    }
}