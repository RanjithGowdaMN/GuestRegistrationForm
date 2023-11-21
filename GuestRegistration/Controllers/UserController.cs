﻿using GuestDataManager.Library.DataAccess;
using GuestDataManager.Library.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuestRegistration.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public UserModel GetById()
        {
            string userId = RequestContext.Principal.Identity.GetUserId();
            UserData data = new UserData();

            return data.GetUserById(userId).First();

        }
        [HttpGet]
        public List<CompanyNameList> GetCompanyNames()
        {
            RetriveCompanyName retriveCompanyName = new RetriveCompanyName();

            return retriveCompanyName.GetCompanyname();
        }
    }
}
