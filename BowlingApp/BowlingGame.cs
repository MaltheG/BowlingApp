namespace BowlingApp;

public class BowlingGame
{
    public readonly List<Frame> Frames;
    public bool IsComplete { get; private set; }
    public List<int> BonusRolls { get; private set; }

    private int numberOfBonusRolls;

    public BowlingGame()
    {
        Frames = [new Frame()];
        BonusRolls = new List<int>();
    }

    public void Roll(int pins)
    {
        if (IsComplete)
        {
            throw new InvalidOperationException("Game is complete");
        }

        RollUpScore(pins);

        if (numberOfBonusRolls > 0)
        {
            numberOfBonusRolls--;

            pins = BonusRolls.FirstOrDefault() == 10 ? pins : Math.Min(pins, 10 - BonusRolls.Sum());

            BonusRolls.Add(pins);

            IsComplete = numberOfBonusRolls == 0;
            return;
        }

        Frames.Last().Roll(pins);

        if (!Frames.Last().IsComplete)
        {
            return;
        }

        if (Frames.Count == 10)
        {
            numberOfBonusRolls = Frames.Last().BonusRolls;
            IsComplete = numberOfBonusRolls == 0;
            return;
        }

        Frames.Add(new Frame());
    }

    public void Roll()
    {
        var pins = new Random().Next(0, 11);
        Roll(pins);
    }

    public int CalculateScore() => Frames.Sum(f => f.TotalScore);

    private void RollUpScore(int pins)
    {
        //We technically only need to look at the last two frames, but this is easier to read
        //and we're not going to be dealing with a large number of frames
        foreach (var frame in Frames)
        {
            if (frame.BonusRolls > 0)
            {
                frame.TotalScore += pins;
                frame.BonusRolls--;
            }
        }
    }    
}
