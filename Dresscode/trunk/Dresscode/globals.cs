using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Dresscode
{
    class globals
    {
        //public OleDbConnection oleconnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\w03s1762d\tech\TSA\dresscode\dc.mdb;Jet OLEDB:Database Password=Braves2013");
        public OleDbConnection oleconnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\DevPump\Documents\Visual Studio 2013\Projects\Dresscode\Dresscode\dc.mdb;Jet OLEDB:Database Password=Braves2013");

        public bool funnymode = false;
        

        public int
            num_periods = 7;

        public string
            //Global strings
            glt_isdean = "yes", //Make this lower case (The program will check for both capitial or lower case starting letter)
            glt_checked = "Checked",
            glt_notpresent = "Not Present",
            glt_present = "Present",
            //Global Table Names
            tbl_studentinfo = "Student Info",
            tbl_teacherinfo = "Teacher Info",
            tbl_emailsettings = "Email Settings",
            tbl_nineweeksdates = "Nine Weeks Dates",
            tbl_reports = "Reports",
            tbl_infractionlist = "Infraction List",
            tbl_mailinglist = "Mailing List",
            //Global Column Names (Some share, such as First Name on student and teacher) [There is absolutely no need to make seperate variables for things such as names]
            col_id = "ID", // <-- Hidden Column (Can't be seen by the user, unless they view the Database)
            col_grade = "Grade",
            col_period = "Period",
            col_deanaction = "Dean Action",
            col_dateofdeanaction = "Date of Dean Action",
            col_reportdate = "Report Date",
            col_teacher = "Teacher",
            col_infractions = "Infractions",
            col_dean = "Dean",
            col_password = "Password",
            col_teacherid = "Teacher ID",
            col_studentid = "Student ID",
            col_firstname = "First Name",
            col_lastname = "Last Name",
            col_smtpserver = "SMTP Server",
            col_hostemail = "Host Email",
            col_hostpassword = "Host Password",
            col_portnumber = "Port Number",
            col_email = "Email",
            col_timehour = "Time Hour",
            col_timeminute = "Time Minute",
            col_emailsubject = "Email Subject",
            col_emailbody = "Email Body",
            col_emaillist = "Email List",
            col_deleteexcel = "Delete Excel",
            col_learningcenter = "Learning Center",


            col_firstnineweeksstart = "firstnineweeksstart",
            col_firstnineweeksend = "firstnineweeksend",
            col_secondnineweeksstart = "secondnineweeksstart",
            col_secondnineweeksend = "secondnineweeksend",
            col_thirdnineweeksstart = "thirdnineweeksstart",
            col_thirdnineweeksend = "thirdnineweeksend",
            col_forthnineweeksstart = "forthnineweeksstart",
            col_forthnineweeksend = "forthnineweeksend";
    }
}
