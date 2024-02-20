using API.Controllers;
using API.Data;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace API
{
    [Authorize]
    public class UsersController : BaseAPiController
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository UserRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = UserRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await _userRepository.GetMemberAsync();
            

            return Ok(users);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            
            return await  _userRepository.GetMemberAsync(username);
        }

    }   
}