using UnityEngine;

public class Musica : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.Instance.Play("Chill");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
