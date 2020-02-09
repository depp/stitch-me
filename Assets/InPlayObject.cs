using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InPlayObject : MonoBehaviour
{
    public Color color;
    public float TotalTime=2;
    public Draggable draggableScript;

    private SpriteRenderer renderer;
    private Coroutine coroutine;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        if(draggableScript==null)
            draggableScript = GetComponent<Draggable>();
        if(color==null)
        {
            color = Color.yellow;
        }
        //renderer.Add(GetComponent<SpriteRenderer>());
        //renderer.Add(GetComponentInChildren<SpriteRenderer>());
        //color = renderer.color;
    }

    // Start is called before the first frame update
    void Start()
    {
        coroutine = StartCoroutine(FadeIn(Color.white, color));
    }

    private void Update()
    {
        if(!draggableScript.IsInPlay)
        {
            StopCoroutine(coroutine);
            renderer.color = Color.white;
            Destroy(this);
        }
    }

    private IEnumerator FadeIn(Color originalColor, Color targetColor)
    {
        float startTime = 0;
        while (startTime <= TotalTime)
        {
            //renderer.color += new Color(0, 0, 0, i);
            startTime += Time.deltaTime;
            renderer.color = Color.Lerp(originalColor, targetColor, (startTime / TotalTime));
            //renderer.ForEach(r => r.color = Color.Lerp(originalColor, targetColor, (startTime / TotalTime)));
            if (renderer.color == targetColor)
            {
                //renderer.color = new Color(color.r, color.g, color.b, limit);
                //fadeInCompleted.SignalChange();
                coroutine = StartCoroutine(FadeIn(targetColor, originalColor));
            }
            yield return null;
        }
    }

    //private IEnumerator FadeIn(Color originalColor, Color targetColor)
    //{
    //    float i = 0;
    //    float totalTime = 6.0f;
    //    while (i <= totalTime)
    //    {
    //        renderer.color += new Color(0, 0, 0, i);
    //        i += Time.deltaTime;
    //        renderer.color = Color.Lerp(Color.white, color, (i / totalTime));
    //        if (renderer.color == color)
    //        {
    //            //renderer.color = new Color(color.r, color.g, color.b, limit);
    //            //fadeInCompleted.SignalChange();
    //            StartCoroutine(FadeOut());
    //        }
    //        yield return null;
    //    }
    //}

    //private IEnumerator FadeOut()
    //{
    //    Debug.Log("FadeOut");
    //    float i = 0;
    //    float totalTime = 6.0f;
    //    while (i <= totalTime)
    //    {
    //        renderer.color += new Color(0, 0, 0, i);
    //        i += Time.deltaTime;
    //        renderer.color = Color.Lerp(Color.white, color, (i / totalTime));
    //        if (renderer.color == color)
    //        {
    //            //renderer.color = new Color(color.r, color.g, color.b, limit);
    //            //fadeInCompleted.SignalChange();
    //            StartCoroutine(FadeOut());
    //        }
    //        yield return null;
    //    }
    //}
}
