
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargaInicio : MonoBehaviour
{
    private PerfilJugador perfil;

    public void InicioJuego(string nombreGuardado)
    {
        GameManager.Instance.nombreGuardado = nombreGuardado;

        perfil = SistemaGuardado.CargarPartida();

        if(perfil != null)
        {
            GameManager.Instance.colect = perfil.colect;

            GameManager.Instance.posX = perfil.posX;
            GameManager.Instance.posY = perfil.posY;
            GameManager.Instance.posZ = perfil.posZ;
            GameManager.Instance.nivel = perfil.nivel;

            GameManager.Instance.Iniciar();
            SceneManager.LoadScene(GameManager.Instance.nivel);
        }
        else
        {
            SceneManager.LoadScene("Mundo2");
        }
    }
}
