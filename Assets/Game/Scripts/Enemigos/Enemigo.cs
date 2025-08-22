using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawPoint;

    private Vector3 iniPos;

    private NavMeshAgent agent;
    private Transform jugador;

    private bool detect;
    [SerializeField]
    private float radio;
    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private Transform[] posicion;

    public int cordenada = 0;

    private bool musicStart;


    private void Start()
    {
        iniPos = transform.position;
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        detect = Physics.CheckSphere(transform.position, radio, mask);

        if(Vector3.Distance(transform.position, posicion[cordenada].position) < 1) 
        {
            cordenada++;
            if(cordenada >= posicion.Length)
            {
                cordenada = 0;
            }
        }

        if (detect)
        {
            if(!musicStart)
            {
                AudioManager.Instance.Play("Candy");
                AudioManager.Instance.Stop("Happy");
                musicStart = true;
            }
         
            agent.SetDestination(jugador.position);
            agent.stoppingDistance = 3;
        }
        else
        {
            agent.SetDestination(posicion[cordenada].position);
            agent.stoppingDistance = 0;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Instantiate(prefab, spawPoint.position, spawPoint.rotation);

        }
    }
}
