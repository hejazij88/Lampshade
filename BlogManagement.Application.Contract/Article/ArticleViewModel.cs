namespace BlogManagement.Application.Contract.Article;

public class ArticleViewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string Picture { get; set; }
    public string PublishDate { get; set; }
    public string Category { get; set; }
    public Guid CategoryId { get; set; }
}