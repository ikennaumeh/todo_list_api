namespace TodoListApi.Models.Domain
{
    public class Item
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
