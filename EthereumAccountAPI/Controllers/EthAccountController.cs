using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EthereumAccountAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class EthAccountController : ControllerBase
    {
        [HttpGet("{ownerId}")]
        [Authorize(Policy ="ReadEthereum")]
        public double GetBalance(int ownerId) { return 43840.3; }

        [HttpGet("{ownerId}")]
        [Authorize(Policy ="AdminEthereum")]
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
        [Authorize(Policy ="WriteEthereum")]
        public double Deposit([FromHeader]double transferAmount) { return 43840.3+transferAmount; }
        
        [HttpPost]
        [Authorize(Policy = "WriteEthereum")]
        public double Withdraw([FromHeader] double transferAmount) { return 43840.3 - transferAmount; }
    }
}
