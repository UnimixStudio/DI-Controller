using Cinemachine;
using DIController.Code.Components;
using UnityEngine;

namespace DIController.Code
{
	public class PlayerUnitFactory : IUnitFactory
	{
		private readonly UnitConfig _config;
		private readonly Transform _cameraTransform;
		private readonly IInputSystem _inputSystem;
		private readonly IDirectionProvider _directionProvider;
		private readonly CinemachineFreeLook _freeLook;

		public PlayerUnitFactory
		(
			UnitConfig config,
			Transform cameraTransform,
			IInputSystem inputSystem,
			IDirectionProvider directionProvider,
			CinemachineFreeLook freeLook
		)
		{
			_config = config;
			_cameraTransform = cameraTransform;
			_inputSystem = inputSystem;
			_directionProvider = directionProvider;
			_freeLook = freeLook;
		}

		public Unit Create()
		{
			UnitReferences references = Object.Instantiate(_config.Prefab);

			_freeLook.m_Follow = references.Transform;
			_freeLook.LookAt = references.CameraTarget;

			references.Renderer.material = _config.Material;

			var movementSystem = new TransformMovementSystem(references.Transform, _config.Speed);

			IRotationSystem rotationSystem = new TransformRotationSystem(
				references.Transform,
				_cameraTransform,
				_inputSystem,
				_config);

			return new Unit(movementSystem, _directionProvider, rotationSystem);
		}
	}

	public interface IRotationSpeedProvider
	{
		float RotationSpeed { get; }
	}
}