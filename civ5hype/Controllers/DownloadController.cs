using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using civ5hype.Data;
using civ5hype.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace civ5hype.Controllers
{
    [Authorize] // Only require authentication, not specific role
    [Route("admin")]
    public class DownloadController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ApplicationDbContext _dbContext;

        public DownloadController(IMemoryCache memoryCache, ApplicationDbContext dbContext)
        {
            _memoryCache = memoryCache;
            _dbContext = dbContext;
        }

        [HttpGet("download-backup")]
        public async Task<IActionResult> DownloadBackup([FromQuery] string id, [FromQuery] string filename)
        {
            try
            {
                // Manual role check like in DatabaseBackup.razor
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("User not authenticated.");
                }

                var user = await _dbContext.Users.FindAsync(userId);
                if (user?.Role != UserRole.Admin)
                {
                    return Forbid(); // 403 Forbidden
                }

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

