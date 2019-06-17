using System;
using TableToObject;
using TableToObject.Attributes;

namespace ExampleUsing
{
    public class User
    {
        [DataNames("Id","IdUser", "nUser")]
        public int Id { get; set; }

        [DataNames("Login", "sLogin")]
        public string UserName { get; set; }

        [DataNames("Pass", "sPass")]
        public string Password { get; set; }

        [DataNames("Date", "Datetime", "dDate")]
        public DateTime RegisterDate { get; set; }
    }
}
