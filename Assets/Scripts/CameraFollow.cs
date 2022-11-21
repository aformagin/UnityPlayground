using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public Transform player;

    // Update is called once per frame
    void Update () {
        transform.position = player.transform.position + new Vector3(0, 1, 0);
        // transform.rotation = player.rotation;
        // this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(45,0,0));
    }
}
