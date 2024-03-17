namespace BowlingApp;

public class Frame
{
    public int TotalScore { get; set; }
    public bool IsComplete { get; private set; }
    public bool IsStrike { get; private set; }
    public bool IsSpare { get; private set; }
    public int FirstRoll { get; private set; }
    public int SecondRoll { get; private set; }
    public int BonusRolls { get; set; }

    private int remainingPins;
    private int roll;

    public Frame() : this(10)
    {

    }

    public Frame(int pins)
    {
        remainingPins = pins;
        roll = 0;
    }

    public void Roll(int pins)
    {
        pins = Math.Min(pins, remainingPins);

        TotalScore += pins;
        remainingPins -= pins;

        if (roll == 0)
        {
            FirstRoll = pins;

            if (remainingPins == 0)
            {
                IsStrike = true;
                IsComplete = true;
            }
        }
        else
        {
            SecondRoll = pins;
            IsSpare = remainingPins == 0;
            IsComplete = true;
        }

        BonusRolls = IsStrike ? 2 : IsSpare ? 1 : 0;

        roll++;
    }
}
