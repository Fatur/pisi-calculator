using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pisi.Calculator
{
    public interface IStaticDataRepository
    {
        Task<IList<Remark>> LoadRemarkAsync();
    }
}
