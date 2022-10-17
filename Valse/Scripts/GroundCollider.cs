using UnityEngine;

public class GroundCollider : MonoBehaviour {


public Texture2d text;


void Awake() {

    SpriteRenderer sprite = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
    transform.position = new Vector3(0.0f, -2.0f, 0.0f);
}
public class GroundCollider : MonoBehaviour {


