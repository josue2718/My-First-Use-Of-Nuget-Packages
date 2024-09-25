using AutoMapper;
using Mangas.Domain.Entities;
using mangas.Services.Features.Mangas;
using manga.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace mangas.Controllers.V1;

[ApiController]
[Route("api/[controller]")]
public class MangaController : ControllerBase
{
    public readonly MangaService _mangaService;
    public readonly IMapper _mapper;

    public MangaController(MangaService mangaService, IMapper mapper)
    {
        this._mangaService = mangaService;
        this._mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var mangas = _mangaService.GetAll();
        var MangaDto = _mapper.Map<IEnumerable<MangaDTO>>(mangas);
        return Ok(MangaDto);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var manga = _mangaService.GetById(id);
        if (manga.Id <= 0)
            return NotFound();
        var dto = _mapper.Map<MangaDTO>(manga);
        return Ok(manga);
    }

    [HttpPost]
public IActionResult Add([FromBody] Manga manga)
{
    // Mapea el objeto Manga desde el request body
    var entity = _mapper.Map<Manga>(manga);

    // Genera un nuevo ID para el manga
    var mangas = _mangaService.GetAll();
    var mangaId = mangas.Count() + 1; // Puede haber una mejor forma de generar el ID en la base de datos

    entity.Id = mangaId;
    
    // Agrega el manga a la base de datos o servicio
    _mangaService.Add(entity);

    // Mapea el objeto Manga a su DTO
    var dto = _mapper.Map<MangaDTO>(entity);

    // Retorna la respuesta Created con la ruta de "GetById"
    return CreatedAtAction(nameof(GetById), new { id = entity.Id }, dto);
}


    [HttpPut("{id}")]
    public IActionResult Update(int id, Manga manga)
    {
        if (id != manga.Id)
            return BadRequest();
        _mangaService.Update(manga);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _mangaService.Delete(id);
        return NoContent();
    }
}