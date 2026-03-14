
using Money_Expenses.DTOs;
using Money_Expenses.Controllers;
using Money_Expenses.DAL;
using System.Globalization;


namespace Money_Expenses.Interfaces
{
    public interface IExpense
    {

        List<incomeDTO> GetIncome(string _connectionString);

        List<incomeDTO> GetExpenses(string _connectionString);
        bool saveIncome(string _connectionString, CreateIncomeDTO _CreateIncome);


    }
}
