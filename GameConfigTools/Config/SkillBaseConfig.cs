/**
 * Autogenerated by Thrift Compiler (0.9.1)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace Config
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class SkillBaseConfig : TBase
  {
    private int _id;
    private int _nameMessageId;
    private int _heroId;
    private int _descMessageId;
    private string _skillIcon;
    private string _animation;
    private sbyte _priority;
    private sbyte _skillType;
    private sbyte _useType;
    private int _atkRange;
    private sbyte _skillFlag;
    private sbyte _atkScopeType;
    private sbyte _castEffect;
    private sbyte _castType;
    private sbyte _noLockType;
    private int _noLockAtkScope;
    private sbyte _effectType;
    private bool _moveCancel;
    private bool _vertigoCancel;
    private bool _silentCancel;
    private bool _sheepCancel;

    public int Id
    {
      get
      {
        return _id;
      }
      set
      {
        __isset.id = true;
        this._id = value;
      }
    }

    public int NameMessageId
    {
      get
      {
        return _nameMessageId;
      }
      set
      {
        __isset.nameMessageId = true;
        this._nameMessageId = value;
      }
    }

    public int HeroId
    {
      get
      {
        return _heroId;
      }
      set
      {
        __isset.heroId = true;
        this._heroId = value;
      }
    }

    public int DescMessageId
    {
      get
      {
        return _descMessageId;
      }
      set
      {
        __isset.descMessageId = true;
        this._descMessageId = value;
      }
    }

    public string SkillIcon
    {
      get
      {
        return _skillIcon;
      }
      set
      {
        __isset.skillIcon = true;
        this._skillIcon = value;
      }
    }

    public string Animation
    {
      get
      {
        return _animation;
      }
      set
      {
        __isset.animation = true;
        this._animation = value;
      }
    }

    public sbyte Priority
    {
      get
      {
        return _priority;
      }
      set
      {
        __isset.priority = true;
        this._priority = value;
      }
    }

    /// <summary>
    /// 0:无效 1:被动技能 2:主动技能
    /// </summary>
    public sbyte SkillType
    {
      get
      {
        return _skillType;
      }
      set
      {
        __isset.skillType = true;
        this._skillType = value;
      }
    }

    /// <summary>
    /// 使用方式，0:无效，1:进入副本自动释放一次，2:进入游戏、技能升级、技能升级品质都释放
    /// </summary>
    public sbyte UseType
    {
      get
      {
        return _useType;
      }
      set
      {
        __isset.useType = true;
        this._useType = value;
      }
    }

    /// <summary>
    /// 攻击距离
    /// </summary>
    public int AtkRange
    {
      get
      {
        return _atkRange;
      }
      set
      {
        __isset.atkRange = true;
        this._atkRange = value;
      }
    }

    /// <summary>
    /// 0:非无双技 1:无双技
    /// </summary>
    public sbyte SkillFlag
    {
      get
      {
        return _skillFlag;
      }
      set
      {
        __isset.skillFlag = true;
        this._skillFlag = value;
      }
    }

    /// <summary>
    /// 0：无效，1：单体，2：群体
    /// </summary>
    public sbyte AtkScopeType
    {
      get
      {
        return _atkScopeType;
      }
      set
      {
        __isset.atkScopeType = true;
        this._atkScopeType = value;
      }
    }

    /// <summary>
    /// 1:瞬发 2:持续
    /// </summary>
    public sbyte CastEffect
    {
      get
      {
        return _castEffect;
      }
      set
      {
        __isset.castEffect = true;
        this._castEffect = value;
      }
    }

    /// <summary>
    /// 0:无效 1:近战锁定 2:近战不锁定 3:远程锁定 4:远程不锁定
    /// </summary>
    public sbyte CastType
    {
      get
      {
        return _castType;
      }
      set
      {
        __isset.castType = true;
        this._castType = value;
      }
    }

    /// <summary>
    /// 无锁定类型 0:无效 1:矩形攻击 2:点攻击 3:扇形60度
    /// </summary>
    public sbyte NoLockType
    {
      get
      {
        return _noLockType;
      }
      set
      {
        __isset.noLockType = true;
        this._noLockType = value;
      }
    }

    /// <summary>
    /// 无锁定攻击范围，打击到敌人是判断，范围内所有敌人都受影响
    /// </summary>
    public int NoLockAtkScope
    {
      get
      {
        return _noLockAtkScope;
      }
      set
      {
        __isset.noLockAtkScope = true;
        this._noLockAtkScope = value;
      }
    }

    public sbyte EffectType
    {
      get
      {
        return _effectType;
      }
      set
      {
        __isset.effectType = true;
        this._effectType = value;
      }
    }

    /// <summary>
    /// 移动打断
    /// </summary>
    public bool MoveCancel
    {
      get
      {
        return _moveCancel;
      }
      set
      {
        __isset.moveCancel = true;
        this._moveCancel = value;
      }
    }

    /// <summary>
    /// 眩晕打断
    /// </summary>
    public bool VertigoCancel
    {
      get
      {
        return _vertigoCancel;
      }
      set
      {
        __isset.vertigoCancel = true;
        this._vertigoCancel = value;
      }
    }

    /// <summary>
    /// 沉默打断
    /// </summary>
    public bool SilentCancel
    {
      get
      {
        return _silentCancel;
      }
      set
      {
        __isset.silentCancel = true;
        this._silentCancel = value;
      }
    }

    /// <summary>
    /// 变羊打断
    /// </summary>
    public bool SheepCancel
    {
      get
      {
        return _sheepCancel;
      }
      set
      {
        __isset.sheepCancel = true;
        this._sheepCancel = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool id;
      public bool nameMessageId;
      public bool heroId;
      public bool descMessageId;
      public bool skillIcon;
      public bool animation;
      public bool priority;
      public bool skillType;
      public bool useType;
      public bool atkRange;
      public bool skillFlag;
      public bool atkScopeType;
      public bool castEffect;
      public bool castType;
      public bool noLockType;
      public bool noLockAtkScope;
      public bool effectType;
      public bool moveCancel;
      public bool vertigoCancel;
      public bool silentCancel;
      public bool sheepCancel;
    }

    public SkillBaseConfig() {
    }

    public void Read (TProtocol iprot)
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 10:
            if (field.Type == TType.I32) {
              Id = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.I32) {
              NameMessageId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.I32) {
              HeroId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 50:
            if (field.Type == TType.I32) {
              DescMessageId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 60:
            if (field.Type == TType.String) {
              SkillIcon = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 70:
            if (field.Type == TType.String) {
              Animation = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 80:
            if (field.Type == TType.Byte) {
              Priority = iprot.ReadByte();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 90:
            if (field.Type == TType.Byte) {
              SkillType = iprot.ReadByte();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 91:
            if (field.Type == TType.Byte) {
              UseType = iprot.ReadByte();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 100:
            if (field.Type == TType.I32) {
              AtkRange = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 110:
            if (field.Type == TType.Byte) {
              SkillFlag = iprot.ReadByte();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 111:
            if (field.Type == TType.Byte) {
              AtkScopeType = iprot.ReadByte();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 119:
            if (field.Type == TType.Byte) {
              CastEffect = iprot.ReadByte();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 120:
            if (field.Type == TType.Byte) {
              CastType = iprot.ReadByte();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 130:
            if (field.Type == TType.Byte) {
              NoLockType = iprot.ReadByte();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 150:
            if (field.Type == TType.I32) {
              NoLockAtkScope = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 170:
            if (field.Type == TType.Byte) {
              EffectType = iprot.ReadByte();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 180:
            if (field.Type == TType.Bool) {
              MoveCancel = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 190:
            if (field.Type == TType.Bool) {
              VertigoCancel = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 200:
            if (field.Type == TType.Bool) {
              SilentCancel = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 210:
            if (field.Type == TType.Bool) {
              SheepCancel = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("SkillBaseConfig");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.id) {
        field.Name = "id";
        field.Type = TType.I32;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Id);
        oprot.WriteFieldEnd();
      }
      if (__isset.nameMessageId) {
        field.Name = "nameMessageId";
        field.Type = TType.I32;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(NameMessageId);
        oprot.WriteFieldEnd();
      }
      if (__isset.heroId) {
        field.Name = "heroId";
        field.Type = TType.I32;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(HeroId);
        oprot.WriteFieldEnd();
      }
      if (__isset.descMessageId) {
        field.Name = "descMessageId";
        field.Type = TType.I32;
        field.ID = 50;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DescMessageId);
        oprot.WriteFieldEnd();
      }
      if (SkillIcon != null && __isset.skillIcon) {
        field.Name = "skillIcon";
        field.Type = TType.String;
        field.ID = 60;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(SkillIcon);
        oprot.WriteFieldEnd();
      }
      if (Animation != null && __isset.animation) {
        field.Name = "animation";
        field.Type = TType.String;
        field.ID = 70;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Animation);
        oprot.WriteFieldEnd();
      }
      if (__isset.priority) {
        field.Name = "priority";
        field.Type = TType.Byte;
        field.ID = 80;
        oprot.WriteFieldBegin(field);
        oprot.WriteByte(Priority);
        oprot.WriteFieldEnd();
      }
      if (__isset.skillType) {
        field.Name = "skillType";
        field.Type = TType.Byte;
        field.ID = 90;
        oprot.WriteFieldBegin(field);
        oprot.WriteByte(SkillType);
        oprot.WriteFieldEnd();
      }
      if (__isset.useType) {
        field.Name = "useType";
        field.Type = TType.Byte;
        field.ID = 91;
        oprot.WriteFieldBegin(field);
        oprot.WriteByte(UseType);
        oprot.WriteFieldEnd();
      }
      if (__isset.atkRange) {
        field.Name = "atkRange";
        field.Type = TType.I32;
        field.ID = 100;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(AtkRange);
        oprot.WriteFieldEnd();
      }
      if (__isset.skillFlag) {
        field.Name = "skillFlag";
        field.Type = TType.Byte;
        field.ID = 110;
        oprot.WriteFieldBegin(field);
        oprot.WriteByte(SkillFlag);
        oprot.WriteFieldEnd();
      }
      if (__isset.atkScopeType) {
        field.Name = "atkScopeType";
        field.Type = TType.Byte;
        field.ID = 111;
        oprot.WriteFieldBegin(field);
        oprot.WriteByte(AtkScopeType);
        oprot.WriteFieldEnd();
      }
      if (__isset.castEffect) {
        field.Name = "castEffect";
        field.Type = TType.Byte;
        field.ID = 119;
        oprot.WriteFieldBegin(field);
        oprot.WriteByte(CastEffect);
        oprot.WriteFieldEnd();
      }
      if (__isset.castType) {
        field.Name = "castType";
        field.Type = TType.Byte;
        field.ID = 120;
        oprot.WriteFieldBegin(field);
        oprot.WriteByte(CastType);
        oprot.WriteFieldEnd();
      }
      if (__isset.noLockType) {
        field.Name = "noLockType";
        field.Type = TType.Byte;
        field.ID = 130;
        oprot.WriteFieldBegin(field);
        oprot.WriteByte(NoLockType);
        oprot.WriteFieldEnd();
      }
      if (__isset.noLockAtkScope) {
        field.Name = "noLockAtkScope";
        field.Type = TType.I32;
        field.ID = 150;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(NoLockAtkScope);
        oprot.WriteFieldEnd();
      }
      if (__isset.effectType) {
        field.Name = "effectType";
        field.Type = TType.Byte;
        field.ID = 170;
        oprot.WriteFieldBegin(field);
        oprot.WriteByte(EffectType);
        oprot.WriteFieldEnd();
      }
      if (__isset.moveCancel) {
        field.Name = "moveCancel";
        field.Type = TType.Bool;
        field.ID = 180;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(MoveCancel);
        oprot.WriteFieldEnd();
      }
      if (__isset.vertigoCancel) {
        field.Name = "vertigoCancel";
        field.Type = TType.Bool;
        field.ID = 190;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(VertigoCancel);
        oprot.WriteFieldEnd();
      }
      if (__isset.silentCancel) {
        field.Name = "silentCancel";
        field.Type = TType.Bool;
        field.ID = 200;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(SilentCancel);
        oprot.WriteFieldEnd();
      }
      if (__isset.sheepCancel) {
        field.Name = "sheepCancel";
        field.Type = TType.Bool;
        field.ID = 210;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(SheepCancel);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("SkillBaseConfig(");
      sb.Append("Id: ");
      sb.Append(Id);
      sb.Append(",NameMessageId: ");
      sb.Append(NameMessageId);
      sb.Append(",HeroId: ");
      sb.Append(HeroId);
      sb.Append(",DescMessageId: ");
      sb.Append(DescMessageId);
      sb.Append(",SkillIcon: ");
      sb.Append(SkillIcon);
      sb.Append(",Animation: ");
      sb.Append(Animation);
      sb.Append(",Priority: ");
      sb.Append(Priority);
      sb.Append(",SkillType: ");
      sb.Append(SkillType);
      sb.Append(",UseType: ");
      sb.Append(UseType);
      sb.Append(",AtkRange: ");
      sb.Append(AtkRange);
      sb.Append(",SkillFlag: ");
      sb.Append(SkillFlag);
      sb.Append(",AtkScopeType: ");
      sb.Append(AtkScopeType);
      sb.Append(",CastEffect: ");
      sb.Append(CastEffect);
      sb.Append(",CastType: ");
      sb.Append(CastType);
      sb.Append(",NoLockType: ");
      sb.Append(NoLockType);
      sb.Append(",NoLockAtkScope: ");
      sb.Append(NoLockAtkScope);
      sb.Append(",EffectType: ");
      sb.Append(EffectType);
      sb.Append(",MoveCancel: ");
      sb.Append(MoveCancel);
      sb.Append(",VertigoCancel: ");
      sb.Append(VertigoCancel);
      sb.Append(",SilentCancel: ");
      sb.Append(SilentCancel);
      sb.Append(",SheepCancel: ");
      sb.Append(SheepCancel);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
