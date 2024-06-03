using AutoMapper;
using E_Learning.Core.DataTransferObjects;
using E_Learning.Core.Interfaces.Repositories;
using E_Learning.Core.Models;
using E_Learning.Error;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        

       public CourseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourses()
        {
            var courses = await _unitOfWork.Repository<Course>().GetAllAsync();
            var mapped = _mapper.Map<IEnumerable<CourseDto>>(courses);
            return Ok(mapped);
        }

        [HttpGet("Id")]
        public async Task<ActionResult<CourseDto>> GetCourse(int id)
        {
            
            var course = await _unitOfWork.Repository<Course>().GetAsync(id);
            return course is not null ? Ok(course) : NotFound(new ApiResponse(404, $"Product With Id {id} Not Found"));

        }

        [HttpPost("Add")]
        public async Task<ActionResult<CourseDto>> AddCourse(CourseDto dto)
        {
            if (ModelState.IsValid)
            {
                var course = _mapper.Map<CourseDto, Course>(dto);
                await _unitOfWork.Repository<Course>().AddAsync(course);
                await _unitOfWork.CompeleteAsync();

            }
            return Ok(dto);

        }


        [HttpDelete("{id:int?}")]
        public async Task<ActionResult<CourseDto>> Delete([FromRoute] int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var course = await _unitOfWork.Repository<Course>().GetAsync(id.Value);
            if (course is null)
                return NotFound();
            try
            {
                _unitOfWork.Repository<Course>().Delete(course);

                await _unitOfWork.CompeleteAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return Ok(course);

        }


        [HttpPost("Edit")]
        public async Task<ActionResult<CourseDto>> Edit(CourseDto courseDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var mapped = _mapper.Map<CourseDto, Course>(courseDto);
                _unitOfWork.Repository<Course>().Update(mapped);

                await _unitOfWork.CompeleteAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return Ok(courseDto);
        }
    }
}
