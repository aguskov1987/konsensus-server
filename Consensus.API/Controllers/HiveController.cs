﻿using System.Threading.Tasks;
using Consensus.API.Auth;
using Consensus.API.Models.Incoming;
using Consensus.Backend.DTOs.Outgoing;
using Consensus.Backend.Hive;
using Consensus.Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Consensus.API.Controllers
{
    [Route("hive")]
    public class HiveController : Controller
    {
        private readonly IHiveService _hive;

        public HiveController(IHiveService hive)
        {
            _hive = hive;
        }

        [HttpPost, Route("search"), AuthorizeEntry]
        public async Task<IActionResult> FindPoints([FromBody] PointSearchModel model)
        {
            PointDto[] points = await _hive.FindPoints(model.Phrase, model.Identifier);
            return Ok(points);
        }

        [HttpPost, Route("point"), AuthorizeEntry]
        public async Task<IActionResult> PostNewPoint([FromBody] NewPointModel model)
        {
            User user = (User)HttpContext.Items["User"];
            PointDto point = await _hive.CreateNewPoint(user.Id, model.Point, model.SupportingLinks,
                model.HiveId, model.Identifier);
            return Ok(new {points = new [] {point}, synapses = new SynapseDto[]{}, origin = point});
        }

        [HttpGet, Route("subgraph"), AuthorizeEntry, DecodeQueryParam]
        public async Task<IActionResult> LoadSubgraph([FromQuery(Name = "pointId")] string pointId)
        {
            SubGraph graph = await _hive.LoadSubgraph(pointId);
            return Ok(graph);
        }

        [HttpPut, Route("respond"), AuthorizeEntry]
        public async Task<IActionResult> RespondToPoint([FromBody] UserResponseModel model)
        {
            return Ok();
        }
        
        [HttpPut, Route("connect"), AuthorizeEntry]
        public async Task<IActionResult> ConnectCauseToSynapse([FromBody] ConnectPointsModel model)
        {
            return Ok();
        }
    }
}
