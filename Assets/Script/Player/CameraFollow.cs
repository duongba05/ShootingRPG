using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Cinemachine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public CinemachineCamera virtualCam;

    void Start()
    {
        StartCoroutine(FindAndSetPlayer());
    }

    IEnumerator FindAndSetPlayer()
    {
        yield return null;

        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            virtualCam.Follow = player.transform;
            virtualCam.LookAt = player.transform;
        }
        else
        {
        }
    }
}
