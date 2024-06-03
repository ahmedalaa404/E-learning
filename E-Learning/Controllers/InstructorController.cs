using AutoMapper;
using E_Learning.Core.DataTransferObjects;
using E_Learning.Core.Interfaces.Repositories;
using E_Learning.Core.Models;
using E_Learning.Error;
using E_Learning.Repository.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepoInstructor repoInstructor;

        public InstructorController(IUnitOfWork unitOfWork, IMapper mapper, IRepoInstructor RepoInstructor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            repoInstructor = RepoInstructor;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstructorDto>>> GetInstructors()
        {
            var instructor = await _unitOfWork.Repository<AppUser>().GetAllAsync();
            var mapped = _mapper.Map<IEnumerable<InstructorDto>>(instructor);
            return Ok(mapped);
        }

        [HttpGet("Id")]
        public async Task<ActionResult<InstructorDto>> GetInstructor(int id)
        {

            var instructor = await _unitOfWork.Repository<AppUser>().GetAsync(id);
            return instructor is not null ? Ok(instructor) : NotFound(new ApiResponse(404, $"Product With Id {id} Not Found"));

        }

        [HttpPost("Add")]
        public async Task<ActionResult<InstructorDto>> AddCourse(InstructorDto dto)
        {
            if (ModelState.IsValid)
            {
                dto.Id=Guid.NewGuid().ToString();
                var instructor = _mapper.Map<InstructorDto, AppUser>(dto);
                await _unitOfWork.Repository<AppUser>().AddAsync(instructor);
                await _unitOfWork.CompeleteAsync();

            }
            return Ok(dto);

        }


        [HttpDelete]
        public async Task<ActionResult<InstructorDto>> Delete(string? id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();

            var instructor = repoInstructor.GetById(id);
            if (instructor is null)
                return NotFound();
            try
            {
                _unitOfWork.Repository<AppUser>().Delete(instructor);

                await _unitOfWork.CompeleteAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return Ok(instructor);

        }


        [HttpPost("Edit")]
        public async Task<ActionResult<InstructorDto>> Edit(InstructorDto instructorDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var mapped = _mapper.Map<InstructorDto, AppUser>(instructorDto);
                _unitOfWork.Repository<AppUser>().Update(mapped);

                await _unitOfWork.CompeleteAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return Ok(instructorDto);
        }


    }
}
