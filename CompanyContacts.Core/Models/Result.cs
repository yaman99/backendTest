using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyContacts.Core.Models
{
    public class Result
    {
        internal Result(bool Successed, string Msg)
        {
            IsSuccessed = Successed;
            Message = Msg;
        }
        public bool IsSuccessed { get; set; }
        public string Message { get; set; }

        public static Result Success(string msg)
        {
            return new Result(true, msg);
        }
        public static Result Failure(string msg)
        {
            return new Result(false, msg);
        }
    }
}
