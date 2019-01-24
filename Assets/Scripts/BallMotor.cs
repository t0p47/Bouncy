using UnityEngine;
using System.Collections;

public class BallMotor : MonoBehaviour {

    private Vector2 velocity = Vector2.zero;
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        PeformMovement();
    }

    public void Move(Vector2 _velocity) {
        velocity = _velocity;
    }

    void PeformMovement() {
        if (velocity != Vector2.zero) {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }
}
