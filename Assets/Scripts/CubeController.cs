using UnityEngine;

public class CubeController : MonoBehaviour
{
    private CubeEffects cubeEffect;
    public GameObject cube;
    //private PickupSpawner spawner;

    void Start()
    {
        cubeEffect = GameObject.FindObjectOfType<CubeEffects>();
        //spawner = GameObject.FindObjectOfType<PickupSpawner>();
    }
    void Update()
    {
        transform.Rotate(new Vector3(30, 0, 30) * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            cubeEffect.CubeCollectEffect(cube);
            CoinScore.coinScore -= 1;
            Destroy(cube);
            //spawner.RemoveObject(cube);  I don't want to lose this
        }
    }
}
