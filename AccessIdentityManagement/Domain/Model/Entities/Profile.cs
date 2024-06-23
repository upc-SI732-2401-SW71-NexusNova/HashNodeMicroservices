﻿namespace HashNode.API.AccessIdentityManagement.Domain.Model.Entities



{
    public class Profile
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        public string Github { get; set; }
        
        public Profile()
        {
        }
        
        public Profile(string fullName, string bio, string profilePictureUrl, string location, string website, string github, string username)
        {
            FullName = fullName;
            Bio = bio;
            ProfilePictureUrl = profilePictureUrl;
            Location = location;
            Website = website;
            Github = github;
            Username = username;
        }
        
        public Profile SaveProfile(string fullName, string bio, string profilePictureUrl, string location, string website, string github)
        {
            FullName = fullName;
            Bio = bio;
            ProfilePictureUrl = profilePictureUrl;
            Location = location;
            Website = website;
            Github = github;
            return this;
        }
    }
    
}
