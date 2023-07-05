using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoomFollow : MonoBehaviour
{
    [SerializeField] GameObject Camera;
    [SerializeField] GameObject[] Rooms;
    public GameObject CurrentRoom;
    [SerializeField] float TD = 0.75f;
    bool Moving = false;

    IEnumerator SmoothTransition(GameObject RoomTransform)
    {
        float time = 0.0f;
        Vector3 StartPos = Camera.transform.position;
        if (!Moving)
        {
            Moving = true;
        }

        while (time < 1.0f)
        {
            time += Time.deltaTime * (Time.timeScale / TD);
            Camera.transform.position = Vector3.Lerp(StartPos, RoomTransform.transform.position, time);
            if (time >= 1)
            {
                Moving = false;
            }
            yield return 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach(GameObject Room in Rooms)
        {
            
            if (collision.transform.gameObject == Room)
            {
                if (!Moving)
                {
                    StartCoroutine(SmoothTransition(Room));
                }
                
            }
        }
    }
}
