using System;
using System.Collections;
using System.Configuration;
using CSSD.IS.ProfLearn.DataEntityModel;
using CSSD.IS.ProfLearn.BusinessFacade;
using CSSD.IS.ProfLearn.BusinessLogic;
using CSSD.IS.ProfLearn.DataAccess;
using CSSD.IS.ProfLearn.Util;
//using CSSD.IS.ProfLearn.UIHelper;

using System.Diagnostics;

namespace ProfLearn.Common
{
    public class UserProfileProcess : BaseProcess
    {
        private UserProfileBF _userProfileBF;

        public UserProfileProcess()
            : base()
        {
            _userProfileBF = new UserProfileBF();
        }


        public UserProfileDEMList RetrieveAllUserProfiles (UserProfileDEMType obj)
        {
            UserProfileRequest requestfacade = new UserProfileRequest();
            UserProfileResponse responsefacade = new UserProfileResponse();

            requestfacade.UserProfileType = obj;
            requestfacade.ConnString = ConnString;

            try
            {
                responsefacade = _userProfileBF.RetrieveAllUserProfiles(requestfacade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return responsefacade.UserProfileList;
                
        }
               

        //UserProfileResponse requestAllUsersFromFacade = new UserProfileResponse();
                    

        //RetrieveAllUserProfiles requestAllUsersFromFacade =  new RetrieveAllUserProfiles();
                
        

        
    }
}
