namespace BowlingApp;

public static class ConsoleBowlingGame
{
    public static void PrintScore(this BowlingGame bowlingGame)
    {
        var frameNumber = 1;
        foreach (var frame in bowlingGame.Frames)
        {
            Console.WriteLine($"Frame {frameNumber}: {frame.FirstRoll} {frame.SecondRoll} {frame.TotalScore}");
            frameNumber++;
        }
    }

    public static void PrintScoreBoard(this BowlingGame bowlingGame)
    {
        Console.WriteLine("Scoreboard");
        Console.WriteLine("##########################################################################################");
        for(int i = 0; i < 10; i++)
        {
            var frame = bowlingGame.Frames.ElementAtOrDefault(i);
            Console.Write(GetFrameString(frame));
        }

        var firstBonusRoll = bowlingGame.BonusRolls.ElementAtOrDefault(0);
        var secondBonusRoll = bowlingGame.BonusRolls.ElementAtOrDefault(1);

        Console.Write($"|| {firstBonusRoll} | {secondBonusRoll} ");
        Console.WriteLine("#");
        Console.WriteLine("##########################################################################################");
    }

    private static string GetFrameString(Frame? frame)
    {
        if (frame is null)
        {
            return "#   |   ";
        }

        var firstRoll = frame.IsStrike ? "X" : frame.FirstRoll.ToString();
        var secondRoll = frame.IsSpare ? "/" : frame.SecondRoll.ToString();
        
        return $"# {firstRoll} | {secondRoll} ";
    }
}
