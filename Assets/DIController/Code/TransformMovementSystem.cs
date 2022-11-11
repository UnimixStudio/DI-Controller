using UnityEngine;

namespace DIController.Code
{
	public class TransformMovementSystem : IMovementSystem
	{
		private readonly Transform _transform;

		public TransformMovementSystem(Transform transform, float speed)
		{
			_transform = transform;
			Speed = speed;
		}

		public float Speed { get; set; }

		public void Move(Vector3 direction) => _transform.position += direction * (Speed * Time.deltaTime);
	}
}