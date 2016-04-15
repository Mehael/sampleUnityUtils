using UnityEngine;

public class ScriptScrollingBackground : MonoBehaviour
{
    private Vector3 savedOffset;
    public GameObject hero;
    public float scrollSpeed;

    private void Start()
    {
        savedOffset = hero.transform.position;
    }

    private void FixedUpdate()
    {
        if (hero == null) return;
        var offset = new Vector2(Mathf.Repeat(hero.transform.position.x*scrollSpeed, 1),
            Mathf.Repeat(hero.transform.position.y*scrollSpeed, 1));
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
        transform.Translate(hero.transform.position - savedOffset);
        savedOffset = hero.transform.position;
    }

    private void OnDisable()
    {
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", new Vector2());
    }
}