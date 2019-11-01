using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sattelite : MonoBehaviour
{
    public float speed;

    private bool orbit;
    private Transform planet;

    private void Update()
    {
        if (orbit)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(planet.position, axis, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Planet"))
        {
            orbit = true;
            planet = collision.transform;
            transform.position = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);

            Planet target = collision.gameObject.GetComponent<Planet>();
            target.hasSattelite = true;
        }
    }
}
