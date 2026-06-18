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
<<<<<<< HEAD
            Poep();
=======
            inpurmamahger healthManager = FindObjectOfType<HealthManager>();
            if (healthManager != null)
            {
                healthManager.TakeDamage(10);
            }
>>>>>>> cc94bed76ec807e23e711940dd22142005af03a9
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
