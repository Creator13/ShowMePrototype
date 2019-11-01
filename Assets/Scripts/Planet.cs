using UnityEngine;

public class Planet : MonoBehaviour {
    [SerializeField] private new string name;
    public string Name => name;

    public Sprite info1;
    public Sprite info2;

    public bool hasSattelite = false;
    public Sprite shownInfo;
}
