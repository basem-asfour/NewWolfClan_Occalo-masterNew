using Dapper;
using WolfClan.SoliHub.Abstracts.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper.Contrib.Extensions;

namespace WolfClan.SoliHub.Abstracts.Concrete
{
    public class DapperManager : IDapperManager
    {
        private readonly string connectionstring;

        public DapperManager(string connectionstring)
        {
            this.connectionstring = connectionstring;
        }

        public DbConnection GetConnection()
        {
            return new SqlConnection(connectionstring);
        }

        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection db = new SqlConnection(connectionstring))
            {
                return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
            }
        }

        public List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection db = new SqlConnection(connectionstring))
            {
                return db.Query<T>(sp, parms, commandType: commandType).ToList();
            }
        }

        public int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection db = new SqlConnection(connectionstring))
            {
                return db.Execute(sp, parms, commandType: commandType);
            }
        }


        public T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result = default(T);

            using (IDbConnection db = new SqlConnection(connectionstring))
            {
                try
                {
                    if (db.State == ConnectionState.Closed) { db.Open(); }
                    using (var trans = db.BeginTransaction())
                    {
                        try
                        {
                            result = db.Query<T>(sp, parms, commandType: commandType, transaction: trans).FirstOrDefault();
                            trans.Commit();
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }

            }

            return result;
            
        }

        public T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
          
        }
    }
}
