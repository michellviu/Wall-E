﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Wall.Wall_EEngine
{
    public class Expresiones
    {   //Palabras reservadas del lenguaje
        public static string[] palabrasreservadas { get; } = new string[] { "if", "else", "let", "in", "then", "point", "circle", "draw" };
        //Definiendo un punto

        //public static string punto = @"^\s*point\s+(?<cuerpoin>.+)";

        //public static string draw = @"^\s*draw";

        ////public static string draw2 = @"^\s*draw\s*{\(?<pintar>.+)\}";

        //public static string constructor = @"\s*(?<type>.+)\s*(\(?<parametros>.+)\)";

        public static Match IsValid(string line, string expresion)
        {
            Regex regex = new Regex(expresion);
            Match match = regex.Match(line);

            return match;
        }

        public static string declaration { get; } = @"^(?<tipo>point|line|circle|segment|ray)\s+(?<nombre>[a-zA-Z_][a-z|A-Z|0-9|_]*?$)";

        public static string draw { get; } = @"^\s*draw\s+(?<cuerpo>.*)";

        public static string color { get; } = @"^color\s+(?<color>.*$)";

        public static string definir { get; } = @"^(?<nombre>[a-zA-Z_][a-zA-Z0-9_]*?)\s*=\s*(?<cuerpo>.*)";

        public static string inicializartipo { get; } = @"^\s*(?<tipo>point|line|circle|segment|ray)\s*\((?<parametros>.*)\)";


        //\\\(\s*(?<ParametroUno>[a-zA-Z_][a-zA-Z0-9_]*?)\s* (?<ParametroDos>[a-zA-Z_][a-zA-Z0-9_]*?)\s*\\\)

        public static string condicionales { get; } = @"^if.*";




        //public static Match EsPunto(string expresion)
        //{
        //    Match match = Regex.Match(expresion, punto);
        //    return match;
        //}
        //public static Match EsDraw(string expresion)
        //{
        //    Match match = Regex.Match(expresion, draw);
        //    return match;
        //}
        ///*public static Match EsDraw2(string expresion)
        //{
        //    Match match = Regex.Match(expresion, draw2);
        //    return match;
        //}*/
        //public static Match EsConstructor(string expresion)
        //{
        //    Match match = Regex.Match(expresion, constructor);
        //    return match;
        //}
        public static bool EsVariable(string v)
        {   //Patron de variables
            string variable = @"^[a-zA-Z]+[\w]*";
            Match match = Regex.Match(v, variable);
            if (match.Success)
            {   //Excluir el caso de que sea una palabra reservada
                for (int i = 0; i < palabrasreservadas.Length; i++)
                {
                    if (v == palabrasreservadas[i]) return false;
                }
                return true;
            }
            return false;
        }




    }
}