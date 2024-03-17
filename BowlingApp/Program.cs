using BowlingApp;

Console.WriteLine("Welcome to the Bowling Game!");

play();

void play()
{
    var bowlingGame = new BowlingGame();
    Console.WriteLine("Enter 'm' for manual mode or 'a' for automatic");
    var arg = Console.ReadLine();

    if (arg == "m")
    {
        Console.WriteLine("Manual mode selected");
        Console.WriteLine("Enter the number of pins knocked down for each roll");
        Console.WriteLine("Enter 'q' to quit");
        while (!bowlingGame.IsComplete)
        {
            //Clear the console
            Console.Clear();
            Console.WriteLine("Enter 'q' to quit");
            bowlingGame.PrintScoreBoard();
            Console.WriteLine($"Total score: {bowlingGame.CalculateScore()}");
            Console.WriteLine("Enter the number of pins knocked down");
            var input = Console.ReadLine();
            if (input == "q")
            {
                break;
            }

            if (int.TryParse(input, out var pins))
            {
                bowlingGame.Roll(pins);
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
    else if (arg == "a")
    {
        Console.Clear();
        Console.WriteLine("Automatic mode selected");
        while (!bowlingGame.IsComplete)
        {
            bowlingGame.Roll();
        }

        bowlingGame.PrintScoreBoard();
        Console.WriteLine($"Total score: {bowlingGame.CalculateScore()}");
    }
    else
    {
        Console.WriteLine("Invalid input");
    }

    Console.Clear();
    Console.WriteLine("Game over!");
    bowlingGame.PrintScoreBoard();
    Console.WriteLine($"Total score: {bowlingGame.CalculateScore()}");
    Console.WriteLine("Do you want to play again? (y/n)");
    var playAgain = Console.ReadLine();
    if (playAgain == "y")
    {
        play();
    }
    else
    {
        Console.WriteLine("Goodbye!");
    }
}





