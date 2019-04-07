using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{

    private bool selected;
    private bool isLastSelected;

    public bool isWinner = false;
    public string blockid = "horizontal";
    public string blockidcopy = "horizontal";

    void FixedUpdate()
    {
        if (selected == true && blockid == "horizontal")
        {
            
            this.GetComponent<Rigidbody>().isKinematic = true;
            Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(cursorPos.x, this.transform.position.y, this.transform.position.z);
        }
        else if(selected == true && blockid == "vertical")
        {
            this.GetComponent<Rigidbody>().isKinematic = true;
            Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(this.transform.position.x, cursorPos.y, this.transform.position.z);
        }
        if (Input.GetMouseButtonUp(0))
        {
            selected = false;
        }
    }

    void OnMouseOver()
    {
        
        if (Input.GetMouseButtonDown(0) && (this.gameObject.GetComponent<Drag>().blockid == "horizontal" || this.gameObject.GetComponent<Drag>().blockid == "vertical"))
        {
            selected = true;
            isLastSelected = true;
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        //Debug.Log("Collision Detected!");

        if (this.gameObject.GetComponent<Drag>().isWinner && coll.gameObject.GetComponent<Drag>().isWinner)
        {
            //end the game
            GameObject master = GameObject.Find("Master");
            master.GetComponent<Master>().changeLevels = true;
        }
        
        //selected = false;
    }
    private void OnTriggerStay(Collider coll)
    {   if(this.gameObject.GetComponent<Drag>().blockid != "NO")
        {
            Debug.Log("coll");
            this.gameObject.GetComponent<Drag>().blockid = "InCollision";
        }
       
        string str = coll.gameObject.GetComponent<Drag>().blockid;
        if (this.blockidcopy == "horizontal" && this.isLastSelected)
        {
            if ((this.transform.position.x - coll.GetComponent<Collider>().transform.position.x) < 0)
            {
                Debug.Log("hit right");
                this.transform.position = new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z);
            }
            else if ((this.transform.position.x - coll.GetComponent<Collider>().transform.position.x) > 0)
            {
                Debug.Log("hit left");
                this.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z);
            }
        }
        else if(this.blockidcopy == "vertical" && this.isLastSelected)
        {
            Vector3 dir = (coll.gameObject.transform.position - gameObject.transform.position).normalized;

            if (dir.y > 0)
            {
                Debug.Log("hit top");
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1, this.transform.position.z);
            }
            else if (dir.y < 0)
            {
                Debug.Log("hit bottom");
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
            }
        }
       
        selected = false;
    }

    private void OnTriggerExit(Collider other)
    {
        isLastSelected = false;
        if (this.gameObject.GetComponent<Drag>().blockid != "NO")
        {
            Debug.Log("coll");
            this.gameObject.GetComponent<Drag>().blockid = this.gameObject.GetComponent<Drag>().blockidcopy;
        }

    }
}
