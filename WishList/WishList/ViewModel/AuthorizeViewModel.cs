using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WishList.Controllers.Authorization.Model;

namespace WishList.ViewModel
{
    public class AuthorizeViewModel
    {
        public LoginModel Login { get; set; }
        public RegisterModel Register { get; set; }
    }
}