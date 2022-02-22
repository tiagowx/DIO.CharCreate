using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.CharCreate
{
  public class BaseStatus
  {
    public int Strength { get; private set; }
    public int Construction { get; private set; }
    public int Dexterity { get; private set; }
    public int Inteligence { get; private set; }
    public int Mentalization { get; private set; }
    public int Wit { get; private set; }


    public void SetBaseStatus(int strength, int construction, int dexterity, int inteligence, int mentalization, int wit)
    {
      this.Strength = strength;
      this.Construction = construction;
      this.Dexterity = dexterity;
      this.Inteligence = inteligence;
      this.Mentalization = mentalization;
      this.Wit = wit;
    }
  }
  public class SocialStatus
  {
    public string? Name { get; private set; }
    public int Level { get; private set; }
    public int Experience { get; private set; }
    public CharClass CharClass { get; private set; }
    public bool Exist { get; private set; }


    public string SetName(string name) => this.Name = name;
    public int SetLevel(int lvl) => this.Level = lvl;
    public int SetExperience(int exp) => this.Experience = exp;
    public CharClass SetCharClass(CharClass charClass) => this.CharClass = charClass;

    public bool Remove() => Exist = true;

  }
  public class SubStatus
  {
    public int MaxHp(BaseStatus baseStatus) => baseStatus.Construction * 30;
    public int MaxMp(BaseStatus baseStatus) => baseStatus.Mentalization * 30;

    public int PDamage(BaseStatus baseStatus) => baseStatus.Strength * 3;
    public int PCriticalDamage(BaseStatus baseStatus) => baseStatus.Strength * 3 * 2;
    public int PCriticalChance(BaseStatus baseStatus) => (int)(baseStatus.Dexterity * 0.5f);

    public int MDamage(BaseStatus baseStatus) => baseStatus.Inteligence * 3;
    public int MCriticalDamage(BaseStatus baseStatus) => baseStatus.Inteligence * 3 * 2;
    public int MCriticalChance(BaseStatus baseStatus) => (int)(baseStatus.Wit * 0.5f);

    public int PDefense(BaseStatus baseStatus) => baseStatus.Construction * 3;
    public int MDefense(BaseStatus baseStatus) => baseStatus.Mentalization * 3;


  }
}