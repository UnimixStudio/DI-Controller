using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace DIController.Code
{
	public class PlayerFactoryProvider
	{
		private readonly UnitConfig _config;
		private readonly Camera _camera;
		private readonly CinemachineFreeLook _freeLook;

		public PlayerFactoryProvider(UnitConfig config, Camera camera, CinemachineFreeLook freeLook)
		{
			_config = config;
			_camera = camera;
			_freeLook = freeLook;
		}

		public PlayerUnitFactory Factory()
		{
			var inputSystem = new KeyboardInputSystem();
			var directionProvider = new PlayerInputDirectionProvider(inputSystem, _camera);

			Transform cameraTransform = _camera.transform;
			return new PlayerUnitFactory(_config, cameraTransform, inputSystem, directionProvider, _freeLook);
		}
	}

	public class Game : MonoBehaviour, ICoroutineRunner
	{
		[SerializeField] private Camera _mainCamera;
		[SerializeField] private CinemachineFreeLook _freeLook;

		[SerializeField] private UnitConfig _playerConfig;
		[SerializeField] private UnitConfig[] _aiConfigs;

		private TickableManager _tickableManager;
		private StartableManager _startableManager;
		private readonly PlayerFactoryProvider _playerFactoryProvider;

		private void Awake()
		{
			var tickables = new List<ITickable>();
			var startables = new List<IStartable>();

			var playerFactoryProvider = new PlayerFactoryProvider(_playerConfig, _mainCamera, _freeLook);

			PlayerUnitFactory playerFactory = playerFactoryProvider.Factory();

			var player = new Player(playerFactory);

			tickables.Add(player);

			foreach(UnitConfig config in _aiConfigs)
			{
				var root = new AIUnit(this, config);
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