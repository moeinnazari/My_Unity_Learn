using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed=10f;
    private Rigidbody playerRB;
    private GameObject focalPoint;
    public GameObject powerUpIndicator;
    // Start is called before the first frame update
    void Start()
    {
        playerRB=GetComponent<Rigidbody>();
        focalPoint=GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float moveV=Input.GetAxisRaw("Vertical");
        float moveH=Input.GetAxisRaw("Horizontal");
        
        playerRB.AddForce(focalPoint.transform.forward*moveV*speed);
         playerRB.AddForce(focalPoint.transform.right*moveH*speed);
         powerUpIndicator.gameObject.transform.position=transform.position+new Vector3(0,-0.5f,0);
    }

    public bool hasPowerUp=false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUp"))
        {
            hasPowerUp=true;
            Destroy(other.gameObject);
            powerUpIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerUpCountDown());
        }
    }

    IEnumerator PowerUpCountDown()
    {
        yield return  new WaitForSeconds(9);
        hasPowerUp=false;
        powerUpIndicator.gameObject.SetActive(false);

    }

    public float strengthPower=15f;
    private void OnCollisionEnter(Collision other)
    {

        if(other.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemRB=other.gameObject.GetComponent<Rigidbody>();
            Vector3 enemyAwayFromPlayer=(other.gameObject.transform.position-transform.position);
            enemRB.AddForce(enemyAwayFromPlayer*strengthPower,ForceMode.Impulse);
            Debug.Log("Collided with "+other.gameObject.name + "set up powerup with "+hasPowerUp);
        }
    }
}
