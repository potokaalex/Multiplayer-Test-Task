using CodeBase.Infrastructure.Project.Services.StateMachine;
using UnityEngine;

namespace CodeBase.Infrastructure.Game.States.GameOver
{
    public struct GameOverStateParameter : IStateParameter
    {
        public Color WinnerColor;
        public int WinnerCoinsCount;
    }
}