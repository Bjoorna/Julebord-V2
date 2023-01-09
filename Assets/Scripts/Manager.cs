using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;
    private List<Player> players = new List<Player>();
    private Dictionary<int, Player> lanes = new Dictionary<int, Player>();

    private Dictionary<Player, int> positions = new Dictionary<Player, int>();

    private bool Go = false;

    private string vinner = "";
    private string taper = "null";

    private bool hasLoser = false;

    void Awake()
    {
        // Time.timeScale = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        var findPlayers = FindObjectsOfType<Player>();
        Debug.Log("findPlayers.Length");

        Debug.Log(findPlayers.Length);
        foreach (var player in findPlayers)
        {
            players.Add(player);
        }
        for (int i = 0; i < players.Count; i++)
        {
            lanes.Add(i, players[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!Go)
            {
                Go = true;
                var audio = GetComponent<AudioSource>();
                if (audio)
                {
                    audio.Play();
                }
            }
            // Time.timeScale = 1;
        }

        GetPlayerPositions();
    }

    public List<Player> GetPlayers()
    {
        return players;
    }

    public void DestroyPlayer(Player player)
    {
        if (!hasLoser)
        {
            taper = player.gameObject.name;
            hasLoser = true;
        }
        var test = player.GetComponent<SpawnParticle>();
        players.Remove(player);
        if (players.Count == 1)
        {
            vinner = players[0].gameObject.name;
        }
        if (projectile != null)
        {
            Debug.Log("Spawn projectile");
            Instantiate(projectile, player.transform.position, player.transform.rotation);
        }
        Destroy(player.gameObject);
        // player.DestroySelf();
    }

    public void GetPlayerPositions()
    {
        List<Player> sortedList = players.OrderBy(p => -p.transform.position.z).ToList();
        Dictionary<Player, int> newPosDict = new Dictionary<Player, int>();
        int count = 1;
        foreach (var player in sortedList)
        {
            newPosDict.Add(player, count);
            count++;
        }
        positions = newPosDict;
        // var listToSort = players.OrderBy(p => p.transform.position.z).ToArray();
        // Dictionary<Player, int> newDict = new Dictionary<Player, int>();
        // for (int i = 0; i < listToSort.Length; i++)
        // {
        //     Debug.Log("Player: " + listToSort[i].name);
        //     Debug.Log("Position: " + i);
        //     newDict.Add(listToSort[1], i);
        // }
        // positions = newDict;
    }

    public bool GetPos(Player player, out int pos)
    {
        return positions.TryGetValue(player, out pos);
    }

    private int SortPosition(Player a, Player b)
    {
        var ya = a.transform.position.z;
        var yb = b.transform.position.z;
        return ya.CompareTo(yb); //here I use the default comparison of floats
    }

    public bool GetGo()
    {
        return Go;
    }

    public string GetVinnerName()
    {
        return vinner;
    }

    public string GetTaperName()
    {
        return taper;
    }
}
