using Pisi.Calculator;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using Pisi.CalculatorRepository.Models;
using Microsoft.Extensions.Configuration;

namespace Pisi.CalculatorRepository
{
    public class DapperStaticDataRepository : IStaticDataRepository
    {
        private readonly string REMARKS_QUERY="SELECT  RemarkId FROM tblRemark ";
        private readonly string connectionString;
        public DapperStaticDataRepository(IConfiguration configuration)
        {
            connectionString = configuration["ConnectionString"];
        }

        public async Task<IList<Remark>> LoadRemarkAsync()
        {
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
