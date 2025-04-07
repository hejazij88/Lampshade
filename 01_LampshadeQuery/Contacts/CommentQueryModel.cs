namespace _01_LampshadeQuery.Contacts
{
    public class CommentQueryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string CreationDate { get; set; }
        public Guid ParentId { get; set; }
        public string parentName { get; set; }
    }
}
