using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Launch : MonoBehaviour {
	private Camera cam;

	public GameObject target;
	public GameObject sattelitePrefab;
	public float speed;

	private void Awake() {
		cam = GetComponent<Camera>();
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (UpdateTarget()) {
				GameObject sattelite = Instantiate(sattelitePrefab, transform.position, Quaternion.identity);
				sattelite.transform.LookAt(target.transform.position);

				Vector3 vector = target.transform.position - transform.position;
				vector.Normalize();
				sattelite.GetComponent<Rigidbody>().AddForce(vector * speed);
			}
		}
	}

	private bool UpdateTarget() {
		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit)) {
			if (hit.transform) {
				target = hit.transform.gameObject;
				return true;
			}

			target = null;
		}

		return false;
	}
}