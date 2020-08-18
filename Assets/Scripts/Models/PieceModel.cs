namespace Models
{
    public class PieceModel
    {
        private PiecePrefabType _type;

        private bool _isFriendly;
        private bool _isFlying;

        public PiecePrefabType Type => _type;
        
        public bool IsFriendly => _isFriendly;
        public bool IsFlying => _isFlying;

        public PieceModel(PieceType type)
        {
            switch (type) // configurations for each piece type
            {
                case PieceType.Friendly:
                    _isFriendly = true;
                    _type = PiecePrefabType.FriendlyPrefab;
                    break;
                
                case PieceType.Enemy:
                    _type = PiecePrefabType.EnemyPrefab;
                    break;
                
                case PieceType.Flying:
                    _isFriendly = true;
                    _isFlying = true;
                    _type = PiecePrefabType.FlyingPrefab;
                    break;
                
                case PieceType.Empty:
                    _isFriendly = true;
                    _type = PiecePrefabType.EmptyPrefab;
                    break;
            }
        }
    }
}