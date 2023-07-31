using Articles.Application;
using Articles.Application.Articles;
using Articles.Application.Dtos;
using Articles.Domain.Entities;
using Articles.Infra;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Net6._0Api.Controllers
{
    [Route("api/[controller]")]
  [ApiController]
  public class ArticlesController : ControllerBase
  {

    // api/articles (GET)

    [HttpGet]
    // GET işlemlerinde IActionResult ile çalışırken apidan çıkan dönüş tiplerimizin swagger üzerinde schema olarak yansıması için kullanılan bir yöntem.
    [ProducesResponseType(statusCode:StatusCodes.Status200OK, type: typeof(ArticleDto))]
    public IActionResult Get()
    {
      var model = new ArticleDto { Id = 1, Name = "Makale1", Description = "Açıklama1"};
      return Ok(model);
    }

    // api/articles/id (GET) -> 200 (OK)
    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
      return StatusCode(StatusCodes.Status200OK,new {id = 1});
    }

    [HttpPost]
    public IActionResult Post([FromBody] ArticleCreateDto dto)
    {


      //article.Name = "213213";
      //article.SetName("asdsad");

      // db atıp kayıt.

      var service = new ArticleCreateService(new ArticleRepository());
      service.Create(dto);

     


      return StatusCode(StatusCodes.Status201Created, dto);
      // return Created()
    }

    [HttpPut("{id:int}")]
    public IActionResult Put([FromRoute] int id, [FromBody] ArticleUpdateDto dto)
    {
      return StatusCode(StatusCodes.Status204NoContent); // 204 No Content.
    }


    [HttpDelete("{id:int}")]
    public IActionResult Delete([FromRoute] int id)
    {
      return StatusCode(StatusCodes.Status204NoContent); // 204 Delete
    }


    // api/articles/id/comments (GET) 

    [HttpGet("{id:int}/comments")]
    public IActionResult GetComments()
    {
      return StatusCode(StatusCodes.Status200OK);
    }

    // api/articles/articleId/comments/commentId (GET) 
    [HttpGet("{articleid:int}/comments/{commentid:int}")]
    public IActionResult GetComment([FromRoute] int articleid, [FromRoute] int commentid)
    {
      return StatusCode(StatusCodes.Status200OK);
    }

    // api/articles/id/addComment (POST)
    [HttpPost("{articleId:int}")]
    public IActionResult AddComment([FromRoute] int articleId, [FromBody] AddCommentDto dto)
    {
      return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPost("{articleId:int}/comments/{commentId:int}")]
    public IActionResult AddComment([FromRoute] int articleId, [FromRoute] int commentid)
    {
      return StatusCode(StatusCodes.Status201Created);
    }


    // filtersDto
    [HttpGet("filters")]
    public IActionResult GetArticlesByFilter([FromQuery] FilterDto dto)
    {
      return StatusCode(StatusCodes.Status200OK);
    }
    




    // api/articles/name (GET) 
    // api/articles (POST) -> 201 (Created)
    // api/articles/id (PUT) -> 204
    // api/articles/id (PATCH) -> 204
    // api/articles/id (DELETE) -> 204 (NoContent)

  }
}
