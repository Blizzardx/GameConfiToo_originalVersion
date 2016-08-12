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
  public partial class HeroConfig : TBase
  {
    private int _id;
    private int _nameMessageId;
    private int _descMessageId;
    private bool _show;
    private string _headIcon;
    private string _dialogIcon;
    private string _model;
    private sbyte _atkType;
    private sbyte _sex;
    private sbyte _camp;
    private sbyte _occupation;
    private sbyte _initStarLevel;
    private sbyte _initQuality;
    private sbyte _initLevel;
    private short _initHp;
    private short _initPhyAtk;
    private short _initPhyDef;
    private short _initMagicAtk;
    private short _initMagicDef;
    private short _atkInterval;
    private short _moveSpeed;
    private short _initAvo;
    private short _initCri;
    private short _initCriDamage;
    private int _growAttrRateId;
    private int _aiId;
    private int _starLevelUpId;
    private int _shardItemId;
    private int _runSkillId;
    private int _idleSkillId;
    private int _winSkillId;
    private int _deathSkillId;
    private List<int> _skillIdList;

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

    public bool Show
    {
      get
      {
        return _show;
      }
      set
      {
        __isset.show = true;
        this._show = value;
      }
    }

    public string HeadIcon
    {
      get
      {
        return _headIcon;
      }
      set
      {
        __isset.headIcon = true;
        this._headIcon = value;
      }
    }

    public string DialogIcon
    {
      get
      {
        return _dialogIcon;
      }
      set
      {
        __isset.dialogIcon = true;
        this._dialogIcon = value;
      }
    }

    public string Model
    {
      get
      {
        return _model;
      }
      set
      {
        __isset.model = true;
        this._model = value;
      }
    }

    public sbyte AtkType
    {
      get
      {
        return _atkType;
      }
      set
      {
        __isset.atkType = true;
        this._atkType = value;
      }
    }

    public sbyte Sex
    {
      get
      {
        return _sex;
      }
      set
      {
        __isset.sex = true;
        this._sex = value;
      }
    }

    public sbyte Camp
    {
      get
      {
        return _camp;
      }
      set
      {
        __isset.camp = true;
        this._camp = value;
      }
    }

    public sbyte Occupation
    {
      get
      {
        return _occupation;
      }
      set
      {
        __isset.occupation = true;
        this._occupation = value;
      }
    }

    public sbyte InitStarLevel
    {
      get
      {
        return _initStarLevel;
      }
      set
      {
        __isset.initStarLevel = true;
        this._initStarLevel = value;
      }
    }

    public sbyte InitQuality
    {
      get
      {
        return _initQuality;
      }
      set
      {
        __isset.initQuality = true;
        this._initQuality = value;
      }
    }

    public sbyte InitLevel
    {
      get
      {
        return _initLevel;
      }
      set
      {
        __isset.initLevel = true;
        this._initLevel = value;
      }
    }

    public short InitHp
    {
      get
      {
        return _initHp;
      }
      set
      {
        __isset.initHp = true;
        this._initHp = value;
      }
    }

    public short InitPhyAtk
    {
      get
      {
        return _initPhyAtk;
      }
      set
      {
        __isset.initPhyAtk = true;
        this._initPhyAtk = value;
      }
    }

    public short InitPhyDef
    {
      get
      {
        return _initPhyDef;
      }
      set
      {
        __isset.initPhyDef = true;
        this._initPhyDef = value;
      }
    }

    public short InitMagicAtk
    {
      get
      {
        return _initMagicAtk;
      }
      set
      {
        __isset.initMagicAtk = true;
        this._initMagicAtk = value;
      }
    }

    public short InitMagicDef
    {
      get
      {
        return _initMagicDef;
      }
      set
      {
        __isset.initMagicDef = true;
        this._initMagicDef = value;
      }
    }

    public short AtkInterval
    {
      get
      {
        return _atkInterval;
      }
      set
      {
        __isset.atkInterval = true;
        this._atkInterval = value;
      }
    }

    public short MoveSpeed
    {
      get
      {
        return _moveSpeed;
      }
      set
      {
        __isset.moveSpeed = true;
        this._moveSpeed = value;
      }
    }

    public short InitAvo
    {
      get
      {
        return _initAvo;
      }
      set
      {
        __isset.initAvo = true;
        this._initAvo = value;
      }
    }

    public short InitCri
    {
      get
      {
        return _initCri;
      }
      set
      {
        __isset.initCri = true;
        this._initCri = value;
      }
    }

    public short InitCriDamage
    {
      get
      {
        return _initCriDamage;
      }
      set
      {
        __isset.initCriDamage = true;
        this._initCriDamage = value;
      }
    }

    public int GrowAttrRateId
    {
      get
      {
        return _growAttrRateId;
      }
      set
      {
        __isset.growAttrRateId = true;
        this._growAttrRateId = value;
      }
    }

    public int AiId
    {
      get
      {
        return _aiId;
      }
      set
      {
        __isset.aiId = true;
        this._aiId = value;
      }
    }

    public int StarLevelUpId
    {
      get
      {
        return _starLevelUpId;
      }
      set
      {
        __isset.starLevelUpId = true;
        this._starLevelUpId = value;
      }
    }

    public int ShardItemId
    {
      get
      {
        return _shardItemId;
      }
      set
      {
        __isset.shardItemId = true;
        this._shardItemId = value;
      }
    }

    public int RunSkillId
    {
      get
      {
        return _runSkillId;
      }
      set
      {
        __isset.runSkillId = true;
        this._runSkillId = value;
      }
    }

    public int IdleSkillId
    {
      get
      {
        return _idleSkillId;
      }
      set
      {
        __isset.idleSkillId = true;
        this._idleSkillId = value;
      }
    }

    public int WinSkillId
    {
      get
      {
        return _winSkillId;
      }
      set
      {
        __isset.winSkillId = true;
        this._winSkillId = value;
      }
    }

    public int DeathSkillId
    {
      get
      {
        return _deathSkillId;
      }
      set
      {
        __isset.deathSkillId = true;
        this._deathSkillId = value;
      }
    }

    public List<int> SkillIdList
    {
      get
      {
        return _skillIdList;
      }
      set
      {
        __isset.skillIdList = true;
        this._skillIdList = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool id;
      public bool nameMessageId;
      public bool descMessageId;
      public bool show;
      public bool headIcon;
      public bool dialogIcon;
      public bool model;
      public bool atkType;
      public bool sex;
      public bool camp;
      public bool occupation;
      public bool initStarLevel;
      public bool initQuality;
      public bool initLevel;
      public bool initHp;
      public bool initPhyAtk;
      public bool initPhyDef;
      public bool initMagicAtk;
      public bool initMagicDef;
      public bool atkInterval;
      public bool moveSpeed;
      public bool initAvo;
      public bool initCri;
      public bool initCriDamage;
      public bool growAttrRateId;
      public bool aiId;
      public bool starLevelUpId;
      public bool shardItemId;
      public bool runSkillId;
      public bool idleSkillId;
      public bool winSkillId;
      public bool deathSkillId;
      public bool skillIdList;
    }

    public HeroConfig() {
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
          case 30:
            if (field.Type == TType.I32) {
              NameMessageId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 40:
            if (field.Type == TType.I32) {
              DescMessageId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 41:
            if (field.Type == TType.Bool) {
              Show = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 50:
            if (field.Type == TType.String) {
              HeadIcon = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 60:
            if (field.Type == TType.String) {
              DialogIcon = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 70:
            if (field.Type == TType.String) {
              Model = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 71:
            if (field.Type == TType.Byte) {
              AtkType = iprot.ReadByte();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 80:
            if (field.Type == TType.Byte) {
              Sex = iprot.ReadByte();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 90:
            if (field.Type == TType.Byte) {
              Camp = iprot.ReadByte();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 100:
            if (field.Type == TType.Byte) {
              Occupation = iprot.ReadByte();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 110:
            if (field.Type == TType.Byte) {
              InitStarLevel = iprot.ReadByte();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 120:
            if (field.Type == TType.Byte) {
              InitQuality = iprot.ReadByte();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 150:
            if (field.Type == TType.Byte) {
              InitLevel = iprot.ReadByte();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 160:
            if (field.Type == TType.I16) {
              InitHp = iprot.ReadI16();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 180:
            if (field.Type == TType.I16) {
              InitPhyAtk = iprot.ReadI16();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 200:
            if (field.Type == TType.I16) {
              InitPhyDef = iprot.ReadI16();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 220:
            if (field.Type == TType.I16) {
              InitMagicAtk = iprot.ReadI16();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 240:
            if (field.Type == TType.I16) {
              InitMagicDef = iprot.ReadI16();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 260:
            if (field.Type == TType.I16) {
              AtkInterval = iprot.ReadI16();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 270:
            if (field.Type == TType.I16) {
              MoveSpeed = iprot.ReadI16();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 280:
            if (field.Type == TType.I16) {
              InitAvo = iprot.ReadI16();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 300:
            if (field.Type == TType.I16) {
              InitCri = iprot.ReadI16();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 320:
            if (field.Type == TType.I16) {
              InitCriDamage = iprot.ReadI16();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 330:
            if (field.Type == TType.I32) {
              GrowAttrRateId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 340:
            if (field.Type == TType.I32) {
              AiId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 350:
            if (field.Type == TType.I32) {
              StarLevelUpId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 360:
            if (field.Type == TType.I32) {
              ShardItemId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 370:
            if (field.Type == TType.I32) {
              RunSkillId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 371:
            if (field.Type == TType.I32) {
              IdleSkillId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 372:
            if (field.Type == TType.I32) {
              WinSkillId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 373:
            if (field.Type == TType.I32) {
              DeathSkillId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 380:
            if (field.Type == TType.List) {
              {
                SkillIdList = new List<int>();
                TList _list12 = iprot.ReadListBegin();
                for( int _i13 = 0; _i13 < _list12.Count; ++_i13)
                {
                  int _elem14 = 0;
                  _elem14 = iprot.ReadI32();
                  SkillIdList.Add(_elem14);
                }
                iprot.ReadListEnd();
              }
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
      TStruct struc = new TStruct("HeroConfig");
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
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(NameMessageId);
        oprot.WriteFieldEnd();
      }
      if (__isset.descMessageId) {
        field.Name = "descMessageId";
        field.Type = TType.I32;
        field.ID = 40;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DescMessageId);
        oprot.WriteFieldEnd();
      }
      if (__isset.show) {
        field.Name = "show";
        field.Type = TType.Bool;
        field.ID = 41;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(Show);
        oprot.WriteFieldEnd();
      }
      if (HeadIcon != null && __isset.headIcon) {
        field.Name = "headIcon";
        field.Type = TType.String;
        field.ID = 50;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(HeadIcon);
        oprot.WriteFieldEnd();
      }
      if (DialogIcon != null && __isset.dialogIcon) {
        field.Name = "dialogIcon";
        field.Type = TType.String;
        field.ID = 60;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(DialogIcon);
        oprot.WriteFieldEnd();
      }
      if (Model != null && __isset.model) {
        field.Name = "model";
        field.Type = TType.String;
        field.ID = 70;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Model);
        oprot.WriteFieldEnd();
      }
      if (__isset.atkType) {
        field.Name = "atkType";
        field.Type = TType.Byte;
        field.ID = 71;
        oprot.WriteFieldBegin(field);
        oprot.WriteByte(AtkType);
        oprot.WriteFieldEnd();
      }
      if (__isset.sex) {
        field.Name = "sex";
        field.Type = TType.Byte;
        field.ID = 80;
        oprot.WriteFieldBegin(field);
        oprot.WriteByte(Sex);
        oprot.WriteFieldEnd();
      }
      if (__isset.camp) {
        field.Name = "camp";
        field.Type = TType.Byte;
        field.ID = 90;
        oprot.WriteFieldBegin(field);
        oprot.WriteByte(Camp);
        oprot.WriteFieldEnd();
      }
      if (__isset.occupation) {
        field.Name = "occupation";
        field.Type = TType.Byte;
        field.ID = 100;
        oprot.WriteFieldBegin(field);
        oprot.WriteByte(Occupation);
        oprot.WriteFieldEnd();
      }
      if (__isset.initStarLevel) {
        field.Name = "initStarLevel";
        field.Type = TType.Byte;
        field.ID = 110;
        oprot.WriteFieldBegin(field);
        oprot.WriteByte(InitStarLevel);
        oprot.WriteFieldEnd();
      }
      if (__isset.initQuality) {
        field.Name = "initQuality";
        field.Type = TType.Byte;
        field.ID = 120;
        oprot.WriteFieldBegin(field);
        oprot.WriteByte(InitQuality);
        oprot.WriteFieldEnd();
      }
      if (__isset.initLevel) {
        field.Name = "initLevel";
        field.Type = TType.Byte;
        field.ID = 150;
        oprot.WriteFieldBegin(field);
        oprot.WriteByte(InitLevel);
        oprot.WriteFieldEnd();
      }
      if (__isset.initHp) {
        field.Name = "initHp";
        field.Type = TType.I16;
        field.ID = 160;
        oprot.WriteFieldBegin(field);
        oprot.WriteI16(InitHp);
        oprot.WriteFieldEnd();
      }
      if (__isset.initPhyAtk) {
        field.Name = "initPhyAtk";
        field.Type = TType.I16;
        field.ID = 180;
        oprot.WriteFieldBegin(field);
        oprot.WriteI16(InitPhyAtk);
        oprot.WriteFieldEnd();
      }
      if (__isset.initPhyDef) {
        field.Name = "initPhyDef";
        field.Type = TType.I16;
        field.ID = 200;
        oprot.WriteFieldBegin(field);
        oprot.WriteI16(InitPhyDef);
        oprot.WriteFieldEnd();
      }
      if (__isset.initMagicAtk) {
        field.Name = "initMagicAtk";
        field.Type = TType.I16;
        field.ID = 220;
        oprot.WriteFieldBegin(field);
        oprot.WriteI16(InitMagicAtk);
        oprot.WriteFieldEnd();
      }
      if (__isset.initMagicDef) {
        field.Name = "initMagicDef";
        field.Type = TType.I16;
        field.ID = 240;
        oprot.WriteFieldBegin(field);
        oprot.WriteI16(InitMagicDef);
        oprot.WriteFieldEnd();
      }
      if (__isset.atkInterval) {
        field.Name = "atkInterval";
        field.Type = TType.I16;
        field.ID = 260;
        oprot.WriteFieldBegin(field);
        oprot.WriteI16(AtkInterval);
        oprot.WriteFieldEnd();
      }
      if (__isset.moveSpeed) {
        field.Name = "moveSpeed";
        field.Type = TType.I16;
        field.ID = 270;
        oprot.WriteFieldBegin(field);
        oprot.WriteI16(MoveSpeed);
        oprot.WriteFieldEnd();
      }
      if (__isset.initAvo) {
        field.Name = "initAvo";
        field.Type = TType.I16;
        field.ID = 280;
        oprot.WriteFieldBegin(field);
        oprot.WriteI16(InitAvo);
        oprot.WriteFieldEnd();
      }
      if (__isset.initCri) {
        field.Name = "initCri";
        field.Type = TType.I16;
        field.ID = 300;
        oprot.WriteFieldBegin(field);
        oprot.WriteI16(InitCri);
        oprot.WriteFieldEnd();
      }
      if (__isset.initCriDamage) {
        field.Name = "initCriDamage";
        field.Type = TType.I16;
        field.ID = 320;
        oprot.WriteFieldBegin(field);
        oprot.WriteI16(InitCriDamage);
        oprot.WriteFieldEnd();
      }
      if (__isset.growAttrRateId) {
        field.Name = "growAttrRateId";
        field.Type = TType.I32;
        field.ID = 330;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(GrowAttrRateId);
        oprot.WriteFieldEnd();
      }
      if (__isset.aiId) {
        field.Name = "aiId";
        field.Type = TType.I32;
        field.ID = 340;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(AiId);
        oprot.WriteFieldEnd();
      }
      if (__isset.starLevelUpId) {
        field.Name = "starLevelUpId";
        field.Type = TType.I32;
        field.ID = 350;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(StarLevelUpId);
        oprot.WriteFieldEnd();
      }
      if (__isset.shardItemId) {
        field.Name = "shardItemId";
        field.Type = TType.I32;
        field.ID = 360;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ShardItemId);
        oprot.WriteFieldEnd();
      }
      if (__isset.runSkillId) {
        field.Name = "runSkillId";
        field.Type = TType.I32;
        field.ID = 370;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(RunSkillId);
        oprot.WriteFieldEnd();
      }
      if (__isset.idleSkillId) {
        field.Name = "idleSkillId";
        field.Type = TType.I32;
        field.ID = 371;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(IdleSkillId);
        oprot.WriteFieldEnd();
      }
      if (__isset.winSkillId) {
        field.Name = "winSkillId";
        field.Type = TType.I32;
        field.ID = 372;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(WinSkillId);
        oprot.WriteFieldEnd();
      }
      if (__isset.deathSkillId) {
        field.Name = "deathSkillId";
        field.Type = TType.I32;
        field.ID = 373;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DeathSkillId);
        oprot.WriteFieldEnd();
      }
      if (SkillIdList != null && __isset.skillIdList) {
        field.Name = "skillIdList";
        field.Type = TType.List;
        field.ID = 380;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.I32, SkillIdList.Count));
          foreach (int _iter15 in SkillIdList)
          {
            oprot.WriteI32(_iter15);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("HeroConfig(");
      sb.Append("Id: ");
      sb.Append(Id);
      sb.Append(",NameMessageId: ");
      sb.Append(NameMessageId);
      sb.Append(",DescMessageId: ");
      sb.Append(DescMessageId);
      sb.Append(",Show: ");
      sb.Append(Show);
      sb.Append(",HeadIcon: ");
      sb.Append(HeadIcon);
      sb.Append(",DialogIcon: ");
      sb.Append(DialogIcon);
      sb.Append(",Model: ");
      sb.Append(Model);
      sb.Append(",AtkType: ");
      sb.Append(AtkType);
      sb.Append(",Sex: ");
      sb.Append(Sex);
      sb.Append(",Camp: ");
      sb.Append(Camp);
      sb.Append(",Occupation: ");
      sb.Append(Occupation);
      sb.Append(",InitStarLevel: ");
      sb.Append(InitStarLevel);
      sb.Append(",InitQuality: ");
      sb.Append(InitQuality);
      sb.Append(",InitLevel: ");
      sb.Append(InitLevel);
      sb.Append(",InitHp: ");
      sb.Append(InitHp);
      sb.Append(",InitPhyAtk: ");
      sb.Append(InitPhyAtk);
      sb.Append(",InitPhyDef: ");
      sb.Append(InitPhyDef);
      sb.Append(",InitMagicAtk: ");
      sb.Append(InitMagicAtk);
      sb.Append(",InitMagicDef: ");
      sb.Append(InitMagicDef);
      sb.Append(",AtkInterval: ");
      sb.Append(AtkInterval);
      sb.Append(",MoveSpeed: ");
      sb.Append(MoveSpeed);
      sb.Append(",InitAvo: ");
      sb.Append(InitAvo);
      sb.Append(",InitCri: ");
      sb.Append(InitCri);
      sb.Append(",InitCriDamage: ");
      sb.Append(InitCriDamage);
      sb.Append(",GrowAttrRateId: ");
      sb.Append(GrowAttrRateId);
      sb.Append(",AiId: ");
      sb.Append(AiId);
      sb.Append(",StarLevelUpId: ");
      sb.Append(StarLevelUpId);
      sb.Append(",ShardItemId: ");
      sb.Append(ShardItemId);
      sb.Append(",RunSkillId: ");
      sb.Append(RunSkillId);
      sb.Append(",IdleSkillId: ");
      sb.Append(IdleSkillId);
      sb.Append(",WinSkillId: ");
      sb.Append(WinSkillId);
      sb.Append(",DeathSkillId: ");
      sb.Append(DeathSkillId);
      sb.Append(",SkillIdList: ");
      sb.Append(SkillIdList);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
