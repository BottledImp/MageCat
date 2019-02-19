using UnityEngine;
using System.Collections;

public class SpiderShooter : MonoBehaviour
{

    [SerializeField]
    private GameObject bullet;
    public float spawn = 2;

    void Start()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        //yield return new WaitForSeconds (Random.Range(2, 7));
        yield return new WaitForSeconds(spawn);
        Instantiate(bullet, transform.position, Quaternion.identity);
        StartCoroutine(Attack());
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            Destroy(target.gameObject);
        }
    }

}