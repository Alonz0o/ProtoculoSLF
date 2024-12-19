using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProtoculoSLF.Repository
{
    internal class Utils
    {
        public static string SOLONUMEROS = @"^-?\d+$";
        public static string SOLO_LETRAS_NUMEROS_SOLO_UN_ESPACIO = @"^(?:[a-zA-Z0-9áéíóúÁÉÍÓÚüÜñÑ]+\s?)*[a-zA-Z0-9áéíóúÁÉÍÓÚüÜñÑ]+$";
        public static string SOLO_LETRAS_NUMEROS_MUCHOS_ESPACIO = @"^(?:[a-zA-Z0-9áéíóúÁÉÍÓÚüÜñÑ]+(\s*?))*[a-zA-Z0-9áéíóúÁÉÍÓÚüÜñÑ]+$";
        public static string SOLONUMODECIMAL = @"^\d+,\d{1,10}$|^\d+$";
        public static string SOLOSIGNOA = @"^(?:\d+(?:,\d{1,10})?|ok|no ok|-)$";
       
        public static bool IsSoloNumerico(string input)
        {
            return Regex.IsMatch(input, SOLONUMEROS);
        }
        public static bool IsSoloLetrasUnEspacio(string input)
        {
            return Regex.IsMatch(input, SOLO_LETRAS_NUMEROS_SOLO_UN_ESPACIO);
        }
        public static bool IsSoloLetrasMultipleEspacios(string input)
        {
            return Regex.IsMatch(input, SOLO_LETRAS_NUMEROS_MUCHOS_ESPACIO);
        }
        public static bool IsSoloNumODecimal(string input)
        {
            return Regex.IsMatch(input, SOLONUMODECIMAL);
        }
        public static bool IsSoloSignoA(string input)
        {
            return Regex.IsMatch(input, SOLOSIGNOA);
        }
    }
}
