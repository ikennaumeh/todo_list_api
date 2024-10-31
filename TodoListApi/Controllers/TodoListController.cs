using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListApi.Data;
using TodoListApi.Models.Domain;
using TodoListApi.Models.DTO;

namespace TodoListApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoListController : ControllerBase
{
    private readonly ApplicationDbContext dbContext;

    public TodoListController(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
        
    }

    [HttpGet]
    public IActionResult FetchAllListItems()
    {
        var items = dbContext.Items.ToList();
        return Ok(items);
    }

    [HttpPost]
    public IActionResult AddItem([FromBody] AddItemRequestDto addItemRequestDto)
    {
        var item = new Item
        {
            Id = Guid.NewGuid(),
            Title = addItemRequestDto.Title,
            Description = addItemRequestDto.Description,
            CreatedDate = DateTime.Now,
        };
        dbContext.Items.Add(item);
        dbContext.SaveChanges();

        var addItemResponseInfo = new AddItemResponseDto
        {
            Id = item.Id,
            Title = item.Title,
            Description = item.Description,
            CreatedDate = item.CreatedDate,
        };

        return Ok(addItemResponseInfo);

    }

    [HttpPut]
    [Route("{id:guid}")]
    public IActionResult UpdateItem([FromRoute]Guid id, [FromBody] UpdateItemRequestDto updateItemRequestDto)
    {
        var item = dbContext.Items.FirstOrDefault(x => x.Id == id);

        if (item == null)
        {
            return NotFound();
        }

        item.Title = updateItemRequestDto.Title;
        item.Description = updateItemRequestDto.Description;
        item.UpdatedDate = DateTime.Now;

        dbContext.SaveChanges();

        var updateResponseInfo = new UpdateItemResponseDto
        {
            Id = item.Id,
            Title = item.Title,
            Description = item.Description,
            UpdatedDate = item.UpdatedDate,
        };

        return Ok(updateResponseInfo);

    }
}
