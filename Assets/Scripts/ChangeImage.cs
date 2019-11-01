using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ChangeImage : MonoBehaviour
    {
        private Image image;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        private void Start()
        {
            UIEvents.Instance.targetUpdated += SetPlanet;
        }

        private void OnDisable()
        {
            UIEvents.Instance.targetUpdated -= SetPlanet;
        }

        private void SetPlanet(Planet target)
        {
            image.enabled = target ? true : false;
            if (target)
            {
                image.sprite = target.hasSattelite ? target.info2 : target.info1;
            }
            
        }
    }
}






//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class ChangeImage : MonoBehaviour
//{
//    public Image image;
//    private Sprite sprite;


//    // Use this for initialization
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Z))
//        {
//            sprite = Resources.Load<Sprite>("Earth_info2");
//            image = this.GetComponent<Image>();
//            image.sprite = sprite;

//        }
//    }
//}
