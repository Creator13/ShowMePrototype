using UnityEngine;

public class Camera : MonoBehaviour {
	[SerializeField] private float speedY;
	[SerializeField] private float speedX;
	
	// Mouselook script
	private void Update() {
		float rotY = Input.GetAxis("Mouse X");
		float rotX = Input.GetAxis("Mouse Y");

		transform.eulerAngles += new Vector3(rotX * speedX, rotY * speedY);
	}
}