using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
//using Core.Data;
using log4net;
namespace Core.InterfaceLayer
{
	/// <summary>
	/// Summary description for Login Helper.
	/// </summary>
   public class LoginHelper
   {
        DataTable datatable = new DataTable();
        private Database dataBase;
        private Database GetDatabaseObject()
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new Database();
            }
            return dataBase;
        }
        private static readonly ILog logger = LogManager.GetLogger(typeof(LoginHelper));
		private SqlParameter[] param;

        /// <summary>





        public void ValidateUser(Login login)
        {
            int iReturn = 0;
            param = new SqlParameter[13];
            dataBase = GetDatabaseObject();
            try
            {
                param[0] = dataBase.MakeInParameter("@userId", SqlDbType.NVarChar, 100, login.UserID);
                param[1] = dataBase.MakeInParameter("@Password", SqlDbType.NVarChar, 100, login.PWD);
                param[2] = dataBase.MakeOutParameter("@Return_Value", SqlDbType.Int, 1);
                param[3] = dataBase.MakeOutParameter("@SubAgentName ", SqlDbType.NVarChar, 50);
                param[4] = dataBase.MakeOutParameter("@Right_Codes", SqlDbType.NVarChar, 4000);
                param[5] = dataBase.MakeOutParameter("@SubAgent_Id", SqlDbType.NVarChar, 20);
                param[6] = dataBase.MakeOutParameter("@FirstPhone", SqlDbType.NVarChar, 20);
                param[7] = dataBase.MakeOutParameter("@BranchId", SqlDbType.SmallInt, 4);
                param[8] = dataBase.MakeOutParameter("@EmailAddress", SqlDbType.NVarChar,50);
                param[9] = dataBase.MakeOutParameter("@FName", SqlDbType.NVarChar, 50);
                param[10] = dataBase.MakeOutParameter("@ProfileImage", SqlDbType.NVarChar, 50);
                param[11] = dataBase.MakeOutParameter("@AgentId", SqlDbType.Int, 4);
                param[12] = dataBase.MakeOutParameter("@RoleType", SqlDbType.Char, 1);
                iReturn = dataBase.RunProcedure("SubAgent_Login_Select", param);
                if (iReturn == 1)
                {
                    login.Status = true;
                    login.UserName = param[3].Value.ToString();
                    login.Right_Codes = param[4].Value.ToString();
                    login.UserID = param[5].Value.ToString();
                    login.Phone = param[6].Value.ToString();
                    login.BranchId = int.Parse(param[7].Value.ToString());
                    login.EMail = param[8].Value.ToString();
                    login.FName = param[9].Value.ToString();
                    login.ProfileImg = param[10].Value.ToString();
                    login.AgentId = (int)param[11].Value;
                    login.RoleType = param[12].Value.ToString();
                }
                else
                {
                    login.Status = false;
                }
            }
            catch (Exception exp)
            {
                logger.Error(exp.ToString());
            }
            finally
            {
                Reset();
            }
        }

        /// <summary>
        /// This function is used to Authenticate user.	
        /// </summary>
        public void AuthenticateUser(Login login)
        {
            int iReturn = 0;
            param = new SqlParameter[11];
            dataBase = GetDatabaseObject();
            try
            {
                param[0] = dataBase.MakeInParameter("@UserId", System.Data.SqlDbType.VarChar, 50, login.UserID);
                param[1] = dataBase.MakeInParameter("@PWD", System.Data.SqlDbType.VarChar, 300, login.PWD);
                param[2] = dataBase.MakeOutParameter("ReturnValue", SqlDbType.Int, 1);
                param[3] = dataBase.MakeOutParameter("@UserName", SqlDbType.VarChar, 100);
                param[4] = dataBase.MakeOutParameter("@Right_Codes", SqlDbType.Char, 1);
                param[5] = dataBase.MakeOutParameter("@EMail", SqlDbType.VarChar, 300);
                param[6] = dataBase.MakeInParameter("@TxtPWD", System.Data.SqlDbType.VarChar, 300, login.TextPassword);
                param[7] = dataBase.MakeInParameter("@IPAddress", SqlDbType.VarChar, 20, login.IPAddress);
                param[8] = dataBase.MakeOutParameter("@EmailCount", SqlDbType.Int, 32);
                param[9] = dataBase.MakeOutParameter("@CommentCount", SqlDbType.Int, 32);
                param[10] = dataBase.MakeOutParameter("@ExtendedUserType", SqlDbType.VarChar, 50);
                iReturn = dataBase.RunProcedure("ValidateUserLogin", param);
                if (iReturn == 0)
                {
                    login.Status = false;
                }
                else
                {
                    login.Status = true;
                    login.UserName = param[3].Value.ToString();
                    login.Right_Codes = param[4].Value.ToString();
                    login.EMail = param[5].Value.ToString();
                    login.EmailCount = Convert.ToInt32(param[8].Value);
                    login.CommentCount = Convert.ToInt32(param[9].Value);
                    login.ExtendedUserType = param[10].Value.ToString();
                }
            }
            catch (Exception exp)
            {
                logger.Error(exp.ToString());
            }
            finally
            {
                Reset();
            }
        }

        /// <summary>
        /// This function is used to Get User Type.
        /// </summary>
        public string GetUserTypeString(Login login)
		{
			string sUserTypeString = "";
			param = new SqlParameter[2];           
            dataBase = GetDatabaseObject();
			try
			{
                param[0] = dataBase.MakeInParameter("@UserId", System.Data.SqlDbType.VarChar, 50, login.UserID);
				param[1] = dataBase.MakeOutParameter("@UserTypeString",SqlDbType.VarChar, 50);
				dataBase.RunProcedure("GetUserTypeString", param);
				sUserTypeString = param[1].Value.ToString(); 
			}
			catch(Exception exp)
			{
				logger.Error(exp.ToString());
				return sUserTypeString;
			}
			finally
			{
				Reset();
			}
			return sUserTypeString;
		}
        /// <summary>
        /// This function is used to edit the password for a user	
        /// </summary>
        /// <returns>Return Status of Request</returns>		
		public int EditPassword(Login login)
		{			
			int sOutput = 0;
			param = new SqlParameter[5];          
            dataBase = GetDatabaseObject();
			try
			{
                param[0] = dataBase.MakeInParameter("@UserId", System.Data.SqlDbType.VarChar, 50, login.UserID);
                param[1] = dataBase.MakeInParameter("@OldPWDE", System.Data.SqlDbType.VarChar, 100, login.OldPWD);
                param[2] = dataBase.MakeInParameter("@NewPWDE", System.Data.SqlDbType.VarChar, 100, login.PWD);
                param[3] = dataBase.MakeInParameter("@OldPWD", System.Data.SqlDbType.VarChar, 100, login.PWDUnEncrypted);
				param[4] = dataBase.MakeOutParameter("@Res",SqlDbType.Int , 4);
				dataBase.RunProcedure("P_UpdatePassword",param);
				sOutput = (int)param[4].Value;
			}
			catch(Exception exp)
			{
				logger.Error(exp.ToString());
				return sOutput;
			}
			finally
			{
				Reset();
			}
			return sOutput;
		}
		
		private void Reset()
		{
			param = null;
        }

        
        /////////////////////////// For Credit card 
        

        public DataTable GetCreditCardLimit(Login login)
        {
            param = new SqlParameter[1];
            dataBase = GetDatabaseObject();
            try
            {
                param[0] = dataBase.MakeInParameter("@UserId", System.Data.SqlDbType.VarChar, 50, login.UserID);
                dataBase.RunProcedure("getCreditCardlimit", param, out datatable);
            }
            catch (Exception exp)
            {
                logger.Error(exp.ToString());
                return datatable;
            }
            finally
            {
                Reset();
            }
            return datatable;
        }

        DataSet dataset = new DataSet();
        public DataSet GetSubAgentDetailsById(SearchEngine searchEngine)
        {
            try
            {
                dataBase = GetDatabaseObject();
                param = new SqlParameter[2];
                param[0] = dataBase.MakeInParameter("@AgencyName", SqlDbType.NVarChar, 50, searchEngine.AgencyName);
                param[1] = dataBase.MakeInParameter("@Id", SqlDbType.Int, 4, searchEngine.Id);
                dataBase.RunProcedure("SubAgent_master_SelectDetail", param, out dataset);
                return dataset;
            }
            catch (Exception exp)
            {
                logger.Error(exp.ToString());
            }
            finally
            {
                Reset();
            }
            return dataset;
        }
        public DataTable getUserIdByEmail(string Email)
        {
            param = new SqlParameter[1];
            dataBase = GetDatabaseObject();
            try
            {
                param[0] = dataBase.MakeInParameter("@Email", System.Data.SqlDbType.VarChar, 100,Email);
                dataBase.RunProcedure("USP_getUserIdByEmail", param, out datatable);
            }
            catch (Exception exp)
            {
                logger.Error(exp.ToString());
                return datatable;
            }
            finally
            {
                Reset();
            }
            return datatable;
        }

    }
}

