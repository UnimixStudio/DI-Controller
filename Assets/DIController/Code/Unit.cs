namespace DIController.Code
{
	public class Unit : ITickable
	{
		private readonly IMovementSystem _movement;
		private readonly IDirectionProvider _provider;

		public Unit(IMovementSystem movement, IDirectionProvider provider)
		{
			_movement = movement;
			_provider = provider;
		}

		public void Tick() => _movement.Move(_provider.Direction);
	}
}