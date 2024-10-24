﻿using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Programacion_3_TPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "ClientPolicy")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("{clientId}/GetAllSubjectsEnrollments")]
        public async Task<ActionResult<List<SubjectDto>>> GetAllSubjectsEnrollments([FromRoute] int clientId)
        {
            try
            {
                var subjects = await _clientService.GetClientSubjects(clientId);
                if (subjects == null || !subjects.Any())
                {
                    return NotFound($"No subjects found for client with ID {clientId}.");
                }
                return Ok(subjects);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}