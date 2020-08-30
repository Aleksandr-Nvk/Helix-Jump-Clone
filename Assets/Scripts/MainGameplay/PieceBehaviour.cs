using Random = UnityEngine.Random;
using UnityEngine;
using Interfaces;

namespace MainGameplay
{
    public class PieceBehaviour : MonoBehaviour, IPiece
    {
    #pragma warning disable 0649

        [SerializeField] private Rigidbody _rigidbody;

        [SerializeField] private MeshRenderer _meshRenderer;
        
        [SerializeField] private MeshCollider _collider;

        [SerializeField] private float _distortionForce = 2f;
        
    #pragma warning restore
        
        /// <summary>
        /// Distorts, fades and destroys the piece
        /// </summary>
        /// <param name="time"> Animation time </param>
        public void Delete(float time)
        {
            Distort();
            //_meshRenderer.material.DOFade(0f, 1f);
            Destroy(gameObject, time);
        }

        /// <summary>
        /// Adds impulse to the piece's rigidbody
        /// </summary>
        private void Distort()
        {
            _rigidbody.isKinematic = false;
            _collider.enabled = false;

            var currentDirectionX = transform.right.x * 2f;
            var currentDirectionY = -transform.up.y * 2f;
            var currentDirectionZ = transform.forward.z * 2f;
            var randomizationValue = -Random.Range(1f, 2f);
            var force = randomizationValue * _distortionForce * new Vector3(currentDirectionX, currentDirectionY, currentDirectionZ);
            
            _rigidbody.AddForceAtPosition(force, _rigidbody.centerOfMass, ForceMode.Impulse);
        }
    }
}