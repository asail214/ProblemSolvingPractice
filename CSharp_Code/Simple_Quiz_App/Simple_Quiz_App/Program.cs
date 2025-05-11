// Assignment 2: Simple Quiz App
namespace Simple_Quiz_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] questions = {
                "What is 12 + 3?",
                "What is 5 * 4?",
                "What is 18 - 6?",
                "What is 7 + 8?",
                "What is 20 / 4?"
            };

            string[] options1 = { "A. 6", "B. 15", "C. 10", "D. 12" };
            string[] options2 = { "A. 8", "B. 20", "C. 12", "D. 14" };
            string[] options3 = { "A. 9", "B. 15", "C. 12", "D. 18" };
            string[] options4 = { "A. 8", "B. 15", "C. 12", "D. 14" };
            string[] options5 = { "A. 5", "B. 7", "C. 8", "D. 10" };

            string[] correctAnswers = { "B", "B", "C", "B", "A" };

            int score = 0;

            Console.WriteLine("Assignment2: Simple Math Quiz!");
            Console.WriteLine("------------------------------");

            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine($"\nQuestion {i + 1}: {questions[i]}");

                switch (i)
                {
                    case 0:
                        foreach (string option in options1)
                        {
                            Console.WriteLine(option);
                        }
                        break;
                    case 1:
                        foreach (string option in options2)
                        {
                            Console.WriteLine(option);
                        }
                        break;
                    case 2:
                        foreach (string option in options3)
                        {
                            Console.WriteLine(option);
                        }
                        break;
                    case 3:
                        foreach (string option in options4)
                        {
                            Console.WriteLine(option);
                        }
                        break;
                    case 4:
                        foreach (string option in options5)
                        {
                            Console.WriteLine(option);
                        }
                        break;
                }

                Console.Write("Your answer: ");
                string userAnswer = Console.ReadLine().ToUpper();

                if (userAnswer == correctAnswers[i])
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Wrong! The answer is: {correctAnswers[i]}");
                }
            }

            Console.WriteLine("\n-------------------------------");
            Console.WriteLine($"End of quiz! \n Your score is: {score}/5");

            switch (score)
            {
                case 5:
                    Console.WriteLine("Excellent!");
                    break;
                case 4:
                case 3:
                    Console.WriteLine("Good!");
                    break;
                default:
                    Console.WriteLine("Try Again");
                    break;
            }
        }
    }
}