using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavableLevel : ISavable
{
   public string CountOfLevel;
   public SavableLevel(string countOfScores)
   {
    CountOfLevel = countOfScores;
   }
   public SavableLevel()
   {
    
   }
}
