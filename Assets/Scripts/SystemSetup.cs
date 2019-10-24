using UnityEngine;

[CreateAssetMenu(menuName = "Solar System Setup", fileName = "NewSetupConfiguration")]
public class SystemSetup : ScriptableObject {
	[SerializeField] private float travelTimeScale = 1;
	public float TravelTimeScale => travelTimeScale * 500;
}