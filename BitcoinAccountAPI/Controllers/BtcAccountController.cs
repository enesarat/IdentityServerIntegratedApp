using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BitcoinAccountAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class BtcAccountController : ControllerBase
    {
        [HttpGet("{ownerId}")]
        public double GetBalance(int ownerId) { return 794618.73; }

        [HttpGet("{ownerId}")]
        public List<string> GetAllWallets(int ownerId)
        {
            return new()
            {
                $"{Guid.NewGuid().ToString()}",
                $"{Guid.NewGuid().ToString()}",
                $"{Guid.NewGuid().ToString()}",
            };
        }
    }
}
