using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVisitor 
{
   void Visit(Player player);
   void Visit(Enemy enemy);
   //void Visit(Slime slime);
   //void Visit(Warrior warrior) ;
   //void Visit(Ranger ranger);
}
