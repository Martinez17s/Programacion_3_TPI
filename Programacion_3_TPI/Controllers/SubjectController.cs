﻿using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Programacion_3_TPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {



        [HttpPost("CreateSubject")]
        public async Task<ActionResult<SubjectDto>> CreateSubject([FromBody] SubjectCreateRequest request) { }

        [HttpGet("GetSubject/{id}")]
        public async Task<ActionResult> GetSubject([FromRoute] int id) { }

        [HttpGet("GetAllSubjects")]
        public async Task<ActionResult<List<SubjectDto>>> GetAllSubjects() { }

        [HttpPut("UpdateSubject/{id}")]
        public async Task<ActionResult<SubjectDto>> UpdateSubject([FromBody] SubjectDto subjectDto, int id) { }

        [HttpDelete("DeleteSubject/{id}")]
        public async Task<ActionResult> DeleteSubject([FromRoute] int id) { }

    }
}