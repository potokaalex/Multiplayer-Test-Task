using CodeBase.Infrastructure.Services.StateMachine;

namespace CodeBase._dev
{
    public class GameLoadingState : IState
    {

        public GameLoadingState()
        {
        }

        public void Enter()
        {
        }
    }

    public class GameDisposeState
    {
    }

    //внешняя стейт машина окрыват стейт GameLoadingState.
    //в лоадинг стейте загружается сцена: инсталлер,обновляется провайдер.
    //дальше,
}