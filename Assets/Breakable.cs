using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public float hp;
    public GameObject brokenCube;
    public float breakForce;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "THROWABLE" || other.gameObject.tag == "GROUND" || other.gameObject.tag == "HAND")
        {
            hp--;
        }
    }

    void Update()
    {
        if (hp == 0)
            Shatter();
    }

    public void Shatter()
    {
        GameObject frac = Instantiate(brokenCube, transform.position, transform.rotation);
        foreach(Rigidbody rb in frac.GetComponentsInChildren<Rigidbody>())
        {
            Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
            rb.AddForce(force);
        }
        Destroy(gameObject);
    }
}
