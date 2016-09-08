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
  public partial class BattleEffectConfig : TBase
  {
    private int _id;
    private string _res;
    private int _totalFrame;
    private int _maxFrame;
    private int _targetId;
    private int _enterLimitId;
    private int _enterFuncId;
    private int _stayLimitId;
    private int _stayFuncId;
    private int _exitLimitId;
    private int _exitFuncId;
    private int _deadLimitId;
    private int _deadFunId;
    private int _type;
    private int _followInterval;
    private bool _isWorld;
    private int _posX;
    private int _posY;
    private int _initSpeedX;
    private int _initSpeedY;
    private int _addSpeedX;
    private int _addSpeedY;
    private string _dataPrefab;
    private string _dieEffect;

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

    public string Res
    {
      get
      {
        return _res;
      }
      set
      {
        __isset.res = true;
        this._res = value;
      }
    }

    public int TotalFrame
    {
      get
      {
        return _totalFrame;
      }
      set
      {
        __isset.totalFrame = true;
        this._totalFrame = value;
      }
    }

    public int MaxFrame
    {
      get
      {
        return _maxFrame;
      }
      set
      {
        __isset.maxFrame = true;
        this._maxFrame = value;
      }
    }

    public int TargetId
    {
      get
      {
        return _targetId;
      }
      set
      {
        __isset.targetId = true;
        this._targetId = value;
      }
    }

    public int EnterLimitId
    {
      get
      {
        return _enterLimitId;
      }
      set
      {
        __isset.enterLimitId = true;
        this._enterLimitId = value;
      }
    }

    public int EnterFuncId
    {
      get
      {
        return _enterFuncId;
      }
      set
      {
        __isset.enterFuncId = true;
        this._enterFuncId = value;
      }
    }

    public int StayLimitId
    {
      get
      {
        return _stayLimitId;
      }
      set
      {
        __isset.stayLimitId = true;
        this._stayLimitId = value;
      }
    }

    public int StayFuncId
    {
      get
      {
        return _stayFuncId;
      }
      set
      {
        __isset.stayFuncId = true;
        this._stayFuncId = value;
      }
    }

    public int ExitLimitId
    {
      get
      {
        return _exitLimitId;
      }
      set
      {
        __isset.exitLimitId = true;
        this._exitLimitId = value;
      }
    }

    public int ExitFuncId
    {
      get
      {
        return _exitFuncId;
      }
      set
      {
        __isset.exitFuncId = true;
        this._exitFuncId = value;
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

    public int DeadFunId
    {
      get
      {
        return _deadFunId;
      }
      set
      {
        __isset.deadFunId = true;
        this._deadFunId = value;
      }
    }

    public int Type
    {
      get
      {
        return _type;
      }
      set
      {
        __isset.type = true;
        this._type = value;
      }
    }

    public int FollowInterval
    {
      get
      {
        return _followInterval;
      }
      set
      {
        __isset.followInterval = true;
        this._followInterval = value;
      }
    }

    public bool IsWorld
    {
      get
      {
        return _isWorld;
      }
      set
      {
        __isset.isWorld = true;
        this._isWorld = value;
      }
    }

    public int PosX
    {
      get
      {
        return _posX;
      }
      set
      {
        __isset.posX = true;
        this._posX = value;
      }
    }

    public int PosY
    {
      get
      {
        return _posY;
      }
      set
      {
        __isset.posY = true;
        this._posY = value;
      }
    }

    public int InitSpeedX
    {
      get
      {
        return _initSpeedX;
      }
      set
      {
        __isset.initSpeedX = true;
        this._initSpeedX = value;
      }
    }

    public int InitSpeedY
    {
      get
      {
        return _initSpeedY;
      }
      set
      {
        __isset.initSpeedY = true;
        this._initSpeedY = value;
      }
    }

    public int AddSpeedX
    {
      get
      {
        return _addSpeedX;
      }
      set
      {
        __isset.addSpeedX = true;
        this._addSpeedX = value;
      }
    }

    public int AddSpeedY
    {
      get
      {
        return _addSpeedY;
      }
      set
      {
        __isset.addSpeedY = true;
        this._addSpeedY = value;
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

    public string DieEffect
    {
      get
      {
        return _dieEffect;
      }
      set
      {
        __isset.dieEffect = true;
        this._dieEffect = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool id;
      public bool res;
      public bool totalFrame;
      public bool maxFrame;
      public bool targetId;
      public bool enterLimitId;
      public bool enterFuncId;
      public bool stayLimitId;
      public bool stayFuncId;
      public bool exitLimitId;
      public bool exitFuncId;
      public bool deadLimitId;
      public bool deadFunId;
      public bool type;
      public bool followInterval;
      public bool isWorld;
      public bool posX;
      public bool posY;
      public bool initSpeedX;
      public bool initSpeedY;
      public bool addSpeedX;
      public bool addSpeedY;
      public bool dataPrefab;
      public bool dieEffect;
    }

    public BattleEffectConfig() {
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
            if (field.Type == TType.String) {
              Res = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.I32) {
              TotalFrame = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 40:
            if (field.Type == TType.I32) {
              MaxFrame = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 45:
            if (field.Type == TType.I32) {
              TargetId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 50:
            if (field.Type == TType.I32) {
              EnterLimitId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 60:
            if (field.Type == TType.I32) {
              EnterFuncId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 61:
            if (field.Type == TType.I32) {
              StayLimitId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 62:
            if (field.Type == TType.I32) {
              StayFuncId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 63:
            if (field.Type == TType.I32) {
              ExitLimitId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 64:
            if (field.Type == TType.I32) {
              ExitFuncId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 70:
            if (field.Type == TType.I32) {
              DeadLimitId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 80:
            if (field.Type == TType.I32) {
              DeadFunId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 90:
            if (field.Type == TType.I32) {
              Type = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 95:
            if (field.Type == TType.I32) {
              FollowInterval = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 100:
            if (field.Type == TType.Bool) {
              IsWorld = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 110:
            if (field.Type == TType.I32) {
              PosX = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 120:
            if (field.Type == TType.I32) {
              PosY = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 130:
            if (field.Type == TType.I32) {
              InitSpeedX = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 140:
            if (field.Type == TType.I32) {
              InitSpeedY = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 150:
            if (field.Type == TType.I32) {
              AddSpeedX = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 160:
            if (field.Type == TType.I32) {
              AddSpeedY = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 170:
            if (field.Type == TType.String) {
              DataPrefab = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 180:
            if (field.Type == TType.String) {
              DieEffect = iprot.ReadString();
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
      TStruct struc = new TStruct("BattleEffectConfig");
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
      if (Res != null && __isset.res) {
        field.Name = "res";
        field.Type = TType.String;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Res);
        oprot.WriteFieldEnd();
      }
      if (__isset.totalFrame) {
        field.Name = "totalFrame";
        field.Type = TType.I32;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(TotalFrame);
        oprot.WriteFieldEnd();
      }
      if (__isset.maxFrame) {
        field.Name = "maxFrame";
        field.Type = TType.I32;
        field.ID = 40;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(MaxFrame);
        oprot.WriteFieldEnd();
      }
      if (__isset.targetId) {
        field.Name = "targetId";
        field.Type = TType.I32;
        field.ID = 45;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(TargetId);
        oprot.WriteFieldEnd();
      }
      if (__isset.enterLimitId) {
        field.Name = "enterLimitId";
        field.Type = TType.I32;
        field.ID = 50;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(EnterLimitId);
        oprot.WriteFieldEnd();
      }
      if (__isset.enterFuncId) {
        field.Name = "enterFuncId";
        field.Type = TType.I32;
        field.ID = 60;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(EnterFuncId);
        oprot.WriteFieldEnd();
      }
      if (__isset.stayLimitId) {
        field.Name = "stayLimitId";
        field.Type = TType.I32;
        field.ID = 61;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(StayLimitId);
        oprot.WriteFieldEnd();
      }
      if (__isset.stayFuncId) {
        field.Name = "stayFuncId";
        field.Type = TType.I32;
        field.ID = 62;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(StayFuncId);
        oprot.WriteFieldEnd();
      }
      if (__isset.exitLimitId) {
        field.Name = "exitLimitId";
        field.Type = TType.I32;
        field.ID = 63;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ExitLimitId);
        oprot.WriteFieldEnd();
      }
      if (__isset.exitFuncId) {
        field.Name = "exitFuncId";
        field.Type = TType.I32;
        field.ID = 64;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ExitFuncId);
        oprot.WriteFieldEnd();
      }
      if (__isset.deadLimitId) {
        field.Name = "deadLimitId";
        field.Type = TType.I32;
        field.ID = 70;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DeadLimitId);
        oprot.WriteFieldEnd();
      }
      if (__isset.deadFunId) {
        field.Name = "deadFunId";
        field.Type = TType.I32;
        field.ID = 80;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DeadFunId);
        oprot.WriteFieldEnd();
      }
      if (__isset.type) {
        field.Name = "type";
        field.Type = TType.I32;
        field.ID = 90;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Type);
        oprot.WriteFieldEnd();
      }
      if (__isset.followInterval) {
        field.Name = "followInterval";
        field.Type = TType.I32;
        field.ID = 95;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(FollowInterval);
        oprot.WriteFieldEnd();
      }
      if (__isset.isWorld) {
        field.Name = "isWorld";
        field.Type = TType.Bool;
        field.ID = 100;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(IsWorld);
        oprot.WriteFieldEnd();
      }
      if (__isset.posX) {
        field.Name = "posX";
        field.Type = TType.I32;
        field.ID = 110;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(PosX);
        oprot.WriteFieldEnd();
      }
      if (__isset.posY) {
        field.Name = "posY";
        field.Type = TType.I32;
        field.ID = 120;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(PosY);
        oprot.WriteFieldEnd();
      }
      if (__isset.initSpeedX) {
        field.Name = "initSpeedX";
        field.Type = TType.I32;
        field.ID = 130;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(InitSpeedX);
        oprot.WriteFieldEnd();
      }
      if (__isset.initSpeedY) {
        field.Name = "initSpeedY";
        field.Type = TType.I32;
        field.ID = 140;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(InitSpeedY);
        oprot.WriteFieldEnd();
      }
      if (__isset.addSpeedX) {
        field.Name = "addSpeedX";
        field.Type = TType.I32;
        field.ID = 150;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(AddSpeedX);
        oprot.WriteFieldEnd();
      }
      if (__isset.addSpeedY) {
        field.Name = "addSpeedY";
        field.Type = TType.I32;
        field.ID = 160;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(AddSpeedY);
        oprot.WriteFieldEnd();
      }
      if (DataPrefab != null && __isset.dataPrefab) {
        field.Name = "dataPrefab";
        field.Type = TType.String;
        field.ID = 170;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(DataPrefab);
        oprot.WriteFieldEnd();
      }
      if (DieEffect != null && __isset.dieEffect) {
        field.Name = "dieEffect";
        field.Type = TType.String;
        field.ID = 180;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(DieEffect);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("BattleEffectConfig(");
      sb.Append("Id: ");
      sb.Append(Id);
      sb.Append(",Res: ");
      sb.Append(Res);
      sb.Append(",TotalFrame: ");
      sb.Append(TotalFrame);
      sb.Append(",MaxFrame: ");
      sb.Append(MaxFrame);
      sb.Append(",TargetId: ");
      sb.Append(TargetId);
      sb.Append(",EnterLimitId: ");
      sb.Append(EnterLimitId);
      sb.Append(",EnterFuncId: ");
      sb.Append(EnterFuncId);
      sb.Append(",StayLimitId: ");
      sb.Append(StayLimitId);
      sb.Append(",StayFuncId: ");
      sb.Append(StayFuncId);
      sb.Append(",ExitLimitId: ");
      sb.Append(ExitLimitId);
      sb.Append(",ExitFuncId: ");
      sb.Append(ExitFuncId);
      sb.Append(",DeadLimitId: ");
      sb.Append(DeadLimitId);
      sb.Append(",DeadFunId: ");
      sb.Append(DeadFunId);
      sb.Append(",Type: ");
      sb.Append(Type);
      sb.Append(",FollowInterval: ");
      sb.Append(FollowInterval);
      sb.Append(",IsWorld: ");
      sb.Append(IsWorld);
      sb.Append(",PosX: ");
      sb.Append(PosX);
      sb.Append(",PosY: ");
      sb.Append(PosY);
      sb.Append(",InitSpeedX: ");
      sb.Append(InitSpeedX);
      sb.Append(",InitSpeedY: ");
      sb.Append(InitSpeedY);
      sb.Append(",AddSpeedX: ");
      sb.Append(AddSpeedX);
      sb.Append(",AddSpeedY: ");
      sb.Append(AddSpeedY);
      sb.Append(",DataPrefab: ");
      sb.Append(DataPrefab);
      sb.Append(",DieEffect: ");
      sb.Append(DieEffect);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
