namespace BlogManagement.Application.Contract.Article;

public class EditArticle:CreateArticle
{
    public Guid ArticleId { get; set; }
}