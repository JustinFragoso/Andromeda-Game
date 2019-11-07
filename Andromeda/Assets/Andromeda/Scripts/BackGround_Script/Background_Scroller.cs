using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Scroller : MonoBehaviour
{
    public float scrollSpeed;                                       // float var that will determine the scroll speed of the BG
    public float tileSizeZ;                                        // float var for the background tile size a;long the z axis 

    private Vector3 StartPosition;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPostion = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
        transform.position = StartPosition + Vector3.forward * newPostion;
    }
}
