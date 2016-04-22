using UnityEngine;
using System.Collections;

public class linemonsrer : MonoBehaviour
{
    public Transform bullet;
    public Transform target;
    public bool isJumpable = false;
    public float jumpPause = 1f;
    public float jumpForce = 100f;
    public bool isDANGERIOUS = false;

    public float speed = 1f;
    float facedX = 1;
    Vector3 baseScale;

    void Start()
    {
        baseScale = transform.localScale;
        if (isJumpable)
            InvokeRepeating("Jump", Random.Range(0f,1f), jumpPause);
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Jump()
    {
        if (Time.timeScale==1f)
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
            transform.Translate((target.position - transform.position).normalized * Time.deltaTime * speed);

        var newFaced = transform.position.x < target.position.x ? -1 : 1;
        if (newFaced != facedX)
        {
            transform.localScale = new Vector3(newFaced * baseScale.x, baseScale.y, baseScale.z);
            facedX = newFaced;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!isDANGERIOUS)
            return;

        if (coll.gameObject.tag == "Player")
            LevelManager.RestartLevel();
    }

    void OnDestroy()
    {
        FadeManager.Hurt();
    }
}
