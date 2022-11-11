using UnityEngine;

namespace DIController.Code
{
	public interface IMovementSystem
	{
		float Speed { get; set; }
		void Move(Vector3 direction);
	}
}