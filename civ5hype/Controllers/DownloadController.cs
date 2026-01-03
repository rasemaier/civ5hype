using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace civ5hype.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("admin")]
    public class DownloadController : Controller
    {
        [HttpGet("download-backup")]
        public IActionResult DownloadBackup([FromQuery] string data, [FromQuery] string filename)
        {
            try
            {
                var bytes = Convert.FromBase64String(data);
                return File(bytes, "application/json", filename);
            }
            catch
            {
                return BadRequest("Invalid data");
            }
        }
    }
}

