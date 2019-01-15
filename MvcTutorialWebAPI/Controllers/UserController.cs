using MvcTutorialWebAPI.Helper;
using MvcTutorialWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace MvcTutorialWebAPI.Controllers
{
    public class UserController : ApiController
    {

        //-------------------------------------------  Registration   --------------------------------------
        //POST: Add User All Details in to the DataBase 
        [HttpPost]
        public HttpResponseMessage Registration(UserRegistrationModelClass modelUserRegisterData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var database = new MvcTutorialEntities())
                    {
                        // this validation is use when browser will disable javasript.
                        if (database.tblUser.Any(email => email.EmailAddress == modelUserRegisterData.EmailAddress))
                        {
                            return this.GenerateResponse(false, HttpStatusCode.Found, Constants.EMAILALREADYEXISTS);
                        }
                        else if (database.tblUser.Any(Mobileno => Mobileno.MobileNo == modelUserRegisterData.MobileNo))
                        {
                            return this.GenerateResponse(false, HttpStatusCode.Found, Constants.MOBILEALREADYEXISTS);
                        }
                        else
                        {
                            tblUser dbobjectuser = new tblUser();
                            dbobjectuser.UserName = modelUserRegisterData.UserName;
                            dbobjectuser.MobileNo = modelUserRegisterData.MobileNo;
                            dbobjectuser.EmailAddress = modelUserRegisterData.EmailAddress;
                            dbobjectuser.Password = modelUserRegisterData.Password;
                            dbobjectuser.Address = modelUserRegisterData.Address;
                            dbobjectuser.IsActive = true;
                            dbobjectuser.AccountCreateDate = System.DateTime.Now;

                            database.tblUser.Add(dbobjectuser);
                            database.SaveChanges();
                            return this.GenerateResponse(true, HttpStatusCode.OK, Constants.ACCOUNTCREATEDSUCCESSFULLY);
                        }
                    }
                }
                else
                {
                    return this.GenerateResponse(false, HttpStatusCode.NotFound, Constants.INVALID);
                }
            }
            catch (Exception ex)
            {
                return this.GenerateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //-------------------------------------------  Login   -----------------------------------------------
        //POST: Check The User Mobile no and Password is Correct or not
        [HttpPost]
        public HttpResponseMessage Login(UserLoginModelClass modeluserLoginData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var database = new MvcTutorialEntities())
                    {
                        var Verify = database.tblUser.FirstOrDefault(user => user.MobileNo == modeluserLoginData.MobileNo);
                        if (Verify == null)
                        {
                            return this.GenerateResponse(false, HttpStatusCode.Conflict, Constants.MOBILENOTEXISTS);
                        }
                        else
                        {
                            if (Verify.IsActive == true)
                            {
                                if (Verify.Password == modeluserLoginData.Password)
                                {
                                    return this.GenerateResponse(true, HttpStatusCode.OK, Verify);
                                }
                                else
                                {
                                    return this.GenerateResponse(false, HttpStatusCode.Conflict, Constants.INVALIDPASSWORD);
                                }
                            }
                            else
                            {
                                return this.GenerateResponse(false, HttpStatusCode.Conflict, Constants.ACCOUNTINACTIVE);
                            }
                        }
                    }
                }
                else
                {
                    return this.GenerateResponse(false, HttpStatusCode.NotFound, Constants.NODATA);
                }
            }
            catch (Exception ex)
            {
                return this.GenerateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //-------------------------------------------  Forgot Password   --------------------------------------
        //POST: check User is Register user or not if it is Registerd the Allow to change his/her password
        [HttpPost]
        public HttpResponseMessage ForgotPassword(UserForgotPasswordModelClass modelForgotPasswordData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var database = new MvcTutorialEntities())
                    {
                        var verify = database.tblUser.FirstOrDefault(user => user.MobileNo == modelForgotPasswordData.MobileNo);
                        if (verify != null)
                        {
                            if (verify.IsActive == true)
                            {
                                return this.GenerateResponse(true, HttpStatusCode.OK, verify.UserID);
                            }
                            else
                            {
                                return this.GenerateResponse(false, HttpStatusCode.Conflict, Constants.ACCOUNTINACTIVE);
                            }
                        }
                        else
                        {
                            return this.GenerateResponse(false, HttpStatusCode.Conflict, Constants.MOBILENOTEXISTS);
                        }
                    }
                }
                else
                {
                    return this.GenerateResponse(false, HttpStatusCode.NotFound, Constants.NODATA);
                }
            }
            catch (Exception ex)
            {
                return this.GenerateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        //-------------------------------------------  Create New Password   --------------------------------------
        // POST:Create New Password for user profile
        [HttpPost]
        public HttpResponseMessage CreateNewPassword(UserNewPasswordModelClass modelnewpasswordData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new MvcTutorialEntities())
                    {
                        var verify = db.tblUser.Find(modelnewpasswordData.UserID);
                        if (verify != null)
                        {
                            verify.Password = modelnewpasswordData.NewPassword;
                            db.SaveChanges();

                            return this.GenerateResponse(true, HttpStatusCode.OK, Constants.NEWPASSWORD);
                        }
                        else
                        {
                            return this.GenerateResponse(false, HttpStatusCode.Unauthorized, Constants.UNOTHORIZED);
                        }
                    }
                }
                else
                {
                    return this.GenerateResponse(false, HttpStatusCode.NotFound, Constants.NODATA);
                }

            }
            catch (Exception ex)
            {
                return this.GenerateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //-------------------------------------------  Update Profile  --------------------------------------
        // GET: Get Data From the database to Display in to user Profile
        [HttpGet]
        public HttpResponseMessage ProfileInfo(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (var database = new MvcTutorialEntities())
                    {
                        var databaseProfileData = database.tblUser.FirstOrDefault(user => user.UserID == id && user.IsActive == true);
                        if (databaseProfileData != null)
                        {
                            UserProfileModelClass modelProfile = new UserProfileModelClass();
                            modelProfile.UserID = databaseProfileData.UserID;
                            modelProfile.UserName = databaseProfileData.UserName;
                            modelProfile.EmailAddress = databaseProfileData.EmailAddress;
                            modelProfile.MobileNo = databaseProfileData.MobileNo;
                            modelProfile.Address = databaseProfileData.Address;
                            return this.GenerateResponse(true, HttpStatusCode.OK, modelProfile);
                        }
                        else
                        {
                            return this.GenerateResponse(false, HttpStatusCode.NotFound, Constants.DATANOTFOUND);
                        }
                    }
                }
                else
                {
                    return this.GenerateResponse(false, HttpStatusCode.NotFound, Constants.NODATA);
                }
            }
            catch (Exception ex)
            {
                return this.GenerateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: Update Data From Which user have change 
        [HttpPut]
        public HttpResponseMessage ProfileInfo(UserProfileModelClass modelprofiledData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var database = new MvcTutorialEntities())
                    {
                        // this validation is use when browser will disable javasript.
                        if (database.tblUser.Any(email => email.EmailAddress == modelprofiledData.EmailAddress && email.EmailAddress != modelprofiledData.EmailAddress))
                        {
                            return this.GenerateResponse(false, HttpStatusCode.Found, Constants.EMAILALREADYEXISTS);
                        }
                        else if (database.tblUser.Any(Mobileno => Mobileno.MobileNo == modelprofiledData.MobileNo && Mobileno.MobileNo != modelprofiledData.MobileNo))
                        {
                            return this.GenerateResponse(false, HttpStatusCode.Found, Constants.MOBILEALREADYEXISTS);
                        }
                        else
                        {
                            var databaseData = database.tblUser.FirstOrDefault(user => user.UserID == modelprofiledData.UserID && user.IsActive == true);
                            if (databaseData != null)
                            {
                                databaseData.MobileNo = modelprofiledData.MobileNo;
                                databaseData.EmailAddress = modelprofiledData.EmailAddress;
                                databaseData.Address = modelprofiledData.Address;

                                database.Entry(databaseData).State = System.Data.Entity.EntityState.Modified;
                                database.SaveChanges();

                                return this.GenerateResponse(true, HttpStatusCode.OK, Constants.PROFILEUPDATE);
                                //ViewBag.SuccessMessage = "Profile Update Successfully.";
                                //return View();
                            }
                            else
                            {
                                return this.GenerateResponse(false, HttpStatusCode.NotFound, Constants.DATANOTFOUND);
                                //ViewBag.Message = "Couldn't Find Your Profile.";
                            }
                        }
                    }
                }
                else
                {
                    return this.GenerateResponse(false, HttpStatusCode.NotFound, Constants.NODATA);
                }
            }
            catch (Exception ex)
            {
                return this.GenerateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //-------------------------------------------  Change Password  --------------------------------------
        // POST:Change User Password as per Request
        [HttpPost]
        public HttpResponseMessage ChangePassword(UserChangePasswordModelClass modelchangerPasswordData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var database = new MvcTutorialEntities())
                    {
                        //int UserID = modelchangerPasswordData.UserID;
                        var verify = database.tblUser.FirstOrDefault(user => user.UserID == modelchangerPasswordData.UserID && user.Password == modelchangerPasswordData.OldPassword && user.IsActive == true);
                        if (verify != null)
                        {
                            verify.Password = modelchangerPasswordData.NewPassword;
                            database.SaveChanges();

                            return this.GenerateResponse(true, HttpStatusCode.OK, Constants.RESETPASSWORD);
                            //ViewBag.SuccessMessage = "Password Change Successfully. Please Re-Login With New Password.";
                        }
                        else
                        {
                            return this.GenerateResponse(false, HttpStatusCode.NotFound, Constants.INVALIDPASSWORD);
                            //ViewBag.Message = "You have Enter Wrong Old Password.";
                        }
                    }
                }
                else
                {
                    return this.GenerateResponse(false, HttpStatusCode.NotFound, Constants.NODATA);
                }
            }
            catch (Exception ex)
            {
                return this.GenerateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //-------------------------------------------  Delete User Account  --------------------------------------
        // GET: find user profile and delete from the database
        [HttpDelete]
        public HttpResponseMessage DeleteAccount(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (var database = new MvcTutorialEntities())
                    {
                        var databaseUserAccount = database.tblUser.Find(id);
                        if (databaseUserAccount != null)
                        {
                            database.tblUser.Remove(databaseUserAccount);
                            database.SaveChanges();
                            return this.GenerateResponse(true, HttpStatusCode.OK, Constants.ACCOUNTDELETEDSUCCESSFULLY);
                        }
                        else
                        {
                            return this.GenerateResponse(false, HttpStatusCode.NotFound, Constants.DATANOTFOUND);
                        }
                    }
                }
                else
                {
                    return this.GenerateResponse(false, HttpStatusCode.NotFound, Constants.NODATA);
                }
            }
            catch (Exception ex)
            {
                return this.GenerateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //-------------------------------------------  Deactivate User Account  --------------------------------------
        // GET: find user profile and deactivate status in database
        [HttpGet]
        public HttpResponseMessage DeactivateAccount(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (var database = new MvcTutorialEntities())
                    {
                        var databaseUserAccount = database.tblUser.Find(id);
                        if (databaseUserAccount != null)
                        {
                            databaseUserAccount.IsActive = false;
                            database.SaveChanges();
                            return this.GenerateResponse(true, HttpStatusCode.OK, Constants.ACCOUNTDEACTIVATEDSUCCESSFULLY);
                        }
                        else
                        {
                            return this.GenerateResponse(false, HttpStatusCode.NotFound, Constants.DATANOTFOUND);
                        }
                    }
                }
                else
                {
                    return this.GenerateResponse(false, HttpStatusCode.NotFound, Constants.NODATA);
                }
            }
            catch (Exception ex)
            {
                return this.GenerateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //-------------------------------------------  Activate User Account  --------------------------------------
        // GET: find user profile and deactivate status in database
        [HttpPost]
        public HttpResponseMessage ActivateAccount(UserActiveAccountClass modeluseractiveaccount)
        {
            try
            {
                using (var database = new MvcTutorialEntities())
                {
                    switch (modeluseractiveaccount.Action)
                    {
                        case "MobileVerify":
                            var verifyMobile = database.tblUser.FirstOrDefault(user => user.MobileNo == modeluseractiveaccount.MobileNo);
                            if (verifyMobile != null)
                            {
                                if (verifyMobile.IsActive == false)
                                {
                                    return this.GenerateResponse(true, HttpStatusCode.OK, verifyMobile.UserID);
                                }
                                else
                                {
                                    return this.GenerateResponse(false, HttpStatusCode.Conflict, Constants.ACCOUNTDEALREADYACTIVE);
                                }
                            }
                            else
                            {
                                return this.GenerateResponse(false, HttpStatusCode.Conflict, Constants.MOBILENOTEXISTS);
                            }
                        case "PasswordVerify":
                            var verifyPassword = database.tblUser.FirstOrDefault(user => user.UserID == modeluseractiveaccount.UserID && user.Password == modeluseractiveaccount.Password && user.IsActive == false);
                            if (verifyPassword != null)
                            {
                                verifyPassword.IsActive = true;
                                database.SaveChanges();
                                return this.GenerateResponse(true, HttpStatusCode.OK, Constants.ACCOUNTACTIVATEDSUCCESSFULLY);
                            }
                            else
                            {
                                return this.GenerateResponse(false, HttpStatusCode.Conflict, Constants.INVALIDPASSWORD);
                            }
                        default:
                            return this.GenerateResponse(false, HttpStatusCode.NotAcceptable, Constants.INVALID);

                    }
                }
            }
            catch (Exception ex)
            {
                return this.GenerateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //-------------------------------------------  Product List  -----------------------------------------------
        // GET: Get All Product List From the Database
        [HttpGet]
        public HttpResponseMessage ProductList()
        {
            try
            {
                using (var database = new MvcTutorialEntities())
                {
                    var ProductList = database.tblProducts.ToList();
                    if (ProductList != null)
                    {
                        return this.GenerateResponse(true, HttpStatusCode.OK, ProductList);
                    }
                    else
                    {
                        return this.GenerateResponse(false, HttpStatusCode.NotFound, Constants.DATANOTFOUND);
                    }
                }
            }
            catch (Exception ex)
            {
                return this.GenerateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
