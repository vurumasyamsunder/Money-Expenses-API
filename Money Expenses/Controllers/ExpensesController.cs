using Microsoft.AspNetCore.Mvc;
using Money_Expenses.DAL;
using Money_Expenses.DTOs;
using Money_Expenses.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly string _connectionString;

    public ExpensesController(IConfiguration config)
    {
        _config = config;
        _connectionString = _config.GetConnectionString("DefaultConnection");
    }

    [HttpGet("GetIncome")]
    public IActionResult GetIncome()
    {
        ExpenseDAL expense = new ExpenseDAL();

        var result = expense.GetIncome(_connectionString);

        return Ok(result);
    }


    [HttpGet("GetExpenses")]
    public IActionResult GetExpenses()
    {
        ExpenseDAL expense = new ExpenseDAL();

        var result = expense.GetExpenses(_connectionString);

        return Ok(result);
    }

    [HttpPost("saveIncome")]
    public IActionResult SaveIncome(CreateIncomeDTO _CreateIncome)
    {

        ExpenseDAL expense = new ExpenseDAL();
        var result = expense.saveIncome(_connectionString, _CreateIncome);

        if (result)
            return Ok("Income Saved Successfully");

        return BadRequest("Insert Failed");
    }





}