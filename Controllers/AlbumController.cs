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

        return album;

    }

    [HttpPost]
    public IActionResult Create(Album album)
    {
        AlbumService.Add(album);
        return CreatedAtAction(nameof(Get), new { Id = album.Id }, album);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int Id, Album album)
    {
        if (Id != album.Id)
        return BadRequest();

        var existingAlbum = AlbumService.Get(Id);
        if (existingAlbum == null)
            return NotFound();


        AlbumService.Update(album);
        return NoContent();
    }

    [HttpDelete]
    public IActionResult Delete(int Id)
    {
        var album = AlbumService.Get(Id);

        if (album is null)
            return NotFound();

        AlbumService.Delete(Id);

        return NoContent();

    }
}