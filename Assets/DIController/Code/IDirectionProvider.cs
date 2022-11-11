using UnityEngine;

namespace DIController.Code
{
	public interface IDirectionProvider
	{
		Vector3 Direction { get; }
	}
}