using adduo.basetype.dto;
using adduo.basetype.result;
using adduo.helper.property;
using adduo.restoudaobra.ie.dal;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace adduo.restoudaobra.dal.framework.database
{
    public class DapperFriendly 
    {
        private DynamicParameters parameters { get; set; }

        private IConfiguration configuration { get; set; }

        public DapperFriendly(IConfiguration configuration) 
        {
            this.configuration = configuration;

            ResetParameter();
        }

        public void ExecuteMultiple(string procedure, IMultiResultExtractor extractor)
        {
            using (var conn = ConnectionFactory())
            {
                var multiple = SqlMapper.QueryMultiple(conn, procedure, param: parameters, commandType: CommandType.StoredProcedure);

                extractor.Execute(multiple);

                conn.Close();
            }
        }

        public bool ExecuteWithBooleanResult(string procedure)
        {
            var response = false;

            AddOutputParameter(DbType.Boolean);

            using (var conn = ConnectionFactory())
            {
                try
                {
                    conn.Open();
                    SqlMapper.Query(conn, procedure, parameters, commandType: CommandType.StoredProcedure);
                    response = parameters.Get<bool>("@Result");
                }
                catch (Exception ex)
                {
                    // ##todo log
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }

            return response;
        }

        public int Execute(string procedure)
        {
            var result = 0;

            using (var conn = ConnectionFactory())
            {
                try
                {
                    result = SqlMapper.QueryFirstOrDefault<int>(conn, procedure, parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    // ##todo log
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }

            return result;
        }
  
        protected SqlConnection ConnectionFactory()
        {
            return new SqlConnection(configuration.GetConnectionString("Production"));
        }

        public DapperFriendly AddParameter(string name, PropertyDto<string> prop)
        {
            return AddParameter(name, prop.Value);
        }

        public DapperFriendly AddParameter(string name, string value)
        {
            var _this = this;

            if (!string.IsNullOrEmpty(value))
            {
                _this = AddParameter(name, value, DbType.String);
            }

            return _this;
        }

        public DapperFriendly ResetParameter()
        {
            parameters = new DynamicParameters();

            return this;
        }

        public DapperFriendly AddParameter(string name, PropertyDto<DateTime> prop)
        {
            return AddParameter(name, prop.Value);
        }

        public DapperFriendly AddParameter(string name, DateTime value)
        {
            return AddParameter(name, value.ToString("yyyy/MM/dd HH:mm"), DbType.DateTime);
        }

        public DapperFriendly AddParameter(string name, PropertyDto<bool> prop)
        {
            return AddParameter(name, prop.Value);
        }

        public DapperFriendly AddParameter(string name, bool value)
        {
            return AddParameter(name, value, DbType.Boolean);
        }

        public DapperFriendly AddParameter(string name, PropertyDto<int> prop)
        {
            return AddParameter(name, prop.Value);
        }

        public DapperFriendly AddParameter(string name, int value)
        {
            return AddParameter(name, value, DbType.Int32);
        }

        public DapperFriendly AddParameter(string name, PropertyDto<Guid> prop)
        {
            return AddParameter(name, prop.Value);
        }

        public DapperFriendly AddParameter(string name, Guid value)
        {
            var _this = this;

            if (!value.Equals(Guid.Empty))
            {
                _this = AddParameter(name, value, DbType.Guid);
            }

            return _this;
        }

        public DapperFriendly AddParameter(string name, PropertyDto<decimal> prop)
        {
            return AddParameter(name, prop.Value);
        }

        public DapperFriendly AddParameter(string name, decimal value)
        {
            return AddParameter(name, value, DbType.Decimal);
        }

        public DapperFriendly AddParameter(string name, PropertyDto<ItemDTO> prop)
        {
            return AddParameter(name, prop.Value.id);
        }

        public DapperFriendly AddParameterNullValue(string name)
        {
            parameters.Add(name, null);

            return this;
        }

        private DapperFriendly AddParameter(string name, object value, DbType type)
        {
            parameters.Add(name, value, type, ParameterDirection.Input);

            return this;
        }

        public DapperFriendly AddOutputParameter(DbType type)
        {
            parameters.Add("@Result", dbType: type, direction: ParameterDirection.Output);

            return this;
        }

        public T ExecuteWithOneResult<T>(string procedure) where T : BaseResult
        {
            T result = default(T);

            var list = ExecuteWithManyResult<T>(procedure);

            if (list != null & list.Any())
            {
                result = list[0];
            }

            return result;
        }

        public List<T> ExecuteWithManyResult<T>(string procedure) where T : BaseResult
        {
            var result = new List<T>();

            using (var conn = ConnectionFactory())
            {
                try
                {
                    conn.Open();
                    result = SqlMapper.Query<T>(conn, procedure, param: parameters, commandType: CommandType.StoredProcedure).ToList();
                }
                catch (Exception ex)
                {
                    // ##todo log
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }

            return result;
        }
    }
}

