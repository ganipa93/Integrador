using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Negocio
{
    public class admUsuarios
    {
        public System.Web.Security.MembershipUserCollection Listar()
        {
            return System.Web.Security.Membership.GetAllUsers();
        }
        public bool CambiarContraseña(string ContraseñaVieja, string ContraseñaNueva)
        {
            if (ContraseñaNueva == ContraseñaVieja)
            {
                throw new Exception("la contraseña no puede ser igual");
            }
            return System.Web.Security.Membership.GetUser().ChangePassword(ContraseñaVieja, ContraseñaNueva);
        }
        public int UsuariosOnline
        {
            get {  return (int)HttpContext.Current.Application["sesiones"]; }
        }
    
    
    }

}
