using System.Collections.Generic;
using UnityEngine;

namespace Oduvaanchikk.HelixJumpClone.Runtime
{
    public class FromPieceTypeToPrefab : Dictionary<PiecePrefabType, GameObject>
    { }
    
    public class FromPieceTypeToProbability : Dictionary<float, PieceType>
    { }
}