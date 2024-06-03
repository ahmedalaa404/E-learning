using AutoMapper;
using E_Learning.Core.DataTransferObjects;
using E_Learning.Core.Interfaces.Repositories;
using E_Learning.Core.Models;
using E_Learning.Error;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public TopicController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopicDto>>> GetTopics()
        {
            var Topic = await _unitOfWork.Repository<Topic>().GetAllAsync();
            var mapped = _mapper.Map<IEnumerable<TopicDto>>(Topic);
            return Ok(mapped);
        }

        [HttpGet("Id")]
        public async Task<ActionResult<TopicDto>> GetTopic(int id)
        {

            var Topic = await _unitOfWork.Repository<Topic>().GetAsync(id);
            return Topic is not null ? Ok(Topic) : NotFound(new ApiResponse(404, $"Product With Id {id} Not Found"));

        }

        [HttpPost("Add")]
        public async Task<ActionResult<TopicDto>> AddCourse(TopicDto dto)
        {
            if (ModelState.IsValid)
            {
                var Topic = _mapper.Map<TopicDto, Topic>(dto);
                await _unitOfWork.Repository<Topic>().AddAsync(Topic);
                await _unitOfWork.CompeleteAsync();

            }
            return Ok(dto);

        }


        [HttpDelete("{id:int?}")]
        public async Task<ActionResult<TopicDto>> Delete([FromRoute] int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var topic = await _unitOfWork.Repository<Topic>().GetAsync(id.Value);
            if (topic is null)
                return NotFound();
            try
            {
                _unitOfWork.Repository<Topic>().Delete(topic);

                await _unitOfWork.CompeleteAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return Ok(topic);

        }


        [HttpPost("Edit")]
        public async Task<ActionResult<TopicDto>> Edit(TopicDto topicDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var mapped = _mapper.Map<TopicDto, Topic>(topicDto);
                _unitOfWork.Repository<Topic>().Update(mapped);

                await _unitOfWork.CompeleteAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return Ok(topicDto);
        }
    }
}
