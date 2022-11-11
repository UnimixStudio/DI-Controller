using UnityEngine;

namespace DIController.Code
{
	public class KeyboardInputSystem : IInputSystem
	{
		private const string Vertical = "Vertical";
		private const string Horizontal = "Horizontal";
		public Vector2 Movement => new Vector2(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));
	}
}