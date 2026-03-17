using Money_Expenses.DTOs;
using Money_Expenses.DAL;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using Money_Expenses.Interfaces;

namespace Money_Expenses.Interfaces
{
    public interface IUser
    {
        internal List<userRightsDTO> GetUserRights(string connectionString)
        {
            throw new NotImplementedException();
        }

        List<userRightsDTO> GetUserRights(string con, int userId);



    }
}
