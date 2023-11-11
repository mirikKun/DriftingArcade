using System.Collections;
using System.Collections.Generic;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Fabric;
using CodeBase.Infrastructure.Logic;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Infrastructure.States;
using DefaultNamespace;
using Infrastructure.Services.SaveLoad;
using UnityEngine;
using Zenject;
using AndroidInput = DefaultNamespace.AndroidInput;

public class BootstrapInstaller : MonoInstaller,ICoroutineRunner
{
    [SerializeField] private LoadingCurtain _loadingCurtain;
    public override void InstallBindings()
    {
        BindCoroutineRunner();
        BindSceneLoader();
        BindCurtain();
        
        BindInputService();
        BindAssetProvider();
        BindProgressService();
        BindSaveLoadService();
        
        BindFactory();
        BindStateMachine();
    }

  

    private void BindFactory()
    {
        Container
            .Bind<IGameFactory>()
            .To<GameFactory>()
            .AsSingle();
    }

    private void BindAssetProvider()
    {
        Container
            .Bind<IAssetProvider>().To<AssetProvider>()
            .AsSingle();
       }

    private void BindStateMachine()
    {
        Container
            .Bind<GameStateMachine>()
            .AsSingle();
    }

    private void BindSaveLoadService()
    {
        Container
            .Bind<ISaveLoadService>()
            .To<SaveLoadService>()
            .AsSingle();
    }

    private void BindProgressService()
    {
        Container
            .Bind<IPersistentProgressService>()
            .To<PersistentProgressService>()
            .AsSingle();
    }

    private void BindInputService()
    {
        Container.Bind<IInput>().To<AndroidInput>().AsSingle();
    }

    private void BindCurtain()
    {
        LoadingCurtain loadingCurtain = Container
            .InstantiatePrefabForComponent<LoadingCurtain>(_loadingCurtain);
        Container
            .Bind<LoadingCurtain>()
            .FromInstance(loadingCurtain)
            .AsSingle();
    }

    private void BindSceneLoader()
    {
        Container
            .Bind<SceneLoader>()
            .AsSingle();
    }

    private void BindCoroutineRunner()
    {

        Container
            .Bind<ICoroutineRunner>()
            .FromInstance(this)
            .AsSingle();
    }
}
