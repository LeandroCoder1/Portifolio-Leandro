namespace Portifolio_Leandro.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public string? RepoUrl { get; set; }
        public string? LiveUrl { get; set; }
        public string[] Tags { get; set; } = Array.Empty<string>();

    }
}
