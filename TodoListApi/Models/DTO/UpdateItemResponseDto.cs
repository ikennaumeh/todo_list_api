namespace TodoListApi.Models.DTO
{
    public class UpdateItemResponseDto
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
