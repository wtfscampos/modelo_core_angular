using System.Collections.Generic;
using System.Security.Claims;

namespace modelo_core_angular.Models
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string Token { get; set; }
        public string Login { get; set; }
        public string DocumentoIdentificacao { get; set; }
        public string DataNascimento { get; set; }
        public List<string> Permissoes { get; set; }

        //public List<UsuarioClaims> Claims { get; set; }
        public string urlApiProjeto { get; set; }
        public string urlApiReserva { get; set; }

        public Usuario(ClaimsPrincipal user)
        {
            Nome = user.Identity.Name;
            Permissoes = new List<string>();
            //Claims = new List<UsuarioClaims>();
            foreach(var claim in user.Claims){
            //Claims.Add(new UsuarioClaims(claim));
               if (claim.OriginalIssuer=="www.identityhml.fazenda.sp.gov.br" &&
                   claim.Type=="http://schemas.microsoft.com/ws/2008/06/identity/claims/role"){
                     Permissoes.Add(claim.Value);
                }
            }
        }
    }
}
