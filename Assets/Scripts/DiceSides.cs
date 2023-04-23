using System.Collections;
using UnityEngine;

public class DiceSides : MonoBehaviour
{
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private int whosTurn = 1;
    private bool coroutineAllowed = true;
    

    private void Start ()
    {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];

    }

    private void OnMouseDown()
    {
        if (!GameControl.gameOver && coroutineAllowed)
            StartCoroutine("RollTheDice");
    }


   
        private IEnumerator RollTheDice()
        {
            coroutineAllowed = false;
        //coroutineAllowed - means dice cannot be rolled untill player finishes moving
            int randomDiceSide = 0;
        //loops randomly 20 times from dice sides, choosing a random range from 0 to 6
            for (int i = 0; i <= 20; i++)
            {
                randomDiceSide = Random.Range(0, 6);
                rend.sprite = diceSides[randomDiceSide];
                yield return new WaitForSeconds(0.05f);

            }
            //envokes GameControl script after choosing who will move - Will be changed to allocate more players 
            GameControl.diceSideThrown = randomDiceSide + 1;
            if (whosTurn == 1)
            {
                GameControl.MovePlayer(1);
            }
            else if (whosTurn == -1)
            {
                GameControl.MovePlayer(2);
            }
            else if (whosTurn == -1)
            {
                GameControl.MovePlayer(3);
            }
        whosTurn *= -1;
            coroutineAllowed = true;

        }
    
}

