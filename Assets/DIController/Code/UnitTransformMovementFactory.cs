using DIController.Code.Components;

using UnityEngine;

namespace DIController.Code
{
	public class UnitTransformMovementFactory
	{
		private readonly UnitConfig _config;

		public UnitTransformMovementFactory(UnitConfig config) => _config = config;

		public Unit Create (IDirectionProvider directionProvider)
		{
			UnitReferences references = Object.Instantiate(_config.Prefab);

			references.Renderer.material = _config.Material;
			
			var movementSystem = new TransformMovementSystem(references.transform, _config.Speed);

			return new Unit(movementSystem, directionProvider);
		}
	}
}