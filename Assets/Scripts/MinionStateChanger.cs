using UnityEngine;

public class MinionStateChanger : MonoBehaviour {

    public enum ClothesState { Hat, Clothes, Nothing}

    public GameObject[] defaultClothes;
    public GameObject[] gameClothes;

    
    public GameObject[] girlClothes;
    public GameObject[] havaiClothes;    
    public GameObject[] gadyaClothes;
    public GameObject[] deerClothes;

    public GameObject[] girlHat;
    public GameObject[] deerHat;
    public GameObject[] hatClothes;
    public GameObject[] hat2Clothes;
    public GameObject[] sombreroClothes;
    public GameObject[] hatHavai;
    public GameObject[] hatGadya;

    public ClothesState currentShopState = ClothesState.Nothing;
    GameObject[] curr;
    GameObject[] currHat;
    GameObject[] currCloth;

    int currHatIndex = 0;
    int currClothIndex = 0;
    Animator anim;
    // Use this for initialization
    void Start () {
        curr = defaultClothes;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        UserInput();
    }

    public void SetDefaultClothes() {
        anim.SetTrigger("Idle2");
        foreach (GameObject g in curr) {
            g.SetActive(false);
        }
        foreach (GameObject g in currHat)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in currCloth)
        {
            g.SetActive(false);
        }
        curr = defaultClothes;
        foreach (GameObject g in curr)
        {
            g.SetActive(true);
        }
    }

    public void SetGameClothes() {
        anim.SetTrigger("Game");
        foreach (GameObject g in curr)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in currHat)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in currCloth)
        {
            g.SetActive(false);
        }
        curr = gameClothes;
        foreach (GameObject g in curr)
        {
            g.SetActive(true);
        }
    }

    public void SetShopState() {

        anim.SetTrigger("Idle");
        currentShopState = ClothesState.Nothing;
        foreach (GameObject g in curr)
        {
            g.SetActive(false);
        }
        currHat = girlHat;
        currCloth = girlClothes;

        foreach (GameObject g in currCloth)
        {
            g.SetActive(true);
        }
        foreach (GameObject g in currHat)
        {
            g.SetActive(true);
        }
    }

    public void ChangeHats() {

        foreach (GameObject g in currHat)
        {
            g.SetActive(false);
        }
        switch (currHatIndex){

            case 0:
                currHat = girlHat;
                break;
            case 1:
                currHat = deerHat;
                break;
            case 2:
                currHat = hatClothes;
                break;
            case 3:
                currHat = hat2Clothes;
                break;
            case 4:
                currHat = sombreroClothes;
                break;
            case 5:
                currHat = hatHavai;
                break;
            case 6:
                currHat = hatGadya;
                break;

        }
        foreach (GameObject g in currHat)
        {
            g.SetActive(true);
        }
        currHatIndex++;
        if (currHatIndex > 6) currHatIndex = 0;
    }

    public void ChangeClothe() {

        foreach (GameObject g in currCloth)
        {
            g.SetActive(false);
        }
        switch (currClothIndex) {

            case 0:
                currCloth = girlClothes;
                break;
            case 1:
                currCloth = havaiClothes;
                break;
            case 2:
                currCloth = gadyaClothes;
                break;
            case 3:
                currCloth = deerClothes;
                break;
        }
        foreach (GameObject g in currCloth)
        {
            g.SetActive(true);
        }
        currClothIndex++;
        if (currClothIndex > 3) currClothIndex = 0;
    }

    public void UserInput()
    {
        if (!Application.isEditor)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 1000))
                {
                    if (hit.transform.gameObject.tag == "Minion")
                    {
                        if (currentShopState == ClothesState.Hat) ChangeHats();
                        if (currentShopState == ClothesState.Clothes) ChangeClothe();
                    }
                }

            }
        }

        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 1000))
                {
                    if (hit.transform.gameObject.tag == "Minion")
                    {
                        if (currentShopState == ClothesState.Hat) ChangeHats();
                        if (currentShopState == ClothesState.Clothes) ChangeClothe();
                    }
                }

            }
        }

    }

}
