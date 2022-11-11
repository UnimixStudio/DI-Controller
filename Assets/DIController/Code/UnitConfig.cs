using DIController.Code.Components;

using UnityEngine;

namespace DIController.Code
{
	[CreateAssetMenu(menuName = "UnitConfig", fileName = "UnitConfig")]
	public class UnitConfig : ScriptableObject
	{
		public float Speed;
		public UnitReferences Prefab;
		public Material Material;
	}
}