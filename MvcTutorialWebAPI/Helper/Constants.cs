using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTutorialWebAPI.Helper
{
    public class Constants
    {
        public static string SUCCESS = "Success";
        public static string NODATA = "No Data Found.";
        public static string INVALID = "Invalid Data.";
        public static string UNOTHORIZED = "Unauthorized Access.";
        public static string DATANOTFOUND = "Data Not Found.";
        public static string ERRORMSG = "Error Message : ";
        public static string DATAREQUIRED = "Data Required.";
        public static string ACCOUNTINACTIVE = "Your Account is Inactive.";
        public static string ACCOUNTCREATEDSUCCESSFULLY = "Account Created Successfully.";
        public static string ACCOUNTDELETEDSUCCESSFULLY = "Account Deleted Successfully.";
        public static string ACCOUNTDEACTIVATEDSUCCESSFULLY = "Account Deactivated Successfully.";
        public static string ACCOUNTDEALREADYACTIVE = "Account Already Active.";
        public static string ACCOUNTACTIVATEDSUCCESSFULLY = "Account Activated Successfully.";


        ////User Related 
        public static string INVALIDUSEREMAIL = "Invalid Username or Password.";
        public static string INVALIDUSERPASSWORD = "Invalid Username or Password.";
        public static string INVALIDEMAIL = "Invalid Email Address.";
        public static string INVALIDPASSWORD = "Invalid Password.";
        public static string INVALIDOLDPASSWORD = "Invalid Old Password.";
        public static string INVALIDPINNUMBER = "Invalid Pin Number.";
        public static string INVALIDMOBILE = "Invalid Mobile Number.";
        public static string INVALIDOTP = "Invalid OTP.";

        public static string EXISTS = "Already Exists.";
        public static string EMAILALREADYEXISTS = "Email Address Already Exist.";
        public static string MOBILEALREADYEXISTS = "Mobile Number Already Used.";
        public static string ADHARCARDALREADYEXISTS = "AdharCard Number Already Used.";

        public static string EMAILNOTEXISTS = "Email Address Doesn't Exist.";
        public static string MOBILENOTEXISTS = "Mobile Number Doesn't Exist.";

        public static string OTPCODE = "OTP Send Successfully.";
        public static string RESETPASSWORD = "Password reset successfully.";
        public static string NEWPASSWORD = "New Password Created Successfully.Please Re-Login with New Password.";
        public static string PROFILEUPDATE = "Profile updated successfully.";

        public static string INNEREXCEPTION = " InnerException Message : ";

    }
}