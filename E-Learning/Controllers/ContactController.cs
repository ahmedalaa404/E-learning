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
    public class ContactController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public ContactController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDto>>> GetContacts()
        {
            var contact = await _unitOfWork.Repository<Contact>().GetAllAsync();
            var mapped = _mapper.Map<IEnumerable<ContactDto>>(contact);
            return Ok(mapped);
        }

        [HttpGet("Id")]
        public async Task<ActionResult<ContactDto>> GetContact(int id)
        {

            var contact = await _unitOfWork.Repository<Contact>().GetAsync(id);
            return contact is not null ? Ok(contact) : NotFound(new ApiResponse(404, $"Product With Id {id} Not Found"));

        }

        [HttpPost("Add")]
        public async Task<ActionResult<ContactDto>> AddContact(ContactDto dto)
        {
            if (ModelState.IsValid)
            {
                var contact = _mapper.Map<ContactDto, Contact>(dto);
                await _unitOfWork.Repository<Contact>().AddAsync(contact);
                await _unitOfWork.CompeleteAsync();

            }
            return Ok(dto);

        }


        [HttpDelete("{id:int?}")]
        public async Task<ActionResult<ContactDto>> Delete([FromRoute] int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var contact = await _unitOfWork.Repository<Contact>().GetAsync(id.Value);
            if (contact is null)
                return NotFound();
            try
            {
                _unitOfWork.Repository<Contact>().Delete(contact);

                await _unitOfWork.CompeleteAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return Ok(contact);

        }


        [HttpPost("Edit")]
        public async Task<ActionResult<ContactDto>> Edit(ContactDto contactDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var mapped = _mapper.Map<ContactDto, Contact>(contactDto);
                _unitOfWork.Repository<Contact>().Update(mapped);

                await _unitOfWork.CompeleteAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return Ok(contactDto);
        }
    }
}
