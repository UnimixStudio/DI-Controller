using DIController.Code.Components;

using UnityEngine;

namespace DIController.Code
{
	[CreateAssetMenu(menuName = "UnitConfig", fileName = "UnitConfig")]
	public class UnitConfig : ScriptableObject, IRotationSpeedProvider
	{
		public float Speed;
		public UnitReferences Prefab;
		public Material Material;
		
		[SerializeField] private float _rotationSpeed = 4f;

		public float RotationSpeed => _rotationSpeed;
	}
}