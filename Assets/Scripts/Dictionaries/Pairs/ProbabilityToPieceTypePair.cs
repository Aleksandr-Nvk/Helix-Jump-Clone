using System;

namespace Dictionaries.Pairs
{
    [Serializable]
    public class ProbabilityToPieceTypePair : BasePair<float, PieceType>
    {
        public ProbabilityToPieceTypePair(float key, PieceType value) : base(key, value)
        { }
    }
}