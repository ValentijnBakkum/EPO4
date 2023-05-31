using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public enum stroopstate{
        StroopBoring,
        StroopHard,
        STROOPEXTREME
    }
    public GameObject textobj;
    private TextMeshProUGUI text;
    private int rndclr, rndname;
    public GameObject background;
    public GameObject debugTextobj;
    private TextMeshProUGUI debugText;

    private stroopstate state;
    private AudioManager audioManager;
    private string[] names = {"BLAUW", "ROOD", "ZWART", "GROEN", "GEEL", "ROZE"};
    private Color[] colors = {Color.blue, Color.red, Color.black, Color.green,Color.yellow, Color.magenta};

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        state = stroopstate.StroopBoring;
        text = textobj.GetComponent<TextMeshProUGUI>();
        debugText = debugTextobj.GetComponent<TextMeshProUGUI>();
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        debugText.text = "state: " + state.ToString();
        if(Input.GetKeyDown(KeyCode.Space)){
            int prevname = rndname;
            rndname = Random.Range(0, names.Length);
            while(rndname == prevname){
                rndname = Random.Range(0, names.Length);
            }
            
            if(state == stroopstate.StroopBoring)
                rndclr = rndname;
            else{
                rndclr = Random.Range(0, names.Length);
                while(rndclr == rndname){
                    rndclr = Random.Range(0, names.Length);
                }
            }

            if(state == stroopstate.STROOPEXTREME){
                int rndbgclr = Random.Range(0, names.Length);
                while(rndbgclr == rndclr){
                    rndbgclr = Random.Range(0, names.Length);
                }
                background.GetComponent<Image>().color = colors[rndbgclr];
            }
            text.text = names[rndname];
            text.color = colors[rndclr];
        }
    }

    IEnumerator Wait()
    {   
        audioManager.Play("clock");
        //wait for 1 minute, then change the state to StroopEXTREME.
        yield return new WaitForSeconds(20);
        state = stroopstate.StroopHard;
        yield return new WaitForSeconds(20);
        state = stroopstate.STROOPEXTREME;
    }
}
