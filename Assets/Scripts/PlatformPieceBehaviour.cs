using UnityEngine;

namespace Oduvaanchikk.HelixJumpClone.Runtime
{
    public class PlatformPieceBehaviour : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] private MeshRenderer currentMeshRenderer;
#pragma warning restore

        private PlatformPieceType _type;

        private GameplaySettings _gameplaySettings;

        private void Awake()
        {
            _gameplaySettings = FindObjectOfType<GameplaySettings>();

            var currentNegativeCase = Random.value;
            _type = currentNegativeCase <= _gameplaySettings.NegativeRate
                ? PlatformPieceType.Negative
                : PlatformPieceType.Positive;

            SetColor(_type);
        }

        private enum PlatformPieceType
        {
            Negative,
            Positive
        }

        /// <summary>
        /// Sets platform piece color, depending on type
        /// </summary>
        /// <param name="platformPieceType"></param>
        private void SetColor(PlatformPieceType platformPieceType)
        {
            var currentEmptyCase = Random.value;
            if (currentEmptyCase <= _gameplaySettings.EmptyRate)
            {
                gameObject.SetActive(false); // "transparent" platform piece
                return;
            }

            switch (platformPieceType)
            {
                case PlatformPieceType.Positive:
                    currentMeshRenderer.material.color = new Color(1f, 0.68f, 0f); // orange platform piece
                    break;

                case PlatformPieceType.Negative:
                    currentMeshRenderer.material.color = new Color(0.15f, 0.15f, 0.15f); // black platform piece
                    break;
            }
        }
    }
}