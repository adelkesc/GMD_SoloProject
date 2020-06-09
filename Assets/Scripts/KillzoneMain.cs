using System.Collections;
using UnityEngine;

public class KillzoneMain : MonoBehaviour
{
    public GameObject killBoundary;
    public float moveSpeed;

    private bool isPaused;

    //public List<string> tags = new List<string>() { "Cube", "Coin", "Collected" };;
    //public List<GameObject> toDestroy = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PauseForPlayer());
        isPaused = true;
    }
    void Update()
    {
        //The plane is rotated so it uses the Y axis to move in the Z axis.
        if(!isPaused)
        {
            killBoundary.transform.Translate(new Vector3(0, moveSpeed, 0) * Time.deltaTime);
        }
    }
    IEnumerator PauseForPlayer()
    {
        yield return new WaitForSeconds(5f);
        isPaused = false;
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        //For some reason other.gameObject.tag will never return the same "tag" as toDestroy[i].tag
        //It must be toDestroy[i].name, be careful.
        for (int i = 0; i < toDestroy.Count; i++) //tags.count
        {
            if (other.gameObject.tag == toDestroy[i].name)
            {
                destroyObj.KillzoneDestroy(toDestroy[i]);
                //only detects objects with colliders.  the empty gameobjects don't have colliders, only tags
                //try making an list of gameobjects and adding them in the inspector
            }
            else
            {
                Debug.Log("ObjectNothing");
            }
        }

    }
    */
}
