using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    [Header("Loading Bar:")]
    [SerializeField] Slider loadingBar;
    
    AsyncOperation async;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        StartCoroutine(LoadingScreen());
    }

    IEnumerator LoadingScreen()
    {
        async = SceneManager.LoadSceneAsync("SalaMultijogador");
        async.allowSceneActivation = false;

        while(async.isDone == false)
        {
            loadingBar.value = async.progress;
            if(async.progress == 0.9f)
            {
                loadingBar.value = 1f;
                async.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
