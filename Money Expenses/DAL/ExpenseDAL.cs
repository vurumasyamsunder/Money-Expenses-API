using Money_Expenses.DTOs;
using Money_Expenses.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Money_Expenses.DAL
{
    public class ExpenseDAL : IExpense
    {
        public List<incomeDTO> GetIncome(string connectionString)
        {
            List<incomeDTO> expenses = new List<incomeDTO>();

            string query = "SELECT fn_income_crud('{\"action\":\"SELECT\"}')";

            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();

                using (var cmd = new NpgsqlCommand(query, con))
                {
                    var result = cmd.ExecuteScalar();

                    if (result != null && result.ToString() != "null")
                    {
                        expenses = JsonSerializer.Deserialize<List<incomeDTO>>(
                            result.ToString(),
                            new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true
                            });
                    }
                }
            }

            return expenses;
        }


        public List<incomeDTO> GetExpenses(string connectionString)
        {
            List<incomeDTO> expenses = new List<incomeDTO>();

            string query = "SELECT fn_expense_crud('{\"action\":\"SELECT\"}')";

            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();

                using (var cmd = new NpgsqlCommand(query, con))
                {
                    var result = cmd.ExecuteScalar();

                    if (result != null && result.ToString() != "null")
                    {
                        expenses = JsonSerializer.Deserialize<List<incomeDTO>>(
                            result.ToString(),
                            new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true
                            });
                    }
                }
            }

            return expenses;
        }


        public bool saveIncome(string connectionString, CreateIncomeDTO _CreateIncome)
        {
            bool isSave = false;

            string json = JsonSerializer.Serialize(new
            {
                action = "INSERT",
                source = _CreateIncome.source,
                amount = _CreateIncome.amount,
                income_date = _CreateIncome.income_date
            });

            string query = "SELECT fn_income_crud(@data)";

            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();

                using (var cmd = new NpgsqlCommand(query, con))
                {
                    //cmd.Parameters.AddWithValue("@data", json);
                    cmd.Parameters.AddWithValue("@data", NpgsqlTypes.NpgsqlDbType.Json, json);


                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        isSave = true;
                    }
                }
            }

            return isSave;
        }
    }
}