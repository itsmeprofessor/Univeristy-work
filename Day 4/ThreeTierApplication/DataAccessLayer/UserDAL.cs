using AppProps;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserDAL
    {
        public bool InsertUserDAL(User U)
        {
            return new DbCon().UDI("INSERT INTO Users (Name,Email,Address) VALUES ('" + U.Name + "','" + U.Email + "','" + U.Address + "')");

        }
        public bool UpdateUserDAL(User U) {
            return new DbCon().UDI("UPDATE Users SET Name = '" + U.Name + "',Email='" + U.Email + "',Address='"+U.Address + "'WHERE Id = '" + U.Id + "'");
        }
        public bool DeleteUserDAL(User U)
        {
            return new DbCon().UDI("DELETE Users WHERE Id = '" + U.Id + "'");
        }
        public DataTable GetUsersDAL() {
            return new DbCon().Search("SELECT * FROM Users");
        }
        public DataTable GetUserDAL(User U)
        {
            return new DbCon().Search("SELECT * FROM Users WHERE Id = '"+U.Id+"'");
        }


    }

}
