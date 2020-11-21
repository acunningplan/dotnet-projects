using FunFacts.Entities;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FunFacts.Dtos;
using FunFacts.Infrastructure;
using FunFacts.FunFactServices;

namespace FunFacts.Controllers
{
    [Route("api/funFact")]
    public class FunFactController : ControllerBase
    {
        private readonly IFunFactService _funFactService;
        private readonly IUserAccessor _userAccessor;

        public FunFactController(IFunFactService funFactService, IUserAccessor userAccessor) : base()
        {
            _funFactService = funFactService;
            _userAccessor = userAccessor;
        }

        // Create, edit, delete
        [HttpPost("{funFactId}")]
        public async Task<IActionResult> CreateAsync(FunFact funFact, string funFactId)
        {
            var user = await _userAccessor.GetCurrentAppUser();
            funFact.Author = user;
            //var funFactDto = await _funFactService.AddFact(funFact, funFactId);
            //if (funFactDto == null) return NotFound();
            //return Ok(funFactDto);
            return Ok();
        }


        //[Authorize(Policy = "IsFunFactAuthor")]
        //[HttpPatch("{funFactId:Guid}")]
        //public override Task<IActionResult> UpdatePartialAsync(Guid funFactId, [FromBody] JsonPatchDocument<FunFact> patchEntity)
        //{
        //    return base.UpdatePartialAsync(funFactId, patchEntity);
        //}

        //[Authorize(Policy = "IsFunFactAuthor")]
        //[HttpDelete("{funFactId}/{funFactId}")]
        //public async Task<IActionResult> DeleteAsync(string funFactId, string funFactId)
        //{
        //    await _funFactService.DeleteAsync(funFactId, funFactId);
        //    return Ok();
        //}
    }
}