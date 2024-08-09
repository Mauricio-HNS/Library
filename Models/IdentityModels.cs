using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    // Classe que representa o usuário na aplicação
    public class ApplicationUser : IdentityUser
    {
        // Propriedades adicionais que você pode querer adicionar
        public string NickName { get; set; } // Exemplo de propriedade personalizada
        public virtual ICollection<Book> RentedBooks { get; set; } // Relacionamento com livros alugados

        // Método para gerar a identidade do usuário
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Criação de identidade com as reivindicações padrão do ASP.NET Core Identity
            var userIdentity = await manager.CreateAsync(this);

            // Adicione reivindicações personalizadas aqui, se necessário
            // Exemplo:
            // userIdentity.AddClaim(new Claim(ClaimTypes.Role, "User"));

            return userIdentity;
        }
    }
}
