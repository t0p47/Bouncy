using UnityEngine;
using System.Collections;

public class SpeedPad : MonoBehaviour {

    GameObject player, gameMaster;
    [SerializeField]
    float speedAndSide = 0.5f; 

    void Start() {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster");
    }

    void OnCollisionEnter2D(Collision2D coll) {
        Debug.Log("SpeedPad");
        player = coll.gameObject;
        player.transform.position = transform.position;
        player.GetComponent<SpeedPadControl>().setSpeedPad(gameObject);
        player.GetComponent<SpeedPadControl>().setSpeedAndSide(speedAndSide);

        player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().enabled = false;
        player.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().enabled = false;
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        player.GetComponent<SpeedPadControl>().enabled = true;
        
    }
}
