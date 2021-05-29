using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PFSoftware.TimeClockApi.Constants;
using PFSoftware.TimeClockApi.Models.Api;
using PFSoftware.TimeClockApi.Models.Domain;
using PFSoftware.TimeClockApi.Models.ViewModels;
using PFSoftware.TimeClockApi.Services;
using System.Collections.Generic;

namespace PFSoftware.TimeClockApi.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleService _service;
        private readonly IMapper _mapper;

        public RolesController(RoleService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/roles
        [HttpGet]
        public ActionResult<IEnumerable<RoleViewModel>> GetAllRoles()
        {
            IEnumerable<Role> roleItems = _service.GetAllRoles();

            return Ok(_mapper.Map<IEnumerable<RoleViewModel>>(roleItems));
        }

        //GET api/roles/{id}
        [HttpGet("{id}", Name = "GetRoleById")]
        public ActionResult<RoleViewModel> GetRoleById(int id)
        {
            Role role = _service.GetRoleById(id);
            if (role != null)
                return Ok(_mapper.Map<RoleViewModel>(role));

            return NotFound();
        }

        //POST api/roles
        [HttpPost]
        public ActionResult<RoleViewModel> CreateRole(CreateEditRoleRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name) || request.PayRate == 0m || request.PayPeriod == PayPeriod.None || request.PayType == PayType.None || request.UserId == 0)
                return Problem("A valid name, pay rate, pay type, pay period, and userId are required. Valid pay types include: Hourly, Salary. Valid pay periods include: Weekly, BiWeekly, SemiMonthly, Monthly");

            Role newRole = _mapper.Map<Role>(request);
            _service.CreateRole(newRole);

            RoleViewModel RoleViewModel = _mapper.Map<RoleViewModel>(newRole);

            return CreatedAtRoute(nameof(GetRoleById), new { Id = RoleViewModel.Id }, RoleViewModel);
        }

        //POST api/roles/{id}
        [HttpPost("{id}")]
        public ActionResult UpdateRole(int id, CreateEditRoleRequest request)
        {
            Role role = _service.GetRoleById(id);
            if (role == null)
                return NotFound();

            if (request.Id != null && request.Id != id)
                return ValidationProblem("The ID in the model doesn't match the ID the request was made on.");

            _service.UpdateRole(request, role);
            return NoContent();
        }

        //DELETE api/roles/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteRole(int id)
        {
            Role role = _service.GetRoleById(id);
            if (role == null)
                return NotFound();

            _service.DeleteRole(role);
            return NoContent();
        }
    }
}