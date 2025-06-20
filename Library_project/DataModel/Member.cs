using System.ComponentModel.DataAnnotations;

namespace Library_project.DataModel
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        public string? MemberName { get; set; } 
        public string? MemberPhone { get; set; }
        public string? MemberEmail {  get; set; }
        public string? MemberType { get; set; }
        public string? MemberAddress {  get; set; }
        public bool IsActive { get; set; }
        public int Id { get; internal set; }
    }
}
