using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class AudioSyncColor : AudioSyncer
{
    private IEnumerator MoveToColor(Color target)
    {
        Color curr = img.color;
        Color initial = curr;
        float timer = 0;

        while (curr != target)
        {
            curr = Color.Lerp(initial, target, timer / timeToBeat);
            timer += Time.deltaTime;

            img.color = curr;

            yield return null;
        }

        isBeat = false;
    }

    private Color RandomColor()
    {
        if (beatColors == null || beatColors.Length == 0) return Color.white;
        randomIndx = Random.Range(0, beatColors.Length);
        return beatColors[randomIndx];
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (isBeat) return;

        img.color = Color.Lerp(img.color, restColor, restSmoothTime * Time.deltaTime);
    }

    public override void OnBeat()
    {
        base.OnBeat();

        Color c = RandomColor();

        StopAllCoroutines();
        StartCoroutine(MoveToColor(c));
    }

    private void Start()
    {
        img = GetComponent<Image>();
    }

    public Color[] beatColors;
    public Color restColor;

    private int randomIndx;
    private Image img;
}