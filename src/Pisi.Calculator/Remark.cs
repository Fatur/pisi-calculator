using System;
using System.Collections.Generic;
using System.Text;

namespace Pisi.Calculator
{
    public class Remark
    {
        private double _val;
        private string _cd;

        public Remark(double value, string code)
        {
            this._val = value;
            this._cd = code;
        }
        public double Value { get { return _val; } }
        public string Code { get { return _cd; } }
    }
}
