using System.Collections.Generic;

using UnityEngine;

namespace DIController.Code
{
	public class GameCompositionRoot : MonoBehaviour, ICoroutineRunner
	{
		[SerializeField] private Camera _mainCamera;

		
		[SerializeField] private UnitConfig _playerConfig;
		[SerializeField] private UnitConfig[] _aiConfigs;

		private TickableManager _tickableManager;
		private StartableManager _startableManager;

		private void Awake()
		{
			var tickables = new List<ITickable>();
			var startables = new List<IStartable>();
			
			var playerCompositionRoot = new PlayerCompositionRoot(_playerConfig, _mainCamera);
			
			tickables.Add(playerCompositionRoot);
			
			foreach(UnitConfig config in _aiConfigs)
			{
				var root = new AICompositionRoot(this, config);
				startables.Add(root);
				tickables.Add(root);
			}

			_startableManager = new StartableManager(startables.ToArray());
			_tickableManager = new TickableManager(tickables.ToArray());
		}

		public void Start() => _startableManager.Start();

		private void Update() => _tickableManager.Tick();
	}
}
