using UnityEngine;
using System.Collections;

public class DeathFromFall : MonoBehaviour {

    GameObject gameMaster;

    void Start() {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster");
    }

    void OnCollisionEnter2D(Collision2D coll) {
        gameMaster.GetComponent<GameMaster>().KillPlayer();
        
    }
}
