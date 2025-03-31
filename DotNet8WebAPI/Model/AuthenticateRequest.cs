﻿using System.ComponentModel;

namespace DotNet8WebAPI.Model
{
    public class AuthenticateRequest
    {
        [DefaultValue("System")]
        public required string Username { get; set; }
        [DefaultValue("System")]
        public required string Password { get; set; }
    }
}
