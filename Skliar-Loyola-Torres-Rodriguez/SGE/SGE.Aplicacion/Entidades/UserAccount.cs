using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGE.Aplicacion.Entidades;

    [Table("user_account")]
    public class UserAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("user_name")]
        [MaxLength(100)]
        public string? UserName { get; set; }

        [Column("name")]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Column("surname")]
        [MaxLength(100)]
        public string? Surname { get; set; }

        [Column("email")]
        [MaxLength(100)]
        public string? Email { get; set; }

        [Column("password")]
        [MaxLength(100)]
        public string? Password { get; set; }

        [Column("role")]
        [MaxLength(20)]
        public string? Role { get; set; }

        public List<Permiso>? Permisos { get; set; }
    }

/*

*/