using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSSD.IS.ProfLearn.DataEntityModel

{
    [Serializable]
    public class UserProfileDEMType
    {
        private string _employeeId;
        private string _username;
        private string _lastname;        
        private string _firstname;
        private string _middlename;
        private string _hiredate;
        private string _email;
        private string _activeaccount;
        private string _grouptypeid;
        private string _demogcode;
        private string _sitecode;
        private string _primarysite;
        private string _field1;
        private string _field2;
        private string _field3;
        private string _field4;
        private string _field5;
                
        public string EmployeeId
        {
            get { return _employeeId; }
            set { _employeeId = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        public string Middlename
        {
            get { return _middlename; }
            set { _middlename = value; }
        }

        public string Hiredate
        {
            get { return _hiredate; }
            set { _hiredate = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
                
        public string Activeaccount
        {
            get { return _activeaccount; }
            set { _activeaccount = value; }
        }                            

        public string Grouptypeid
        {
            get { return _grouptypeid; }
            set { _grouptypeid = value; }
        }

        public string Demogcode
        {
            get { return _demogcode; }
            set { _demogcode = value; }
        }

        public string Sitecode
        {
            get { return _sitecode; }
            set { _sitecode = value; }
        }

        public string Primarysite
        {
            get { return _primarysite; }

            set { _primarysite = value; }
        }

        public string Field1
        {
            get { return _field1; }
            set { _field1 = value; }
        }

        public string Field2
        {
            get { return _field2; }
            set { _field2 = value; }
        }

        public string Field3
        {
            get { return _field3; }
            set { _field3 = value; }
        }

        public string Field4
        {
            get { return _field4; }
            set { _field4 = value; }
        }

        public string Field5
        {
            get { return _field5; }
            set { _field5 = value; }
        }
                
    }

    [Serializable]
    public class UserProfileDEMList : CSSDCollection<UserProfileDEMType>
    {
        public IList<UserProfileDEMType> Collection
        {
            get { return base._list; }
            set { base._list = value; }
        }
    }


    public class UserProfileRequest
    {
        private UserProfileDEMType _userProfileType = new UserProfileDEMType();
        private string _connString;

        public UserProfileDEMType UserProfileType
        {
            get { return _userProfileType; }
            set { _userProfileType = value; }
        }

        public string ConnString
        {
            get {return _connString; }
            set { _connString= value;}
        }
    }      

    public class UserProfileResponse
    {
        private UserProfileDEMType _userprofileType = new UserProfileDEMType();
        private UserProfileDEMList _userprofileList = new UserProfileDEMList();

        public UserProfileDEMType UserProfileType
        {
            get { return _userprofileType; }
            set { _userprofileType = value; }
        }

        public UserProfileDEMList UserProfileList
        {
            get { return _userprofileList; }
            set { _userprofileList = value; }
        }
    }

    
}
