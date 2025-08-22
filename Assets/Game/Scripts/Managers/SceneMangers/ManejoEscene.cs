using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManejoEscene : MonoBehaviour
{
    public static ManejoEscene Instance;

    private string nivelVoy;
    private string areaVoy;
    private bool AreaEspecifico;

    private Animator anim;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        anim = transform.GetChild(0).transform.GetChild(0).GetComponent<Animator>();
    }

    public void CambioEscena(string nivel, bool especifico, string area)
    {
        nivelVoy = nivel;
        areaVoy = area;
        AreaEspecifico = especifico;
              
        StartCoroutine(Waiter());
    }

    IEnumerator Waiter()
    {
        GameManager.Instance.activo = false;
        anim.SetBool("Active", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nivelVoy);
        yield return new WaitForSeconds(.5f);
        if (AreaEspecifico)
        {
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            player.GetComponent<CharacterController>().enabled = false;
            Transform spawnPoint = GameObject.Find(areaVoy).transform;
            player.position = spawnPoint.position;
            player.rotation = spawnPoint.rotation;
            player.GetComponent<CharacterController>().enabled = true;
        }
        anim.SetBool("Active", false);
        GameManager.Instance.activo = true;
    }
}
