using UnityEngine;

namespace DIController.Code
{
	public class PlayerInputDirectionProvider : IDirectionProvider
	{
		private readonly IInputSystem _input;
		private readonly Camera _camera;

		public PlayerInputDirectionProvider(IInputSystem input, Camera camera)
		{
			_input = input;
			_camera = camera;
		}

		public Vector3 Direction
		{
			get
			{
				Vector2 movement = _input.Movement;

				float x = movement.x;
				float y = movement.y;

				var direction = new Vector3(x, 0, y);

				Transform cameraTransform = _camera.transform;
				
				direction = cameraTransform.forward * direction.z + cameraTransform.right * direction.x;

				direction.y = 0;
				
				return direction;
			}
		}

	}
}