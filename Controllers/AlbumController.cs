using album_api.Models;
using album_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace album_api.Controllers;

[ApiController]
[Route("[controller]")]
public class AlbumController : ControllerBase
{
    public AlbumController()
    {

    }

    [HttpGet]
    public ActionResult<List<Album>> GetAll() =>
        AlbumService.GetAll();

    [HttpGet("{Id}")]
    public ActionResult<Album> Get(int Id)
    {
        var album = AlbumService.Get(Id);

        if (album == null)
        {
            return NotFound();
        }
        return Ok(album);

    }
}