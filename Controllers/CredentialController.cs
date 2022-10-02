using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PWDManager_BE.Data;
using PWDManager.Shared.Entities;

namespace PWDManager_BE.Controllers
{
    [ApiController]
    [Route("password-cards")]
    public class CredentialController : Controller
    {
        private DataContext _dbContext;

        public CredentialController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Private Methods

        private async Task<CredentialDTO> GetCredentials()
        {
            CredentialDTO response = new CredentialDTO
            {
                data = await _dbContext.Credentials.ToListAsync()
            };
            return response;
        }

        private async Task<Credential> GetDBCredential(int id)
        {
            return await _dbContext.Credentials.FirstOrDefaultAsync(c => c.Id.Equals(id));
        }

        #endregion

        [HttpGet()]
        public async Task<ActionResult<CredentialDTO>> GetAllCredentials()
        {
            return Ok(await GetCredentials());
        }

        [HttpPost]
        public async Task<ActionResult<CredentialDTO>> Create(Credential credential)
        {
            await _dbContext.AddAsync(credential);
            await _dbContext.SaveChangesAsync();

            return Ok(await GetCredentials());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CredentialDTO>> GetCredential(int id)
        {
            var dbCredential = await GetDBCredential(id);
            if (dbCredential == null)
                return NotFound("Sorry, no credential here...");

            CredentialDTO response = new CredentialDTO
            {
                data = dbCredential
            };

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CredentialDTO>> UpdateCredential(Credential credential, int id)
        {
            var dbCredential = await GetDBCredential(id);
            if (dbCredential == null)
                return NotFound("Sorry, but there is no credential...");

            dbCredential.Name = credential.Name;
            dbCredential.Url = credential.Url;
            dbCredential.UserName = credential.UserName;
            dbCredential.Password = credential.Password;

            await _dbContext.SaveChangesAsync();

            return Ok(await GetCredentials());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CredentialDTO>> DeleteCredential(int id)
        {
            var dbCredential = await GetDBCredential(id);
            if (dbCredential == null)
                return NotFound("Sorry, but there is no credential...");

            _dbContext.Credentials.Remove(dbCredential);
            await _dbContext.SaveChangesAsync();

            return Ok(await GetCredentials());
        }
    }
}
