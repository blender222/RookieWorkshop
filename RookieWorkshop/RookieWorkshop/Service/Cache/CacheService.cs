using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using StackExchange.Redis;

namespace RookieWorkshop.Service.Cache
{
    public class CacheService : ICacheService
    {
        private readonly ConnectionMultiplexer redisConnection;

        private readonly IDatabase redisDB;

        public CacheService()
        {
            this.redisConnection = ConnectionMultiplexer.Connect("localhost:6379");
            this.redisDB = redisConnection.GetDatabase();
        }

        public string Get<T>(string key, TimeSpan expireTime, Func<T> getDataFunc)
        {
            string data;

            if (redisDB.KeyExists(key))
            {
                data = redisDB.StringGet(key);
            }
            else
            {
                data = getDataFunc().ToString();
            }

            //更新expireTime
            redisDB.StringSet(key, data, expireTime);

            return data;
        }

        public void Remove(string key)
        {
            redisDB.KeyDelete(key);
        }

        //public void Set<T>(string key, T value, TimeSpan expireTime)
        //{
        //    redisDB.StringSet(key, value.ToString(), TimeSpan.FromSeconds(15));
        //}

        //public string Get(string key)
        //{
        //    if (redisDB.KeyExists(key))
        //    {
        //        string value = redisDB.StringGet(key);

        //        return value;
        //    }
        //    else
        //    {
        //        string sql = $"SELECT * FROM dbo.CacheTest WHERE DB_Key = '{key}'";
        //        string value = string.Empty;
        //        using (SqlConnection dbConnection = new SqlConnection(builder.ConnectionString))
        //        {
        //            dbConnection.Open();
        //            SqlCommand command = new SqlCommand(sql, dbConnection);

        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    value = reader["DB_Value"].ToString();
        //                }
        //            }
        //            redisDB.StringSet(key, value, TimeSpan.FromSeconds(15));
        //        }
        //        return value;
        //    }
        //}
    }
}
