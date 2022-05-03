using System.Collections;
using Pathfinding;
using Player;
using UnityEngine;

/*
 * RfManager
 * Script to Camera Zoom and Enable Guide after FadeIn.
 */
public class RfManager : MonoBehaviour
{
    private GameObject _guide, _camera, _player;

    private void Awake()
    {
        _guide = GameObject.FindGameObjectWithTag("Guide");
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
        _player = GameObject.FindGameObjectWithTag("Player");
        _guide.GetComponent<AIPath>().enabled = false;
        _camera.GetComponent<CameraProfiler>().enabled = false;
        StartCoroutine(Activate());
    }

    private IEnumerator Activate()
    {
        yield return new WaitForSeconds(2.5f);
        _guide.GetComponent<AIPath>().enabled = true;
        _camera.GetComponent<CameraProfiler>().enabled = true;
    }
}