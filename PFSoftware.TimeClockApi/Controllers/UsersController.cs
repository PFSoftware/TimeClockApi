using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PFSoftware.TimeClockApi.Models.Api;
using PFSoftware.TimeClockApi.Models.Domain;
using PFSoftware.TimeClockApi.Models.ViewModels;
using PFSoftware.TimeClockApi.Services;
using System.Collections.Generic;

namespace PFSoftware.TimeClockApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _service;
        private readonly IMapper _mapper;

        public UsersController(UserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<UserViewModel>> GetAllUsers()
        {
            IEnumerable<User> userItems = _service.GetAllUsers();

            return Ok(_mapper.Map<IEnumerable<UserViewModel>>(userItems));
        }

        //GET api/users/{id}
        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<UserViewModel> GetUserById(int id)
        {
            User user = _service.GetUserById(id);
            if (user != null)
                return Ok(_mapper.Map<UserViewModel>(user));

            return NotFound();
        }

        //POST api/users
        [HttpPost]
        public ActionResult<UserViewModel> CreateUser(CreateEditUserRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.FirstName) || string.IsNullOrWhiteSpace(request.LastName))
                return Problem("A valid username, first name, and last name are required.");

            User newUser = _mapper.Map<User>(request);
            _service.CreateUser(newUser);

            UserViewModel UserViewModel = _mapper.Map<UserViewModel>(newUser);

            return CreatedAtRoute(nameof(GetUserById), new { Id = UserViewModel.Id }, UserViewModel);
        }

        //POST api/users/{id}
        [HttpPost("{id}")]
        public ActionResult UpdateUser(int id, CreateEditUserRequest request)
        {
            User user = _service.GetUserById(id);
            if (user == null)
                return NotFound();

            if (request.Id != null && request.Id != id)
                return ValidationProblem("The ID in the model doesn't match the ID the request was made on.");

            _service.UpdateUser(request, user);
            return NoContent();
        }

        //DELETE api/users/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            User user = _service.GetUserById(id);
            if (user == null)
                return NotFound();

            _service.DeleteUser(user);
            return NoContent();
        }
    }
}