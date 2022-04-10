using System.Collections;
using UnityEngine;

public class TransportGuide : MonoBehaviour
{
    public GameObject guide;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        guide.transform.position = new Vector3(102.42f, 1.44f, -19.32f);
        yield return new WaitForSeconds(1f);
        guide.SetActive(false);
        yield return new WaitForSeconds(50f);
        guide.SetActive(true);
    }
}
