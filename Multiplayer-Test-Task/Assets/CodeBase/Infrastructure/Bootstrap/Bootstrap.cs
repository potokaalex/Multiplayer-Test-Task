using System;
using CodeBase.Gameplay.Bullet;
using CodeBase.Gameplay.Coin.Data;
using CodeBase.Gameplay.Player.Data;
using CodeBase.Infrastructure.Services.Data;
using CodeBase.Infrastructure.Services.StateMachine;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Bootstrap
{
    public class Bootstrap : MonoBehaviour
    {

        private IStateMachine _stateMachine;
        private IStateFactory _stateFactory;
        private IDataProvider _dataProvider;

        [Inject]
        private void Constructor(IStateMachine stateMachine, IStateFactory stateFactory,
            IDataProvider dataProvider)
        {
            _stateMachine = stateMachine;
            _stateFactory = stateFactory;
            _dataProvider = dataProvider;
        }
        
        private void Start()
        {
            
        }

        private void SetData()
        {
            //_dataProvider.Set(_sceneData);
        }
    }
}