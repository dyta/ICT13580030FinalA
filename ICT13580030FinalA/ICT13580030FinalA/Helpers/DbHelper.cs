using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT13580030FinalA.Models;

namespace ICT13580030FinalA.Helpers
{
    public class DbHelper
    {
        SQLiteConnection db;

        public DbHelper(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Employee>();
        }

        public int AddEmployee(Employee employee)
        {
            return db.Insert(employee);
        }

        public List<Employee> GetEmployees()
        {
            return db.Table<Employee>().ToList();
        }

        public int UpdateEmployee(Employee employee)
        {
            return db.Update(employee);
        }

        public int DeleteEmployee(Employee employee)
        {
            return db.Delete(employee);
        }
    }
    
}