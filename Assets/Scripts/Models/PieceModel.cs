namespace Models
{
    public class PieceModel
    {
        private readonly PieceType _type;
        
        public PieceType Type => _type;

        public bool IsFriendly => _type == PieceType.Friendly;

        public PieceModel(PieceType type)
        {
            _type = type;
        }
    }
}