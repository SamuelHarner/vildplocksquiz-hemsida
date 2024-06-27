using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using VildplocksquizHemsida.Data;
using VildplocksquizHemsida.Models;
using Microsoft.EntityFrameworkCore;

namespace VildplocksquizHemsida.Controllers
{
    public class QuizController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuizController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var question = await GetRandomQuestionAsync();
            if (question == null)
            {
                ViewBag.NoQuestions = true;
                return View();
            }
            ViewBag.Result = null;
            return View(question);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitAnswer(int id, string answer)
        {
            var question = await _context.QuizQuestions.FindAsync(id);
            if (question != null && question.Answer.ToLower() == answer.ToLower())
            {
                ViewBag.Result = "Korrekt!";
            }
            else
            {
                ViewBag.Result = $"Fel. Svaret var: {question.Answer}";
            }

            return View("Index", question);
        }

        [HttpPost]
        public async Task<IActionResult> NextQuestion()
        {
            var nextQuestion = await GetRandomQuestionAsync();
            if (nextQuestion == null)
            {
                ViewBag.NoQuestions = true;
                return View("Index");
            }
            ViewBag.Result = null;
            return View("Index", nextQuestion);
        }

        private async Task<QuizQuestion> GetRandomQuestionAsync()
        {
            int count = await _context.QuizQuestions.CountAsync();
            if (count == 0)
            {
                return null; // Handle no questions in the database case
            }

            var random = new Random();
            int index = random.Next(count);
            return await _context.QuizQuestions.Skip(index).FirstOrDefaultAsync();
        }
    }
}
