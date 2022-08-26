using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    [SerializeField]
    GameObject spikePrefab;

    [SerializeField]
    Transform spawnPoint;

    void Start()
    {
        StartCoroutine(SpawnFallingObjects());
    }

    void Update()
    {
        if (spikePrefab.transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator SpawnFallingObjects()
    {
        while (true)
        {
            spikePrefab.transform.Rotate(0f, 0f, 180f);
            Instantiate(
                spikePrefab,
                new Vector3(Random.Range(-10f, 10f), 6f, 0f),
                Quaternion.identity
            );

            yield return new WaitForSeconds(Random.Range(0.3f, 0.6f));
        }
    }
}
