namespace BlogManagement.Application.Contract.Article;

public class ArticleSearchModel
{
    public string Title { get; set; }

    public Guid CategoryId { get; set; }
}