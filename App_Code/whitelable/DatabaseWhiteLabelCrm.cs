using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using System.Configuration;
using log4net;

/// <summary>
/// Summary description for DatabaseWhiteLabelCrm
/// </summary>
public class DatabaseWhiteLabelCrm
{
   // private readonly string _connectionString;
    public DatabaseWhiteLabelCrm()
	{
        //
        // TODO: Add constructor logic here
        //
    }

    #region Private Definitions

    /// <summary>
    /// Required for Log4Net
    /// </summary>
    private static readonly ILog logger = LogManager.GetLogger(typeof(DatabaseWhiteLabelCrm));

    /// <summary>
    /// Connection 
    /// </summary>
    private SqlConnection connection = null;

    /// <summary>
    /// Command
    /// </summary>
    private SqlCommand command = null;

    /// <summary>
    /// DataAdapter
    /// </summary>
    private SqlDataAdapter adapter = null;

    /// <summary>
    /// Return value
    /// </summary>
    private int returnValue = -1;

    /// <summary>
    /// Connection string 
    /// </summary>
    private string connectionString = string.Empty;

    /// <summary>
    /// ConnectionString property. In case we need to override the default property.
    /// </summary>
    public string ConnectionString
    {
        get { return this.connectionString; }
        set { this.ConnectionString = value; }
    }

    /// <summary>
    /// Encryption class object declaration
    /// </summary>
    private SymmCrypto DecryptPassword;

    #endregion

    public int RunProcedure(string StoredProcedureName)
    {
        try
        {
            command = CreateCommand(OpenConnection(), StoredProcedureName, null);
            command.ExecuteNonQuery();
            returnValue = (int)command.Parameters["ReturnValue"].Value;
        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
            if (Configurations.RethrowError)
                throw;
            returnValue = -1;
        }
        finally
        {
            this.CloseConnection();
        }
        return returnValue;
    }

    /// <summary>
    /// Run SQL Command
    /// </summary>
    /// <param name="StoredProcedureName">Name of stored procedure.</param>
    /// <returns>Stored procedure return value.</returns>
    public bool RunCommand(string query)
    {
        try
        {
            command = CreateCommand(OpenConnection(), query);
            command.ExecuteNonQuery();
        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
            if (Configurations.RethrowError)
                throw;
            return false;
        }
        finally
        {
            this.CloseConnection();
        }
        return true;
    }

    /// <summary>
    /// Run stored procedure.
    /// </summary>
    /// <param name="StoredProcedureName">Name of stored procedure.</param>
    /// <param name="objaPrams">Stored procedure params.</param>
    /// <returns>Stored procedure return value.</returns>
    public int RunProcedure(string StoredProcedureName, SqlParameter[] parametersList)
    {
        try
        {
            command = CreateCommand(OpenConnection(), StoredProcedureName, parametersList);
            command.ExecuteNonQuery();
            return Convert.ToInt32(command.Parameters["ReturnValue"].Value);
        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
            if (Configurations.RethrowError)
                throw;
            return -1;
        }
        finally
        {
            this.CloseConnection();
        }
    }

    /// <summary>
    /// Run stored procedure.
    /// </summary>
    /// <param name="StoredProcedureName">Name of stored procedure.</param>
    /// <param name="objDataReader">Return result of procedure.</param>
    public void RunProcedure(string StoredProcedureName, out SqlDataReader reader)
    {
        command = CreateCommand(OpenConnection(), StoredProcedureName, null);
        reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
    }

    /// <summary>
    /// Run stored procedure.
    /// </summary>
    /// <param name="StoredProcedureName">Name of stored procedure.</param>
    /// <param name="objaPrams">Stored procedure params.</param>
    /// <param name="objDataReader">Return result of procedure.</param>
    public void RunProcedure(string StoredProcedureName, SqlParameter[] parametersList, out SqlDataReader reader)
    {
        command = CreateCommand(OpenConnection(), StoredProcedureName, parametersList);
        reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
    }

    /// <summary>
    /// Run stored procedure.
    /// </summary>
    /// <param name="StoredProcedureName">Name of stored procedure.</param>
    /// <param name="objaPrams">Stored procedure params.</param>
    /// <param name="objDataReader">Return result of procedure.</param>
    public void RunProcedure(string StoredProcedureName, SqlParameter[] parametersList, out DataSet dataSet)
    {
        try
        {
            adapter = new SqlDataAdapter();
            //connection = OpenConnection();
            command = CreateCommand(OpenConnection(), StoredProcedureName, parametersList);
            adapter.SelectCommand = command;
            dataSet = new DataSet();
            adapter.Fill(dataSet);
        }
        catch (Exception exp)
        {
            dataSet = null;
            logger.Error(exp.ToString());
            if (Configurations.RethrowError)
                throw;

        }
        finally
        {
            this.CloseConnection();
        }
    }

    /// <summary>
    /// Run stored procedure.
    /// </summary>
    /// <param name="StoredProcedureName">Name of stored procedure.</param>
    /// <param name="objaPrams">Stored procedure params.</param>
    /// <param name="objDataReader">Return result of procedure.</param>
    public void RunProcedure(string StoredProcedureName, SqlParameter[] parametersList, out DataTable dataTable)
    {
        try
        {
            adapter = new SqlDataAdapter();
            //connection = OpenConnection();
            command = CreateCommand(OpenConnection(), StoredProcedureName, parametersList);
            adapter.SelectCommand = command;

            command.CommandTimeout = 9000000;


            dataTable = new DataTable();
            adapter.Fill(dataTable);
        }
        catch (Exception exp)
        {
            dataTable = null;
            logger.Error(exp.ToString());
            if (Configurations.RethrowError)
                throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }

    /// <summary>
    /// Run Command.
    /// </summary>
    /// <param name="query">SQL query to execute.</param>
    /// <param name="dataSet">Return dataSet of query.</param>
    public void RunCommand(string query, ref DataSet dataSet)
    {
        try
        {
            adapter = new SqlDataAdapter();
            command = CreateCommand(OpenConnection(), query);
            adapter.SelectCommand = command;
            dataSet = new DataSet();
            adapter.Fill(dataSet);
        }
        catch (Exception exp)
        {
            dataSet = null;
            logger.Error(exp.ToString());
            if (Configurations.RethrowError)
                throw;

        }
        finally
        {
            this.CloseConnection();
        }

    }

    /// <summary>
    /// Create command object used to call stored procedure.		
    /// </summary>
    /// <param name="StoredProcedureName">Name of stored procedure.</param>
    /// <param name="objaPrams">Params to stored procedure.</param>
    /// <returns>Command object.</returns>
    private SqlCommand CreateCommand(SqlConnection connection, string StoredProcedureName, SqlParameter[] parametersList)
    {
        command = new SqlCommand(StoredProcedureName, connection);
        command.CommandType = CommandType.StoredProcedure;

        // add proc parameters
        if (parametersList != null)
        {
            foreach (SqlParameter parameter in parametersList)
                command.Parameters.Add(parameter);
        }
        // return objaPrams
        command.Parameters.Add(
            new SqlParameter("ReturnValue", SqlDbType.Int, 4,
            ParameterDirection.ReturnValue, false, 0, 0,
            string.Empty, DataRowVersion.Default, null));

        return command;
    }

    /// <summary>
    /// Create command object used to execute query.		
    /// </summary>
    /// <param name="StoredProcedureName">Name of stored procedure.</param>
    /// <param name="objaPrams">Params to stored procedure.</param>
    /// <returns>Command object.</returns>
    private SqlCommand CreateCommand(SqlConnection connection, string query)
    {
        command = new SqlCommand(query, connection);
        return command;
    }

    /// <summary>
    /// If connection is not available, creates the connection. 
    /// Opens the connection and returns it
    /// </summary>
    private SqlConnection OpenConnection()
    {
        try
        {
            if (DateTime.Now <= DateTime.Parse("10/10/2030"))
            {
                // If connection is null, create a new connection
                if (connection == null)
                {
                    DecryptPassword = new SymmCrypto(0);
                    string connStr;
                    //connStr = @"Server=S20747004\TRAVELNSAVE;database=pcmt_whiteLabelCrm;UID=sa;pwd=wintellect321";
                    connStr = ConfigurationManager.AppSettings["conReservation"].ToString();
                    connection = new SqlConnection(connStr);
                }
                // If connection is not open, open it
                if (connection.State != ConnectionState.Open)
                    connection.Open();
            }
        }
        catch (Exception exception)
        {
            logger.Error(exception.ToString());
            if (Configurations.RethrowError)
                throw;
            return null;
        }
        // Return a valid opened connection
        return connection;
    }

    /// <summary>
    /// Close the connection.
    /// </summary>
    public void CloseConnection()
    {
        if (connection != null)
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    /// <summary>
    /// Make input param.
    /// </summary>
    /// <param name="ParameterName">Name of param.</param>
    /// <param name="ParameterType">Param type.</param>
    /// <param name="ParameterSize">Param size.</param>
    /// <param name="ParameterValue">Param value.</param>
    /// <returns>New parameter.</returns>
    public SqlParameter MakeInParameter(string ParameterName, SqlDbType ParameterType, int ParameterSize, object ParameterValue)
    {
        return MakeParameter(ParameterName, ParameterType, ParameterSize, ParameterDirection.Input, ParameterValue);
    }

    /// <summary>
    /// Make input param.
    /// </summary>
    /// <param name="ParameterName">Name of param.</param>
    /// <param name="ParameterType">Param type.</param>
    /// <param name="ParameterSize">Param size.</param>
    /// <returns>New parameter.</returns>
    public SqlParameter MakeOutParameter(string ParameterName, SqlDbType ParameterType, int ParameterSize)
    {
        return MakeParameter(ParameterName, ParameterType, ParameterSize, ParameterDirection.Output, null);
    }

    /// <summary>
    /// Make stored procedure param.
    /// </summary>
    /// <param name="ParameterName">Name of param.</param>
    /// <param name="ParameterType">Param type.</param>
    /// <param name="ParameterSize">Param size.</param>
    /// <param name="objDirection">Parm direction.</param>
    /// <param name="ParameterValue">Param value.</param>
    /// <returns>New parameter.</returns>
    public SqlParameter MakeParameter(string ParameterName, SqlDbType ParameterType, Int32 ParameterSize, ParameterDirection objDirection, object ParameterValue)
    {
        SqlParameter parameter;

        if (ParameterSize > 0)
            parameter = new SqlParameter(ParameterName, ParameterType, ParameterSize);
        else
            parameter = new SqlParameter(ParameterName, ParameterType);

        parameter.Direction = objDirection;
        if (!(objDirection == ParameterDirection.Output && ParameterValue == null))
            parameter.Value = ParameterValue;

        return parameter;
    }

    public int InsertReturnOutPutParameters(string SPName, SqlParameter[] Parameter, out int ResultCaller, out string msgOutCaller)
    {
        string _connectionString = ConfigurationManager.AppSettings["conWhiteLabel"].ToString();
        SqlConnection con = new SqlConnection(_connectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand(SPName.Trim(), con);
        cmd.CommandType = CommandType.StoredProcedure;
        for (int i = 0; i < Parameter.Length; i++)
        {
            cmd.Parameters.Add(Parameter[i]);
        }
        cmd.Parameters.Add("@msgOut", SqlDbType.NVarChar, 300);
        cmd.Parameters.Add("@Result", SqlDbType.Int);
        cmd.Parameters["@msgOut"].Direction = ParameterDirection.Output;
        cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
        int result = Convert.ToInt32(cmd.ExecuteNonQuery());
        msgOutCaller = cmd.Parameters["@msgOut"].Value.ToString();
        ResultCaller = Convert.ToInt32(cmd.Parameters["@Result"].Value);
        return result;
    }
}