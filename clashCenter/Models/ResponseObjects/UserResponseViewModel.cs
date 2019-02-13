﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clashCenter.Models.ResponseObjects
{
    public class UserResponseViewModel
    {
        public UserResponseViewModel()
        {

        }
        public UserResponseViewModel(bool error, string errors, string message)
        {
            Error = error;
            Errors = Errors;
            Message = message;
        }
        public bool Error { get; set; }
        public string Errors { get; set; }
        public string Message { get; set; }
    }
}