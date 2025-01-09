using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyCreateUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField lobbyNameInputField;
    [SerializeField] private Button createPrivateButton;
    [SerializeField] private Button createPublicButton;
    [SerializeField] private Button closeButton;

    private void Awake()
    {
        createPrivateButton.onClick.AddListener(() =>
        {
            KitchenGameLobby.Instance.CreateLobby(lobbyNameInputField.name, false);
        });
        createPublicButton.onClick.AddListener(() =>
        {
            KitchenGameLobby.Instance.CreateLobby(lobbyNameInputField.name, true);
        });
        closeButton.onClick.AddListener(() =>
        {
            Hide();
        });
    }

    private void Start()
    {
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
