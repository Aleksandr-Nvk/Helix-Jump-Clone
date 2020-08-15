namespace Oduvaanchikk.HelixJumpClone.Runtime
{
    public class PieceCreator
    {
        private LevelSettings _levelSettings;
        
        public PieceCreator(LevelSettings levelSettings)
        {
            _levelSettings = levelSettings;
        }

        public PieceModel Create(PieceType pieceType)
        {
            var piece = new PieceModel(pieceType);
            return piece;
        }

        public PieceModel CreateRandom()
        {
            return null;
        }
    }
}