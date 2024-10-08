
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class SseController : ControllerBase
{
    [HttpGet("Time")]
    public async Task GetEvents()
    {
        Response.Headers.Add("Content-Type", "text/event-stream");
        Response.Headers.Add("Cache-Control", "no-cache");
        Response.Headers.Add("Connection", "keep-alive");

        while (true)
        {
            await Response.WriteAsync($"data: {DateTime.Now}\n\n");
            await Response.Body.FlushAsync();
            await Task.Delay(1000); 
        }
    }
}


