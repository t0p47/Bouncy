using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

    public GameObject player, playerPrefab, spawnPoint;
    public int needsMoney = 0;
    public int moneyCollect = 0;
    public GameObject winPanel;
    public GameObject controlPanel;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void KillPlayer() {
        if (player == null)
        {
            Debug.Log("Player alreadDead");
            Destroy(player);
        }
        else {
            Destroy(player);
        }
        StartCoroutine(DeathWait());
    }

    IEnumerator DeathWait()
    {
        print(Time.time);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        print(Time.time);
    }

    public void addMoney() {
        moneyCollect++;
        if (moneyCollect==needsMoney) {
            winPanel.SetActive(true);
            controlPanel.SetActive(false);
            Time.timeScale = 0;
        }
    }

}
