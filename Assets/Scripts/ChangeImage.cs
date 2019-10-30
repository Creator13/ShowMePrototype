using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Image image;
    private Sprite sprite;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            sprite = Resources.Load<Sprite>("Earth_info2");
            image = this.GetComponent<Image>();
            image.sprite = sprite;

        }
    }
}
