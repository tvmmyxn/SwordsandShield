using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour
{
    public Owner CurrentPlayer;
    public Tile[] Tiles = new Tile[9];
    public int SwordScore;
    public int ShieldScore;
    public KeepScore scorekeep;
    public Button reset;
    public Button quit;

    public enum Owner
    {
        None,
        Sword,
        Shield
    }

    private bool won;

    // Start is called before the first frame update
    void Start()
    {
        startGame();
    }

    public void startGame()
    {
        won = false;
        CurrentPlayer = Owner.Sword;
        reset.transform.localScale = new Vector3(0, 0, 0);
        quit.transform.localScale = new Vector3(0, 0, 0);
    }

    public void ChangePlayer()
    {
        if (CurrentPlayer == Owner.None)
            return;

        if (CheckForWinner())
        {
            reset.transform.localScale = new Vector3(1, 1, 1);
            quit.transform.localScale = new Vector3(1, 1, 1);
            scorekeep.UpdateScore(CurrentPlayer);
            CurrentPlayer = Owner.None;
            return;
        }

        if (CurrentPlayer == Owner.Sword)
            CurrentPlayer = Owner.Shield;
        else
            CurrentPlayer = Owner.Sword;
    }

    public void Reset()
    {
        foreach (Tile tile in Tiles)
        {
            tile.owner = Owner.None;
            tile.GetComponent<SpriteRenderer>().color = Color.white;
        }
        startGame();
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("You have quit the game");
    }

    public bool CheckForWinner()
    {
        if (Tiles[0].owner == CurrentPlayer && Tiles[1].owner == CurrentPlayer && Tiles[2].owner == CurrentPlayer)
            won = true;
        else if (Tiles[3].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[5].owner == CurrentPlayer)
            won = true;
        else if (Tiles[6].owner == CurrentPlayer && Tiles[7].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;
        else if (Tiles[0].owner == CurrentPlayer && Tiles[3].owner == CurrentPlayer && Tiles[6].owner == CurrentPlayer)
            won = true;
        else if (Tiles[1].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[7].owner == CurrentPlayer)
            won = true;
        else if (Tiles[2].owner == CurrentPlayer && Tiles[5].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;
        else if (Tiles[2].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[6].owner == CurrentPlayer)
            won = true;
        else if (Tiles[0].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;

        if (won)
        {
            Debug.Log("Winner: " + CurrentPlayer);
            return true;
        }

        return false;
    }


}
