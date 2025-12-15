using AppProps;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class UserBLL
    {
        public bool InsertUserBLL(User U)
        {
            return new UserDAL().InsertUserDAL(U);
        }
        public bool UpdateUserBLL(User U)
        {
            return new UserDAL().UpdateUserDAL(U);
        }
        public bool DeleteUserBLL(User U)
        {
            return new UserDAL().DeleteUserDAL(U);
        }
        public DataTable GetUsersBLL()
        {
            return new UserDAL().GetUsersDAL();

        }
        public DataTable GetUserBLL(User U)
        {
            return new UserDAL().GetUserDAL(U);

        }
    }
}
