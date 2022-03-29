using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public Transform teleportPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = new Vector3 (teleportPosition.position.x, teleportPosition.position.y,-5);
        collision.GetComponent<CharacterManager>().rg.velocity = Vector2.zero;
    }
}
