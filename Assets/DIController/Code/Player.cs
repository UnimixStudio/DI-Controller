namespace DIController.Code
{
	public class Player : ITickable
	{
		private readonly Unit _unit;

		public Player(IUnitFactory factory) =>
			_unit = factory.Create();

		public void Tick() => _unit.Tick();
	}
}