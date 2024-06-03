using AutoMapper;
using E_Learning.Core.DataTransferObjects;
using E_Learning.Core.Interfaces.Repositories;
using E_Learning.Core.Models;
using E_Learning.Error;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public AssignmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssignmentDto>>> GetAssignments()
        {
            var assignment = await _unitOfWork.Repository<Assignment>().GetAllAsync();
            var mapped = _mapper.Map<IEnumerable<AssignmentDto>>(assignment);
            return Ok(mapped);
        }

        [HttpGet("Id")]
        public async Task<ActionResult<AssignmentDto>> GetAssignment(int id)
        {

            var assignment = await _unitOfWork.Repository<Assignment>().GetAsync(id);
            var mapped = _mapper.Map<AssignmentDto>(assignment);

            return mapped is not null ? Ok(mapped) : NotFound(new ApiResponse(404, $"Product With Id {id} Not Found"));

        }

        [HttpPost("Add")]
        public async Task<ActionResult<AssignmentDto>> AddAssignment(AssignmentDto dto)
        {
            if (ModelState.IsValid)
            {
                var assignment = _mapper.Map<AssignmentDto, Assignment>(dto);
                await _unitOfWork.Repository<Assignment>().AddAsync(assignment);
                await _unitOfWork.CompeleteAsync();

            }
            return Ok(dto);

        }

        [HttpDelete("{id:int?}")]
        public async Task<ActionResult<AssignmentDto>> Delete([FromRoute] int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var assignment = await _unitOfWork.Repository<Assignment>().GetAsync(id.Value);
            if (assignment is null)
                return NotFound();
            try
            {
                _unitOfWork.Repository<Assignment>().Delete(assignment);

                await _unitOfWork.CompeleteAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return Ok(assignment);

        }

        [HttpPost("Edit")]
        public async Task<ActionResult<AssignmentDto>> Edit(AssignmentDto assignmentDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var mapped = _mapper.Map<AssignmentDto, Assignment>(assignmentDto);
                _unitOfWork.Repository<Assignment>().Update(mapped);

                await _unitOfWork.CompeleteAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return Ok(assignmentDto);
        }




    }
}
