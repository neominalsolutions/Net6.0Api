using Articles.Application;
using Articles.Application.Articles;
using Articles.Application.Dtos;
using Articles.Application.Features.Article.WithComments;
using Articles.Domain.Entities;
using Articles.Infra;
using Articles.Infra.EF.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Net6._0Api.Controllers
{
    [Route("api/[controller]")]
  [ApiController]
  public class ArticlesController : ControllerBase
  {
    private readonly IMediator mediator;

    public ArticlesController(IMediator mediator)
    {
      this.mediator = mediator;
    }



    // api/articles (GET)

    [HttpGet]
    // GET işlemlerinde IActionResult ile çalışırken apidan çıkan dönüş tiplerimizin swagger üzerinde schema olarak yansıması için kullanılan bir yöntem.
    [ProducesResponseType(statusCode:StatusCodes.Status200OK, type: typeof(ArticleWithCommentsDto))]
    public async Task<IActionResult> Get()
    {

     var response = this.mediator.Send(new GetArticleQuery()).GetAwaiter().GetResult();

      return Ok(response);
    }

    // api/articles/id (GET) -> 200 (OK)
    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
      return StatusCode(StatusCodes.Status200OK,new {id = 1});
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ArticleCreateDto dto)
    {


      //article.Name = "213213";
      //article.SetName("asdsad");

      // db atıp kayıt.

      // command
      var entityId = await this.mediator.Send(dto);

      //var service = new ArticleCreateService(new ArticleRepository());
      //service.Create(dto);

      //var repo = new EFArticleRepository(new Articles.Infra.EF.Contexts.AppDbContext());
      //repo.up
     


      return StatusCode(StatusCodes.Status201Created, entityId);
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
