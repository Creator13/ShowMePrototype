using UnityEngine;

namespace UI {

public delegate void UpdateTarget(Planet target);

public class UIEvents {
    private static UIEvents instance;
    public static UIEvents Instance => instance ?? (instance = new UIEvents());

    public UpdateTarget targetUpdated;
}
}
