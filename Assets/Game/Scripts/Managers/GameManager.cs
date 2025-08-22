using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int dinero;
    public bool activo = true;

    public int colect;

    public float posX;
    public float posY;
    public float posZ;

    private Transform player;

    public string nivel;

    public string nombreGuardado;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void GuardarDatos()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        posX = player.position.x;
        posY = player.position.y;
        posZ = player.position.z;
        nivel = SceneManager.GetActiveScene().name;
    }

    public void Iniciar()
    {
        StartCoroutine(Mover());
    }

    private IEnumerator Mover()
    {
        yield return new WaitForSeconds(1);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        CharacterController ctrl = player.GetComponent<CharacterController>();
        ctrl.enabled = false;
        player.transform.position = new Vector3(GameManager.Instance.posX, GameManager.Instance.posY, GameManager.Instance.posZ);
        ctrl.enabled = true;
        Debug.Log("Aki");
    }
}
