using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasrFlying : MonoBehaviour
{
    public flyingenermy[] enermyArray;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (flyingenermy enermy in enermyArray)
            {
                {
                    enermy.chase = true;
                } }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (flyingenermy enermy in enermyArray)
            {
                enermy.chase = false;
            }
        }
    }
}
