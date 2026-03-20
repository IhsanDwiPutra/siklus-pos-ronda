using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public static SceneFader instance;

    public Image panelHitam;

    private void Awake() {
        instance = this;
    }

    public IEnumerator FadeOut(float durasi) {
        float t = 0;
        panelHitam.raycastTarget = true;

        while (t < durasi) {
            t += Time.deltaTime;
            panelHitam.color = new Color(0, 0, 0, t / durasi);
            yield return null;
        }
        panelHitam.color = new Color(0, 0, 0, 1);
    }

    public IEnumerator FadeIn(float durasi) {
        float t = durasi;
        while (t > 0) {
            t -= Time.deltaTime;
            panelHitam.color = new Color(0, 0, 0, t / durasi);
            yield return null;
        }
        panelHitam.color = new Color(0, 0, 0, 0);
        panelHitam.raycastTarget = false;
    }


}
