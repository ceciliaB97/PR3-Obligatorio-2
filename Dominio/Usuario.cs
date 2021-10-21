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
        [Column("Id"), Key]
        public int Id { get; set; }

        [Required, EmailAddress, StringLength(50)]
        public string Mail { set; get; }
        [Required, MinLength(6), MaxLength(100), Display(Name = "Contraseña")]
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


        //public static string EncriptarContrasena(string contrasena)
        //{
        //    string contraEncriptada = "";
        //    //ascii 33 al 59 son caracteres especiales y numeros
        //    int[] ASCIINum = new int[] { 33, 34, 35, 36, 37, 38, 39, 40, 41, 42 };
        //    int[] arrNum = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        //    for (int i = 0; i < contrasena.Length; i++)
        //    {
        //        //si es letra
        //        if (Char.IsLetter(contrasena[i]))
        //        {
        //            //se cambia el lowercase por Uppercase
        //            if (char.IsUpper(contrasena[i]))
        //            {
        //                contraEncriptada += char.ToLower(contrasena[i]);
        //            }

        //            if (char.IsLower(contrasena[i]))
        //            {
        //                contraEncriptada += char.ToUpper(contrasena[i]);
        //            }
        //        }

        //        //si es digito
        //        if (Char.IsDigit(contrasena[i]))
        //        {
        //            for (int m = 0; m < arrNum.Length; m++)
        //            {
        //                //si coincide el digito
        //                if (int.Parse(contrasena[i].ToString()) == arrNum[m])
        //                {
        //                    //se cambia por el valor en TEXTO con el numero correspondiente
        //                    //ej si el numero es 1 se pone a
        //                    contraEncriptada += (char)ASCIINum[arrNum[m]];
        //                }
        //            }
        //        }

        //    }

        //    //agrego valores random al final
        //    Random rd = new Random();
        //    string texto = "";

        //    int rand_num = rd.Next(10, 20); //numero de 2 digitos entre el 10 y el 20
        //    int simbolo1 = rd.Next(33, 41); //simbolos especiales
        //    int simbolo2 = rd.Next(33, 41);

        //    texto += (char)simbolo1 + rand_num + (char)simbolo2;
        //    //se le agregan 4 digitos random
        //    contraEncriptada += texto;

        //    return contraEncriptada;
        //}

        //public static string DesencriptarContrasena(string encriptada)
        //{
        //    string contraDesencriptada = "";
        //    int[] ASCIINum = new int[] { 33, 34, 35, 36, 37, 38, 39, 40, 41, 42 }; //simbolos
        //    int[] arrNum = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        //    int largo = encriptada.Length;
        //    //se llega al largo original
        //    encriptada = encriptada.Substring(0, largo - 2);

        //    for (int i = 0; i < encriptada.Length; i++)
        //    {
        //        //si es un caracter especial
        //        if (!Char.IsDigit(encriptada[i]) && !char.IsLetter(encriptada[i]))
        //        {
        //            for (int m = 0; m < ASCIINum.Length; m++)
        //            {
        //                //si coincide el valor del ascii
        //                if ((int)encriptada[i] == ASCIINum[m])
        //                {
        //                    //se pasa al numero correspondiente por la posicion
        //                    contraDesencriptada += arrNum[m];
        //                }
        //            }
        //        }

        //        //si es letra
        //        if (char.IsLetter(encriptada[i]))
        //        {
        //            //se cambia de upper a lower
        //            if (char.IsUpper(encriptada[i]))
        //            {
        //                contraDesencriptada += char.ToLower(encriptada[i]);
        //            }

        //            //se cambia de lower a upper
        //            if (char.IsLower(encriptada[i]))
        //            {
        //                contraDesencriptada += char.ToUpper(encriptada[i]);
        //            }
        //        }
        //    }

        //    return contraDesencriptada;
        //}

    }
}
