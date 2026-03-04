using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfAppDemo.Models
{
    [Table("Users")] // Use this class to represent the "Users" table in the database.
    public class User
    {
        [Key] // Primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-generate the Id
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";      
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
