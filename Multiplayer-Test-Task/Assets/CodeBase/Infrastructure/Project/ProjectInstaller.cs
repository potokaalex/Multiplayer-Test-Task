using CodeBase.Infrastructure.Services.GlobalData;
using CodeBase.Infrastructure.Services.StateMachine;
using CodeBase.Infrastructure.Services.StateMachine.Implementations;
using Zenject;

namespace CodeBase.Infrastructure.Project
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IDataProvider>().To<DataProvider>().AsSingle();
            Container.Bind<IStateMachine>().To<StateMachine>().AsSingle();
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
        }
    }
}