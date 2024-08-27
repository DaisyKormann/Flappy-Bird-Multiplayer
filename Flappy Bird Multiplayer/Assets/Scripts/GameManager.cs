using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourPun
{
    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
    #endregion

    Vector2 screenBounds;
    int score;
    int playersInGame = 0;
    const string playerPrefabPath = "Prefabs/Player";

    public Vector2 ScreenBounds { get => screenBounds; }
    public int Score { get => score; set => score = value; }

<<<<<<< Updated upstream
    const string playerPrefabPath = "Prefabs/Player";
    int playersInGame = 0;

    private void Start()
    {
        photonView.RPC("AddPlayer", RpcTarget.AllBuffered);
    }

    private void CreatePlayer()
    {
        Player player = NetworkManager.instance.Instantiate(playerPrefabPath, new Vector3(-5,0), Quaternion.identity).GetComponent<Player>();
=======
    private void CreatePlayer()
    {
        Player player = NetworkManager.instance.Instantiate(playerPrefabPath, new Vector3(-5, 0), Quaternion.identity).GetComponent<Player>();
>>>>>>> Stashed changes
        player.photonView.RPC("Initialize", RpcTarget.All);
    }

    [PunRPC]
    private void AddPlayer()
    {
        playersInGame++;
        if (playersInGame == PhotonNetwork.PlayerList.Length)
        {
            CreatePlayer();
        }
    }
<<<<<<< Updated upstream

    [PunRPC]
    public void SetScore(int value)
    {
        score += value;
        UIManager.instance.UpdateScoreText();
    }
=======
>>>>>>> Stashed changes
}
