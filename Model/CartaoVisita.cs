using System.ComponentModel.DataAnnotations;

namespace CartaoDeVisitas.Model
{
    public class CartaoVisita
    {
        [Key]
        public int Id { get; set; }

        [MinLength(2, ErrorMessage = "Os dados informados não correspondem ao padrão aceito. Favor verificar!")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,200}$", ErrorMessage = "Os dados informados não correspondem ao padrão aceito. Favor verificar!")]
        public string NomeCompleto { get; set; }

        [MaxLength(200)]
        public string? NomeEmpresa { get; set; }

        [MaxLength(200)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,200}$", ErrorMessage = "Os dados informados não correspondem ao padrão aceito. Favor verificar.")]
        public string? ProfissaoCargo { get; set; }

        [RegularExpression(@"^(?:(?:\+|00)?(55)\s?)?(?:\(?([1-9][0-9])\)?\s?)(?:((?:9\d|[2-9])\d{3})\-?(\d{4}))$", ErrorMessage = "Informe um número de telefone válido (xx) (xxxxx-xxxx).")]
        public string Telefone1 { get; set; }

        [RegularExpression(@"^(?:(?:\+|00)?(55)\s?)?(?:\(?([1-9][0-9])\)?\s?)(?:((?:9\d|[2-9])\d{3})\-?(\d{4}))$", ErrorMessage = "Informe um número de telefone válido (xx) (xxxxx-xxxx).")]
        public string? Telefone2 { get; set; }

        [Required(ErrorMessage = "Informe o seu email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido.")]
        [MaxLength(250)]
        public string Email { get; set; }

        [MaxLength(200)]
        [RegularExpression(@"^[a-zA-Z0-9._-]{1,200}$", ErrorMessage = "Os dados informados não correspondem ao padrão aceito. Favor verificar!")]
        public string? Facebook { get; set; }

        [MaxLength(200)]
        [RegularExpression(@"^[a-zA-Z0-9._-]{1,200}$", ErrorMessage = "Os dados informados não correspondem ao padrão aceito. Favor verificar!")]
        public string? Instagram { get; set; }

        [MaxLength(200)]
        [RegularExpression(@"^[a-zA-Z0-9._-]{1,200}$", ErrorMessage = "Os dados informados não correspondem ao padrão aceito. Favor verificar!")]
        public string? Twitter { get; set; }

        [MaxLength(200)]
        [RegularExpression(@"^[a-zA-Z0-9._-]{1,200}$", ErrorMessage = "Os dados informados não correspondem ao padrão aceito. Favor verificar!")]
        public string? YouTube { get; set; }

        [MaxLength(200)]
        [RegularExpression(@"^[a-zA-Z0-9._-]{1,200}$", ErrorMessage = "Os dados informados não correspondem ao padrão aceito. Favor verificar!")]
        public  string? Linkedin { get; set; }
        
        [DataType(DataType.DateTime)]

        public DateTime DataCriacao { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DataAtualizacao { get; set; }

    }
}
