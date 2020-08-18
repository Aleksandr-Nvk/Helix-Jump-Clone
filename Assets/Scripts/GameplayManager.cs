using Tools;

public class GameplayManager
{
    private readonly LevelBuilder _levelBuilder;

    public GameplayManager(LevelBuilder levelBuilder)
    {
        _levelBuilder = levelBuilder;
    }

    public void Start()
    {
        _levelBuilder.Build(); // building a level
    }
}