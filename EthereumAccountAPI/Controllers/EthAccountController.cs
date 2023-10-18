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
        public double GetBalance(int ownerId) { return 43840.3; }

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
