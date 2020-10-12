using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPadChecker : MonoBehaviour
{
    public Vector2 sendToPosition = Vector2.zero;

    void OnTriggerEnter2D(Collider2D coll)
    {
        coll.gameObject.transform.position = sendToPosition;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
