﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_C_
{
    internal class dbconnection
    {
        public string dbconnect()
        {
            string conn = "server=localhost;user=root;password=;database=db_crud";
                return conn;
        }
    }
}
