﻿namespace LMSServices.Models
{
    public class UserRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
    }
}