using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    [Header("Áreas do Lobby:")]
    [SerializeField] GameObject userArea;
    [SerializeField] GameObject creatingArea;

    [Header("Botões:")]
    [SerializeField] GameObject logInButton;

    [Header("Caixas de Texto:")]
    [SerializeField] TMP_InputField createField;
    [SerializeField] TMP_InputField joinField;
    [SerializeField] TMP_InputField userField;

    void Start()
    {
        userArea.SetActive(true);
    }

    public void ChangeUser()
    {
        if (userField.text.Length >= 3)
            logInButton.SetActive(true);
        else
            logInButton.SetActive(false);
    }

    public void SetUser()
    {
        userArea.SetActive(false);
        PhotonNetwork.NickName = userField.text;
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createField.text, new RoomOptions { MaxPlayers = 2 });
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinField.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Multijogador");
    }
}
