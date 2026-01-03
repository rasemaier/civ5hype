using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace civ5hype.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("admin")]
    public class DownloadController : Controller
    {
        private readonly IMemoryCache _memoryCache;

        public DownloadController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet("download-backup")]
        public IActionResult DownloadBackup([FromQuery] string id, [FromQuery] string filename)
        {
            try
            {
                var cacheKey = $"backup_{id}";
                if (_memoryCache.TryGetValue(cacheKey, out byte[]? bytes) && bytes != null)
                {
                    // Remove from cache after retrieval
                    _memoryCache.Remove(cacheKey);
                    return File(bytes, "application/json", filename);
                }
                
                return BadRequest("Backup not found or expired. Please try exporting again.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}

