using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float jumpForce = 100f;
    public Rigidbody2D rigidbody2D;
    public string currentColor;
    public SpriteRenderer spriteRenderer;

    public Color colorCyan;
    public Color colorMagenta;
    public Color colorYellow;
    public Color colorPink;

    void Start()
    {
        SetRandomColor();
    }

    void Update () {
		if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rigidbody2D.velocity = Vector2.up * jumpForce;
        }
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(collider.gameObject);

            return;
        }

        if (collider.tag != currentColor)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                currentColor = "Cyan";
                spriteRenderer.color = colorCyan;
                break;
            case 1:
                currentColor = "Yellow";
                spriteRenderer.color = colorYellow;
                break;
            case 2:
                currentColor = "Magenta";
                spriteRenderer.color = colorMagenta;
                break;
            case 3:
                currentColor = "Pink";
                spriteRenderer.color = colorPink;
                break;
        }
    }
}
