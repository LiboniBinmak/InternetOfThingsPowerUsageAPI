using InternetOfThingsPowerUsageAPI.Enums;
using InternetOfThingsPowerUsageAPI.Models.Data;
using InternetOfThingsPowerUsageAPI.Models.Data.Repositories;
using InternetOfThingsPowerUsageAPI.Models.Local;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InternetOfThingsPowerUsageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<BroadcastHub> _hubContext;
        public ValuesController(ApplicationDbContext context, IHubContext<BroadcastHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public IActionResult Get([FromQuery] Value value)
        {
            var data = new ApplianceRepository(_context).FindByIsBeingConfiguredAndHouseHold(true, value.HouseHoldId);
            if (data != null)
            {
               var pattern = new AppliancePatternRepository(_context).Add(new AppliancePattern
                {
                    ApplianceId = data.Id,
                    DateCreated = DateTime.Now,
                    Current = value.Current / 10,
                    Power = (value.Current * value.Voltage) / 10000,
                    FormFactor = value.FormFactor,

                });
                _hubContext.Clients.All.SendAsync(BroadcastHubMethod.AppliancePattern.GetEnumDescription(),pattern);
                data.OnPower = true;
                new ApplianceRepository(_context).Update(data.Id, data);
            }
            var sensorReadingRepository = new SensorReadingRepository(_context);
            var sensor = sensorReadingRepository.Add(new SensorReading
            {
                Current = value.Current/10,
                DateCreated = DateTime.Now,
                Power = (value.Current * value.Voltage)/10000,
                FormFactor = value.FormFactor
            });
            _hubContext.Clients.All.SendAsync(BroadcastHubMethod.AppliancePower.GetEnumDescription(), sensor);
            _hubContext.Clients.All.SendAsync(BroadcastHubMethod.CurrentPower.GetEnumDescription(),
                (sensorReadingRepository.Find().ToList().Sum(a=>a.Current) * value.Voltage)/1000);
            return Ok();
        }
    }
}
