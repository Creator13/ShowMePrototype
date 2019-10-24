using System;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraZoomer : MonoBehaviour {
	private Camera cam;

	[SerializeField] private float wideFocalLength = 20;
	[SerializeField] private float teleFocalLength = 200;
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
	}

	private void Start() {
		cam.usePhysicalProperties = true;
		Zoom = 0;
	}

	private void Update() {
		bool zoomIn = Input.GetButtonDown("ZoomIn");
		bool zoomOut = Input.GetButtonDown("ZoomOut");

		if (zoomIn && zoomOut) return;

		if (zoomIn) Zoom++;

		if (zoomOut) Zoom--;
	}

	private void UpdateCameraZoom() {
		cam.focalLength = Mathf.Lerp(wideFocalLength, teleFocalLength, Zoom / (zoomLevels - 1f));
	}
}