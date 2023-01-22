using UnityEngine;

namespace DIController.Code
{
	using Components;

	public class AIUnitFactory : IUnitFactory
	{
		private readonly UnitConfig _config;
		private readonly IDirectionProvider _directionProvider;

		public AIUnitFactory(UnitConfig config, IDirectionProvider directionProvider)
		{
			_config = config;
			_directionProvider = directionProvider;
		}

		public Unit Create()
		{
			UnitReferences references = Object.Instantiate(_config.Prefab);

			references.Renderer.material = _config.Material;

			var movementSystem = new TransformMovementSystem(references.Transform, _config.Speed);

			IRotationSystem rotationSystem = new AIRotationSystem(references.Transform, _config, _directionProvider);

			return new Unit(movementSystem, _directionProvider, rotationSystem);
		}
	}

	public class AIRotationSystem : IRotationSystem
	{
		private readonly Transform _transform;
		private readonly IRotationSpeedProvider _rotationSpeedProvider;
		private readonly IDirectionProvider _directionProvider;

		public AIRotationSystem
			(Transform transform, IRotationSpeedProvider rotationSpeedProvider, IDirectionProvider directionProvider)
		{
			_transform = transform;
			_rotationSpeedProvider = rotationSpeedProvider;
			_directionProvider = directionProvider;
		}

		public void Rotate()
		{
			float rotationSpeed = Time.deltaTime * _rotationSpeedProvider.RotationSpeed;
			Quaternion rotation = Quaternion.LookRotation(_directionProvider.Direction);
			_transform.rotation = Quaternion.Lerp(_transform.rotation,rotation, rotationSpeed);
		}
	}
}