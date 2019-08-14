using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteXamarinDemo
{
    public interface IDatabaseConnection
    {
        SQLite.SQLiteConnection DbConnection();
    }
}
