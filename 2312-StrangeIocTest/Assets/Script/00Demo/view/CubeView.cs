using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeView : View
{
    [Inject]
    public IEventDispatcher dispatcher { get; set; }
    [Inject]
    public AudioManager audioManager { get; set; }

    private Text scoreText;

    public void Init()
    {
        scoreText = GetComponentInChildren<Text>();
    }
    void Update()
    {
        if (GameModel.IsPlay)
            return;
        transform.Translate(new Vector3(Random.Range(-1, 2), Random.Range(-1, 2),0)*0.05f);
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }
    private void OnMouseDown()
    {
        //按下
        audioManager.Play("hit");
        //PoolManager.Instance.GetCity("bullet", GameObject.Find("pos").transform);
        dispatcher.Dispatch(DemoMediatorEvent.ClickDown);
    }
    public void UpdateScore( int score)
    {
        scoreText.text = score.ToString();
    }
}
