using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDestroyer : MonoBehaviour
{
    Transform player;
    public Transform playerLowerChecker;
    public Transform playerUpperChecker;
    public Transform playerSideChecker;
    public LayerMask layerMask;

    [SerializeField] Tile GrassTopMid;
    [SerializeField] Tile GrassTopLeft;
    [SerializeField] Tile GrassTopRight;
    //[SerializeField] Tile GrassTopLeftPlat;
    //[SerializeField] Tile GrassTopRightPlat;
    //[SerializeField] Tile GrassTopDownPlat;
    //[SerializeField] Tile GrassBottomMid;
    //[SerializeField] Tile GrassBlock;
    [SerializeField] Tile DirtMid;
    [SerializeField] Tile DirtLeft;
    [SerializeField] Tile DirtRight;
    //[SerializeField] Tile DirtDownPlat;
    //[SerializeField] Tile DirtBottomLeft;
    //[SerializeField] Tile DirtBottomRight;
    //[SerializeField] Tile DirtBottomMid;
    //[SerializeField] Tile DirtBlock;
    //[SerializeField] Tile DirtDownPlat;


    enum Tile_Type
    {
        

         unknown,
         GrassTopMid,
         GrassTopLeft,
         GrassTopRight,
         //GrassTopLeftPlat,
         //GrassTopRightPlat,
         //GrassTopDownPlat,
         //GrassBottomMid,
         //GrassBlock,
         DirtMid,
         DirtLeft,
         DirtRight,
         //DirtDownPlat,
         //DirtBottomLeft,
         //DirtBottomRight,
         //DirtBottomMid,
         //DirtBlock,

    }

    enum Tile_location
    {
        N,E,S,W,
    }

    List<object> localTiles;  // empty list to store the neighbour tiles
    List<Tile_Type> localTileTypes;  // empty list to store the type of neighbour tile.

    Tilemap tilemap;
    Vector3 mousePos;
    Vector3Int tilePos;

    [SerializeField] GridLayout grid;



    Vector3Int nTilePos;
    Vector3Int wTilePos;
    Vector3Int eTilePos;
    Vector3Int sTilePos;
    Tile nTile;
    Tile wTile;
    Tile eTile;
    Tile sTile;



    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        tilePos = grid.WorldToCell(mousePos);
        //Debug.Log(tilePos);
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(tilePos);
        }
        /*
         
         testing
         
         
         */


        //Debug.DrawRay(player.position, Vector2.down,color: Color.red,1f);
        

        //Debug.Log(raycasthitx.collider.name);
        if (Input.GetKeyDown(KeyCode.S))
        {
            RaycastHit2D raycasthitx = Physics2D.Raycast(player.position, -Vector2.up, 1f, layerMask);
            if (raycasthitx.collider != null)
            {

                //tilePos = new Vector3(raycasthitx.point.x,raycasthitx.point.y,0);
                //tilePos = new Vector3Int(Mathf.RoundToInt(raycasthitx.collider.bounds.center.x),Mathf.RoundToInt(raycasthitx.collider.bounds.center.y),0);
                tilePos = new Vector3Int(Mathf.RoundToInt(raycasthitx.point.x), Mathf.RoundToInt(raycasthitx.point.y - 1f), 0);
                Debug.DrawRay(player.position, Vector2.down, color: Color.red, tilePos.y);
                //Debug.DrawRay(player.position, Vector2.right, color: Color.red, tilePos.x);
                //Debug.DrawRay(player.position, Vector2.up, color: Color.red, tilePos.y);
                //Debug.DrawRay(player.position, -Vector2.right, color: Color.red, tilePos.y);
                Debug.Log(tilePos);
                Debug.Log(raycasthitx.collider.bounds.center.x);
                GetLocalTiles(tilePos);
                //Debug.Log("hello");
                //Debug.Log(mousePos);
                //Debug.Log("tile Position" + tilePos);
                tilemap.SetTile(tilePos, null);
                SetLocalTiles(tilePos);
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            RaycastHit2D raycasthitx = Physics2D.Raycast(player.position, Vector2.up, 1f, layerMask);
            if (raycasthitx.collider != null)
            {

                //tilePos = new Vector3(raycasthitx.point.x,raycasthitx.point.y,0);
                //tilePos = new Vector3Int(Mathf.RoundToInt(raycasthitx.collider.bounds.center.x),Mathf.RoundToInt(raycasthitx.collider.bounds.center.y),0);
                tilePos = new Vector3Int(Mathf.RoundToInt(raycasthitx.point.x), Mathf.RoundToInt(raycasthitx.point.y + 0.5f), 0);
                //Debug.DrawRay(player.position, Vector2.down, color: Color.red, tilePos.y);
                //Debug.DrawRay(player.position, Vector2.right, color: Color.red, tilePos.x);
                Debug.DrawRay(player.position, Vector2.up, color: Color.red, tilePos.y);
                //Debug.DrawRay(player.position, -Vector2.right, color: Color.red, tilePos.y);
                Debug.Log(tilePos);
                Debug.Log(raycasthitx.collider.bounds.center.x);
                GetLocalTiles(tilePos);
                //Debug.Log("hello");
                //Debug.Log(mousePos);
                //Debug.Log("tile Position" + tilePos);
                tilemap.SetTile(tilePos, null);
                SetLocalTiles(tilePos);
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            RaycastHit2D raycasthitx = Physics2D.Raycast(player.position, Vector2.right, 1f, layerMask);
            if (raycasthitx.collider != null)
            {

                //tilePos = new Vector3(raycasthitx.point.x,raycasthitx.point.y,0);
                //tilePos = new Vector3Int(Mathf.RoundToInt(raycasthitx.collider.bounds.center.x),Mathf.RoundToInt(raycasthitx.collider.bounds.center.y),0);
                tilePos = new Vector3Int(Mathf.RoundToInt(raycasthitx.point.x), Mathf.RoundToInt(raycasthitx.point.y), 0);
                //Debug.DrawRay(player.position, Vector2.down, color: Color.red, tilePos.y);
                Debug.DrawRay(player.position, Vector2.right, color: Color.red, tilePos.x);
                //Debug.DrawRay(player.position, Vector2.up, color: Color.red, tilePos.y);
                //Debug.DrawRay(player.position, -Vector2.right, color: Color.red, tilePos.y);
                Debug.Log(tilePos);
                //Debug.Log(raycasthitx.collider.bounds.center.x);
                GetLocalTiles(tilePos);
                //Debug.Log("hello");
                //Debug.Log(mousePos);
                //Debug.Log("tile Position" + tilePos);
                tilemap.SetTile(tilePos, null);
                SetLocalTiles(tilePos);
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            RaycastHit2D raycasthitx = Physics2D.Raycast(player.position, -Vector2.right, 1f, layerMask);
            if (raycasthitx.collider != null)
            {

                //tilePos = new Vector3(raycasthitx.point.x,raycasthitx.point.y,0);
                //tilePos = new Vector3Int(Mathf.RoundToInt(raycasthitx.collider.bounds.center.x),Mathf.RoundToInt(raycasthitx.collider.bounds.center.y),0);
                tilePos = new Vector3Int(Mathf.RoundToInt(raycasthitx.point.x - 1f), Mathf.RoundToInt(raycasthitx.point.y), 0);
                //Debug.DrawRay(player.position, Vector2.down, color: Color.red, tilePos.y);
                //Debug.DrawRay(player.position, Vector2.right, color: Color.red, tilePos.x);
                //Debug.DrawRay(player.position, Vector2.up, color: Color.red, tilePos.y);
                Debug.DrawRay(player.position, -Vector2.right, color: Color.red, tilePos.x);
                Debug.Log(tilePos);
                //Debug.Log(raycasthitx.collider.bounds.center.x);
                GetLocalTiles(tilePos);
                //Debug.Log("hello");
                //Debug.Log(mousePos);
                //Debug.Log("tile Position" + tilePos);
                tilemap.SetTile(tilePos, null);
                SetLocalTiles(tilePos);
            }
        }



        //tilePos = new Vector3Int((int)player.position.x,(int)player.position.y,(int)player.position.z);
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    tilePos = new Vector3Int((int)player.position.x-1, (int)player.position.y-2, (int)player.position.z);
        //    Debug.Log(tilePos);
        //    GetLocalTiles(tilePos);
        //    //Debug.Log("hello");
        //    //Debug.Log(mousePos);
        //    //Debug.Log("tile Position" + tilePos);
        //    tilemap.SetTile(tilePos, null);
        //    SetLocalTiles(tilePos);
        //}

        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    tilePos = new Vector3Int((int)player.position.x-1, (int)player.position.y, (int)player.position.z);
        //    Debug.Log(tilePos);
        //    GetLocalTiles(tilePos);
        //    //Debug.Log("hello");
        //    //Debug.Log(mousePos);
        //    //Debug.Log("tile Position" + tilePos);
        //    tilemap.SetTile(tilePos, null);
        //    SetLocalTiles(tilePos);
        //}

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    tilePos = new Vector3Int((int)player.position.x-2, (int)player.position.y-1, (int)player.position.z);
        //    Debug.Log(tilePos);
        //    GetLocalTiles(tilePos);
        //    //Debug.Log("hello");
        //    //Debug.Log(mousePos);
        //    //Debug.Log("tile Position" + tilePos);
        //    tilemap.SetTile(tilePos, null);
        //    SetLocalTiles(tilePos);
        //}

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    tilePos = new Vector3Int((int)player.position.x, (int)player.position.y-1, (int)player.position.z);
        //    Debug.Log(tilePos);
        //    GetLocalTiles(tilePos);
        //    //Debug.Log("hello");
        //    //Debug.Log(mousePos);
        //    //Debug.Log("tile Position" + tilePos);
        //    tilemap.SetTile(tilePos, null);
        //    SetLocalTiles(tilePos);
        //}

        



        if (Input.GetMouseButtonUp(0))
        {
            GetLocalTiles(tilePos);
            //Debug.Log("hello");
            //Debug.Log(mousePos);
            //Debug.Log("tile Position" + tilePos);
            tilemap.SetTile(tilePos, null);
            SetLocalTiles(tilePos);
        }
    }

    Tile_Type GetTileType(Tile tile)
    {
        if (tile == GrassTopMid)
        {
            return Tile_Type.GrassTopMid;
        }
        if (tile == GrassTopLeft)
        {
            return Tile_Type.GrassTopLeft;
        }
        if (tile == GrassTopRight)
        {
            return Tile_Type.GrassTopRight;
        }
        //if (tile == GrassTopLeftPlat)
        //{
        //    return Tile_Type.GrassTopLeftPlat;
        //}
        //if (tile == GrassTopRightPlat)
        //{
        //    return Tile_Type.GrassTopRightPlat;
        //}
        //if (tile == GrassTopDownPlat)
        //{
        //    return Tile_Type.GrassTopDownPlat;
        //}
        //if (tile == GrassBottomMid)
        //{
        //    return Tile_Type.GrassBottomMid;
        //}
        //if (tile == GrassBlock)
        //{
        //    return Tile_Type.GrassBlock;
        //}
        if (tile == DirtMid)
        {
            return Tile_Type.DirtMid;
        }
        if (tile == DirtLeft)
        {
            return Tile_Type.DirtLeft;
        }
        if (tile == DirtRight)
        {
            return Tile_Type.DirtRight;
        }
        //if (tile == DirtDownPlat)
        //{
        //    return Tile_Type.DirtDownPlat;
        //}
        //if (tile == DirtBottomLeft)
        //{
        //    return Tile_Type.DirtBottomLeft;
        //}
        //if (tile == DirtBottomRight)
        //{
        //    return Tile_Type.DirtBottomRight;
        //}
        //if (tile == DirtBottomMid)
        //{
        //    return Tile_Type.DirtBottomMid;
        //}
        //if (tile == DirtBlock)
        //{
        //    return Tile_Type.DirtBlock;
        //}
        return Tile_Type.unknown;
    }

    void GetLocalTiles(Vector3Int tilePos)
    {
        // initializing the position of neighbours.
        nTilePos = new Vector3Int(tilePos.x,tilePos.y+1,tilePos.z);
        sTilePos = new Vector3Int(tilePos.x, tilePos.y - 1, tilePos.z);
        wTilePos = new Vector3Int(tilePos.x-1, tilePos.y, tilePos.z);
        eTilePos = new Vector3Int(tilePos.x+1, tilePos.y, tilePos.z);

        // getting the original tile at that position
        nTile = tilemap.GetTile<Tile>(nTilePos);
        wTile = tilemap.GetTile<Tile>(wTilePos);
        eTile = tilemap.GetTile<Tile>(eTilePos);
        sTile = tilemap.GetTile<Tile>(sTilePos);

        //storing the tiles in list.
        localTiles = new List<object> { nTile, eTile, sTile, wTile };

        //storing the type of neighbour
        localTileTypes = new List<Tile_Type> { GetTileType(nTile), GetTileType(eTile), GetTileType(sTile), GetTileType(wTile) };
    }

    void UpdateTile(Tile_location loc)
    {
        switch (loc)
        {
            case Tile_location.N:
                switch (localTileTypes[0])
                {

                    case Tile_Type.DirtMid:
                        tilemap.SetTile(nTilePos,DirtMid);  //done
                        Debug.Log("dirtmid");
                        break;
                    case Tile_Type.DirtLeft:
                        tilemap.SetTile(nTilePos, DirtLeft);  //done
                        Debug.Log("dirtleft");
                        break;
                    case Tile_Type.DirtRight:
                        tilemap.SetTile(nTilePos, DirtRight);  //done
                        Debug.Log("dirtright");
                        break;
                    case Tile_Type.GrassTopMid:
                        tilemap.SetTile(nTilePos, GrassTopMid); //done
                        Debug.Log("grasstopmid");
                        break;
                    case Tile_Type.GrassTopLeft:
                        tilemap.SetTile(nTilePos, GrassTopLeft); //done
                        Debug.Log("dirtmid1");
                        break;
                    case Tile_Type.GrassTopRight:
                        tilemap.SetTile(nTilePos, GrassTopRight); //done
                        Debug.Log("dirtmid2");
                        break;
                       
                }
                break;
            case Tile_location.S:
                switch (localTileTypes[2])
                {

                    case Tile_Type.DirtMid:
                        tilemap.SetTile(sTilePos, GrassTopMid);  //done
                        break;
                    case Tile_Type.DirtLeft:
                        tilemap.SetTile(sTilePos, DirtLeft); //done
                        break;
                    case Tile_Type.DirtRight:
                        tilemap.SetTile(sTilePos, DirtRight); //done
                        break;
                    case Tile_Type.GrassTopMid:
                        tilemap.SetTile(sTilePos, GrassTopMid); //done
                        break;
                    case Tile_Type.GrassTopLeft:
                        tilemap.SetTile(sTilePos, GrassTopLeft); //done
                        break;
                    case Tile_Type.GrassTopRight:
                        tilemap.SetTile(sTilePos, GrassTopRight); //done
                        break;
                    
                }
                break;
            case Tile_location.W:
                switch (localTileTypes[3])
                {

                    case Tile_Type.DirtMid:
                        tilemap.SetTile(wTilePos, DirtRight);  //done
                        break;
                    case Tile_Type.DirtLeft:
                        tilemap.SetTile(wTilePos, DirtLeft); //done
                        break;
                    case Tile_Type.DirtRight:
                        tilemap.SetTile(wTilePos, DirtRight); //done
                        break;
                    case Tile_Type.GrassTopMid:
                        tilemap.SetTile(wTilePos, GrassTopRight); //done
                        break;
                    case Tile_Type.GrassTopLeft:
                        tilemap.SetTile(wTilePos, GrassTopLeft); //done
                        break;
                    case Tile_Type.GrassTopRight:
                        tilemap.SetTile(wTilePos, GrassTopRight); //done
                        break;
                    
                }
                break;
            case Tile_location.E:
                switch (localTileTypes[1])
                {

                    case Tile_Type.DirtMid:
                        tilemap.SetTile(eTilePos, DirtLeft);  //done
                        break;
                    case Tile_Type.DirtLeft:
                        tilemap.SetTile(eTilePos, DirtLeft);  //done
                        break;
                    case Tile_Type.DirtRight:
                        tilemap.SetTile(eTilePos, DirtRight); //done
                        break;
                    case Tile_Type.GrassTopMid:
                        tilemap.SetTile(eTilePos, GrassTopLeft); //done
                        break;
                    case Tile_Type.GrassTopLeft:
                        tilemap.SetTile(eTilePos, GrassTopLeft); //done
                        break;
                    case Tile_Type.GrassTopRight:
                        tilemap.SetTile(eTilePos, GrassTopRight); //done
                        break;
                    
                }
                break;
        }
    }

    void SetLocalTiles(Vector3Int tilePos)
    {
        foreach(Tile_location loc in Tile_location.GetValues(typeof(Tile_location)))
        {
            //Debug.Log(Tile_location.GetValues(typeof(Tile_location)));
            //Debug.Log(loc);
            //Debug.Log(typeof(Tile_location));
            UpdateTile(loc);
        }
    }
}
