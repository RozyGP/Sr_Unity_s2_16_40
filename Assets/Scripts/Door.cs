using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform closePosition;
    public Transform openPosition;
    public Transform door;

    public bool open = false;
    public float speed = 1f;

    private void Start()
    {
        door.position = closePosition.position;
    }

    public void CloseOpen()
    {
        open = !open;
    }

    private void Update()
    {
        if (open && Vector3.Distance(door.position, openPosition.position) > 0.001f)
        {
            door.position = Vector3.MoveTowards(door.position,
                openPosition.position, Time.deltaTime * speed);
        }

        if (!open && Vector3.Distance(door.position, closePosition.position) > 0.001f)
        {
            door.position = Vector3.MoveTowards(door.position,
                closePosition.position, Time.deltaTime * speed);
        }
    }
}
