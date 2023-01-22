using UnityEngine;

namespace DIController.Code
{
	public class TransformRotationSystem : IRotationSystem
	{
		private readonly Transform _transform;
		private readonly Transform _cameraTransform;
		private readonly IInputSystem _inputSystem;
		private readonly IRotationSpeedProvider _speedProvider;

		public TransformRotationSystem
		(
			Transform transform,
			Transform cameraTransform,
			IInputSystem inputSystem,
			IRotationSpeedProvider speedProvider
		)
		{
			_transform = transform;
			_cameraTransform = cameraTransform;
			_inputSystem = inputSystem;
			_speedProvider = speedProvider;
		}

		public void Rotate()
		{
			Vector2 movement = _inputSystem.Movement;

			if (movement == Vector2.zero)
				return;

			float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg * _cameraTransform.eulerAngles.y;
			
			Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);

			float rotationSpeed = Time.deltaTime * _speedProvider.RotationSpeed;

			_transform.rotation = Quaternion.Lerp(_transform.rotation, rotation, rotationSpeed);
		}
	}
}