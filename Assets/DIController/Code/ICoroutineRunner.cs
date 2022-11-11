using System.Collections;

using UnityEngine;

namespace DIController.Code
{
	public interface ICoroutineRunner
	{
		public Coroutine StartCoroutine(IEnumerator routine);
	}
}