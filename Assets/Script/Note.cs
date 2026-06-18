using UnityEngine;


public enum NoteType
{
    Standard,
    GhostNote,
    HeldNote
}
public class Note : MonoBehaviour
{
    public float speed = 10f;
    public int lane;
    public int noteLength = 1;
    internal NoteType noteType = NoteType.Standard;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        if(transform.position.y <= -6.7f)
        {
            Poep();
        }
        
    }
    public void Poep()
    {
        inpurmamahger health = GetComponent<inpurmamahger>();

            Debug.Log("Ik doe iets");
            health.health -= 10;
            Destroy(gameObject);
    }
}
