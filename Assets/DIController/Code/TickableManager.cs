namespace DIController.Code
{
	public class TickableManager
	{
		private readonly ITickable[] _tickables;

		public TickableManager(params ITickable[] tickables) =>
			_tickables = tickables;

		public void Tick()
		{
			for (int index = _tickables.Length - 1; index >= 0; index--)
				_tickables[index].Tick();
		}
	}
}