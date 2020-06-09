using UnityEngine;

public class PlayerDeathMain : MonoBehaviour
{
    private PlayerEffects effects;

    private float deathZone;
    private float currentPosition;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        deathZone = transform.position.y - 5;
        effects = GameObject.FindObjectOfType<PlayerEffects>();
    }
    void Update()
    {
        currentPosition = player.transform.position.y;
        if (currentPosition <= deathZone)
        {
            PlayerDeath();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Killzone"))
        {
            PlayerDeath();
        }
    }
    public void PlayerDeath()
    {
        effects.PlayerDeathEffect();
        AudioManagerMain.instance.Play("PlayerDeath");
        player.SetActive(false);  //Destroying player gives reference errors, unnecessary anyway
        GameOverMenu.isDead = true;
    }
}
