using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.CharCreate
{
    public class CharRepository : IRepository<Character>
    {
        public List<Character> MainList = new List<Character>();
        public int NextId() => 0;
        public List<Character> ListAll() => new List<Character>();
        public List<Character> ListOf() =>new List<Character>();
        public void Insert(Character character) => MainList.Add(character);
        public void Remove(int id) => MainList[id].SocialStatus.Remove();
        public void Update(int id, Character entity) => MainList[id] = entity ;
        public Character GetById(int id) => MainList[id];
    }
}