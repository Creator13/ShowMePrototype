using System;
using UI;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Launch : MonoBehaviour {
    public event Action SatelliteLaunched;
    
    private Camera cam;
    private Planet target;

    private Planet Target {
        get => target;
        set {
            if (value != target) {
                UIEvents.Instance.targetUpdated?.Invoke(value);
            }

            target = value;
        }
    }

    public GameObject sattelitePrefab;

    private void Awake() {
        cam = GetComponent<Camera>();
    }

    private void Update() {
        UpdateTarget();

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (Target) {
                Vector3 launchPos = new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z);
                GameObject sattelite = Instantiate(sattelitePrefab, launchPos, Quaternion.identity);
                sattelite.transform.LookAt(Target.transform.position);

                Vector3 vector = Target.transform.position - launchPos;
                vector.Normalize();

                float speed = Settings.Instance.Setup.TravelTimeScale;
                sattelite.GetComponent<Rigidbody>().AddForce(vector * speed);
                
                SatelliteLaunched?.Invoke();
            }
        }
    }

    private void UpdateTarget() {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit)) {
            Planet planet = hit.transform.gameObject.GetComponent<Planet>();
            if (hit.transform && planet) {
                Target = planet;
                Debug.Log(planet.Name);
                return;
            }
        }

        Target = null;
    }
}
