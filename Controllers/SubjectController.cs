using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using interrapidisimo.Data.Repositories.Interfaces;
using interrapidisimo.Dto;
using interrapidisimo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;

namespace interrapidisimo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;

        public SubjectController(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var subjects = await _subjectRepository.GetAllAsync();
            return Ok(_mapper.Map<List<SubjectDto>>(subjects));
        }

        [HttpGet("byStudent")]
        public async Task<IActionResult> GetByStudentAsync(string userId)
        {
            var subjects = await _subjectRepository.GetByStudentAsync(userId);
            return Ok(_mapper.Map<List<SubjectDto>>(subjects));
        }

        [HttpGet("get-students")]
        public async Task<IActionResult> GetStudentsAsync(int id)
        {
            var subject = await _subjectRepository.GetByIdAsync(id);
            if(subject == null){
                return NotFound();
            }
            var fullNames = subject.UserSubjects.Select(us => us.User.Email).ToList();

            return Ok(fullNames);
        }

        [HttpPost("enroll")]
        public async Task<IActionResult> Enroll(EnrollDto dto)
        {
            //realizr las validaciones aqui de nuevo porque aunque estan en front
            //se pueden saltar modificando el dom
            var subjects = await _subjectRepository.GetByStudentAsync(dto.UserId!);
            if(subjects.Count() >= 3)
            {
                return BadRequest("No puede inscribir mas de 3 materias");
            }
            var subjectToEnroll = await _subjectRepository.GetByIdAsync(dto.SubjectId);
            if(subjectToEnroll != null)
            {
                if(subjects.Any(s => s.TeacherId == subjectToEnroll.TeacherId)){
                    return BadRequest("Ya esta viendo una meteria con este profesor, no puede inscribirla");
                }
                await _subjectRepository.Enroll(dto.UserId!, dto.SubjectId);
                return Ok();
            }
            return BadRequest("Error en la solicitud, revise id de usuario y materia");            
        }
    }
}