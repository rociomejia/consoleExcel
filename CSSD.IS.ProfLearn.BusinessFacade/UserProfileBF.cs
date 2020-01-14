using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;

using CSSD.IS.ProfLearn.DataEntityModel;
using CSSD.IS.ProfLearn.BusinessLogic;
using CSSD.IS.ProfLearn.Util;
using System.Security.Permissions;

namespace CSSD.IS.ProfLearn.BusinessFacade

{
    public class UserProfileBF
    {
        public UserProfileResponse RetrieveAllUserProfiles(UserProfileRequest obj)
        {
            UserProfileResponse result = new UserProfileResponse();

            DbConnectionHandler dbConnectionHandler = new DbConnectionHandler();
            DbConnection dbConnection =    dbConnectionHandler.GetSqlConnection(obj.ConnString);
            SqlTransaction transaction = null;

            try
            {
                dbConnectionHandler.OpenDbConnection(dbConnection);
                transaction = (SqlTransaction)dbConnection.BeginTransaction();

                UserProfileBL userProfileBL = new UserProfileBL();
                result.UserProfileList = userProfileBL.RetrieveAllUserProfiles(obj.UserProfileType, dbConnection, transaction);
            }
            catch (Exception ex)
            {
                AppLog.GetAppLog().Log("Error: occurred in retrieving from query RetriveAllUserProfiles.");
                AppLog.GetAppLog().Log(ex.ToString());
                AppLog.GetAppLog().HasError = true;                
                throw ex;
            }
            finally
            {
                dbConnectionHandler.CloseDbConnection(dbConnection);
            }
            return result;
        }
    }
}
