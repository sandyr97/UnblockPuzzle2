using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{

    private bool selected; /*<Is this block currently selected?>*/
    private bool isLastSelected; /*<Was this block last selected?>*/

    public bool isWinner = false; /*<Is this block one of the red "winner" blocks?>*/
    public string blockid = "horizontal"; /*<The blockid. Denotes which axis the block may slide on (if it may slide at all).>*/
    public string blockidcopy = "horizontal"; /*<A copy of blockid. May be set differently for unusual block behavior.>*/

    /**
     * Method: FixedUpdate()
     * Params: None
     * Description: if block is selected and may move, move it with the user mouse along the appropriate axis.
     */
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

    /**
    * Method: OnMouseOver()
    * Params: None
    * Description: if the user clicks a block and it may move, set it as selected and last selected.
    */
    void OnMouseOver()
    {
        
        if (Input.GetMouseButtonDown(0) && (this.gameObject.GetComponent<Drag>().blockid == "horizontal" || this.gameObject.GetComponent<Drag>().blockid == "vertical"))
        {
            selected = true;
            isLastSelected = true;
        }
    }

    /**
    * Method: OnTriggerEnter()
    * Params: coll , the collider box of the box the selected box collided with.
    * Description: if the collided box and the selected box are both "winner" boxes, tell "Master" to change levels.
    */
    private void OnTriggerEnter(Collider coll)
    {

        if (this.gameObject.GetComponent<Drag>().isWinner && coll.gameObject.GetComponent<Drag>().isWinner)
        {
            //end the game
            GameObject master = GameObject.Find("Master");
            master.GetComponent<Master>().changeLevels = true;
        }
        
     
    }

    /**
    * Method: OnTriggerStay()
    * Params: coll , the collider box of the box the selected box collided with.
    * Description: While remaining in a collision, move the selected box away from the box it collided with.
    *              Also, lock motion so the user cannot force the block through.
    */
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

    /**
    * Method: OnTriggerExit()
    * Params: coll , the collider box of the box the selected box collided with.
    * Description: After resolving a collision, set everything back to normal.
    */
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
