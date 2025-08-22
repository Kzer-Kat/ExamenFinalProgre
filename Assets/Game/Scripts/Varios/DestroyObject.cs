using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private int vida;

    [SerializeField] private GameObject obj;

    [SerializeField] private Transform spawn;

    public void Danio(int danio)
    {
        int rand = Random.Range(1, 4);

        for (int i = 0; i < rand; i++)
        {
            GameObject clon = Instantiate(obj, spawn.position, Quaternion.identity);

            int rx = Random.Range(1, 361);
            int ry = Random.Range(1, 361);
            int rz = Random.Range(1, 361);
            clon.transform.rotation = Quaternion.Euler(rx, ry, rz);

            int dx = Random.Range(1, 100);
            int dy = Random.Range(1, 100);
            int dz = Random.Range(1, 100);
            clon.GetComponent<Rigidbody>().AddForce(new Vector3(dx,dy,dz));
        }
        
        vida -= danio;

        if(vida <= 0)
        {
            Instantiate(obj, spawn.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
