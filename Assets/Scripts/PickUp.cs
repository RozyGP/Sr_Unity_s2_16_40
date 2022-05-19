using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public AudioClip pickedClip;

    void Update()
    {
        Rotation();
    }

    public virtual void Picked()
    {
        Debug.Log("Picked");
        Destroy(this.gameObject);
    }

    public void Rotation()
    {
        transform.Rotate(new Vector3(0, 1f, 0));
    }
}
