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
  public partial class MonsterConfig : TBase
  {
    private int _id;
    private int _nameMessageId;
    private int _tagMessageId;
    private string _headIcon;
    private string _dialogIcon;
    private string _model;
    private sbyte _atkType;
    private int _normalSkill;
    private int _points;
    private sbyte _sex;
    private int _bornLimitId;
    private int _bornFuncId;
    private int _deadLimitId;
    private int _deadFuncId;
    private short _level;
    private int _hp;
    private List<int> _dropList;
    private bool _canResume;
    private bool _isAliveInRiver;
    private int _resumeId;
    private int _resumeLast;
    private bool _canDestroy;
    private int _alivetime;
    private int _initActionGroupId;
    private int _initAiId;
    private List<MonsterAiParam> _aiChangeList;
    private List<int> _skillIdList;
    private string _dataPrefab;

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

    public int TagMessageId
    {
      get
      {
        return _tagMessageId;
      }
      set
      {
        __isset.tagMessageId = true;
        this._tagMessageId = value;
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

    public int NormalSkill
    {
      get
      {
        return _normalSkill;
      }
      set
      {
        __isset.normalSkill = true;
        this._normalSkill = value;
      }
    }

    public int Points
    {
      get
      {
        return _points;
      }
      set
      {
        __isset.points = true;
        this._points = value;
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

    public int BornLimitId
    {
      get
      {
        return _bornLimitId;
      }
      set
      {
        __isset.bornLimitId = true;
        this._bornLimitId = value;
      }
    }

    public int BornFuncId
    {
      get
      {
        return _bornFuncId;
      }
      set
      {
        __isset.bornFuncId = true;
        this._bornFuncId = value;
      }
    }

    public int DeadLimitId
    {
      get
      {
        return _deadLimitId;
      }
      set
      {
        __isset.deadLimitId = true;
        this._deadLimitId = value;
      }
    }

    public int DeadFuncId
    {
      get
      {
        return _deadFuncId;
      }
      set
      {
        __isset.deadFuncId = true;
        this._deadFuncId = value;
      }
    }

    public short Level
    {
      get
      {
        return _level;
      }
      set
      {
        __isset.level = true;
        this._level = value;
      }
    }

    public int Hp
    {
      get
      {
        return _hp;
      }
      set
      {
        __isset.hp = true;
        this._hp = value;
      }
    }

    public List<int> DropList
    {
      get
      {
        return _dropList;
      }
      set
      {
        __isset.dropList = true;
        this._dropList = value;
      }
    }

    public bool CanResume
    {
      get
      {
        return _canResume;
      }
      set
      {
        __isset.canResume = true;
        this._canResume = value;
      }
    }

    public bool IsAliveInRiver
    {
      get
      {
        return _isAliveInRiver;
      }
      set
      {
        __isset.isAliveInRiver = true;
        this._isAliveInRiver = value;
      }
    }

    public int ResumeId
    {
      get
      {
        return _resumeId;
      }
      set
      {
        __isset.resumeId = true;
        this._resumeId = value;
      }
    }

    public int ResumeLast
    {
      get
      {
        return _resumeLast;
      }
      set
      {
        __isset.resumeLast = true;
        this._resumeLast = value;
      }
    }

    public bool CanDestroy
    {
      get
      {
        return _canDestroy;
      }
      set
      {
        __isset.canDestroy = true;
        this._canDestroy = value;
      }
    }

    public int Alivetime
    {
      get
      {
        return _alivetime;
      }
      set
      {
        __isset.alivetime = true;
        this._alivetime = value;
      }
    }

    public int InitActionGroupId
    {
      get
      {
        return _initActionGroupId;
      }
      set
      {
        __isset.initActionGroupId = true;
        this._initActionGroupId = value;
      }
    }

    public int InitAiId
    {
      get
      {
        return _initAiId;
      }
      set
      {
        __isset.initAiId = true;
        this._initAiId = value;
      }
    }

    public List<MonsterAiParam> AiChangeList
    {
      get
      {
        return _aiChangeList;
      }
      set
      {
        __isset.aiChangeList = true;
        this._aiChangeList = value;
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

    public string DataPrefab
    {
      get
      {
        return _dataPrefab;
      }
      set
      {
        __isset.dataPrefab = true;
        this._dataPrefab = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool id;
      public bool nameMessageId;
      public bool tagMessageId;
      public bool headIcon;
      public bool dialogIcon;
      public bool model;
      public bool atkType;
      public bool normalSkill;
      public bool points;
      public bool sex;
      public bool bornLimitId;
      public bool bornFuncId;
      public bool deadLimitId;
      public bool deadFuncId;
      public bool level;
      public bool hp;
      public bool dropList;
      public bool canResume;
      public bool isAliveInRiver;
      public bool resumeId;
      public bool resumeLast;
      public bool canDestroy;
      public bool alivetime;
      public bool initActionGroupId;
      public bool initAiId;
      public bool aiChangeList;
      public bool skillIdList;
      public bool dataPrefab;
    }

    public MonsterConfig() {
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
              TagMessageId = iprot.ReadI32();
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
          case 72:
            if (field.Type == TType.I32) {
              NormalSkill = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 73:
            if (field.Type == TType.I32) {
              Points = iprot.ReadI32();
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
            if (field.Type == TType.I32) {
              BornLimitId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 91:
            if (field.Type == TType.I32) {
              BornFuncId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 92:
            if (field.Type == TType.I32) {
              DeadLimitId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 93:
            if (field.Type == TType.I32) {
              DeadFuncId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 130:
            if (field.Type == TType.I16) {
              Level = iprot.ReadI16();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 140:
            if (field.Type == TType.I32) {
              Hp = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 150:
            if (field.Type == TType.List) {
              {
                DropList = new List<int>();
                TList _list41 = iprot.ReadListBegin();
                for( int _i42 = 0; _i42 < _list41.Count; ++_i42)
                {
                  int _elem43 = 0;
                  _elem43 = iprot.ReadI32();
                  DropList.Add(_elem43);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 160:
            if (field.Type == TType.Bool) {
              CanResume = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 161:
            if (field.Type == TType.Bool) {
              IsAliveInRiver = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 170:
            if (field.Type == TType.I32) {
              ResumeId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 171:
            if (field.Type == TType.I32) {
              ResumeLast = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 180:
            if (field.Type == TType.Bool) {
              CanDestroy = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 190:
            if (field.Type == TType.I32) {
              Alivetime = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 200:
            if (field.Type == TType.I32) {
              InitActionGroupId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 240:
            if (field.Type == TType.I32) {
              InitAiId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 241:
            if (field.Type == TType.List) {
              {
                AiChangeList = new List<MonsterAiParam>();
                TList _list44 = iprot.ReadListBegin();
                for( int _i45 = 0; _i45 < _list44.Count; ++_i45)
                {
                  MonsterAiParam _elem46 = new MonsterAiParam();
                  _elem46 = new MonsterAiParam();
                  _elem46.Read(iprot);
                  AiChangeList.Add(_elem46);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 250:
            if (field.Type == TType.List) {
              {
                SkillIdList = new List<int>();
                TList _list47 = iprot.ReadListBegin();
                for( int _i48 = 0; _i48 < _list47.Count; ++_i48)
                {
                  int _elem49 = 0;
                  _elem49 = iprot.ReadI32();
                  SkillIdList.Add(_elem49);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 260:
            if (field.Type == TType.String) {
              DataPrefab = iprot.ReadString();
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
      TStruct struc = new TStruct("MonsterConfig");
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
      if (__isset.tagMessageId) {
        field.Name = "tagMessageId";
        field.Type = TType.I32;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(TagMessageId);
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
      if (__isset.normalSkill) {
        field.Name = "normalSkill";
        field.Type = TType.I32;
        field.ID = 72;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(NormalSkill);
        oprot.WriteFieldEnd();
      }
      if (__isset.points) {
        field.Name = "points";
        field.Type = TType.I32;
        field.ID = 73;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Points);
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
      if (__isset.bornLimitId) {
        field.Name = "bornLimitId";
        field.Type = TType.I32;
        field.ID = 90;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(BornLimitId);
        oprot.WriteFieldEnd();
      }
      if (__isset.bornFuncId) {
        field.Name = "bornFuncId";
        field.Type = TType.I32;
        field.ID = 91;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(BornFuncId);
        oprot.WriteFieldEnd();
      }
      if (__isset.deadLimitId) {
        field.Name = "deadLimitId";
        field.Type = TType.I32;
        field.ID = 92;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DeadLimitId);
        oprot.WriteFieldEnd();
      }
      if (__isset.deadFuncId) {
        field.Name = "deadFuncId";
        field.Type = TType.I32;
        field.ID = 93;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DeadFuncId);
        oprot.WriteFieldEnd();
      }
      if (__isset.level) {
        field.Name = "level";
        field.Type = TType.I16;
        field.ID = 130;
        oprot.WriteFieldBegin(field);
        oprot.WriteI16(Level);
        oprot.WriteFieldEnd();
      }
      if (__isset.hp) {
        field.Name = "hp";
        field.Type = TType.I32;
        field.ID = 140;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Hp);
        oprot.WriteFieldEnd();
      }
      if (DropList != null && __isset.dropList) {
        field.Name = "dropList";
        field.Type = TType.List;
        field.ID = 150;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.I32, DropList.Count));
          foreach (int _iter50 in DropList)
          {
            oprot.WriteI32(_iter50);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (__isset.canResume) {
        field.Name = "canResume";
        field.Type = TType.Bool;
        field.ID = 160;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(CanResume);
        oprot.WriteFieldEnd();
      }
      if (__isset.isAliveInRiver) {
        field.Name = "isAliveInRiver";
        field.Type = TType.Bool;
        field.ID = 161;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(IsAliveInRiver);
        oprot.WriteFieldEnd();
      }
      if (__isset.resumeId) {
        field.Name = "resumeId";
        field.Type = TType.I32;
        field.ID = 170;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ResumeId);
        oprot.WriteFieldEnd();
      }
      if (__isset.resumeLast) {
        field.Name = "resumeLast";
        field.Type = TType.I32;
        field.ID = 171;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ResumeLast);
        oprot.WriteFieldEnd();
      }
      if (__isset.canDestroy) {
        field.Name = "canDestroy";
        field.Type = TType.Bool;
        field.ID = 180;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(CanDestroy);
        oprot.WriteFieldEnd();
      }
      if (__isset.alivetime) {
        field.Name = "alivetime";
        field.Type = TType.I32;
        field.ID = 190;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Alivetime);
        oprot.WriteFieldEnd();
      }
      if (__isset.initActionGroupId) {
        field.Name = "initActionGroupId";
        field.Type = TType.I32;
        field.ID = 200;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(InitActionGroupId);
        oprot.WriteFieldEnd();
      }
      if (__isset.initAiId) {
        field.Name = "initAiId";
        field.Type = TType.I32;
        field.ID = 240;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(InitAiId);
        oprot.WriteFieldEnd();
      }
      if (AiChangeList != null && __isset.aiChangeList) {
        field.Name = "aiChangeList";
        field.Type = TType.List;
        field.ID = 241;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, AiChangeList.Count));
          foreach (MonsterAiParam _iter51 in AiChangeList)
          {
            _iter51.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (SkillIdList != null && __isset.skillIdList) {
        field.Name = "skillIdList";
        field.Type = TType.List;
        field.ID = 250;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.I32, SkillIdList.Count));
          foreach (int _iter52 in SkillIdList)
          {
            oprot.WriteI32(_iter52);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (DataPrefab != null && __isset.dataPrefab) {
        field.Name = "dataPrefab";
        field.Type = TType.String;
        field.ID = 260;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(DataPrefab);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("MonsterConfig(");
      sb.Append("Id: ");
      sb.Append(Id);
      sb.Append(",NameMessageId: ");
      sb.Append(NameMessageId);
      sb.Append(",TagMessageId: ");
      sb.Append(TagMessageId);
      sb.Append(",HeadIcon: ");
      sb.Append(HeadIcon);
      sb.Append(",DialogIcon: ");
      sb.Append(DialogIcon);
      sb.Append(",Model: ");
      sb.Append(Model);
      sb.Append(",AtkType: ");
      sb.Append(AtkType);
      sb.Append(",NormalSkill: ");
      sb.Append(NormalSkill);
      sb.Append(",Points: ");
      sb.Append(Points);
      sb.Append(",Sex: ");
      sb.Append(Sex);
      sb.Append(",BornLimitId: ");
      sb.Append(BornLimitId);
      sb.Append(",BornFuncId: ");
      sb.Append(BornFuncId);
      sb.Append(",DeadLimitId: ");
      sb.Append(DeadLimitId);
      sb.Append(",DeadFuncId: ");
      sb.Append(DeadFuncId);
      sb.Append(",Level: ");
      sb.Append(Level);
      sb.Append(",Hp: ");
      sb.Append(Hp);
      sb.Append(",DropList: ");
      sb.Append(DropList);
      sb.Append(",CanResume: ");
      sb.Append(CanResume);
      sb.Append(",IsAliveInRiver: ");
      sb.Append(IsAliveInRiver);
      sb.Append(",ResumeId: ");
      sb.Append(ResumeId);
      sb.Append(",ResumeLast: ");
      sb.Append(ResumeLast);
      sb.Append(",CanDestroy: ");
      sb.Append(CanDestroy);
      sb.Append(",Alivetime: ");
      sb.Append(Alivetime);
      sb.Append(",InitActionGroupId: ");
      sb.Append(InitActionGroupId);
      sb.Append(",InitAiId: ");
      sb.Append(InitAiId);
      sb.Append(",AiChangeList: ");
      sb.Append(AiChangeList);
      sb.Append(",SkillIdList: ");
      sb.Append(SkillIdList);
      sb.Append(",DataPrefab: ");
      sb.Append(DataPrefab);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
