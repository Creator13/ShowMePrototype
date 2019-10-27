using System;
using TMPro;
using UnityEngine;

namespace UI {
[RequireComponent(typeof(TextMeshProUGUI))]
public class PlanetText : MonoBehaviour {
    private TextMeshProUGUI text;

    private void Awake() {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Start() {
        UIEvents.Instance.targetUpdated += SetPlanet;
    }

    private void OnDisable() {
        UIEvents.Instance.targetUpdated -= SetPlanet;
    }

    private void SetPlanet(Planet target) {
        text.text = target ? target.Name : "";
    }
}
}
