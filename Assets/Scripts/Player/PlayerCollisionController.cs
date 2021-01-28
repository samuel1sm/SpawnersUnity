using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    [SerializeField] private int bananaQtd = 0;
    [SerializeField] private float imortalTime = 0;

    private bool isImortal;

    // Start is called before the first frame update

    private BananaHudController bnnController;

    private void Awake()
    {
        bnnController = FindObjectOfType<BananaHudController>();
        bnnController.TextUpdate(bananaQtd);
        isImortal = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollisionVerifier(collision.gameObject);
    }


    private void OnCollisionStay2D(Collision2D collision)
    {


        OnCollisionVerifier(collision.gameObject);


    }

    private void OnCollisionVerifier(GameObject collision)
    {
        if (collision.tag == "Traps" && isImortal == false)
        {
            bananaQtd = bananaQtd - 1;
            bnnController.TextUpdate(bananaQtd);
            isImortal = true;
            StartCoroutine(imortalCountdown());
        }
    }

    IEnumerator imortalCountdown()
    {
        yield return new WaitForSeconds(imortalTime);
        isImortal = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectables")
        {
            bananaQtd = bananaQtd + 1;
            bnnController.TextUpdate(bananaQtd);
            Destroy(collision.gameObject);
        }
        else
        {
            OnCollisionVerifier(collision.gameObject);

        }
    }
}
