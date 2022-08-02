using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class RequestInfo
    {
        public tbl_WebsiteUsers customers { get; set; }
        public tbl_CreditCardRequests requestors { get; set; }
    }
}