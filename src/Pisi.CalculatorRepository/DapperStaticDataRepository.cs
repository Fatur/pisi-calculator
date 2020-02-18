using Pisi.Calculator;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using Pisi.CalculatorRepository.Models;

namespace Pisi.CalculatorRepository
{
    public class DapperStaticDataRepository : IStaticDataRepository
    {
        private readonly string REMARKS_QUERY="SELECT  RemarkId FROM tblRemark ";

        public async Task<IList<Remark>> LoadRemarkAsync()
        {
            //TODO: Pindahkan ke appsettings
            var connectionString = "Server=167.71.194.103;Database = PISI2KBE_DEMO; User Id = demo; Password = 123; ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var queryResult = await connection.QueryAsync<DBRemark>(REMARKS_QUERY);
                int i = 0;
                var remarks = queryResult.Select(x => new Remark(i++, x.RemarkId));
                return remarks.ToList();
            }
        }
    }
}
