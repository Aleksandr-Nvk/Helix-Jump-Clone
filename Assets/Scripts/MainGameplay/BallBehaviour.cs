using System.Collections.Generic;
using UnityEngine;
using Interfaces;

namespace MainGameplay
{
    public class BallBehaviour : MonoBehaviour
    {
    #pragma warning disable 0649

        [SerializeField] private Rigidbody _ball;
        [SerializeField] private Rigidbody _ballParent;
        
    #pragma warning restore

        private List<float> _platformsYPositions = new List<float>();
        
        private List<IPiece[]> _piecesBehaviours = new List<IPiece[]>();

        private void Start()
        {
            // ball start position validation
            var parent = _ballParent.gameObject;
            var ray = new Ray(parent.transform.position, Vector3.down);
            Physics.Raycast(ray, out var data);
            
            // TODO: Check ray length
        }

        private void Update()
        {
            if (transform.position.y < _platformsYPositions[0])
            {
                foreach (var piece in _piecesBehaviours[0])
                {
                    piece?.Delete(1f);
                }
                
                _platformsYPositions.Remove(_platformsYPositions[0]);
                _piecesBehaviours.Remove(_piecesBehaviours[0]);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            Jump();
        }

        /// <summary>
        /// Makes the ball jump
        /// </summary>
        private void Jump()
        {
            _ball.velocity = Vector3.zero;
            _ball.AddForce(Vector3.up * 1f, ForceMode.Impulse);
        }

        /// <summary>
        /// Sets built level data
        /// </summary>
        /// <param name="platformsYPositions"> Platforms' Y positions </param>
        /// <param name="piecesBehaviours"> Pieces' behaviour components </param>
        public void SetLevelData(List<float> platformsYPositions, List<IPiece[]> piecesBehaviours)
        {
            _platformsYPositions = platformsYPositions;
            _piecesBehaviours = piecesBehaviours;
        }
    }
}