using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NexusBehaviour : LifeEntity
{
    public Slider healthBar;
    public Gradient gradient;
    public Image fill;

    public GameObject stageEnd;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = startHealth;
        healthBar.value = health;
        fill.color = gradient.Evaluate(1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnDamage(float damage)
    {
        base.OnDamage(damage);
        healthBar.value = health;
        fill.color = gradient.Evaluate(healthBar.normalizedValue);
    }
    public override void Die()
    {
        base.Die();
        healthBar.gameObject.SetActive(false);
        // 게임 오버 ui 출력
        stageEnd.SetActive(true);
        Text clearText = GameObject.Find("clearText").GetComponent<Text>();
        Text gainGold = GameObject.Find("gainGold").GetComponent<Text>();
        Text gainEnt = GameObject.Find("gainEnt").GetComponent<Text>();

        float stageClearEnt = StageSelector.stageClear * 5.0f * PlayerPrefs.GetFloat("charGainEnt");
        stageClearEnt = PlayerPrefs.GetInt("Stage Ent") + stageClearEnt;
        PlayerPrefs.SetInt("Stage Ent", (int) stageClearEnt);
        float totalClearEnt = PlayerPrefs.GetInt("Total Ent") + stageClearEnt;
        PlayerPrefs.SetInt("Total Ent", (int) totalClearEnt);
        gainGold.text = "+0 G"; 
        gainEnt.text = "+" + (int) stageClearEnt + " E  >>> Total : " + (int) totalClearEnt + " E";

        ObjectGenerator.killcount = 0;
    }
    public void ToMain()
    {
        SceneManager.LoadScene("Main");
    }
}
