using DarkPixelRPGUI.Scripts.UI.Equipment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDeckManager : MonoBehaviour
{

    [SerializeField] private GameObject setPosGreen;
    [SerializeField] private Grid grid;
    [SerializeField] private DeckSlot slotPrefab;
    [SerializeField] private GameObject slotParticle;
    [SerializeField] private Transform deckRoot;

    private Vector3 setPos;
    private GameObject currentPrefab;
    public bool settingStart { get; private set; }

    private void Awake()
    {

        var save = JSON.ReadJson<DeckSaveData>(Application.dataPath + @"\Deck.json");
        var res = Resources.Load<DeckBindingSO>("Bind");

        foreach(var item in save.deckSave)
        {

            var obj = res.bindList.Find(x => x.key == item);

            var slot = Instantiate(slotPrefab, deckRoot);
            slot.Setting(obj.iconSprite, obj.cost, obj.unitPrefab);

        }

    }

    private void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {

            ReleaseSetting();

        }

        if (settingStart)
        {

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit, 100, LayerMask.GetMask("Ground")))
            {

                var pos = grid.WorldToCell(hit.point);
                setPos= pos;
                setPosGreen.transform.position = pos;

            }

        }

    }

    public void StartSetting(GameObject prefab)
    {


        setPosGreen.SetActive(true);
        currentPrefab = prefab;
        settingStart = true;
        WaveManager.instance.TurretCnt++;

    }

    public void ReleaseSetting()
    {

        if (settingStart == false) return;

        setPosGreen.SetActive(false);
        Instantiate(currentPrefab, setPos, Quaternion.identity);
        var slotPart = Instantiate(slotParticle, setPos + new Vector3(0, 0.7f), Quaternion.Euler(45, 0, 0));
        StartCoroutine(slotPart.GetComponent<BatchEffect>().EffectPush(0.4f));
        //���⼭ ����Ʈ
        settingStart = false;
        currentPrefab = null;
        SoundManager.Instance.PlaySound("BatchSound");

    }

}
