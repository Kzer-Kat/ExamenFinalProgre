using UnityEngine;

public class AttackTest : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.LeftControl)) // atacar con espacio
        {
            animator.SetTrigger("Attack");
        }
        if (Input.GetKeyDown(KeyCode.RightControl)) // atacar con espacio
        {
            animator.SetTrigger("Hit");
        }
    }
}