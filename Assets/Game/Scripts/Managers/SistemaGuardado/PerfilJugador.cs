using UnityEngine;

[System.Serializable]
public class PerfilJugador
{
    public int colect;

    public float posX;
    public float posY;
    public float posZ;

    public string nivel;

    public bool cosa;

    public PerfilJugador()
    {
        cosa = true;

        if(cosa)
        {
            colect = GameManager.Instance.colect;

            posX = GameManager.Instance.posX;
            posY = GameManager.Instance.posY;
            posZ = GameManager.Instance.posZ;

            nivel = GameManager.Instance.nivel;
        }
        
    }
}
