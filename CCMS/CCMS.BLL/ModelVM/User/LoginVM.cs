﻿namespace CCMS.BLL.ModelVM.User
{
    public class LoginVM
    {
        public string EmailOrUserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
