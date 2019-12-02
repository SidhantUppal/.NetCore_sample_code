using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Newtonsoft.Json.Linq;
namespace CFMData.Collections.Custom
{
  public static class StringExtension
  {
    public static string ToCamelCase(this string str)
    {
      if (!string.IsNullOrEmpty(str))
      {
        if (str.Length > 1)
        {
          return Char.ToLowerInvariant(str[0]) + str.Substring(1);
        }
        else
        {
          return Char.ToLowerInvariant(str[0]).ToString();
        }

      }

      return str;
    }
  }

  [Serializable]
  public class DynamicColumnDetails
  {
    public int DataIndex { get; set; }
    public List<string> Columns { get; set; }
  }

  [Serializable]
  public partial class DynamicList : List<JObject>
  {
    public JArray GetJson()
    {

      JArray arr = new JArray();
      foreach (JObject jObject in this)
      {
        arr.Add(jObject);
      }

      return arr;
    }

    public string ToString()
    {

      JArray arr = new JArray();
      foreach (JObject jObject in this)
      {
        arr.Add(jObject);
      }

      return arr.ToString();
    }

    public List<DynamicColumnDetails> AllDataColumns = new List<DynamicColumnDetails>();

    public static DynamicList GetData(string sql, Dictionary<string, object> commandParams,
        string connectionString = null, bool IsProc = true)
    {
      DynamicList lst = new DynamicList();
      if (string.IsNullOrEmpty(connectionString))
      {
        connectionString = ADOHelper.ConnectionString;
      }

      using (var connection = new SqlConnection(connectionString))
      {
        connection.Open();
        using (var command = new SqlCommand(sql, connection))
        {
          if (IsProc)
          {

            command.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters((SqlCommand)command);
          }
          else
          {
            command.CommandType = CommandType.Text;
          }

          List<string> coveredParams = new List<string>();
          if (commandParams != null)
          {
            foreach (KeyValuePair<string, object> commandParam in commandParams)
            {
              foreach (DbParameter dbParameter in command.Parameters)
              {
                string paramSearch = dbParameter.ParameterName.ToLower().Replace("@", "");
                string currentParam = commandParam.Key.ToLower().Replace("@", "");
                if (paramSearch == currentParam)
                {
                  dbParameter.Value = commandParam.Value;
                  coveredParams.Add(commandParam.Key);


                }
              }


            }

            foreach (KeyValuePair<string, object> commandParam in commandParams)
            {
              if (coveredParams.Contains(commandParam.Key))
              {
                continue;
              }

              if (commandParam.Value != null)
              {
                sql = sql.Replace("@" + commandParam.Key, commandParam.Value.ToString());
              }
              else
              {
                sql = sql.Replace("@" + commandParam.Key, "");
              }

            }

          }


          using (var reader = command.ExecuteReader())
          {
            List<JObject> allParentObjects = new List<JObject>();
            JArray subObjects = null;
            int ResultIndex = 0;

            do
            {


              subObjects = LoadData((SqlDataReader)reader, ResultIndex, lst);

              dynamic obj = new JObject();
              obj.Index = ResultIndex;
              obj.Data = subObjects;
              JArray columnsArray = new JArray();
              foreach (string column in lst.AllDataColumns[ResultIndex].Columns)
              {
                columnsArray.Add(column);
              }

              obj.Columns = columnsArray;
              allParentObjects.Add(obj);
              ResultIndex++;

            } while (reader.NextResult());

            lst.AddRange(allParentObjects);


            return lst;
          }
        }
      }
    }

    public static DynamicList GetData(string sql, Dictionary<string, object> commandParams, SqlTransaction tr,
        bool IsProc = true)
    {
      DynamicList lst = new DynamicList();
      // 
      //using (var connection = new SqlConnection(connectionString))
      {
        //connection.Open();
        using (var command = new SqlCommand(sql, tr.Connection))
        {
          command.Connection = tr.Connection;

          command.Transaction = tr;
          if (IsProc)
          {

            command.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters((SqlCommand)command);
          }
          else
          {
            command.CommandType = CommandType.Text;
          }

          List<string> coveredParams = new List<string>();
          if (commandParams != null)
          {
            foreach (KeyValuePair<string, object> commandParam in commandParams)
            {
              foreach (DbParameter dbParameter in command.Parameters)
              {
                string paramSearch = dbParameter.ParameterName.ToLower().Replace("@", "");
                string currentParam = commandParam.Key.ToLower().Replace("@", "");
                if (paramSearch == currentParam)
                {
                  dbParameter.Value = commandParam.Value;
                  coveredParams.Add(commandParam.Key);


                }
              }


            }

            foreach (KeyValuePair<string, object> commandParam in commandParams)
            {
              if (coveredParams.Contains(commandParam.Key))
              {
                continue;
              }

              if (commandParam.Value != null)
              {
                sql = sql.Replace("@" + commandParam.Key, commandParam.Value.ToString());
              }
              else
              {
                sql = sql.Replace("@" + commandParam.Key, "");
              }

            }

          }


          using (var reader = command.ExecuteReader())
          {
            List<JObject> allParentObjects = new List<JObject>();
            JArray subObjects = null;
            int ResultIndex = 0;

            do
            {


              subObjects = LoadData((SqlDataReader)reader, ResultIndex, lst);

              dynamic obj = new JObject();
              obj.Index = ResultIndex;
              obj.Data = subObjects;
              JArray columnsArray = new JArray();
              foreach (string column in lst.AllDataColumns[ResultIndex].Columns)
              {
                columnsArray.Add(column);
              }

              obj.Columns = columnsArray;
              allParentObjects.Add(obj);
              ResultIndex++;

            } while (reader.NextResult());

            lst.AddRange(allParentObjects);


            return lst;
          }
        }
      }
    }

    private static JArray LoadData(SqlDataReader reader, int index, DynamicList lst)
    {
      JArray allObjects = new JArray();
      DynamicColumnDetails columnDetails = new DynamicColumnDetails();
      columnDetails.DataIndex = index;

      List<string> Columns = new List<string>();
      for (int i = 0; i < reader.FieldCount; i++)
      {
        Columns.Add(reader.GetName(i).ToCamelCase());
      }

      columnDetails.Columns = Columns;
      lst.AllDataColumns.Add(columnDetails);
      if (reader.Read())
      {

        do
        {
          try
          {


            dynamic jsonObject = new JObject();
            foreach (string colName in Columns)
            {
              if (reader[colName] != null && reader[colName] != DBNull.Value)
              {
                JToken jt = JToken.FromObject(reader[colName]);
                if (jt.Type == JTokenType.Date)
                {
                  string s = jt.ToString();
                  if (!string.IsNullOrEmpty(s))
                  {
                    DateTime dt = DateTime.Now;
                    if (DateTime.TryParse(s, out dt))
                    {
                      int totalSeconds = (int)(dt - new DateTime(1970, 1, 1)).TotalSeconds;

                      jsonObject[colName + "Epoch"] = "/Date(" + (totalSeconds) + "000)/";
                      jsonObject[colName + "_Date"] = dt.ToString("dd-MMM-yyyy");
                    }

                  }

                }


                jsonObject[colName] = jt;
              }
              else
              {
                jsonObject[colName] = null;
              }


            }

            allObjects.Add(jsonObject);
          }
          catch (Exception e)
          {

          }
        } while (reader.Read());
      }

      return allObjects;
    }





    public static void ExecuteCommand(string sql, Dictionary<string, object> commandParams,
        string connectionString = null, bool IsProc = true)
    {

      if (string.IsNullOrEmpty(connectionString))
      {
        connectionString = ADOHelper.ConnectionString;
      }

      using (var connection = new SqlConnection(connectionString))
      {
        connection.Open();
        using (var command = new SqlCommand(sql, connection))
        {
          if (IsProc)
          {

            command.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters((SqlCommand)command);
          }
          else
          {
            command.CommandType = CommandType.Text;
          }

          List<string> coveredParams = new List<string>();
          if (commandParams != null)
          {
            foreach (KeyValuePair<string, object> commandParam in commandParams)
            {
              foreach (DbParameter dbParameter in command.Parameters)
              {
                string paramSearch = dbParameter.ParameterName.ToLower().Replace("@", "");
                string currentParam = commandParam.Key.ToLower().Replace("@", "");
                if (paramSearch == currentParam)
                {
                  dbParameter.Value = commandParam.Value;
                  coveredParams.Add(commandParam.Key);


                }
              }


            }

            foreach (KeyValuePair<string, object> commandParam in commandParams)
            {
              if (coveredParams.Contains(commandParam.Key))
              {
                continue;
              }

              if (commandParam.Value != null)
              {
                sql = sql.Replace("@" + commandParam.Key, commandParam.Value.ToString());
              }
              else
              {
                sql = sql.Replace("@" + commandParam.Key, "");
              }

            }

          }


          command.ExecuteNonQuery();
        }
      }
    }


    public static void ExecuteCommand(string sql, Dictionary<string, object> commandParams, SqlTransaction tr,
        bool IsProc = true)
    {

      // using (var connection = new SqlConnection(connectionString))
      {
        //  connection.Open();
        using (var command = new SqlCommand(sql, tr.Connection))
        {
          command.Connection = tr.Connection;

          command.Transaction = tr;
          if (IsProc)
          {

            command.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters((SqlCommand)command);
          }
          else
          {
            command.CommandType = CommandType.Text;
          }

          List<string> coveredParams = new List<string>();
          if (commandParams != null)
          {
            foreach (KeyValuePair<string, object> commandParam in commandParams)
            {
              foreach (DbParameter dbParameter in command.Parameters)
              {
                string paramSearch = dbParameter.ParameterName.ToLower().Replace("@", "");
                string currentParam = commandParam.Key.ToLower().Replace("@", "");
                if (paramSearch == currentParam)
                {
                  dbParameter.Value = commandParam.Value;
                  coveredParams.Add(commandParam.Key);


                }
              }


            }

            foreach (KeyValuePair<string, object> commandParam in commandParams)
            {
              if (coveredParams.Contains(commandParam.Key))
              {
                continue;
              }

              if (commandParam.Value != null)
              {
                sql = sql.Replace("@" + commandParam.Key, commandParam.Value.ToString());
              }
              else
              {
                sql = sql.Replace("@" + commandParam.Key, "");
              }

            }

          }


          command.ExecuteNonQuery();
        }
      }
    }
  }
}
