namespace DIController.Code
{
	public class Unit : ITickable
	{
		private readonly IMovementSystem _movement;
		private readonly IDirectionProvider _provider;
		private readonly IRotationSystem _rotationSystem;

		public Unit(IMovementSystem movement, IDirectionProvider provider, IRotationSystem rotationSystem)
		{
			_movement = movement;
			_provider = provider;
			_rotationSystem = rotationSystem;
		}

		public void Tick()
		{
			_movement.Move(_provider.Direction);
			_rotationSystem.Rotate();
		}
	}
}