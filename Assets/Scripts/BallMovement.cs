using UnityEngine;

public class BallMovement : MonoBehaviour
{
#pragma warning disable 0649

    [SerializeField] private Rigidbody ball;

#pragma warning restore
    
    private void OnCollisionEnter(Collision collision)
    {
        ball.velocity = Vector3.zero;
        ball.AddForce(Vector3.up * 4, ForceMode.Impulse);
    }
}
