namespace DIController.Code
{
	public class StartableManager
	{
		private readonly IStartable[] _startables;

		public StartableManager(params IStartable[] startables) =>
			_startables = startables;

		public void Start()
		{
			for (int i = _startables.Length - 1; i >= 0; i--)
				_startables[i].Start();
		}
	}
}