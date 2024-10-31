namespace TodoListApi.Models.DTO
{
    public class AddItemRequestDto
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
    }
}
