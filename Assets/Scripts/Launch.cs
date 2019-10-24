using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    public GameObject target;
    public GameObject sattelitePrefab;
    public float speed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject sattelite = Instantiate(sattelitePrefab, transform.position, Quaternion.identity);
            sattelite.transform.LookAt(target.transform.position);

            Vector3 vector = target.transform.position - transform.position;
            vector.Normalize();
            sattelite.GetComponent<Rigidbody>().AddForce(vector * speed);
        }
    }
}
