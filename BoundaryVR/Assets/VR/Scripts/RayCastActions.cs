using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastActions : MonoBehaviour
{
    public Slider slider;
    public float damage = 5f;

    private float currHP;
    private float recentDamageTime = 0f;
    private float nowTime;
    private float coldTime = 1f;
    private AudioSource source;
    [SerializeField] AudioClip clip;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        slider.value = slider.maxValue;
        currHP = slider.value;
    }

    
    private void GetDamage()
    {
        nowTime = Time.time;
        if (nowTime - recentDamageTime > coldTime)
        {
            source.PlayOneShot(clip);
            slider.value -= damage;
            recentDamageTime = nowTime;
            Debug.Log($"Get {damage} damage !");
        }
    }

    public void DoSomething()
    {
        GetDamage();
    }
}
