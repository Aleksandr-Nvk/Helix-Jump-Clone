using System;

namespace Oduvaanchikk.HelixJumpClone.Runtime
{
    [Serializable]
    public class PieceTypeToProbabilityPair : BasePair<float, PieceType>
    {
        public PieceTypeToProbabilityPair(float key, PieceType value) : base(key, value)
        { }
    }
}