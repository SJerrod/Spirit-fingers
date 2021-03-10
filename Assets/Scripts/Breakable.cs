using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Breakable : MonoBehaviour
{
    public float hp;
    public GameObject brokenCube;
    public float breakForce;

    public SteamVR_Action_Boolean punch;
    private SteamVR_Input_Sources punchInput;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "THROWABLE" || other.gameObject.tag == "GROUND")
        {
            hp--;
        }

        if (punch.GetState(punchInput) && other.gameObject.tag == "HAND")
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
