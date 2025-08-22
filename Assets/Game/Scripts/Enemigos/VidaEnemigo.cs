using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    [SerializeField]
    int vida;

    public void DanioEnemigo(int danio)
    {
        vida -= danio;

        if( vida <= 0 )
        {
            Destroy( this.gameObject );
        }
    }
}
