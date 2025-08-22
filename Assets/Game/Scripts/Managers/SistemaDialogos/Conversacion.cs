using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Conversacion : MonoBehaviour
{
    [SerializeField]
    private float velocidadText;

    [SerializeField]
    private Dialogos[] dialogo;

    [SerializeField]
    private GameObject sistemaDialogos;
    [SerializeField]
    private Image caja;
    [SerializeField]
    private Image per1;
    [SerializeField]
    private Image per2;
    [SerializeField]
    private TextMeshProUGUI nombre;
    [SerializeField]
    private TextMeshProUGUI texto;

    private bool check;

    private bool inside;
    [SerializeField]
    private float radio;
    [SerializeField]
    private LayerMask playerLayer;

    private bool active = false;

    private int linea = 0;

    private IEnumerator co;

    private void OnMouseEnter()
    {
        check = true;
    }

    private void OnMouseExit()
    {
        check = false;
    }

    private void Update()
    {
        inside = Physics.CheckSphere(transform.position, radio, playerLayer);

        if(Input.GetKeyDown(KeyCode.E) && check && inside && !active && dialogo.Length > linea)
        {
            sistemaDialogos.SetActive(true);
            nombre.text = dialogo[linea].nombre;
            co = PrintText(dialogo[linea].texto);
            StartCoroutine(co);
            caja.sprite = dialogo[linea].box;
            per1.sprite = dialogo[linea].personaje1;
            per2.sprite = dialogo[linea].personaje2;
            linea++;
        }
        else if(Input.GetKeyDown(KeyCode.E) && check && inside && active && dialogo.Length > linea)
        {
            active = false;
            StopCoroutine(co);
            sistemaDialogos.SetActive(true);
            nombre.text = dialogo[linea].nombre;
            co = PrintText(dialogo[linea].texto);
            StartCoroutine(co);
            caja.sprite = dialogo[linea].box;
            per1.sprite = dialogo[linea].personaje1;
            per2.sprite = dialogo[linea].personaje2;
            linea++;
        }
        else if (Input.GetKeyDown(KeyCode.E) && check && inside)
        {
            linea = 0;
            nombre.text = null;
            texto.text = null;
            caja.sprite = null;
            per1.sprite = null;
            per2.sprite = null;
            sistemaDialogos.SetActive(false);
        }
    }

    private IEnumerator PrintText(string palabras)
    {
        active = true;

        for(int i = 0; i <= palabras.Length; i++)
        {
            texto.text = palabras.Substring(0,i);
            yield return new WaitForSeconds(velocidadText);
        }

        active = false;
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
