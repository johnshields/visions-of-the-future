using System.Collections;
using UnityEngine;

public class DrivingSettings : MonoBehaviour
{
    public GameObject guide, dummyGuide, player, dummy;
    public GameObject dashCam, mainCam;
    public AudioSource drivingMusic;

    private void OnTriggerEnter(Collider other)
    {
        drivingMusic.Play();
        dashCam.SetActive(true);
        mainCam.SetActive(false);
        dummy.SetActive(true);
        player.SetActive(false);
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        player.transform.position = new Vector3(92f, 0.50f, -20f);
        yield return new WaitForSeconds(1f);
        guide.transform.position = new Vector3(98f, 1.5f, -20f);
        guide.SetActive(false);
        dummyGuide.SetActive(true);
        yield return new WaitForSeconds(50f);
        dashCam.SetActive(false);
        mainCam.SetActive(true);
        dummy.SetActive(false);
        dummyGuide.SetActive(false);
        player.SetActive(true);
        guide.SetActive(true);
    }
}
