﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LaboratoryInformationSystem.DAO
{
    public static class BaseDAO
    {
        private static string cnnString = @"Server=DESKTOP-1GSDLH6\SQLSERVER;Database=LaboratoryDB;Trusted_Connection=True;";

        public static List<T> Select<T>(string query, Func<CustomReader, T> readFunc)
        {
            using (SqlConnection conn = new SqlConnection(cnnString))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Dictionary<string, int> columnNames = new Dictionary<string, int>();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        columnNames.Add(reader.GetName(i), i);
                    }

                    CustomReader customReader = new CustomReader(reader, columnNames);
                    List<T> result = new List<T>();
                    while (customReader.Read())
                    {
                        result.Add(readFunc(customReader));
                    }
                    conn.Close();
                    return result;
                }
            }
        }

        public static T SelectFirst<T>(string query, Func<CustomReader, T> readFunc)
        {
            var list = Select<T>(query, readFunc);
            return list?.Count > 0 ? list[0] : default(T);
        }
    }
}