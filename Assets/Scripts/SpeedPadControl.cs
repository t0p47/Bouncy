using UnityEngine;
using System.Collections;

public class SpeedPadControl : MonoBehaviour {

    GameObject player, speedPad;
    float speedAndSide = 0.5f;

    public void setSpeedAndSide(float turnSide) {
        this.speedAndSide = turnSide;
    }

    public void setSpeedPad(GameObject _speedPad) {
        this.speedPad = _speedPad;
    }

    void Start() {
        player = gameObject;
    }

    void Update() {
        player.GetComponent<Rigidbody2D>().MovePosition(new Vector2(player.transform.position.x + speedAndSide, player.transform.position.y));
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            EnableStandartControl();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            EnableStandartControl();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            EnableStandartControl();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            EnableStandartControl();
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject != speedPad) {
            EnableStandartControl();
        }
    }

    void EnableStandartControl() {
        player = gameObject;
        player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().enabled = true;
        player.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().enabled = true;
        player.GetComponent<Rigidbody2D>().gravityScale = 4;
        player.GetComponent<SpeedPadControl>().enabled = false;
    }
}
