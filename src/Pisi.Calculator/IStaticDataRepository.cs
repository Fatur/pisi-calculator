using System;
using System.Collections.Generic;
using System.Text;

namespace Pisi.Calculator
{
    public interface IStaticDataRepository
    {
        IList<Remark> LoadRemark();
    }
}
