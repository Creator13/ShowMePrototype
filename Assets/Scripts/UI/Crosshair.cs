using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
[RequireComponent(typeof(Image))]
public class Crosshair : MonoBehaviour {
    private Image image;

    private bool crosshairActive;

    private bool CrosshairActive {
        set {
            crosshairActive = value;

            image.color = value ? Color.blue : Color.cyan;
        }
    }

    private void Awake() {
        image = GetComponent<Image>();
    }

    private void Start() {
        UIEvents.Instance.targetUpdated += CheckTarget;
    }
    
    private void OnDisable() {
        UIEvents.Instance.targetUpdated -= CheckTarget;
    }

    private void CheckTarget(Planet target) {
        // Implicitly convert gameObject to bool yields false if gameObject is null or inactive or destroyed (see Unity)
        CrosshairActive = target;
    }
}
}
