using System;
using System.Collections.Generic;
using System.Text;

namespace Pisi.Calculator
{
    public static class FormulaTransformationExtentions
    {
        public static string BuangTandaPetik(this string formula)
        {
            return formula.Replace("'", "");
        }
        public static string UbahTandaSamaDenganMenjadiGanda(this string formula)
        {
            return formula.Replace("=", "==");
        }
        public static string UbahOrMenjadiPagar(this string formula)
        {
            return formula.Replace(" Or ", " || ").Replace(" OR ", " || ");
        }
        public static string UbahAndMenjadiTanda(this string formula)
        {
            return formula.Replace(" and ", " && ").Replace(" AND ", " && ");
        }
        public static string TransformToJaceFormat(this string formula)
        {
            return formula.BuangTandaPetik()
                          .UbahTandaSamaDenganMenjadiGanda()
                          .UbahOrMenjadiPagar()
                          .UbahAndMenjadiTanda();
        }
    }
}
