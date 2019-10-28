using UnityEngine;

public interface ISettings {
    SystemSetup Setup { get; }
}

public class Settings : MonoBehaviour, ISettings {
    [SerializeField] private SystemSetup setup;
    public SystemSetup Setup => setup;

    public static ISettings Instance;

    private void Awake() {
        Instance = this;
    }
}
