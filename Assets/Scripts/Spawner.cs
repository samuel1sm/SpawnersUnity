using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float itemVelocity;
    [SerializeField] private float maxItemCount;
    [SerializeField] private float spawnTime;
    [SerializeField] private float despawnTime;
    [SerializeField] private GameObject spawnBag;
    [SerializeField] private GameObject itemToBeSpawned;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnerCouroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnerCouroutine()
    {
        while (true)
        {
            yield return new WaitUntil(() => maxItemCount > spawnBag.transform.childCount);

            yield return new WaitForSeconds(spawnTime);
            GameObject newItem = Instantiate(itemToBeSpawned, transform.position, transform.rotation, spawnBag.transform);
            Rigidbody2D rb = newItem.GetComponent<Rigidbody2D>();
            rb.velocity = transform.right * -1 * itemVelocity;
            Destroy(newItem, despawnTime);
        }
    }
}
