using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Transform>().position = new Vector3(canvas.GetComponent<Transform>().position.x, 
            canvas.GetComponent<Transform>().position.y, transform.position.z);
    }
}
