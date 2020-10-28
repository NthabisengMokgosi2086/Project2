using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project2.Data;
using Project2.Models;

namespace Project2.Controllers
{
    public class Sheet1Controller : Controller
    {
        private readonly Pro2_dbContext _context;

        public Sheet1Controller(Pro2_dbContext context)
        {
            _context = context;
        }

        // GET: Sheet1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sheet1.ToListAsync());
        }

        // GET: Sheet1/Details/5
        public async Task<IActionResult> Details(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sheet1 = await _context.Sheet1
                .FirstOrDefaultAsync(m => m.EmployeeNumber == id);
            if (sheet1 == null)
            {
                return NotFound();
            }

            return View(sheet1);
        }

        // GET: Sheet1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sheet1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Age,Attrition,BusinessTravel,DailyRate,Department,DistanceFromHome,Education,EducationField,EmployeeCount,EmployeeNumber,EnvironmentSatisfaction,Gender,HourlyRate,JobInvolvement,JobLevel,JobRole,JobSatisfaction,MaritalStatus,MonthlyIncome,MonthlyRate,NumCompaniesWorked,Over18,OverTime,PercentSalaryHike,PerformanceRating,RelationshipSatisfaction,StandardHours,StockOptionLevel,TotalWorkingYears,TrainingTimesLastYear,WorkLifeBalance,YearsAtCompany,YearsInCurrentRole,YearsSinceLastPromotion,YearsWithCurrManager")] Sheet1 sheet1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sheet1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sheet1);
        }

        // GET: Sheet1/Edit/5
        public async Task<IActionResult> Edit(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sheet1 = await _context.Sheet1.FindAsync(id);
            if (sheet1 == null)
            {
                return NotFound();
            }
            return View(sheet1);
        }

        // POST: Sheet1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(double? id, [Bind("Age,Attrition,BusinessTravel,DailyRate,Department,DistanceFromHome,Education,EducationField,EmployeeCount,EmployeeNumber,EnvironmentSatisfaction,Gender,HourlyRate,JobInvolvement,JobLevel,JobRole,JobSatisfaction,MaritalStatus,MonthlyIncome,MonthlyRate,NumCompaniesWorked,Over18,OverTime,PercentSalaryHike,PerformanceRating,RelationshipSatisfaction,StandardHours,StockOptionLevel,TotalWorkingYears,TrainingTimesLastYear,WorkLifeBalance,YearsAtCompany,YearsInCurrentRole,YearsSinceLastPromotion,YearsWithCurrManager")] Sheet1 sheet1)
        {
            if (id != sheet1.EmployeeNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sheet1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Sheet1Exists(sheet1.EmployeeNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sheet1);
        }

        // GET: Sheet1/Delete/5
        public async Task<IActionResult> Delete(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sheet1 = await _context.Sheet1
                .FirstOrDefaultAsync(m => m.EmployeeNumber == id);
            if (sheet1 == null)
            {
                return NotFound();
            }

            return View(sheet1);
        }

        // POST: Sheet1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(double? id)
        {
            var sheet1 = await _context.Sheet1.FindAsync(id);
            _context.Sheet1.Remove(sheet1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Sheet1Exists(double? id)
        {
            return _context.Sheet1.Any(e => e.EmployeeNumber == id);
        }
    }
}
