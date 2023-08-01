using CodeBase.Infrastructure.Services.Data;
using CodeBase.Infrastructure.Services.StateMachine;
using CodeBase.Infrastructure.Services.StateMachine.Implementations;
using Zenject;

namespace CodeBase.Infrastructure.Bootstrap
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStateMachine();

            Container.Bind<IDataProvider>().To<DataProvider>().AsSingle();
        }

        private void BindStateMachine()
        {
            Container.Bind<IStateMachine>().To<StateMachine>().AsSingle();
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
        }
    }
}