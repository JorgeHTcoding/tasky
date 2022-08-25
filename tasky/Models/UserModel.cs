using System.ComponentModel.DataAnnotations;

namespace tasky.Models
{
    public enum Rol { Admin, User};
    public class UserModel {
        [Key]
        public int Id_User { get; set; }
        [Required, StringLength(50)]
        public string Nick { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public Rol Rol { get; set; }
    }
}
