using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sand.Domain.Uow
{
    public class MySqlConfig : ISqlConfig
    {
        private readonly IConfiguration _configuration;
        public MySqlConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string SqlConnectionString { get => _configuration.GetConnectionString("DefaultConnection"); }
        public DbType DbType { get => DbType.Mysql; }
    }
}
