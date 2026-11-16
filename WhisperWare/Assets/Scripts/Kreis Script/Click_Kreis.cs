using UnityEngine;

public class Click_Kreis : MonoBehaviour
{
    
    private Collider2D meinCollider;

    void Start()
    {
        meinCollider = GetComponent<Collider2D>();

        // Schaltet den Collider aus
        meinCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            print("Hilfffffeeeeeeeeeeee");
            meinCollider.enabled = true;
        }
    }
}