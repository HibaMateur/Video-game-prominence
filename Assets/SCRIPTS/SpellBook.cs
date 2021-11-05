using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellBook : MonoBehaviour
{
    [SerializeField]
    private Image castingBar;
    [SerializeField]
    private Text spellName;
    [SerializeField]
    private Image icon;
    [SerializeField]
    private Text MyCastTime;
    [SerializeField]
    private CanvasGroup CG;
    [SerializeField]
    private SpellScript[] spells;
   

    private Coroutine spellRoutine;
    private Coroutine fadeRoutine;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public SpellScript CastSpell(int i)
    {
        castingBar.color = spells[i].BarColor;
        castingBar.fillAmount = 0;
        spellName.text = spells[i].Name;
        icon.sprite = spells[i].Icon;
        spellRoutine = StartCoroutine(Progress(i));
        StartCoroutine(FadeBar());
        return spells[i];
    }
    private IEnumerator Progress(int i)
    {
        float timeLeft = Time.deltaTime;
        float rate = 1.0f / spells[i].CastTime;
        float progress = 0.0f;
        while (progress <= 1.0)
        {

            castingBar.fillAmount = Mathf.Lerp(0, 1, progress);
            progress += rate * Time.deltaTime;
            timeLeft += Time.deltaTime;
            MyCastTime.text = (spells[i].CastTime - timeLeft).ToString("F2");
            if (spells[i].CastTime - timeLeft < 0)
            {
                MyCastTime.text = "0.0";
            }
            yield return null;
        }
    }
    private IEnumerator FadeBar()
    {
        
        float rate = 1.0f /0.25f;
        float progress = 0.0f;
        while (progress <= 1.0)
        {
            CG.alpha = Mathf.Lerp(0, 1, progress);
            progress += rate * Time.deltaTime;
            yield return null;
        }
    }
    public void StopCasting()
    {//need to look into it (cast bar doesn't disapear)
        if(fadeRoutine != null)
        {
           StopCoroutine(fadeRoutine);
           CG.alpha = 0;
           fadeRoutine = null;
        }
        if (spellRoutine != null)
        {
            StopCoroutine(spellRoutine);
            spellRoutine = null;
        }
    }
}
