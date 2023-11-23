using System.Collections;
using UnityEngine;

public class PosteQueimado : MonoBehaviour
{
    [SerializeField] float intervaloPiscar = .8f;
    [SerializeField] GameObject luz;

    private void Start()
    {
        StartCoroutine(PiscarLuz());
    }

    IEnumerator PiscarLuz()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervaloPiscar);
            luz.SetActive(!luz.activeInHierarchy);
        }
    }
}
