﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportScales.Core.Services.Interfaces;
using TransportScales.Dto.DtoModels;

namespace TransportScales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalController : ControllerBase
    {
        private readonly IJournalService _journalService;

        public JournalController(IJournalService journalService)
        {
            _journalService = journalService;
        }

        [HttpGet("journal")]
        public async Task<ActionResult<List<JournalDto>>> GetJournalDtos(CancellationToken ct = default)
        {
            var journalDto = await _journalService.GetJournalDtosAsync(ct);
            return Ok(journalDto);
        }

        [HttpPost("search")]
        public async Task<ActionResult<List<JournalDto>>> SearchInJournal([FromBody] SearchModel searchModel, CancellationToken ct = default)
        {
            var searchDtos = await _journalService.SearchInJournalAsync(searchModel, ct);
            return Ok(searchDtos.ToList());
        }
    }
}
