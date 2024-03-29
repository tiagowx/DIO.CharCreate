using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.CharCreate
{
  public class Character : BaseClass
  {
    public BaseStatus BaseStatus = new BaseStatus();
    public SocialStatus SocialStatus = new SocialStatus();
    public SubStatus SubStatus = new SubStatus();

    public int CurrentHP { get; private set; }
    public int CurrentMP { get; private set; }

    public Character(int id, string name, CharClass charClass)
    {
      this.Id = id;
      this.SocialStatus.SetName(name);
      this.SocialStatus.SetCharClass(charClass);

      switch (this.SocialStatus.CharClass)
      {
        case CharClass.HUNTER:
          this.BaseStatus.SetBaseStatus(6, 5, 9, 3, 4, 3);
          break;
        case CharClass.PALADIN:
          this.BaseStatus.SetBaseStatus(5, 9, 3, 3, 7, 3);
          break;
        case CharClass.WIZARD:
          this.BaseStatus.SetBaseStatus(3, 4, 3, 9, 6, 6);
          break;
      }

      CurrentHP = SubStatus.MaxHp(BaseStatus);
      CurrentMP = SubStatus.MaxMp(BaseStatus);

    }

    public override string ToString()
    {
      string props = "";

      props += $"#{this.Id} ";
      props += $"Name: {this.SocialStatus.Name} ";
      props += $"({this.SocialStatus.CharClass}) ";
      props += $"Lvl: {this.SocialStatus.Level + 1} \n";
      props += $"   HP/MaxHP: {this.CurrentHP.ToString()}/{this.SubStatus.MaxHp(BaseStatus)} \n";
      props += $"   MP/MaxMP: {this.CurrentMP.ToString()}/{this.SubStatus.MaxMp(BaseStatus)}";

      return props;
    }

    public string Status()
    {
      string status = this.ToString() + "\n";
      // Physical
      status += $"\t STR: {this.BaseStatus.Strength} ";
      status += $"CON: {this.BaseStatus.Construction} ";
      status += $"DEX: {this.BaseStatus.Dexterity} \n";
      status += $"\t P.Damage: {this.SubStatus.PDamage(this.BaseStatus)} ";
      status += $"P.C.Damage: {this.SubStatus.PCriticalChance(this.BaseStatus)} ";
      status += $"P.Defence: {this.SubStatus.PDefense(this.BaseStatus)} ";
      status += $"P.C.Chance: {this.SubStatus.PCriticalChance(this.BaseStatus)} \n\n";
      // Magical
      status += $"\t INT: {this.BaseStatus.Inteligence} ";
      status += $"MEN: {this.BaseStatus.Mentalization} ";
      status += $"WIT: {this.BaseStatus.Wit} \n";
      status += $"\t M.Damage: {this.SubStatus.MDamage(this.BaseStatus)} ";
      status += $"M.C.Damage: {this.SubStatus.MCriticalChance(this.BaseStatus)} ";
      status += $"M.Defence: {this.SubStatus.MDefense(this.BaseStatus)} ";
      status += $"M.C.Chance: {this.SubStatus.MCriticalChance(this.BaseStatus)} \n\n";
      return status;
    }
  }
}