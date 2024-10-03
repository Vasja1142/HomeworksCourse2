using System.ComponentModel.DataAnnotations;

namespace WinForms
{
    internal class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Login { get; set; }

        [MaxLength(36)] // Длина хеша пароля (или пароля в открытом виде, что небезопасно).  255 - достаточная длина для большинства хешей.
        public string Password { get; set; } //  Можно переименовать в PasswordHash, если используете BCrypt
    }
}
