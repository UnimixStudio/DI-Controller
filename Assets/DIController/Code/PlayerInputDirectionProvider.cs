using UnityEngine;

namespace DIController.Code
{
	public class PlayerInputDirectionProvider : IDirectionProvider
	{
		private readonly IInputSystem _input;

		public PlayerInputDirectionProvider(IInputSystem input) =>
			_input = input;

		public Vector3 Direction
		{
			get
			{
				Vector2 movement = _input.Movement;

				float x = movement.x;
				float y = movement.y;

				return new Vector3(x, 0, y);
			}
		}

	}
}