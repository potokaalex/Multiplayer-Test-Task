using CodeBase.Infrastructure.Project;
using CodeBase.Infrastructure.Project.Services.Data;
using CodeBase.Infrastructure.Project.Services.StateMachine;
using CodeBase.Infrastructure.Project.States;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private ProjectStaticData _projectStaticData;
        private IStateMachine _stateMachine;
        private IStateFactory _stateFactory;
        private IDataProvider _dataProvider;

        [Inject]
        private void Constructor(IStateMachine stateMachine, IStateFactory stateFactory, IDataProvider dataProvider)
        {
            _stateMachine = stateMachine;
            _stateFactory = stateFactory;
            _dataProvider = dataProvider;
        }

        private void Start()
        {
            SetData();
            InitializeStateMachine();
            _stateMachine.SwitchTo<BootstrapState>();
        }

        private void SetData() => _dataProvider.Set(_projectStaticData);

        private void InitializeStateMachine()
        {
            _stateMachine.Initialize(
                _stateFactory.Create<BootstrapState>(),
                _stateFactory.Create<LoadLobbyState>(),
                _stateFactory.Create<LoadGameState>(),
                _stateFactory.Create<ApplicationExitState>());
        }
    }
}