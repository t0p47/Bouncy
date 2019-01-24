using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class BallController : MonoBehaviour {

    public float myJumpHeight;
    public LayerMask whatIsGround;
    bool canJump;
    private BallMotor motor;
    public int money;
    GameObject gameMaster;


    float _maxSpeed;

    Rigidbody2D rb;
    
    void Start () {
        rb = transform.parent.gameObject.GetComponent<Rigidbody2D>();
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster");
    }
    
	void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Time.timeScale = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Up") {
            rb.velocity = new Vector2(rb.velocity.x, myJumpHeight*1.47f);
        }

        else {
            rb.velocity = new Vector2(rb.velocity.x, myJumpHeight);
            canJump = true;
            _maxSpeed = 7;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        gameMaster.GetComponent<GameMaster>().addMoney();
        Destroy(other.gameObject);
    }
}
