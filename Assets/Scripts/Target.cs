using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{

    public float limit;
    public float fadeCounter;
    public float fadeInterval;
    public string tag;

    private SpriteRenderer renderer;
    private Color color;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        color = renderer.color;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log("Collison!");
    //    if(Input.GetMouseButton(0) == false && collision.gameObject.tag==tag)
    //    {
    //        //StopCoroutine();
    //        renderer.enabled = false;
    //    }
    //}

    private IEnumerator FadeIn()
    {
        float i = 0;
        while (i <= limit)
        {
            renderer.color += new Color(0, 0, 0, i);
            i += fadeCounter;
            if (i >= limit)
            {
                renderer.color = new Color(color.r, color.g, color.b, limit);
                //fadeInCompleted.SignalChange();
                StartCoroutine(FadeOut());
            }
            yield return new WaitForSeconds(fadeInterval);
        }
    }

    private IEnumerator FadeOut()
    {
        //Debug.Log("poop");
        float i = limit;
        while (i >= 0)
        {
            renderer.color -= new Color(0, 0, 0, i);
            i -= fadeCounter;
            if (i < 0)
            {
                renderer.color = new Color(color.r, color.g, color.b, 0);
                StartCoroutine(FadeIn());
            }
            yield return new WaitForSeconds(fadeInterval);
        }
    }

}

