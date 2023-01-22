namespace DIController.Code
{
	public class AIUnit : IStartable, ITickable
	{
		private readonly StartableManager _startableManager;
		private readonly TickableManager _tickableManager;

		public AIUnit(ICoroutineRunner coroutineRunner, UnitConfig config)
		{
			var directionProvider = new AIDirectionProvider(coroutineRunner);

			var factory = new AIUnitFactory(config, directionProvider);

			Unit unit = factory.Create();

			_startableManager = new StartableManager(directionProvider);
			_tickableManager = new TickableManager(unit);
		}

		public void Start() => _startableManager.Start();

		public void Tick() => _tickableManager.Tick();
	}
}