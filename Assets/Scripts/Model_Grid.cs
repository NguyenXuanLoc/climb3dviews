using System;
namespace d
{
    [Serializable]
    public partial class GridData
    {
        public Meta Meta { get; set; }
        public Data Data { get; set; }
        public dynamic PaginationDetails { get; set; }
    }
    [Serializable]
    public partial class Meta
    {
        public long Code { get; set; }
        public string Message { get; set; }
    }
    [Serializable]
    public partial class Hold
    {
        public string type { get; set; }
        public int rotation { get; set; }
    }
    [Serializable]
    public partial class Data
    {
        public long Height { get; set; }
        public long UserId { get; set; }
        public Guid Id { get; set; }
        public long AuthorGrade { get; set; }
        public string Name { get; set; }
        public long UserGrade { get; set; }
        public bool CreatedBySetter { get; set; }
        public long Modified { get; set; }
        public long Visibility { get; set; }
        public bool Published { get; set; }
        public string Holds { get; set; }
        public bool HasConner { get; set; }
        public long UserGradeCount { get; set; }
        public long Created { get; set; }
        public long Popurlarity { get; set; }
        public long Status { get; set; }
        public bool PlaylistIn { get; set; }
        public bool FavouriteIn { get; set; }
        public UserProfile UserProfile { get; set; }
    }
    [Serializable]
    public partial class UserProfile
    {
        public string LastName { get; set; }
        public long Height { get; set; }
        public string Username { get; set; }
        public long FavoriteRouteGrade { get; set; }
        public string FirstName { get; set; }
        public long AccountId { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
    } 
}