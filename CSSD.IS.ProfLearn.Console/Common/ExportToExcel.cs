using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using CSSD.IS.ProfLearn.DataEntityModel;
using CSSD.IS.ProfLearn.BusinessFacade;
using CSSD.IS.ProfLearn.BusinessLogic;
using CSSD.IS.ProfLearn.DataAccess;
using CSSD.IS.ProfLearn.Util;


namespace ProfLearn.Common
{
    public class ExportToExcel
    {
        
        private string _filename;
        bool flag_counting_ocurrance;
             
        public ExportToExcel(String value)
        {
            _filename = value;            
        }

        public string filename
        {
            get { return _filename; }
            set { _filename = value; }
        }

        public void GenerateReport(string[] usersSkip_array)
        {
            try
            {
                UserProfileProcess retrieveProcess = new UserProfileProcess();
                UserProfileDEMType requestType = new UserProfileDEMType();

                var dt = new DataTable();
                dt.Columns.Add("EmployeeId",    typeof(string));
                dt.Columns.Add("Username",      typeof(string));
                dt.Columns.Add("LastName",      typeof(string));
                dt.Columns.Add("FirstName",     typeof(string));
                dt.Columns.Add("MiddleName",    typeof(string));
                dt.Columns.Add("Hiredate",      typeof(string));
                dt.Columns.Add("ActiveAccount", typeof(string));
                dt.Columns.Add("GroupTypeid",   typeof(string));
                dt.Columns.Add("DemogCode",     typeof(string));
                dt.Columns.Add("Sitecode",      typeof(string));
                dt.Columns.Add("PrimarySite",   typeof(string));
                dt.Columns.Add("Field1",        typeof(string));
                dt.Columns.Add("Field2",        typeof(string));
                dt.Columns.Add("Field3",        typeof(string));
                dt.Columns.Add("Field4",        typeof(string));
                dt.Columns.Add("Field5",        typeof(string));

                foreach (var userStaff in retrieveProcess.RetrieveAllUserProfiles(requestType))
                {
                    string username_string;
                    username_string = userStaff.Username;

                    flag_counting_ocurrance = false;
                    foreach (string line in usersSkip_array)
                    {

                        if (username_string.Trim().ToLower() == line.Trim().ToLower())
                        {
                            flag_counting_ocurrance = true;
                        }

                    }
                    if (flag_counting_ocurrance == false)
                    {
                        dt.Rows.Add(
                            userStaff.EmployeeId, userStaff.Username, userStaff.Lastname, userStaff.Firstname, 
                            userStaff.Middlename, userStaff.Hiredate, userStaff.Activeaccount, userStaff.Grouptypeid, 
                            userStaff.Demogcode,  userStaff.Sitecode, userStaff.Primarysite, userStaff.Field1, 
                            userStaff.Field2, userStaff.Field3, userStaff.Field4, userStaff.Field5
                            );

                    }
                }


                using (ExcelPackage p = new ExcelPackage())
                {
                    var workbook = p.Workbook;
                    var worksheet = workbook.Worksheets.Add("Sheet1");
                    var cell1 = worksheet.Cells["A1"];
                    var cell2 = worksheet.Cells["B1"];
                    var cell3 = worksheet.Cells["C1"];
                    var cell4 = worksheet.Cells["D1"];
                    var cell5 = worksheet.Cells["E1"];
                    var cell6 = worksheet.Cells["F1"];
                    var cell7 = worksheet.Cells["G1"];
                    var cell8 = worksheet.Cells["H1"];
                    var cell9 = worksheet.Cells["I1"];
                    var cell10 = worksheet.Cells["J1"];
                    var cell11 = worksheet.Cells["K1"];
                    var cell12 = worksheet.Cells["L1"];
                    var cell13 = worksheet.Cells["M1"];
                    var cell14 = worksheet.Cells["N1"];
                    var cell15 = worksheet.Cells["O1"];
                    var cell16 = worksheet.Cells["P1"];
                    var cell17 = worksheet.Cells["Q1"];
                    var cell18 = worksheet.Cells["R1"];
                    

                    cell1.Value = "EmployeeId";
                    cell2.Value = "UserName";
                    cell3.Value = "LastName";
                    cell4.Value = "Password";
                    cell5.Value = "FirstName";
                    cell6.Value = "MiddleName";
                    cell7.Value = "Hiredate";
                    cell8.Value = "Email";
                    cell9.Value = "ActiveAccount";
                    cell10.Value = "GroupTypeid";
                    cell11.Value = "DemogCode";
                    cell12.Value = "SiteCode";
                    cell13.Value = "PrimarySite";
                    cell14.Value = "Field1";
                    cell15.Value = "Field2";
                    cell16.Value = "Field3";
                    cell17.Value = "Field4";
                    cell18.Value = "Field5";                   
                                       

                    worksheet.Cells.LoadFromDataTable(dt, true);
                    p.SaveAs(new System.IO.FileInfo(filename));
                    AppLog.GetAppLog().Log("Export file is completed... " + filename);
                }
                dt.Clear();
            } catch (Exception ex)
            {
              AppLog.GetAppLog().Log("The task is terminated in Export to Excel.cs - " + ex.Message);
            }
    }

   }
}
    
