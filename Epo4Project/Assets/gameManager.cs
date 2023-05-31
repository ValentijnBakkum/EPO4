using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameManager : MonoBehaviour
{
    public GameObject textobj;
    private TextMeshProUGUI text;
    private int rndclr, rndname;

    private string[] names = {"BLAUW", "ROOD", "ZWART", "GROEN", "GEEL", "ROZE"};
    private Color[] colors = {Color.blue, Color.red, Color.black, Color.green,Color.yellow, Color.magenta};

    // Start is called before the first frame update
    void Start()
    {
        text = textobj.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            int prevname = rndname;
            rndname = Random.Range(0, names.Length);
            while(rndname == prevname){
                rndname = Random.Range(0, names.Length);
            }


            rndclr = Random.Range(0, names.Length);
            while(rndclr == rndname){
                rndclr = Random.Range(0, names.Length);
            }
            text.text = names[rndname];
            text.color = colors[rndclr];
        }
    }
}
