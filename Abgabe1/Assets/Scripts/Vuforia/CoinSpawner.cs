using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public Transform _Anchor;
    public Transform _CoinPref;
    [SerializeField]
    private int _AnzahlCoins = 10;
    [SerializeField]
    private int _FieldSize = 5;
    // Start is called before the first frame update
    void Start()
    {
        bool[,] field = new bool[_FieldSize, _FieldSize];
        int randX, randY;
        for (int i = 0; i < _AnzahlCoins; i++)
        {
            randX = Random.Range(0, _FieldSize);
            randY = Random.Range(0, _FieldSize);
            if (field[randX, randY] == true)
            {
                i--;
                continue;
            }

            field[randX, randY] = true;
            
            var coin = Instantiate(_CoinPref, new Vector3(_Anchor.position.x - (_FieldSize/2) + randX, _Anchor.position.y, _Anchor.position.z - (_FieldSize / 2) + randY), Quaternion.identity, _Anchor);
            coin.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
    }
}
