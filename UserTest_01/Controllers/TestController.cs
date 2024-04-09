using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using UserTest_01.Data;
using UserTest_01.Model;

namespace UserTest_01.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TestController(ApplicationDbContext context)
        {
                _context= context;
        }


        private static List<Test> _testQuestions = new List<Test>
{
    new Test
    {
        Id = 1,
        Question = "What does HTML stand for?",
        Options = "Hyper Text Markup Language,Hyperlinks and Text Markup Language,Home Tool Markup Language,Hyperlinking Text Markup Language",
        CorrectOption = "Hyper Text Markup Language",
        Category = TestCategory.IT
    },
    new Test
    {
        Id = 2,
        Question = "What is the default port for HTTP?",
        Options = "80,8080,443,23",
        CorrectOption = "80",
        Category = TestCategory.IT
    },
    new Test
    {
        Id = 3,
        Question = "What does CSS stand for?",
        Options = "Cascading Style Sheets,Computer Style Sheets,Colorful Style Sheets,Creative Style Sheets",
        CorrectOption = "Cascading Style Sheets",
        Category = TestCategory.IT
    },
    new Test
    {
        Id = 4,
        Question = "Who is known as the father of computers?",
        Options = "Charles Babbage,Alan Turing,Ada Lovelace,Steve Jobs",
        CorrectOption = "Charles Babbage",
        Category = TestCategory.IT
    },
    new Test
    {
        Id = 5,
        Question = "What is the full form of RAM?",
        Options = "Random Access Memory,Read Access Memory,Randomized Access Memory,Rapid Access Memory",
        CorrectOption = "Random Access Memory",
        Category = TestCategory.IT
    },
    new Test
    {
        Id = 6,
        Question = "What is the most commonly used programming language for web development?",
        Options = "JavaScript,Python,Java,C#",
        CorrectOption = "JavaScript",
        Category = TestCategory.IT
    },
    new Test
    {
        Id = 7,
        Question = "What is the capital of France?",
        Options = "Paris,Berlin,London,Rome",
        CorrectOption = "Paris",
        Category = TestCategory.General
    },
    new Test
    {
        Id = 8,
        Question = "Who wrote 'To Kill a Mockingbird'?",
        Options = "Harper Lee,John Steinbeck,Mark Twain,F. Scott Fitzgerald",
        CorrectOption = "Harper Lee",
        Category = TestCategory.General
    },
    new Test
    {
        Id = 9,
        Question = "What is the currency of Japan?",
        Options = "Yen,Dollar,Pound,Euro",
        CorrectOption = "Yen",
        Category = TestCategory.General
    },
    new Test
    {
        Id = 10,
        Question = "Who is known as the 'Father of Modern Physics'?",
        Options = "Albert Einstein,Nikola Tesla,Isaac Newton,Stephen Hawking",
        CorrectOption = "Albert Einstein",
        Category = TestCategory.General
    },
    new Test
    {
        Id = 11,
        Question = "Who discovered Penicillin?",
        Options = "Alexander Fleming,Louis Pasteur,Marie Curie,Jonas Salk",
        CorrectOption = "Alexander Fleming",
        Category = TestCategory.General
    },
    new Test
    {
        Id = 12,
        Question = "What is the chemical symbol for water?",
        Options = "H2O,CO2,NaCl,O2",
        CorrectOption = "H2O",
        Category = TestCategory.General
    },
    new Test
    {
        Id = 13,
        Question = "Who proposed the theory of relativity?",
        Options = "Albert Einstein,Isaac Newton,Nikola Tesla,Stephen Hawking",
        CorrectOption = "Albert Einstein",
        Category = TestCategory.Science
    },
    new Test
    {
        Id = 14,
        Question = "What is the smallest bone in the human body?",
        Options = "Stapes,Patella,Femur,Radius",
        CorrectOption = "Stapes",
        Category = TestCategory.Science
    },
    new Test
    {
        Id = 15,
        Question = "Which gas is most abundant in Earth's atmosphere?",
        Options = "Nitrogen,Oxygen,Carbon dioxide,Argon",
        CorrectOption = "Nitrogen",
        Category = TestCategory.Science
    },
    new Test
    {
        Id = 16,
        Question = "When did World War I end?",
        Options = "1918,1945,1939,1914",
        CorrectOption = "1918",
        Category = TestCategory.History
    },
    new Test
    {
        Id = 17,
        Question = "Who was the first President of the United States?",
        Options = "George Washington,Thomas Jefferson,Abraham Lincoln,John Adams",
        CorrectOption = "George Washington",
        Category = TestCategory.History
    },
    new Test
    {
        Id = 18,
        Question = "Which civilization built the Machu Picchu citadel?",
        Options = "Inca,Aztec,Maya,Egyptian",
        CorrectOption = "Inca",
        Category = TestCategory.History
    },
    new Test
    {
        Id = 19,
        Question = "Who was the first female Prime Minister of the United Kingdom?",
        Options = "Margaret Thatcher,Theresa May,Angela Merkel,Indira Gandhi",
        CorrectOption = "Margaret Thatcher",
        Category = TestCategory.History
    },
    new Test
    {
        Id = 20,
        Question = "Who invented the light bulb?",
        Options = "Thomas Edison,Nikola Tesla,Albert Einstein,Alexander Graham Bell",
        CorrectOption = "Thomas Edison",
        Category = TestCategory.History
    },
    new Test
    {
        Id = 21,
        Question = "Who painted the Mona Lisa?",
        Options = "Leonardo da Vinci,Vincent van Gogh,Pablo Picasso,Michelangelo",
        CorrectOption = "Leonardo da Vinci",
        Category = TestCategory.History
    }
};

        [HttpGet("General")]
        public IActionResult GetGeneralTestQuestions()
        {
            return GetTestQuestionsByCategory(TestCategory.General);
        }

        [HttpGet("Science")]
        public IActionResult GetScienceTestQuestions()
        {
            return GetTestQuestionsByCategory(TestCategory.Science);
        }

        [HttpGet("History")]
        public IActionResult GetHistoryTestQuestions()
        {
            return GetTestQuestionsByCategory(TestCategory.History);
        }

        [HttpGet("IT")]
        public IActionResult GetITTestQuestions()
        {
            return GetTestQuestionsByCategory(TestCategory.IT);
        }


        [HttpGet("{category}")]
        private IActionResult GetTestQuestionsByCategory(TestCategory category)
        {
            try
            {
                var questionsByCategory = _testQuestions.Where(q => q.Category == category).ToList();
                return Ok(questionsByCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetTestQuestions()
        {
            return Ok(_testQuestions);
        }

        [HttpPost("submit")]
        public IActionResult SubmitTest([FromBody] Dictionary<int, string> answers)
        {
            try
            {
                var score = CalculateScore(answers);

                
                var totalQuestions = _testQuestions.Count(q => answers.ContainsKey(q.Id));

                string resultMessage = (score >= 4) ? "Congratulations! You passed the test." :
                    "Sorry, you failed the test. Please try again later.";

                return Ok($"{resultMessage} Your score: {score}/{totalQuestions}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        private int CalculateScore(Dictionary<int, string> answers)
        {
            int score = 0;
            foreach (var kvp in answers)
            {
                var question = _testQuestions.FirstOrDefault(q => q.Id == kvp.Key);
                if (question != null && question.CorrectOption == kvp.Value)
                {
                    score++;
                }
            }
            return score;
        }

        [HttpPost("selectedcategory")]
        public IActionResult PostSelectedCategory([FromBody] string category)
        {
            try
            {
                if (string.IsNullOrEmpty(category))
                {
                    return BadRequest("Category cannot be empty");
                }

                var selectedCategory = new Test
                {
                    CategoryName = category
                };

                _context.Tests.Add(selectedCategory);
                _context.SaveChanges();

                return Ok("Selected category stored successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
