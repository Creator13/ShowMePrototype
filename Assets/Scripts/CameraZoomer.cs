using System;
using UnityEngine;

[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(Launch))]
public class CameraZoomer : MonoBehaviour {
    private Camera cam;

    [SerializeField] private float wideFOV = 60;
    [SerializeField] private float teleFOV = 5;
    [SerializeField] private int zoomLevels = 5;

    private int zoomLevel;

    private int Zoom {
        set {
            zoomLevel = Mathf.Clamp(value, 0, zoomLevels - 1);

            UpdateCameraZoom();
        }
        get => zoomLevel;
    }

    private void Awake() {
        cam = GetComponent<Camera>();
        GetComponent<Launch>().SatelliteLaunched += ResetZoom;
    }

    private void Start() {
        cam.usePhysicalProperties = false;
        Zoom = 0;
    }

    private void Update() {
        bool zoomIn = Input.GetButtonDown("ZoomIn");
        bool zoomOut = Input.GetButtonDown("ZoomOut");

        if (zoomIn && zoomOut) return;

        if (zoomIn) Zoom++;

        if (zoomOut) Zoom--;
    }

    private void OnDisable() {
        GetComponent<Launch>().SatelliteLaunched -= ResetZoom;
    }

    private void UpdateCameraZoom() {
        cam.fieldOfView = Mathf.Lerp(wideFOV, teleFOV, Zoom / (zoomLevels - 1f));
    }

    private void ResetZoom() {
        Zoom = 0;
    }
}
