using CodeBase.Infrastructure.Project.Services.Data;
using CodeBase.Infrastructure.Project.Services.Network;
using CodeBase.Infrastructure.Project.Services.SceneLoader;
using CodeBase.Infrastructure.Project.Services.StateMachine;
using CodeBase.Infrastructure.Project.Services.StateMachine.Implementations;
using Zenject;

namespace CodeBase.Infrastructure.Project
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStateMachine();

            Container.Bind<IDataProvider>().To<DataProvider>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<INetworkService>().To<NetworkService>().FromNewComponentOnNewGameObject().AsSingle();
        }

        private void BindStateMachine()
        {
            Container.Bind<IStateMachine>().To<StateMachine>().AsSingle();
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
        }
    }
}