using UnityEngine;

public class rotatecoin : MonoBehaviour
{
   
    public float rotatespeed = 100f;
    void Update()
    {
        transform.Rotate(0,rotatespeed*Time.deltaTime,0);
    }
}
