using UnityEngine;

public class FadeInAnimCotroller : MonoBehaviour
{
    private void OnEnable() => Hero.Dead += StartFadeInAnim;
    private void OnDisable() => Hero.Dead -= StartFadeInAnim;

    [SerializeField] private Animator spiderSheepAnimator;
    [SerializeField] private SpiderSeepSounds spiderSounds;

   private Animator anim;
   [SerializeField] private GameObject hero;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void StartFadeInAnim(int scene)
    {
        spiderSheepAnimator.enabled = false;
        spiderSounds.StopSounds();
        hero.GetComponent<SpriteRenderer>().sortingLayerName = "AboweFadeIn";
        anim.SetTrigger("StartAnim");
    }

    private void Update()
    {
        if (GamePause.Instance.IsPaused)
        {
            GetComponent<Animator>().enabled = false;
        }
        else
        {
            GetComponent<Animator>().enabled = true;
        }
    }
}
