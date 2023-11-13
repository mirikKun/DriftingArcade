using System;
using Data;
using Infrastructure.AssetManagement;
using Infrastructure.Services.PersistentProgress;
using Photon.Pun;
using UnityEngine;
using Zenject;

public class CarView : MonoBehaviour
{
    [SerializeField] private Renderer[] _renderers;
    [SerializeField] private Transform _accessoriesHolder;
    private IAssetProvider _assetProvider;
    private IPersistentProgressService _progressService;
    private PhotonView _photonView;

    
    [Inject]
    private void Construct(IAssetProvider assetProvider,IPersistentProgressService progressService)
    {
        _assetProvider = assetProvider;
        _progressService = progressService;
    }

    private void Start()
    {
        _photonView = GetComponent<PhotonView>();
        CustomCarData currentCarData = _progressService.PlayerData.CustomCarData;
        ChangeColor(currentCarData.CarColor);
        CreateAccessory(currentCarData.AccessoriesType);
        _photonView.RPC("SetSkinOnline", RpcTarget.Others,currentCarData.CarColor.ColorToVector3(), currentCarData.AccessoriesType.ToString());
        
    }

    [PunRPC]
    private void SetSkinOnline(Vector3 color, string accessoriesType)
    {
        ChangeColor(color.Vector3ToColor());
        CreateAccessory((accessoriesType).ToEnum<AccessoriesType>());
    }
    private void ChangeColor(Color color)
    {
        foreach (Renderer renderer in _renderers)
        {
            renderer.material.SetColor("_Color", color);
        }
    }
    private void CreateAccessory(AccessoriesType type)
    {
        if(type==AccessoriesType.None)
            return;
        GameObject newAccessories = _assetProvider.Instantiate(type.ToString());
        newAccessories.transform.SetParent(_accessoriesHolder);
        newAccessories.transform.localPosition = Vector3.zero;
        newAccessories.transform.localRotation = Quaternion.identity;
    }
}
