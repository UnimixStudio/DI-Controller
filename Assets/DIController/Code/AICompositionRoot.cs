namespace DIController.Code
{
	public class AICompositionRoot : IStartable, ITickable
	{
		private readonly StartableManager _startableManager;
		private readonly TickableManager _tickableManager;

		public AICompositionRoot(ICoroutineRunner coroutineRunner, UnitConfig config)
		{
			var directionProvider = new AIDirectionProvider(coroutineRunner);
			
			var factory = new UnitTransformMovementFactory(config);
			
			Unit unit = factory.Create(directionProvider);
			
			_startableManager = new StartableManager(directionProvider);
			_tickableManager = new TickableManager(unit);
		}

		public void Start() => _startableManager.Start();
		public void Tick() => _tickableManager.Tick();
	}
}