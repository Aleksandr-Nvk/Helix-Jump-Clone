using Random = UnityEngine.Random;
using UnityEngine;
using DG.Tweening;
using Interfaces;

namespace MainGameplay
{
    public class PieceBehaviour : MonoBehaviour, IPiece
    {
    #pragma warning disable 0649

        [SerializeField] private Rigidbody _rigidbody;

        [SerializeField] private MeshRenderer _meshRenderer;
        
        [SerializeField] private MeshCollider _collider;
        
    #pragma warning restore
        
        /// <summary>
        /// Distorts, fades and destroys the piece
        /// </summary>
        /// <param name="time"> Fading animation time </param>
        public void Delete(float time)
        {
            Distort();
            _meshRenderer.material.DOFade(0f, 1f);
            Destroy(gameObject, time);
        }

        /// <summary>
        /// Adds impulse to the piece's rigidbody
        /// </summary>
        private void Distort()
        {
            _rigidbody.isKinematic = false;
            _collider.enabled = false;

            var currentDirectionX = transform.right.x;
            var currentDirectionY = transform.up.y;
            var currentDirectionZ = transform.forward.z;
            var force = new Vector3(currentDirectionX, currentDirectionY, currentDirectionZ) * Random.Range(0.5f, 1f);
            
            _rigidbody.AddForceAtPosition(force, _rigidbody.centerOfMass, ForceMode.Impulse);
        }
    }
}