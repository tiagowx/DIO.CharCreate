using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.CharCreate
{
  public class CharRepository : IRepository<Character>
  {
    public List<Character> MainList = new List<Character>();
    public int NextId() => MainList.Count + 1;
    public List<Character> ListOf() => new List<Character>();
    public void Insert(Character entity) => MainList.Add(entity);
    public void Update(int id, Character entity) => MainList[id] = entity;
    public Character GetById(int id) => MainList[id - 1];
    public void Remove(int id) => MainList[id-1].SocialStatus.Remove();
  }
}