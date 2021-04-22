using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundLoop : MonoBehaviour
{
    public GameObject[] layers;
    private Camera mainCamera;
    private Vector2 screenBounds;
    public float choke;                 // Use this to eliminate the spaces between sprites in the background;

    private void Awake()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        foreach (GameObject obj in layers)
        {
            loadChildObjects(obj);
        }
    }

    void loadChildObjects(GameObject obj)
    {
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x - choke;                                   // Gets the width of the current object
        int childsNeeded = (int)Mathf.Ceil(screenBounds.x * 2 / objectWidth);                                           // Determines how many of the current object are needed to fill the screen
        GameObject clone = Instantiate(obj) as GameObject;                                                              // Creates a clone of the object to be used as a reference for the needed childs
        for (int i = 0; i <= childsNeeded; i++)                                                                         // A loop that creates all the childs needed
        {
            GameObject c = Instantiate(clone) as GameObject;                                                            // Creates the child object
            c.transform.SetParent(obj.transform);                                                                       // Sets the original object as it's parent
            c.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);    // Positions the childs after each other in a line
            c.name = obj.name + i;                                                                                      // Sets the name of the child to make it more descriptive
        }
        Destroy(clone);                                                                                                 // Destroy the clone
        Destroy(obj.GetComponent<SpriteRenderer>());                                                                    // Destroy the current object's sprite renderer as it's no longer needed
    }
    void LateUpdate()
    {
        foreach (GameObject obj in layers)
        {
            repositionChildObjects(obj);
        }    
    }

    void repositionChildObjects(GameObject obj)                                                                         // This method takes the first child in an object and repositions it to be the last when the camera passes the first child's edge.
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();                                                // Creates a list of all the components in the objects children
        if (children.Length > 1)                                                                                        // If the object has more than 1 child...
        {
            GameObject firstChild = children[1].gameObject;                                                             // The first child is at index 1 because index 0 is the parent                                                                
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x - choke;                  // Finds the edge of the child's sprite
            if (transform.position.x + screenBounds.x > lastChild.transform.position.x + halfObjectWidth)               // If the camera passes the edge of the first child's sprite...
            {
                firstChild.transform.SetAsLastSibling();                                                                // Moves the child to the bottom of the Unity hierarchy
                // Move the first child's position to the last child's position
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);      
            }
            else if (transform.position.x - screenBounds.x < lastChild.transform.position.x - halfObjectWidth)          // If the camera passes the edge of the last child's sprite...
            {
                lastChild.transform.SetAsFirstSibling();
                // Move the last child's position to the first child's position
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
            }
        }
    }
}
