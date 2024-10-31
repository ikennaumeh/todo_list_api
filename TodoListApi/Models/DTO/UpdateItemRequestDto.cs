namespace TodoListApi.Models.DTO
{
    public class UpdateItemRequestDto
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
    }
}
