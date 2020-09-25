namespace Models
{
    public class Piece
    {
        private readonly PieceType _type;
        
        public PieceType Type => _type;

        public bool IsFriendly => _type == PieceType.Friendly;

        public Piece(PieceType type)
        {
            _type = type;
        }
    }
}