using System.Collections;
using Guide;
using UnityEngine;

public class DrivingSettings : MonoBehaviour
{
    public GameObject guide, dummyGuide, player, dummy, gd;
    public GameObject dashCam, mainCam;
    public AudioSource drivingMusic, carSound;
    public GameObject[] cinematicBorders;

    private void OnTriggerEnter(Collider other)
    {
        // Cinema borders
        CinemaMode(true, false);
        // Music and audio.
        drivingMusic.Play();
        carSound.Play();
        // Cameras.
        dashCam.SetActive(true);
        mainCam.SetActive(false);
        //Player & Guide.
        dummy.SetActive(true);
        player.SetActive(false);
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        // Player & Guide.
        player.transform.position = new Vector3(92f, 0.50f, -20f);
        yield return new WaitForSeconds(1f);
        guide.transform.position = new Vector3(95f, 1.5f, -20f);
        guide.SetActive(false);
        dummyGuide.SetActive(true);
        yield return new WaitForSeconds(50f);
        // Cinema Borders
        CinemaMode(false, true);
        // Cameras.
        dashCam.SetActive(false);
        mainCam.SetActive(true);
        // Player & guide.
        dummy.SetActive(false);
        dummyGuide.SetActive(false);
        player.SetActive(true);
        guide.SetActive(true);
        StartCoroutine(Dialogue());
    }

    private IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(2f);
        // Dialogue
        gd.GetComponent<GuideDialogue>().WelcomeHome();
    }

    private void CinemaMode(bool fadeIn, bool fadeOut)
    {
        cinematicBorders[0].GetComponent<Animator>().SetBool("FadeIn", fadeIn);
        cinematicBorders[1].GetComponent<Animator>().SetBool("FadeIn", fadeIn);
        cinematicBorders[0].GetComponent<Animator>().SetBool("FadeOut", fadeOut);
        cinematicBorders[1].GetComponent<Animator>().SetBool("FadeOut", fadeOut);
    }
}
