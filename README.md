# BowlingApp

## How to run:

```
git clone https://github.com/MaltheG/BowlingApp.git
cd BowlingApp
dotnet run --project BowlingApp
```

## Design Choices
The core bowling logic is handled by two classes: Frame and BowlingApp. Frame handles everything to do with a bowlingframe. It focuses on keeping track of how many pins are left in the frame, score, strikes, and spares. BowlingApp has the broader overview. It exists as one instance per bowlinggame and handles the interaction between frames such as score rollups and adding new frames when old ones are completed, as well as keeping track of when the game is completed. We split the logic into these two classes to properly delegate responsibility and reduce frame logic in BowlingApp. E.g. BowlingApp does not need to check whether a roll results in a strike or spare, it just needs to know whether the frame is done or not. 

In order to print the scoreboard to console, we make use of an extension class, ConsoleBowlingGame. This is done as to make a clear distinction between what is the logic of the bowlinggame and what counts as the "visual" element to the user. Methods in ConsoleBowlingGame are not needed for the bowlinggame logic, and could be removed or replaced e.g. if a visual interface was to be implemented instead.

If a player gets a strike or a spare in the 10th frame, the bonus rolls are kept track of by the BowlingApp and not a frame, as these rolls are not the same as frames. They only count towards the bonus.

We make us of escape early principles to avoid nesting, where possible, and improve readability.