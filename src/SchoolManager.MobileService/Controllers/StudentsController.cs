﻿using Microsoft.WindowsAzure.Mobile.Service;
using SchoolManager.MobileService.DataObjects;
using SchoolManager.MobileService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;

namespace SchoolManager.MobileService.Controllers
{
    public class StudentsController : TableController<Student>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Student>(context, Request, Services);
        }

        public IQueryable<Student> GetAllStudents()
        {
            return Query();
        }

        public SingleResult<Student> GetStudent(string id)
        {
            return Lookup(id);
        }
    }
}