using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Board : MonoBehaviour
{
	public List<Gem> gems = new List<Gem>();                            // reference that grants access to the gem list 
	public int GridWidth;                                              // reference that grants access to the grid width 
	public int GridHeight;                                            // refernce that grants access to the grid height    
	public GameObject gemPrefab;                                     // reference that grants access to the gem Prefab 
	public Gem lastGem;                                             // reference that grants access to the last gem
	public Vector3 gem1Start,gem1End,gem2Start,gem2End;            // reference that grants access to gem1 and gem2 start and end position 
	public bool isSwapping = false;                               // reference that grants acess to the boolean variable isSwapping
	public bool SwapBack =false;                                 // reference that grants access to the boolean variable swapback 
	public Gem gem1,gem2;                                       // reference that grants access to gem 1 and gem 2 
    public float startTime = 10;                               // reference that grants access to the start timer 
	public float SwapRate =1;                                 // reference that grants access to the swaprate 
	public int AmountToMatch = 3;                            // reference that grants access to the amount to match rate 
	public bool isMatched = false;                          // reference that grants access to the isMatched boolean variable 


    public int scoreValue;                                        //  refernece to the score value for each object that this script is attached to



    // Use this for initialization
    void Start () 
	{
		for(int y=0;y<GridHeight;y++)                     // for int loop that loops through the Y position of the grid height 
		{
			for(int x=0;x<GridWidth;x++)                 // for int loop that loops throught the X position of the grid width 
			{
				GameObject g = Instantiate(gemPrefab,new Vector3(x,y,0),Quaternion.identity)as GameObject;      // function that clones the gem prefab at it orgins  
				g.transform.parent = gameObject.transform;                                                     // function that transforms the parent gem gameobject 
				gems.Add(g.GetComponent<Gem>());                                                              // function that adds in gems  
			}
		}
		gameObject.transform.position = new Vector3(-2.5f,-2f,0);                                            // function that transforms the position of the grid to the set values 
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isMatched)                                                                                     // if than statement 
		{
			for(int i=0;i<gems.Count;i++)                                                                // for int loop that cycles through each gem 
			{   
				if(gems[i].isMatched)                                                                   // if than statement that will determine if a gem has been matched 
				{
					gems[i].CreateGem();                                                               // creating the game out of the for int loop 
					gems[i].transform.position = new Vector3(                                         // transforming the position of gem i using the algrothim that can be found below 
						gems[i].transform.position.x,
						gems[i].transform.position.y + 6,
						gems[i].transform.position.z);                                              // end of algorthim 
				}
			}
			isMatched = false;                                                                     // boolean that is determining that isMatched is = to false 
		}
		else if(isSwapping)                                                                      // if the boolean isMatched is equal to false than we are going to be swapping 
		{
			MoveGem(gem1,gem1End,gem1Start);                                                    // Moving Gem 1 to there start and end position 
			MoveNegGem(gem2,gem2End,gem2Start);                                                // Moving Gem 2 to there start and end positions 
			if(Vector3.Distance(gem1.transform.position,gem1End) <.1f ||Vector3.Distance(gem2.transform.position,gem2End) <.1f)              // the gems will only be swapped if they are within distance of one and another 
			{
				gem1.transform.position = gem1End;                                            // we are transforming gem 1 to its end position 
				gem2.transform.position = gem2End;                                           // we are transforming gem 2 to its end position 

				lastGem = null;                                                             // the last gem will = null 
				isSwapping =false;                                                         // if the boolean isSwapping = false than we are going to 
				TogglePhysics(false);                                                     // turn the physics system off 
				if(!SwapBack)                                                            // if we are not swapping back than we are going to 
				{
					gem1.ToggleSelector();                                              // toggle on the selector for gem1 
					gem2.ToggleSelector();                                             // and toggle on the selector for gem 2 
					CheckMatch();                                                     // we will than check to see if a match has been created 
				}
				else
				{
					SwapBack = false;                                              // we will swap the gems back to their desire location on the grid 
				}
			}
		}
		else if(!DetermineBoardState())                                           // we must first determine what is the state of the board 
		{
			for(int i =0 ;i<gems.Count;i++)                                      // than we must loop through are gems 
			{
				CheckForNearbyMatches(gems[i]);                                 // and check to see if there are any matches that are nearby 
			}
			
		}

	}

    // Determine Board State system 
    public bool DetermineBoardState()                              
	{
		for(int i=0;i<gems.Count;i++)                              // for int loop that will loop through each gem 
		{
            /* This line of code cause the game to break
             * when > is less than 6 or higher than 6 */
			if(gems[i].transform.localPosition.y >6)              // if the local position of Gem i is less than 6 than we will 
			{
				return true;                                     // return turn 
			}
			if(gems[i].GetComponent<Rigidbody>().velocity.y > 0.1f)   // we must than see if the rigidbody velocity of y is less than 0.1
			{                           
				return true;                                          // if it is we will then reutrn true 
			}       
			
		}
		return false;                                                // After returning true we must then return false 
	}
	
    // Checking Match System 
	public void CheckMatch()                                        
	{
		List<Gem> gem1List = new List<Gem>();                     // reference list for gem1 
		List<Gem> gem2List = new List<Gem>();                    // reference list for gem2 
		ConstructMatchList(gem1.color,gem1,gem1.XCoord,gem1.YCoord,ref gem1List);       // we are constructing the match list for Gem1 in the X position 
		FixMatchList(gem1,gem1List);                                                   // we are fixing the match list for gem1 
		ConstructMatchList(gem2.color,gem2,gem2.XCoord,gem2.YCoord,ref gem2List);     //  we are constructing the match list for Gem2 in the u position 
        FixMatchList(gem2,gem2List);                                                 // we are fixing the match list for gem1 
        if (!isMatched)                                                             // if isMatched is not true 
		{
			SwapBack = true;                                                       // Swapback will then equal true 
			ResetGems();                                                          // And we must then rest the gems 
		}

	}

    // Resting Gems System 
	public void ResetGems()
	{
		gem1Start = gem1.transform.position;                                // we are getting gem1 start position then transforming its position 
		gem1End = gem2.transform.position;                                 // we are getting gem1 end position then we are going to transform it between gem 2 position 
		
		gem2Start = gem2.transform.position;                              // we are getting gem2 start position then transforming its position 

        gem2End = gem1.transform.position;                              // we are getting gem2 end position then we are going to transform it between gem 2 position 

        startTime = Time.time;                                        // are start time will equal time .time 
		TogglePhysics(true);                                         // we are turning are physics system back on 
		isSwapping = true;                                          // isSwapping will then equal true and swap the gems 
	}

    // Checking Matches systems 
	public void CheckForNearbyMatches(Gem g)
	{
		List<Gem> gemList = new List<Gem>();                     // functions that is granting acess to the gem list then creating a new gem list 
		ConstructMatchList(g.color,g,g.XCoord,g.YCoord,ref gemList);        // Constructing the matches for the new gem list in the Y position 
		FixMatchList(g,gemList);                                            // fixing the match list for gem g 
	}
	
    // Matching List system 
	public void ConstructMatchList(string color,Gem gem,int XCoord,int YCoord, ref List<Gem> MatchList)         
	{
		if(gem == null)                                            // if the gem == null we are going to 
		{
			return;                                              // then we are going to return it 
		}
		else if(gem.color != color)                             // if color not equal to color then we are going to 
		{
			return;                                             // return the color 
		}
		else if(MatchList.Contains(gem))                        // the match list contains the gem we are going to 
		{
			return;                                            // return the match list 
		}
		else
		{
			MatchList.Add(gem);                             // we are going to add the gem to the match list 
			if(XCoord == gem.XCoord || YCoord == gem.YCoord)        // if the X coordante == the gem X corrand ||and the Y coord == the gem Ycoord we are going to
			{
				foreach(Gem g in gem.Neighbors)                 // loop through gem g in are gem neighbors then we are going to 
				{
					ConstructMatchList(color,g,XCoord,YCoord,ref MatchList);            // construct the match list for gem G 
				}
			}
		}
		
	}

    // Bord Matching system
	public bool DoesBoardContainMatches()                                           // Interal Economony 
	{
		TogglePhysics(true);
		for(int i=0;i<gems.Count;i++)
		{
			for(int j =0;j<gems.Count;j++)
			{
				if(gems[i].IsNeighborWith(gems[j]))
				{
					Gem g  = gems[i];
					Gem f = gems[j];
					Vector3 GTemp = g.transform.position;
					Vector3 FTemp = f.transform.position;
					List<Gem> tempNeighbors = new List<Gem>(g.Neighbors);
					g.transform.position = FTemp;
					f.transform.position =GTemp;
					g.Neighbors = f.Neighbors;
					f.Neighbors = tempNeighbors;
					List<Gem> testListG = new List<Gem>();
					ConstructMatchList(g.color,g,g.XCoord,g.YCoord,ref testListG);
					if(TestMatchList(g,testListG))
					{
						g.transform.position = GTemp;
						f.transform.position = FTemp;
						f.Neighbors = g.Neighbors;
						g.Neighbors = tempNeighbors;
						TogglePhysics(false);
						return true;
					}
					List<Gem> testListF = new List<Gem>();
					ConstructMatchList(f.color,f,f.XCoord,f.YCoord,ref testListF);
					if(TestMatchList(f,testListF))
					{
						g.transform.position = GTemp;
						f.transform.position = FTemp;
						f.Neighbors = g.Neighbors;
						g.Neighbors = tempNeighbors;
						TogglePhysics(false);
						return true;
					}

					g.transform.position = GTemp;
					f.transform.position = FTemp;
					f.Neighbors = g.Neighbors;
					g.Neighbors = tempNeighbors;
					TogglePhysics(true);
				}
			}
		}
		return false;
	}

	public bool TestMatchList(Gem gem, List<Gem> ListToFix)                     // Interal Econmoy 
	{
		List<Gem> rows = new List<Gem>();
		List<Gem> collumns = new List<Gem>();
		for(int i=0;i<ListToFix.Count;i++)
		{
			if(gem.XCoord == ListToFix[i].XCoord)
			{
				rows.Add(ListToFix[i]);
			}
			if(gem.YCoord == ListToFix[i].YCoord)
			{
				collumns.Add(ListToFix[i]);
			}
		}
		if(rows.Count >= AmountToMatch)
		{
			return true;
		}
		if(collumns.Count >= AmountToMatch)
		{
			return true;
		}

		return false;
	}

    // Fixing Match list System 
	public void FixMatchList(Gem gem, List<Gem> ListToFix)                              // Interal Econmony
	{
		List<Gem> rows = new List<Gem>();
		List<Gem> collumns = new List<Gem>();
		for(int i=0;i<ListToFix.Count;i++)
		{
			if(gem.XCoord == ListToFix[i].XCoord)
			{
				rows.Add(ListToFix[i]);
			}
			if(gem.YCoord == ListToFix[i].YCoord)
			{
				collumns.Add(ListToFix[i]);
			}
		}
		if(rows.Count >= AmountToMatch)
		{
            GameObject.Find("ScoreMeter").GetComponent<ScoreMeter>().AddScore(5);            // Finding the match 3 then getting the game controller and adding 1 to the score when the player makes a match 
			isMatched = true;
			for(int i=0;i<rows.Count;i++)
			{
				rows[i].isMatched = true;
			}
		}
		if(collumns.Count >= AmountToMatch)
		{
            GameObject.Find("ScoreMeter").GetComponent<ScoreMeter>().AddScore(5);            // Finding the match 3 then getting the game controller and adding 1 to the score when the player makes a match 
            isMatched = true;
			for(int i=0;i<collumns.Count;i++)
			{
				collumns[i].isMatched = true;
			}
		}
	}
	
    // Movement System 
	public void MoveGem(Gem gemToMove,Vector3 toPos,Vector3 fromPos)                        // Physics Mechanic 
	{
		Vector3 center = (fromPos + toPos) *.5f;
		center -= new Vector3(0,0,.1f);
		Vector3 riseRelCenter = fromPos - center;
		Vector3 setRelCenter = toPos - center;
		float fracComplete = (Time.time - startTime)/SwapRate;
		gemToMove.transform.position = Vector3.Slerp(riseRelCenter,setRelCenter,fracComplete);
		gemToMove.transform.position += center;
	}

    // Moving Neghibors systems                                         
	public void MoveNegGem(Gem gemToMove,Vector3 toPos,Vector3 fromPos)                     //Phsyics Mechanic 
	{
		Vector3 center = (fromPos + toPos) *.5f;
		center -= new Vector3(0,0,-.1f);
		Vector3 riseRelCenter = fromPos - center;
		Vector3 setRelCenter = toPos - center;
		float fracComplete = (Time.time - startTime)/SwapRate;
		gemToMove.transform.position = Vector3.Slerp(riseRelCenter,setRelCenter,fracComplete);
		gemToMove.transform.position += center;
	}

    // Toggle system                                              
	public void TogglePhysics(bool isOn)                                   // Interal Ecomony 
    {
		for(int i=0;i<gems.Count;i++)
		{
			gems[i].GetComponent<Rigidbody>().isKinematic = isOn;
		}
	}

    // Swapping System                                                      
	public void SwapGems(Gem currentGem)                                // Interal Ecomony 
	{
		if(lastGem == null)
		{
			lastGem = currentGem;
		}
		else if(lastGem == currentGem)
		{
			lastGem = null;
		}
		else
		{
			if(lastGem.IsNeighborWith(currentGem))
			{
				gem1Start = lastGem.transform.position;
				gem1End = currentGem.transform.position;
				
				gem2Start = currentGem.transform.position;
				gem2End = lastGem.transform.position;
				
				startTime = Time.time;
				TogglePhysics(true);
				gem1 = lastGem;
				gem2 = currentGem;
				isSwapping = true;
			}
			else
			{
				lastGem.ToggleSelector();
				lastGem = currentGem;
			}
		}
    }
}
