using System;
using System.Text.RegularExpressions;

namespace App_entity
{
    class Validations
    {
        public bool Vacio(string texto)
        {
            if (texto.Equals(""))
            {
                Console.WriteLine(" La entrada no puede ser VACIO");
                return true;
            }
            else
                return false;
        }

        public bool TipoNumero(string texto)
        {
            Regex regla = new Regex("[0-9]{1,9}(//.[0-9]{0,2})?$");

            if (regla.IsMatch(texto))
                return true;
            else
            {
                Console.WriteLine(" La entrada no debe ser NUMERICA");
                return false;
            }
        }

        public bool TipoTexto(string texto)
        {
            var regla = new Regex("^[a-zA-Z ]*$");

            if (regla.IsMatch(texto))
                return true;
            else
            {
                Console.WriteLine(" La entrada no debe ser SOLO TEXTO");
                return false;
            }
        }

        public bool emailValido(string email)

        {
            try
            {   
                var address = new System.Net.Mail.MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                Console.WriteLine("el correo ingresado no es valido, ingrese uno valido");
                return false;

            }
        }
    }
}
