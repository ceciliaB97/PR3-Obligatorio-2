using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    [Table("Usuarios")]
    public class Usuario
    {
     //   [Column("Id"), Key]
        public int Id { get; set; }

        [Required, EmailAddress, StringLength(50)]
        public string Mail { set; get; }
        [Required, MinLength(6), MaxLength(200), Display(Name = "Contraseña")]      
        public string Password { get; set; }

        public Usuario()
        {

        }

        public Usuario(string mail, string contrasena)
        {
            Mail = mail;
            Password = contrasena;
        }

        public static bool ValidarContrasena(string contra)
        {
            //al menos 6 caracteres que incluyan letras mayúsculas y minúsculas(al menos una de cada una) y dígitos(0 al 9)
            bool digito = false;
            bool upper = false;
            bool lower = false;

            //recorre toda la contraseña, si encuentra 1 digito, 1 minuscula, 1 mayuscula esta OK, si no NO
            for (int i = 0; i < contra.Length; i++)
            {
                if (char.IsDigit(contra[i]))
                {
                    digito = true;
                }

                if (char.IsLetter(contra[i]))
                {
                    if (char.IsUpper(contra[i]))
                    {
                        upper = true;
                    }
                    if (char.IsLower(contra[i]))
                    {
                        lower = true;
                    }
                }
            }

            if (digito && upper && lower)
            {
                return true;
            }

            return false;
        }

        public static bool validarDatosUsuario(Usuario usuario)
        {
            //contraseña de al menos 6 caracteres
            //que incluyan letras mayúsculas y minúsculas (al menos una de cada una)
            //dígitos (0 al 9)
            if (usuario.Password.Length >= 6)
            {
                if (usuario.Password.Any(char.IsUpper) && usuario.Password.Any(char.IsLower) && usuario.Password.Any(char.IsDigit))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
