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
        [Authorize(Policy = "ReadBitcoin")]
        public double GetBalance(int ownerId) { return 794618.73; }

        [HttpGet("{ownerId}")]
        [Authorize(Policy = "AdminBitcoin")]
        public List<string> GetAllWallets(int ownerId)
        {
            return new()
            {
                $"{Guid.NewGuid().ToString()}",
                $"{Guid.NewGuid().ToString()}",
                $"{Guid.NewGuid().ToString()}",
            };
        }
        [HttpPost]
        [Authorize(Policy = "AdminBitcoin")]
        public double Deposit([FromHeader] double transferAmount) { return 43840.3 + transferAmount; }

        [HttpPost]
        [Authorize(Policy = "AdminBitcoin")]
        public double Withdraw([FromHeader] double transferAmount) { return 43840.3 - transferAmount; }
    }
}
