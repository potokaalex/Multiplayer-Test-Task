using CodeBase.Infrastructure.Project.Services.StateMachine;

namespace CodeBase.Infrastructure.Project.States
{
    public class ApplicationExitState : IState
    {
        public void Enter()
#if UNITY_EDITOR
            => UnityEditor.EditorApplication.isPlaying = false;
#else
            => UnityEngine.Application.Quit();
#endif
    }
}