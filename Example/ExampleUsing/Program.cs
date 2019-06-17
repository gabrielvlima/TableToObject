using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TableToObject.Mapping;

namespace ExampleUsing
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Definition Tables
            DataTable UsersT1 = new DataTable();
            UsersT1.Columns.Add(InsertColumn("Id", typeof(Int32)));
            UsersT1.Columns.Add(InsertColumn("Login", typeof(string)));
            UsersT1.Columns.Add(InsertColumn("Pass", typeof(string)));
            UsersT1.Columns.Add(InsertColumn("Date", typeof(DateTime)));

            DataTable UsersT2 = new DataTable();
            UsersT2.Columns.Add(InsertColumn("IdUser", typeof(Int32)));
            UsersT2.Columns.Add(InsertColumn("Login", typeof(string)));
            UsersT2.Columns.Add(InsertColumn("Pass", typeof(string)));
            UsersT2.Columns.Add(InsertColumn("Datetime", typeof(DateTime)));

            DataTable UsersT3 = new DataTable();
            UsersT3.Columns.Add(InsertColumn("nUser", typeof(Int32)));
            UsersT3.Columns.Add(InsertColumn("sLogin", typeof(string)));
            UsersT3.Columns.Add(InsertColumn("sPass", typeof(string)));
            UsersT3.Columns.Add(InsertColumn("dDate", typeof(DateTime)));
            #endregion Definition Tables

            #region Populate Tables
            UsersT1.Rows.Add(5, "Gabriel", "Gabriel", DateTime.Parse("2019-05-04"));
            UsersT1.Rows.Add(4, "Mirella", "Liv3Music", DateTime.Parse("2018-11-04"));
            UsersT2.Rows.Add(3, "Luzia", "AllBeRight", DateTime.Parse("2015-06-14"));
            UsersT2.Rows.Add(2, "Pedro", "fullBottle", DateTime.Parse("2015-01-20"));
            UsersT3.Rows.Add(1, "HBO", "GOT", DateTime.Parse("2011-02-21"));
            #endregion

            // Creating Map
            var mapUser = new DataNamesMapper<User>();

            // Creating List Object
            var Users = new List<User>();

            // Insert TableRows to List Object
            Users.AddRange(mapUser.Map(UsersT1));
            Users.AddRange(mapUser.Map(UsersT2));
            Users.AddRange(mapUser.Map(UsersT3));

            // Writing in Console
            foreach (var user in Users.OrderBy(c => c.Id))
                Console.WriteLine($"Id:{user.Id} - Login:{user.UserName} - Password:{user.Password} - Register:{user.RegisterDate}");
            
            Console.ReadKey();
        }

        static DataColumn InsertColumn(string name, Type type)
        {
            DataColumn column = new DataColumn(name);
            column.DataType = type;
            return column;
        }
    }
}
