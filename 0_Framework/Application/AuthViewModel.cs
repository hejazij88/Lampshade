﻿using System;
using System.Collections.Generic;

namespace _0_Framework.Application
{
    public class AuthViewModel
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public string Role { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Mobile { get; set; }
        public List<int> Permissions { get; set; }

        public AuthViewModel()
        {
        }

        public AuthViewModel(Guid id, Guid roleId, string fullname, string username, string mobile,
            List<int> permissions)
        {
            Id = id;
            RoleId = roleId;
            Fullname = fullname;
            Username = username;
            Mobile = mobile;
            Permissions = permissions;
        }
    }
}