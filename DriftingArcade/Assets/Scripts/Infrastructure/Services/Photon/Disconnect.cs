using Infrastructure;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Disconnect : MonoBehaviour
{
    [SerializeField] private Button _backButton;
    private PhotonDisconnector _photonDisconnector;

    [Inject]
    private void Construct(PhotonDisconnector photonDisconnector)
    {
        _photonDisconnector = photonDisconnector;
    }

    private void Start()
    {
        _backButton.onClick.AddListener(_photonDisconnector.DisconnectPlayer);
    }
}
