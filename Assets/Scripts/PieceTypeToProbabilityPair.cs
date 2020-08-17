using System;

namespace Oduvaanchikk.HelixJumpClone.Runtime
{
    [Serializable]
    public class PieceTypeToProbabilityPair : BasePair<PieceType, float>
    {
        public PieceTypeToProbabilityPair(PieceType key, float value) : base(key, value)
        {
        }
    }
}