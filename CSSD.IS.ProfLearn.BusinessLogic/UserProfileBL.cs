using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using CSSD.IS.ProfLearn.DataEntityModel;
using CSSD.IS.ProfLearn.DataAccess;

namespace CSSD.IS.ProfLearn.BusinessLogic
{
    public class UserProfileBL
    {
        public UserProfileDEMList RetrieveAllUserProfiles(UserProfileDEMType obj, DbConnection dbConnection, SqlTransaction transaction)
        {
            UserProfileDA da = new UserProfileDA(dbConnection, transaction);
            UserProfileDEMList result = da.RetriveAllUserProfiles(obj);                                           
            return result;
        }
    }
}
