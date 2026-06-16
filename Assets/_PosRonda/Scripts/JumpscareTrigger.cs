using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareTrigger : MonoBehaviour
{
    public AudioSource suaraKaget;
    private bool udahPernahKaget = false;

    void OnTriggerEnter(Collider other) {
        Debug.Log("Di lewati");
        if (other.CompareTag("Player")) {
            if (MisiManager.instance.gembokSelesai >= MisiManager.instance.totalGembok) {
                if (udahPernahKaget) return;

                udahPernahKaget = true;

                if (suaraKaget != null) {
                    suaraKaget.Play();
                }

                UIManager.instance.MunculinTeksBatin("ASTAGFIRULLAH! Kaget gue!", 2.5f);
                StartCoroutine(ParnoBerlanjut());
            }
        }
    }

    IEnumerator ParnoBerlanjut() {
        yield return new WaitForSeconds(3f);
        UIManager.instance.MunculinTeksBatin("Perasaan gue makin nggak enak...!", 4f);
    }



}
