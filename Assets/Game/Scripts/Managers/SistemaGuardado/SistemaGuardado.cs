using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SistemaGuardado
{
    public static void GuardarPartida()
    {
        // Direccion donde se guarda el archivo
        string path = Application.dataPath + GameManager.Instance.nombreGuardado;

        // Se crea un flujo de informacion con la direccion y accion
        FileStream stream = new FileStream(path, FileMode.Create);

        // Mandamos a llamar la info que se va a guardar
       PerfilJugador perfil = new PerfilJugador();

        // Creamos una variable de formateo binario
        BinaryFormatter formatter = new BinaryFormatter();

        // Encriptar en binario la info
        formatter.Serialize(stream, perfil);

        // Se cierra el flujo de la informacion
        stream.Close();
    }

    public static PerfilJugador CargarPartida()
    {
        // Direccion donde se guarda el archivo
        string path = Application.dataPath + GameManager.Instance.nombreGuardado;

        if(File.Exists(path))
        {
            // Se crea un flujo de informacion con la direccion y accion
            FileStream stream = new FileStream(path, FileMode.Open);

            // Creamos una variable de formateo binario
            BinaryFormatter formatter = new BinaryFormatter();

            // Descomprimir archivo
            PerfilJugador perfil = formatter.Deserialize(stream) as PerfilJugador;

            // Se cierra el flujo de la informacion
            stream.Close();

            return perfil;
        }
        else
        {
            Debug.Log("No se encontro archivo");

            return null;
        }
    }
}
