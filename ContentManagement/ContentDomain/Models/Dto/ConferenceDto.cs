namespace ContentManagement.ContentDomain.Models.Dto;

public class ConferenceDto
{
    public int userId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
}