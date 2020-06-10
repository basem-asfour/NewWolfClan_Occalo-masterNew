using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WolfClan.SoliHub.Abstracts.Contracts;
using WolfClan.SoliHub.Abstracts.Messages;
using WolfClan.SoliHub.Messages.Base;
using WolfClan.SoliHub.Models.ViewModels;

namespace WolfClan.SoliHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralSettingsController : ControllerBase
    {
        private readonly IGeneralSettingsRepository repo;

        public GeneralSettingsController(IGeneralSettingsRepository repo)
        {
            this.repo = repo;
        }


        // GET: api/Branch
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GeneralSettingsRequest _req = null)
        {
            if (_req == null)
            {
                _req = new GeneralSettingsRequest();
            }
            var res = await repo.GetAll(_req);
            if (res.MessageType == MessageTypes.Success)
            {
                return Ok(res.ResponseData.ToList());
            }
            else
            {
                return BadRequest();
            }
        }


        // GET: api/Branch/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null)
            { return BadRequest(); }
            var res = await repo.GetById(id);
            if (res.MessageType == MessageTypes.Success)
            {
                return Ok(res.ResponseData.ToList());
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/Branch
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GeneralSettingsVM _model)
        {
            if (IsValid(_model))
            {
                var res = await repo.Add(_model);
                if (res.MessageType == MessageTypes.Success)
                {
                    return Ok(res.ResponseData.ToList());
                }
            }
            return BadRequest();
        }

        // PUT: api/Branch/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] GeneralSettingsVM _model)
        {
            if (id != _model.Id) { return BadRequest(); }
            if (IsValid(_model))
            {
                var res = await repo.Update(_model);
                if (res.MessageType == MessageTypes.Success)
                {
                    return Ok(res.ResponseData.ToList());
                }
            }
            return BadRequest();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null && id > 0)
            {
                var res = await repo.Remove(id);
                if (res.MessageType == MessageTypes.Success)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        bool IsValid(GeneralSettingsVM _model)
        {
            // Validate Current Model data
            return true;
            
        }
    }

}
