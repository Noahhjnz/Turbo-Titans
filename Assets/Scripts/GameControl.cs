using UnityEngine.UI;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    private static GameObject whoWinsTextShadow, player1MoveText, player2MoveText, player3MoveText;
    private static GameObject player1, player2, player3; //refs player game objects

    public static int diceSideThrown = 0;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;
    public static int player3StartWaypoint = 0;
    public static bool gameOver = false;
    //Everything in start method will be dublicated to add more players
    void Start()
    {
        //finding move text to display on screen
        whoWinsTextShadow = GameObject.Find("WhoWinsText");
        player1MoveText = GameObject.Find("Player1MoveText"); 
        player2MoveText = GameObject.Find("Player2MoveText");
        player3MoveText = GameObject.Find("Player3MoveText");

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");

        player1.GetComponent<FollowThePath>().moveAllowed = false;
        player2.GetComponent<FollowThePath>().moveAllowed = false;
        player3.GetComponent<FollowThePath>().moveAllowed = false;
        whoWinsTextShadow.gameObject.SetActive(false);
        player1MoveText.gameObject.SetActive(true);
        player2MoveText.gameObject.SetActive(false);
        player3MoveText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (player1.GetComponent<FollowThePath>().waypointIndex >
            player1StartWaypoint + diceSideThrown)
        {
            player1.GetComponent<FollowThePath>().moveAllowed = false;
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(true);
            player3MoveText.gameObject.SetActive(false);
            player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex - 1;

        }

        if (player2.GetComponent<FollowThePath>().waypointIndex >
            player2StartWaypoint + diceSideThrown)
        {
            player2.GetComponent<FollowThePath>().moveAllowed = false;
            player2MoveText.gameObject.SetActive(false);
            player1MoveText.gameObject.SetActive(false);
            player3MoveText.gameObject.SetActive(true);
            player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex - 1;
        }
        if (player3.GetComponent<FollowThePath>().waypointIndex >
           player3StartWaypoint + diceSideThrown)
        {
            player3.GetComponent<FollowThePath>().moveAllowed = false;
            player3MoveText.gameObject.SetActive(false);
            player1MoveText.gameObject.SetActive(true);
            player2MoveText.gameObject.SetActive(false);
            player3StartWaypoint = player3.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        if (player1.GetComponent<FollowThePath>().waypointIndex ==
            player1.GetComponent<FollowThePath>().waypoints.Length)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            player3MoveText.gameObject.SetActive(false);
            whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Wins";
            gameOver = true;

        }
        if (player2.GetComponent<FollowThePath>().waypointIndex ==
            player2.GetComponent<FollowThePath>().waypoints.Length)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            player3MoveText.gameObject.SetActive(false);
            whoWinsTextShadow.GetComponent<Text>().text = "Player 2 Wins";
            gameOver = true;

        }
        if (player3.GetComponent<FollowThePath>().waypointIndex ==
            player3.GetComponent<FollowThePath>().waypoints.Length)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            player3MoveText.gameObject.SetActive(false);
            whoWinsTextShadow.GetComponent<Text>().text = "Player 3 Wins";
            gameOver = true;

        }
    }

    public static void MovePlayer(int playerToMove)
        //envoked when dice is rolled
    {
        switch (playerToMove)
        {
            case 1:
                player1.GetComponent<FollowThePath>().moveAllowed = true;
                break;
            case 2:
                player2.GetComponent<FollowThePath>().moveAllowed = true;
                break;
            case 3:
                player3.GetComponent<FollowThePath>().moveAllowed = true;
                break;
        }
    }
}

   


