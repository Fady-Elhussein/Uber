
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uber.DTOs.VehicleDto;
using Uber.Model;
using Uber.Repo.Interface;

namespace Uber.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehiclesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() {
          return Ok( await _unitOfWork.Vehicles.GetAllAsync());
            
        
        }

        // POST: api/vehicles

        [HttpPost]
        public async Task<IActionResult> Create(CreateVehicleDto dto)
        {

            if (!await _unitOfWork.Vehicles.DriverExists(dto.DriverId))
                return BadRequest("Driver does not exist");

            if (await _unitOfWork.Vehicles.VehicleExistsForDriver(dto.DriverId))
                return BadRequest("Driver already has a vehicle");

            var vehicle = new Vehicle
            {
                Model = dto.Model,
                PlateNumber = dto.PlateNumber,
                Color = dto.Color,
                DriverId = dto.DriverId
            };

            await _unitOfWork.Vehicles.AddAsync(vehicle);
            await _unitOfWork.SaveChangesAsync();

            var result = new VehicleDto
            {
                Id = vehicle.Id,
                Model = vehicle.Model,
                PlateNumber = vehicle.PlateNumber,
                Color = vehicle.Color,
                DriverId = vehicle.DriverId
            };

            return StatusCode(201, result);
        }

        // PUT: api/vehicles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id, UpdateVehicleDto dto)
        {
            var vehicle = await _unitOfWork.Vehicles.GetByIdAsync(id);

            if (vehicle == null)
                return NotFound("Vehicle not found");

            if (!await _unitOfWork.Vehicles.DriverExists(dto.DriverId))
                return BadRequest("Driver does not exist");

            if (vehicle.DriverId != dto.DriverId &&
                await _unitOfWork.Vehicles
                    .VehicleExistsForDriver(dto.DriverId))
                return BadRequest("Driver already has a vehicle");

            vehicle.Model = dto.Model;
            vehicle.PlateNumber = dto.PlateNumber;
            vehicle.Color = dto.Color;
            vehicle.DriverId = dto.DriverId;

            _unitOfWork.Vehicles.Update(vehicle);
            await _unitOfWork.SaveChangesAsync();

            var result = new VehicleDto
            {
                Id = vehicle.Id,
                Model = vehicle.Model,
                PlateNumber = vehicle.PlateNumber,
                Color = vehicle.Color,
                DriverId = vehicle.DriverId
            };

            return Ok(result);
        }

        // DELETE: api/vehicles/{id}
        [Authorize (Roles ="Driver")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicle = await _unitOfWork.Vehicles.GetById(id);

            if (vehicle == null)
                return NotFound("Vehicle not found");

            _unitOfWork.Vehicles.Delete(vehicle);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
