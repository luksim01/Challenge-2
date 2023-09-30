using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool dogCooldown = false;
    private float cooldownTime = 3;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog provided dog isn't in cooldown
        if (Input.GetKeyDown(KeyCode.Space) && !dogCooldown)
        {
            // coroutine runs spawnDog method asynchronously with the main game loop
            StartCoroutine("spawnDog");
        }
    }

    IEnumerator spawnDog()
    {
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

        dogCooldown = true;
        // yield pauses spawnDog method until cooldown timer is done
        yield return new WaitForSeconds(cooldownTime);
        dogCooldown = false;
    }
}
