namespace Oduvaanchikk.HelixJumpClone.Runtime
{
    public class GameplayManager
    {
        private readonly GameplaySettings _settings;
        private readonly LevelBuilder _levelBuilder;

        public GameplayManager(GameplaySettings settings, LevelBuilder levelBuilder)
        {
            _settings = settings;
            _levelBuilder = levelBuilder;
        }

        public void Start()
        {
            _levelBuilder.Build(); // building a level
        }
    }
}