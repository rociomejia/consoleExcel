using System;
using System.Collections.Generic;
using System.Text;

namespace CSSD.IS.ProfLearn.Util

{
    /// <summary>
    /// This is the class to map the tables and columns in the Adhoc database using Enum.
    /// </summary>
    public class AdhocDatabaseMapping
    {
        public enum AdhocTables
        {
            tlkpLocations = 0,
            tblValidation_Rules,
            tlkpValidation_Types,
            tmpExportStaffStudentEnroll_ForCompare,
            tmpGradesImportFromD2L,
            tmpGradesSelectListingCode,
            tblBackup_GradesExportToPPS,
            tblBackup_GradesErrors
        }

        public enum UDSysParameters
        {
            ParamID = 0,
            ParamValue,
            MinAuthorityLevel,
            ParamDesc
        }

        public enum TLKPLocations
        {
            ischoolid = 0,
            Plant,
            LocationName,
            ABLearningCode,
            ShortName,
            Divisions,
            Zone,
            IntegrateWithD2L,
            Division,
            D2LOU,
            GradesPath,
            TotalCount
        }

        public enum TBLUserProfiles
        {
            EmployeeId = 0,
            Username ,
            LastName,            
            FirstName,
            MiddleName,
            Hiredate,
            Email,
            ActiveAccount,
            GroupTypeId,
            DemogCode,
            SiteCode,
            PrimarySite,                      
            Field1,
            Field2,
            Field3,
            Field4,
            Field5            
        }

        public enum TBLUsers
        {
            EmployeeId = 0,
            Username,
            LastName,
            FirstName,
            MiddleName,
            Hiredate,
            Email,
            ActiveAccount,
            GroupTypeId,
            DemogCode,
            SiteCode,
            PrimarySite,
            Field1,
            Field2,
            Field3,
            Field4,
            Field5
        }

        public enum TLKPInactiveCourseCodes
        {
            ABCourseCode
        }

        public enum TMPExportCourses
        {
            ListingCode = 0,
            ListingName,
            IsCourse,
            SISID,
            CoursePath,
            CohortCode,
            CategoryCode,
            TemplateCode,
            TemplateSISID,
            SemesterCode,
            OrgUnitCode,
            StartDate,
            EndDate,
            TemplatePath,
            CanRegister,
            ischoolid,
            MCSISID,
            IsResend,
            Grade,
            Diploma,
            ClassID,
            TermID,
            CreditHours,
            CreditType,
            ChangeStatus,
            CountOfListingCode,
            CountOfTemplateCode,
            YearCode,
            Dept,

            //* Add those fields for Cohort Tool:
            CourseCode,
            CourseName,
            Instructor,

            //* New Fields for SSC Tool:
            JobID,
            class_iclassid,
            departmentexams_ccode,
            Comments,
            ChangeStatusComment
        }

        public enum TMPExportStaffStudentEnroll
        {
            StudentID = 0,
            ListingCode,
            SISID,
            ischoolid,
            CountOfStudentID,
            CountOfSchool,
            School,
            RoleCode,
            EnrollType,
            BaseRoleCode,
            CohortCode,
            JobID,
            CountOfCourseOfferingCode,
            EnrollStatus,
            ShortName
        }

        public enum TMPExportStaffStudentCreate
        {
            StudentID = 0,
            UserName,
            FirstName,
            LastName,
            RoleCode,
            ischoolid,
            Password,
            EmployeeID,
            sirs_student_staff_id,
            BaseRoleCode,
            StudentGrade
        }

        public enum TBLValidation_Rules
        {
            RULE_NUM = 0,
            DESCRIPTION,
            ACTIVE,
            COMMENTS
        }

        public enum TLKPValidation_Types
        {
            TYPE_NUM = 0,
            TYPE,
            DESCRIPTION,
            COMMENTS
        }

        public enum TMPXMLTABLE_VARCHAR
        {
            Extract_Type = 0,
            Extract_Varchar
        }

        public enum CSSD_CLASS_CSV
        {
            ListingCode_ = 0,
            CategoryCode_,
            TemplateCode,
            SemesterCode,
            ListingName_,
            StartDate_,
            EndDate_,
            CanRegister,
            OrgUnitCode_,
            IsCourse,
            SISID_,
            CohortCode_,
            CoursePath,
            MCSISID
        }

        public enum CSSD_ROSTER_CSV
        {
            StudentID_ = 0,
            ListingCode_,
            RoleCode_
        }

        public enum CSSD_USER_CSV
        {
            StudentID_ = 0,
            UserName_,
            FirstName,
            MiddleName_,
            LastName_,
            Password_,
            RoleCode_,
            Gender,
            PrivacyFlag,
            Email_
        }

        public enum TBLJob
        {
            JobID = 0,
            DateStart,
            Success
        }

        public enum TBLJob_History_Adhoc
        {
            JobID = 0,
            User_ID,
            Processed_Schools
        }

        public enum TMPImportStaff
        {
            ischoolid = 0,
            staff_istaffid,
            staff_cfirstname,
            staff_clastname,
            FullName,
            StaffID
        }

        public enum TBLMappedRoleCode
        {
            RecordID = 0,
            StudentID,
            MappedRoleCode,
            StartDate,
            EndDate,
            ApprovedBy,
            EnteredBy,
            Comments
        }

        public enum TBLGradesRP
        {
            RPID = 0,
            RPLongName,
            RPShortName,
            Division,
            GradesStartDate,
            GradesEndDate,
            Comments,
            ReportPeriodLongName,
            ReportPeriodID
        }

        public enum TMPGradesImportFromD2L
        {
            ListingCode = 0,
            StudentID,
            FinalGrade,
            FinalComment,
            GradesJobID,
            WorkHabit,
            IsValid,
            IsValidComment,
            SupportInd,
            PublicComments,
            //columns in backup table:
            ListingName,
            SelectedforExport,
            CreditType,
            EarnedCrHrs,
            PPSPercent,
            PPSGrade,
            PotentialCrHrs,
            StoreCode,
            TermID,
            InstructorName,
            ClassID,
            ischoolid,
            LocationName,
            ExportJobID,
            GradeLevel,
            DateStored
        }

        public enum TMPGradesSelectListingCode
        {
            ListingCode = 0,
            Diploma,
            ListingName,
            ClassID,
            GradesJobID,
            SelectedForExport,
            TermID,
            StoreCode,
            StaffID,
            CreditHours,
            CreditType,
            CategoryCode,
            IsValid,
            GradeLevel,
            SemesterCode,
            StartDate,
            EndDate
        }

        public enum TBLGradesJob
        {
            GradesJobID = 0,
            ImportedByUser,
            ImportDate,
            Plant,
            RPID,
            Comment
        }

        public enum TlkpWorkHabits
        {
            WHID = 0,
            WHCode,
            Comment
        }

        public enum TlkpClassDept
        {
            values_ccode = 0,
            department,
            DepartmentCode
        }

        public enum GradesRPStoreCodes
        {
            StoreCode = 0,
            TermID,
            Plant,
            FinalRP
        }

        public enum PPSGradesTable
        {
            Course_Name = 0,
            Course_Number,
            Credit_Type,
            EarnedCrHrs,
            PotentialCrHrs,
            Grade,
            Percent,
            SchoolID,
            Student_Number,
            SectionID,
            StoreCode,
            SchoolName,
            TermID,
            Teacher_Name,
            Grade_Level,
            Behavior,
            Comment,
            DateStored
        }

        public enum TBLCohort
        {
            CohortSISID = 0,
            ListingCode,
            ListingName,
            DoIntegrate,
            Comment,
            UserName,
            InstructorName,
            Plant,
            Dept,
            MajorStatusID,
            MinorStatusID,
            DateCreated,
            LastModified,
            InstructorID
        }

        public enum tlkpExcludeCourses
        {
            course_ccoursecode = 0,
            Plant,
            Comment
        }

        public enum tblBackup_GradesErrors
        {
            ID = 0,
            ErrorID,
            GradesJobID,
            InstructorName,
            StudentID,
            ListingCode,
            ListingName,
            WorkHabit,
            FinalGrade,
            FinalComment,
            SupportInd,
            errorCount
        }

        public enum tlkpGradesErrorMessages
        {
            ErrorID = 0,
            ErrorType,
            ErrorMessage,
            IsActive,
            Action
        }

        public enum tlkpStaffWithNoITS
        {
            FirstName = 0,
            LastName,
            D2LUserName,
            PlantCode,
            ListingCode,
            IsActive
        }

        public enum tlkpIntSchoolParameters
        {
            ischoolid = 0,
            grades_cname,
            ReadinessLevel,
            CourseExtension
        }

        public enum tmpWithdrawals
        {
            JobID = 0,
            WithdrawalDateStart,
            StudentID,
            UserName,
            RoleCode,
            ListingCode,
            ERGIUserName,
            Updated,
            PlantCode,
            ProcessDate,
            StartDate,
            EndDate
        }

        public enum D2LCohortCourse
        {
            UID = 0,
            CohortSISID,
            CohortJobUID,
            CourseCode,
            CourseName,
            Instructor,
            Plant,
            Department,
            SemesterCode,
            CohortStatusUID,
            RequestedBy,
            RequestedDate,
            UpdatedBy,
            UpdatedDate,
            TemplateCode,
            CourseStartDate,
            CourseEndDate
        }

        public enum D2LCohortMemberCourse
        {
            UID = 0,
            CohortMemberSISID,
            CohortSISID,
            CohortJobUID,
            CourseCode,
            CourseName,
            Instructor,
            Plant,
            Department,
            SemesterCode,
            CohortStatusUID,
            StatusCode,
            RequestedBy,
            RequestedDate,
            UpdatedBy,
            UpdatedDate,
            CourseStartDate,
            CourseEndDate,
            IntegratedDate
        }

        public enum CohortUser
        {
            UID = 0,
            UserName,
            Plant,
            SchoolName
        }

        public enum CohortStatus
        {
            UID = 0,
            StatusCode,
            Description
        }

        public enum CohortType
        {
            UID = 0,
            TypeCode,
            Description
        }

        public enum CohortJob
        {
            UID = 0,
            CohortTypeUID,
            RequestedBy,
            RequestedDate,
            UpdatedBy,
            UpdatedDate,
            Comments
        }

        public enum CohortHistory
        {
            UID = 0,
            CohortJobUID,
            Plant,
            CohortSISID,
            CohortCourseCode,
            CohortCourseName,
            MemberCourseCode,
            MemberCourseName,
            MemberSISID,
            CohortInstructor,
            MemberInstructor,
            SemesterCode,
            StatusCode,
            RequestedBy,
            RequestedDate,
            UpdatedBy,
            UpdatedDate,
            Comments
        }

        public enum TGCD2LCohortNoMember
        {
            UID = 0,
            CohortSISID,
            CohortJobUID,
            CourseCode,
            CourseName,
            Department,
            Instructor,
            Plant,
            SemesterCode,
            CohortStatusUID,
            RequestedBy,
            RequestedDate,
            UpdatedBy,
            UpdatedDate,
            TemplateCode
        }
    }
}
