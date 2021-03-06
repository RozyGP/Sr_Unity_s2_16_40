using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    bool iCanOpen = false;
    public Door door;
    public KeyColor myColor;
    bool locked = false;
    Animator key;

    public Material red;
    public Material green;
    public Material gold;

    public Renderer myLock;

    private void Start()
    {
        key = GetComponent<Animator>();
        SetMyColor();
    }

    void SetMyColor()
    {
        switch (myColor)
        {
            case KeyColor.Red:
                GetComponent<Renderer>().material = red;
                myLock.material = red;
                break;
            case KeyColor.Green:
                GetComponent<Renderer>().material = green;
                myLock.material = green;
                break;
            case KeyColor.Gold:
                GetComponent<Renderer>().material = gold;
                myLock.material = gold;
                break;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && iCanOpen && !locked)
        {
            key.SetBool("useKey", CheckTheKey());
        }
    }

    public void UseKey()
    {
        door.CloseOpen();
    }

    public bool CheckTheKey()
    {
        if(GameManager.gameManager.redKey > 0 && myColor==KeyColor.Red)
        {
            GameManager.gameManager.redKey--;
            locked = true;
            return true;
        }
        else if (GameManager.gameManager.greenKey > 0 && myColor == KeyColor.Green)
        {
            GameManager.gameManager.greenKey--;
            locked = true;
            return true;
        }
        else if (GameManager.gameManager.goldKey > 0 && myColor == KeyColor.Gold)
        {
            GameManager.gameManager.goldKey--;
            locked = true;
            return true;
        }
        else
        {
            Debug.Log("No key!");
            return false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            iCanOpen = true;
            Debug.Log("You can use the lock.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            iCanOpen = false;
            Debug.Log("You cannot use the lock.");
        }
    }
}
