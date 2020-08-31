using Dapper.Contrib.Extensions;
using Npgsql;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using TestRepository;

namespace TestDataAccess
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected string _connectionString;
        private string _schema;
        public RepositoryBase(string connectionString)
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return $"public.{ type.Name }"; };
            this._connectionString = connectionString;
        }

        public void SetSchema(string schema)
        {
            _schema = string.IsNullOrEmpty(schema) ? "modelo" : schema;

            ReinitMapper();
            SqlMapperExtensions.TableNameMapper = (type) => { return $"{_schema}.{ type.Name }"; };
        }

        public bool Delete(T entity)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return connection.Delete(entity);
            }
        }

        public T GetById(int Id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return connection.Get<T>(Id);
            }
        }

        public IEnumerable<T> GetList()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return connection.GetAll<T>();
            }
        }

        public int Insert(T entity)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return (int)connection.Insert(entity);
            }
        }

        public bool Update(T entity)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return connection.Update(entity);
            }
        }

        private void ReinitMapper()
        {
            var fields = typeof(SqlMapperExtensions).GetFields(BindingFlags.Static | BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (var field in fields)
            {
                if (field.Name == "TypeTableName" || field.Name == "GetQueries")
                    field.SetValue(new ConcurrentDictionary<RuntimeTypeHandle, string>(), new ConcurrentDictionary<RuntimeTypeHandle, string>());
            }
        }
    }
}
