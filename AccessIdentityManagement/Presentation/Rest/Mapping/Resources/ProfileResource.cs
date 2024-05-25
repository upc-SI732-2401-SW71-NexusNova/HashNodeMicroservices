namespace HashNode.API.AccessIdentityManagement.Presentation.Rest.Mapping.Resources;

public record ProfileResource(string Id, string FullName, string Bio, string ProfilePictureUrl, string Location, string Website, string Github)
{
}
