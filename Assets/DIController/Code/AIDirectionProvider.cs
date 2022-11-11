using System.Collections;

using UnityEngine;

namespace DIController.Code
{
	public class AIDirectionProvider : IDirectionProvider, IStartable
	{
		private readonly ICoroutineRunner _coroutineRunner;
		private Vector3 _direction;
		public Vector3 Direction => _direction;

		public AIDirectionProvider(ICoroutineRunner coroutineRunner)
		{
			_coroutineRunner = coroutineRunner;
		}

		public void Start()
		{
			_coroutineRunner.StartCoroutine(RandomMovement());
		}

		private IEnumerator RandomMovement()
		{
			var waitForSeconds = new WaitForSeconds(1f);
			while (true)
			{
				_direction = Random.onUnitSphere;
				_direction.y = 0;
				yield return waitForSeconds;
			}
		}
	}
}