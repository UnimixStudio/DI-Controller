using UnityEngine;

namespace DIController.Code
{
	public class PlayerCompositionRoot : ITickable
	{
		private readonly TickableManager _tickableManager;

		public PlayerCompositionRoot(UnitConfig config, Camera mainCamera)
		{
			var inputSystem = new KeyboardInputSystem();
			var directionProvider = new PlayerInputDirectionProvider(inputSystem);

			var factory = new UnitTransformMovementFactory(config);
			
			Unit unit = factory.Create(directionProvider);

			_tickableManager = new TickableManager(unit);
		}

		public void Tick() => _tickableManager.Tick();
	}
}