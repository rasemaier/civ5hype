using Microsoft.AspNetCore.Components.Forms;

namespace civ5hype.Services
{
    public class FileUploadService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<FileUploadService> _logger;
        private const long MaxFileSize = 10 * 1024 * 1024; // 10 MB
        private readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };

        public FileUploadService(IWebHostEnvironment environment, ILogger<FileUploadService> logger)
        {
            _environment = environment;
            _logger = logger;
        }

        public async Task<string?> UploadScreenshotAsync(IBrowserFile file)
        {
            try
            {
                // Validate file size
                if (file.Size > MaxFileSize)
                {
                    _logger.LogWarning("File size exceeds maximum allowed size: {Size}", file.Size);
                    return null;
                }

                // Validate file extension
                var extension = Path.GetExtension(file.Name).ToLowerInvariant();
                if (!AllowedExtensions.Contains(extension))
                {
                    _logger.LogWarning("File extension not allowed: {Extension}", extension);
                    return null;
                }

                // Convert to Base64 for database storage
                using var memoryStream = new MemoryStream();
                await file.OpenReadStream(MaxFileSize).CopyToAsync(memoryStream);
                var base64 = Convert.ToBase64String(memoryStream.ToArray());
                
                // Determine MIME type
                var mimeType = extension switch
                {
                    ".jpg" or ".jpeg" => "image/jpeg",
                    ".png" => "image/png",
                    ".gif" => "image/gif",
                    ".webp" => "image/webp",
                    _ => "image/jpeg"
                };

                // Return data URL
                return $"data:{mimeType};base64,{base64}";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading file: {FileName}", file.Name);
                return null;
            }
        }

        public bool DeleteScreenshot(string? path)
        {
            if (string.IsNullOrEmpty(path))
                return false;

            try
            {
                var filePath = Path.Combine(_environment.WebRootPath, path.TrimStart('/'));
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting file: {Path}", path);
            }

            return false;
        }
    }
}

