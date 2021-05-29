using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PFSoftware.TimeClockApi.Models.Api;
using PFSoftware.TimeClockApi.Models.Domain;
using PFSoftware.TimeClockApi.Models.ViewModels;
using PFSoftware.TimeClockApi.Services;
using System;
using System.Collections.Generic;

namespace PFSoftware.TimeClockApi.Controllers
{
    [Route("api/shifts")]
    [ApiController]
    public class ShiftsController : ControllerBase
    {
        private readonly ShiftService _service;
        private readonly IMapper _mapper;

        public ShiftsController(ShiftService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/shifts
        [HttpGet]
        public ActionResult<IEnumerable<ShiftViewModel>> GetAllShifts()
        {
            IEnumerable<Shift> shiftItems = _service.GetAllShifts();

            return Ok(_mapper.Map<IEnumerable<ShiftViewModel>>(shiftItems));
        }

        //GET api/shifts/{id}
        [HttpGet("{id}", Name = "GetShiftById")]
        public ActionResult<ShiftViewModel> GetShiftById(int id)
        {
            Shift shift = _service.GetShiftById(id);
            if (shift != null)
                return Ok(_mapper.Map<ShiftViewModel>(shift));

            return NotFound();
        }

        //POST api/shifts
        [HttpPost]
        public ActionResult<ShiftViewModel> CreateShift(CreateEditShiftRequest request)
        {
            if (request.StartTime == DateTime.MinValue || request.RoleId == 0 || request.UserId == 0)
                return Problem("A valid starting time (including timezone offset), roleId, and userId are required.\nA valid starting time could be represented like: 2021-05-29 08:54 AM -05:00");

            Shift newShift = _mapper.Map<Shift>(request);
            _service.CreateShift(newShift);

            ShiftViewModel ShiftViewModel = _mapper.Map<ShiftViewModel>(newShift);

            return CreatedAtRoute(nameof(GetShiftById), new { Id = ShiftViewModel.Id }, ShiftViewModel);
        }

        //POST api/shifts/{id}
        [HttpPost("{id}")]
        public ActionResult UpdateShift(int id, CreateEditShiftRequest request)
        {
            Shift shift = _service.GetShiftById(id);
            if (shift == null)
                return NotFound();

            if (request.Id != null && request.Id != id)
                return ValidationProblem("The ID in the model doesn't match the ID the request was made on.");

            _service.UpdateShift(request, shift);
            return NoContent();
        }

        //DELETE api/shifts/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteShift(int id)
        {
            Shift shift = _service.GetShiftById(id);
            if (shift == null)
                return NotFound();

            _service.DeleteShift(shift);
            return NoContent();
        }
    }
}