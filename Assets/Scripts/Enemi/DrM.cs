using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DrM : MonoBehaviour
{
    public GameObject spell;
    public Animator energy1;
    public Animator energy2;
    public GameObject wab;
    public GameObject leverPrefab;
    public TextMeshProUGUI textFieldBossLifes;
    public Vector3[] positions;
    private EnergyBall energyBall;
    private int life = 1;
    private AudioSettings audioSettings;
    private LevelSettings levelSettings;
    private LevelProgress levelProgress;
    private List<EnergySource> energySource = new List<EnergySource>();
    private List<EnergyBall> energyBallsOfDeath = new List<EnergyBall>();
    private bool killEveryone = false;
    private Animator animator;

    private void Start() {

        this.animator = gameObject.GetComponent<Animator>();
        this.textFieldBossLifes.text = this.life.ToString("00");

        GameObject gameSettings = GameObject.Find("GameSettings");

        if (gameSettings) {
            this.audioSettings = gameSettings.GetComponent<AudioSettings>();
            this.levelSettings = gameSettings.GetComponent<LevelSettings>();
        }

        GameObject levelProgressGO = GameObject.Find("LevelProgress");

        if (gameSettings) {
            this.levelProgress = levelProgressGO.GetComponent<LevelProgress>();
        }

        InvokeRepeating("InvokeAndShot", 5f, 8f);

        GenerateLevers();
    }

    void Update()
    {

        if (this.levelProgress.levelMaxSeconds - this.levelProgress.timeElipsed <= 0 && !this.killEveryone) {
            this.killEveryone = true;

            for (var i = 0; i < 30; i++) {
                Vector3 pos = gameObject.transform.position + new Vector3(0f, 0.4f, 0f);
                GameObject lastEnergyBall = Instantiate(spell, pos, gameObject.transform.rotation);
                lastEnergyBall.GetComponent<SpriteRenderer>().color = new Color(1f, 0.4f, 0f, 1f);
                EnergyBall en = lastEnergyBall.GetComponent<EnergyBall>();
                this.energyBallsOfDeath.Add(en);
            }

            Invoke("ShotAllDeathEnergyBall", 1f);
        }

        if (this.energySource.Count == 2 && this.energySource[0].state && this.energySource[1].state) {
            this.energySource[1].DestroyYourself();
            this.energySource[0].DestroyYourself();
            this.energySource.RemoveAll(el => true);
            GenerateWAB();
            this.levelProgress.levelMaxSeconds += 15;
            Invoke("GenerateLevers", 2f);
        }
    }

    private void InvokeAndShot() {

        if (!this.levelSettings.paused) { 
            this.energy1.SetTrigger("Charge");
            this.energy2.SetTrigger("Charge");
            Invoke("PlayChargeSound", 1f);
            Invoke("InvokeEnergyBall", 2f);
        }
    }

    private void PlayChargeSound() {
        this.audioSettings.PlaySound("Charge");
    }

    private void InvokeEnergyBall() {
        Vector3 pos = gameObject.transform.position + new Vector3(0f, 0.4f, 0f);
        GameObject lastEnergyBall = Instantiate(spell, pos, gameObject.transform.rotation);
        this.energyBall = lastEnergyBall.GetComponent<EnergyBall>();
        Invoke("ShotLastEnergyBall", 2f);
    }

    private void ShotLastEnergyBall() {
        this.audioSettings.PlaySound("EnergyShot");
        this.energyBall.Shot();
    }

    public void TakeDamage() {
        this.life -= 1;
        this.animator.SetTrigger("TakeDamage");
        this.textFieldBossLifes.text = this.life.ToString("00");
        
        if (this.life <= 0) {
            Destroy(gameObject);
            SceneManager.LoadScene("End", LoadSceneMode.Single);
        }
    }

    public void GenerateWAB() {
        Vector3 pos = gameObject.transform.position + new Vector3(0f, 1f, 0f);
        Instantiate(this.wab, pos, gameObject.transform.rotation);
    }

    public void GenerateLevers() {
        int pos1Index = Random.Range(0, this.positions.Length);
        int pos2Index = Random.Range(0, this.positions.Length);

        while (pos1Index == pos2Index) {
            pos1Index = Random.Range(0, this.positions.Length);
        }

        Vector3 pos1 = this.positions[pos1Index];
        Vector3 pos2 = this.positions[pos2Index];

        GameObject es1 = Instantiate(this.leverPrefab, pos1, gameObject.transform.rotation);
        GameObject es2 = Instantiate(this.leverPrefab, pos2, gameObject.transform.rotation);

        EnergySource energySource1 = es1.GetComponent<EnergySource>();
        EnergySource energySource2 = es2.GetComponent<EnergySource>();

        this.energySource.Add(energySource1);
        this.energySource.Add(energySource2);
    }

    private void ShotAllDeathEnergyBall() {

        if (this.energyBallsOfDeath.Count <= 0) {
            return;
        }

        EnergyBall en = this.energyBallsOfDeath[0];
        en.Shot();
        this.energyBallsOfDeath.RemoveAt(0);


        Invoke("ShotAllDeathEnergyBall", 0.3f);
    }
}
