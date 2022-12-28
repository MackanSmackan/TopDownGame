using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoomFollow : MonoBehaviour
{
    [SerializeField] GameObject Camera;
    [SerializeField] Transform RoomTransform1;
    [SerializeField] Transform RoomTransform2;
    [SerializeField] Transform RoomTransform3;
    [SerializeField] Transform RoomTransform4;
    [SerializeField] Transform RoomTransform5;
    [SerializeField] Transform RoomTransform6;
    [SerializeField] Transform RoomTransformCor;
    [SerializeField] Transform RoomTransformSpawn;
    [SerializeField] float TD = 0.75f;

    IEnumerator SmoothTranstion1()
    {
        float time = 0.0f;
        Vector3 StartPos = Camera.transform.position;

        while (time < 1.0f)
        {
            time += Time.deltaTime * (Time.timeScale / TD);
            Camera.transform.position = Vector3.Lerp(StartPos, RoomTransform1.position, time);
            yield return 0;
        }
    }
    IEnumerator SmoothTranstion2()
    {
        float time = 0.0f;
        Vector3 StartPos = Camera.transform.position;

        while (time < 1.0f)
        {
            time += Time.deltaTime * (Time.timeScale / TD);
            Camera.transform.position = Vector3.Lerp(StartPos, RoomTransform2.position, time);
            yield return 0;
        }
    }
    IEnumerator SmoothTranstion3()
    {
        float time = 0.0f;
        Vector3 StartPos = Camera.transform.position;

        while (time < 1.0f)
        {
            time += Time.deltaTime * (Time.timeScale / TD);
            Camera.transform.position = Vector3.Lerp(StartPos, RoomTransform3.position, time);
            yield return 0;
        }
    }
    IEnumerator SmoothTranstion4()
    {
        float time = 0.0f;
        Vector3 StartPos = Camera.transform.position;

        while (time < 1.0f)
        {
            time += Time.deltaTime * (Time.timeScale / TD);
            Camera.transform.position = Vector3.Lerp(StartPos, RoomTransform4.position, time);
            yield return 0;
        }
    }
    IEnumerator SmoothTranstion5()
    {
        float time = 0.0f;
        Vector3 StartPos = Camera.transform.position;

        while (time < 1.0f)
        {
            time += Time.deltaTime * (Time.timeScale / TD);
            Camera.transform.position = Vector3.Lerp(StartPos, RoomTransform5.position, time);
            yield return 0;
        }
    }

    IEnumerator SmoothTranstion6()
    {
        float time = 0.0f;
        Vector3 StartPos = Camera.transform.position;

        while (time < 1.0f)
        {
            time += Time.deltaTime * (Time.timeScale / TD);
            Camera.transform.position = Vector3.Lerp(StartPos, RoomTransform6.position, time);
            yield return 0;
        }
    }
    IEnumerator SmoothTranstionCor()
    {
        float time = 0.0f;
        Vector3 StartPos = Camera.transform.position;

        while (time < 1.0f)
        {
            time += Time.deltaTime * (Time.timeScale / TD);
            Camera.transform.position = Vector3.Lerp(StartPos, RoomTransformCor.position, time);
            yield return 0;
        }


    }

    IEnumerator SmoothTranstionSpawn()
    {
        float time = 0.0f;
        Vector3 StartPos = Camera.transform.position;

        while (time < 1.0f)
        {
            time += Time.deltaTime * (Time.timeScale / TD);
            Camera.transform.position = Vector3.Lerp(StartPos, RoomTransformSpawn.position, time);
            yield return 0;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Room1")
        {
            StartCoroutine(SmoothTranstion1());
        }

        if (collision.name == "Room2")
        {
            StartCoroutine(SmoothTranstion2());
        }

        if (collision.name == "Room3")
        {
            StartCoroutine(SmoothTranstion3());
        }

        if (collision.name == "Room4")
        {
            StartCoroutine(SmoothTranstion4());
        }

        if (collision.name == "Room5")
        {
            StartCoroutine(SmoothTranstion5());
        }

        if (collision.name == "Room6")
        {
            StartCoroutine(SmoothTranstion6());
        }

        if (collision.name == "Corridor1")
        {
            StartCoroutine(SmoothTranstionCor());
        }

        if (collision.name == "Spawn")
        {
            StartCoroutine(SmoothTranstionSpawn());
        }
    }
}
