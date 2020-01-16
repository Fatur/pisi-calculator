using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pisi.Calculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace PisiCloud.FormulaTest
{
    [TestClass]
    public class FormulaTransformationTest
    {
        private string formula = "iif((Regular=True AND Remark='ABS') Or (Regular=True AND Remark='UPL'),1,iif(Regular=True AND Remark='UP05',0.5,0))";
        [TestMethod]
        public void remove_all_tanda_petik()
        {
            
            string expected = "iif((Regular=True AND Remark=ABS) Or (Regular=True AND Remark=UPL),1,iif(Regular=True AND Remark=UP05,0.5,0))";
            string result = formula.BuangTandaPetik();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ubah_tanda_sama_dengan_menjadi_dua_sama_dengan()
        {
            string expected = "iif((Regular==True AND Remark=='ABS') Or (Regular==True AND Remark=='UPL'),1,iif(Regular==True AND Remark=='UP05',0.5,0))";
            string result = formula.UbahTandaSamaDenganMenjadiGanda();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void transform_formula_dari_format_access_ke_format_jace()
        {
            string expected = "iif((Regular==True && Remark==ABS) || (Regular==True && Remark==UPL),1,iif(Regular==True && Remark==UP05,0.5,0))";
            string result = formula.TransformToJaceFormat();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ubah_or_menjadi_tanda_pagar_dua()
        {
            string expected = "iif((Regular=True AND Remark='ABS') || (Regular=True AND Remark='UPL'),1,iif(Regular=True AND Remark='UP05',0.5,0))";
            string result = formula.UbahOrMenjadiPagar();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ubah_AND_menjadi_tanda_dan()
        {
            string expected = "iif((Regular=True && Remark='ABS') Or (Regular=True && Remark='UPL'),1,iif(Regular=True && Remark='UP05',0.5,0))";
            string result = formula.UbahAndMenjadiTanda();
            Assert.AreEqual(expected, result);
        }
    }
}
