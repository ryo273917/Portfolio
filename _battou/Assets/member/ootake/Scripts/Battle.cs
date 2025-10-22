using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    [SerializeField] GameObject icon;
    [SerializeField] GameObject damyicon;
    [SerializeField] GameObject radyObject;
    [SerializeField] AudioSource sordAudio;
    [SerializeField] AudioSource missAudio;
    public SceneChange _sceneChanger1;
    public SceneChange _sceneChanger2;
    public PlayerAnimationController1 animCon1;
    public bool ready = false;
    public bool judge;
    private int ran;
    private int damy;
    private bool damyout =true;
    //お手付き用
    private bool ote = true;
    //勝者判定用
    private bool win = false;
    //ポイント先取用
    private int pointA = 0;
    private int pointL = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Ready");
        StartCoroutine("WaitTime");
        StartCoroutine("Damy");
        icon.SetActive(false);
        damyicon.SetActive(false);
        radyObject.SetActive(true);
    }
    void Update()
    {

        Ready();
        if (ready == false)
        {
            //お手付き判定
            if (ote == true)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    LoseA();
                    ote = false;
                }
                if (Input.GetKeyDown(KeyCode.L))
                {
                    LoseL();
                    ote = false;
                }
            }
        }
        if(ready == true)
        {
            //勝敗判定
            if(win == false)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    WinA();
                }
                if (Input.GetKeyDown(KeyCode.L))
                {
                    WinL();
                }
            }
        }
        Winner();
    }

    IEnumerator Ready()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Ready");
        radyObject.SetActive(false);
    }

    IEnumerator WaitTime()
    {
        ran = Random.Range(8, 15);
        yield return new WaitForSeconds(ran);
        Debug.Log("!");
        icon.SetActive(true);
        damyicon.SetActive(false);
        ready = true;
        //  開始の合図が出てきた後にダミーの合図が出てこないようにするフラグ処理
        damyout = false;
    }

    IEnumerator Damy()
    {
        damy = Random.Range(5, 15);
        yield return new WaitForSeconds(damy);
        //  開始の合図が出てきたら出てこないようにする。
        if (damyout == true)
        {
            damyicon.SetActive(true);
        }
    }

    private void LoseA()
    {
        Debug.Log("1pおてつき");
        animCon1.PlayDamaged1();
        missAudio.Play();
        pointL += 1;
    }

    private void LoseL()
    {
        Debug.Log("2pおてつき");
        animCon1.PlayDamaged2();
        missAudio.Play();
        pointA += 1;
    }

    private void WinA()
    {
        pointA += 1;
        Debug.Log("プレイヤー１");
        animCon1.PlaySlash1();
        sordAudio.Play();
        animCon1.PlayDeath2();
        win = true;
    }

    private void WinL()
    {
        pointL += 1;
        Debug.Log("プレイヤー2");
        animCon1.PlaySlash2();
        sordAudio.Play();
        animCon1.PlayDeath1();
        win = true;
    }

    private void Winner()
    {
        if(pointA == 1)
        {
            Debug.Log("プレイヤー１の勝利");
            StartCoroutine("Win1");
        }
        if(pointL == 1)
        {
            Debug.Log("プレイヤー2の勝利");
            StartCoroutine("Win2");
        }
    }

    IEnumerator Win1()
    {
        yield return new WaitForSeconds(2);
        _sceneChanger1.ChangeScene();
    }
    IEnumerator Win2()
    {
        yield return new WaitForSeconds(2);
        _sceneChanger2.ChangeScene();
    }
}
