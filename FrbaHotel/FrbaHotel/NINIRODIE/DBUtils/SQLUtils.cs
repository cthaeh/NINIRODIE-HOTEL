using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace FrbaHotel.NINIRODIE.DBUtils
{
    public class SQLUtils
    {
        private static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD1C2014"].ConnectionString);

        public static DataRowCollection EjecutarConsultaSimple(String selectQuery, String table)
        {
            SqlCommand command = RealizarQuery(selectQuery);
            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataSet, table);
            connection.Close();
            return dataSet.Tables[table].Rows;
        }

        private static SqlCommand RealizarQuery(String selectQuery)
        {
            SqlCommand command = new SqlCommand(selectQuery, connection);
            connection.Open();
            command.ExecuteNonQuery();
            return command;
        }

        public static void EjecutarConsultaConEfectoDeLado(String insertQuery)
        {
            SqlCommand command = new SqlCommand(insertQuery, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static DataRowCollection EjecutarConsultaListado(String selectQuery, DataTable resultTable)
        {
            SqlCommand command = RealizarQuery(selectQuery);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(resultTable);
            connection.Close();
            return resultTable.Rows;
        }
    }
}
