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
    private string _model;
    private string _dataPrefab;
    private string _blush;
    private int _blushType;
    private int _totalTime;
    private int _maxTime;
    private int _collisionLimitId;
    private int _collisionFuncId;
    private int _enterLimitId;
    private int _enterFuncId;
    private int _stayLimitId;
    private int _stayFuncId;
    private int _exitLimitId;
    private int _exitFuncId;
    private int _deadLimitId;
    private int _deadFunId;
    private int _type;
    private int _targetId;
    private int _followInterval;
    private int _posCoordType;
    private int _speedCoordType;
    private int _floatTime;
    private int _posX;
    private int _posY;
    private int _poxZ;
    private int _initSpeedX;
    private int _initSpeedY;
    private int _initSpeedZ;
    private int _addSpeedX;
    private int _addSpeedY;
    private int _addSpeedZ;
    private string _dieEffect;
    private int _bornRotate;
    private int _moveForward;
    private int _score;
    private int _specialMpRate;
    private int _dieDelayTime;

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

    public string Blush
    {
      get
      {
        return _blush;
      }
      set
      {
        __isset.blush = true;
        this._blush = value;
      }
    }

    public int BlushType
    {
      get
      {
        return _blushType;
      }
      set
      {
        __isset.blushType = true;
        this._blushType = value;
      }
    }

    public int TotalTime
    {
      get
      {
        return _totalTime;
      }
      set
      {
        __isset.totalTime = true;
        this._totalTime = value;
      }
    }

    public int MaxTime
    {
      get
      {
        return _maxTime;
      }
      set
      {
        __isset.maxTime = true;
        this._maxTime = value;
      }
    }

    public int CollisionLimitId
    {
      get
      {
        return _collisionLimitId;
      }
      set
      {
        __isset.collisionLimitId = true;
        this._collisionLimitId = value;
      }
    }

    public int CollisionFuncId
    {
      get
      {
        return _collisionFuncId;
      }
      set
      {
        __isset.collisionFuncId = true;
        this._collisionFuncId = value;
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

    public int PosCoordType
    {
      get
      {
        return _posCoordType;
      }
      set
      {
        __isset.posCoordType = true;
        this._posCoordType = value;
      }
    }

    public int SpeedCoordType
    {
      get
      {
        return _speedCoordType;
      }
      set
      {
        __isset.speedCoordType = true;
        this._speedCoordType = value;
      }
    }

    public int FloatTime
    {
      get
      {
        return _floatTime;
      }
      set
      {
        __isset.floatTime = true;
        this._floatTime = value;
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

    public int PoxZ
    {
      get
      {
        return _poxZ;
      }
      set
      {
        __isset.poxZ = true;
        this._poxZ = value;
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

    public int InitSpeedZ
    {
      get
      {
        return _initSpeedZ;
      }
      set
      {
        __isset.initSpeedZ = true;
        this._initSpeedZ = value;
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

    public int AddSpeedZ
    {
      get
      {
        return _addSpeedZ;
      }
      set
      {
        __isset.addSpeedZ = true;
        this._addSpeedZ = value;
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

    public int BornRotate
    {
      get
      {
        return _bornRotate;
      }
      set
      {
        __isset.bornRotate = true;
        this._bornRotate = value;
      }
    }

    public int MoveForward
    {
      get
      {
        return _moveForward;
      }
      set
      {
        __isset.moveForward = true;
        this._moveForward = value;
      }
    }

    public int Score
    {
      get
      {
        return _score;
      }
      set
      {
        __isset.score = true;
        this._score = value;
      }
    }

    public int SpecialMpRate
    {
      get
      {
        return _specialMpRate;
      }
      set
      {
        __isset.specialMpRate = true;
        this._specialMpRate = value;
      }
    }

    public int DieDelayTime
    {
      get
      {
        return _dieDelayTime;
      }
      set
      {
        __isset.dieDelayTime = true;
        this._dieDelayTime = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool id;
      public bool model;
      public bool dataPrefab;
      public bool blush;
      public bool blushType;
      public bool totalTime;
      public bool maxTime;
      public bool collisionLimitId;
      public bool collisionFuncId;
      public bool enterLimitId;
      public bool enterFuncId;
      public bool stayLimitId;
      public bool stayFuncId;
      public bool exitLimitId;
      public bool exitFuncId;
      public bool deadLimitId;
      public bool deadFunId;
      public bool type;
      public bool targetId;
      public bool followInterval;
      public bool posCoordType;
      public bool speedCoordType;
      public bool floatTime;
      public bool posX;
      public bool posY;
      public bool poxZ;
      public bool initSpeedX;
      public bool initSpeedY;
      public bool initSpeedZ;
      public bool addSpeedX;
      public bool addSpeedY;
      public bool addSpeedZ;
      public bool dieEffect;
      public bool bornRotate;
      public bool moveForward;
      public bool score;
      public bool specialMpRate;
      public bool dieDelayTime;
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
              Model = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 21:
            if (field.Type == TType.String) {
              DataPrefab = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 22:
            if (field.Type == TType.String) {
              Blush = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 23:
            if (field.Type == TType.I32) {
              BlushType = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.I32) {
              TotalTime = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 40:
            if (field.Type == TType.I32) {
              MaxTime = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 45:
            if (field.Type == TType.I32) {
              CollisionLimitId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 46:
            if (field.Type == TType.I32) {
              CollisionFuncId = iprot.ReadI32();
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
          case 91:
            if (field.Type == TType.I32) {
              TargetId = iprot.ReadI32();
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
            if (field.Type == TType.I32) {
              PosCoordType = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 101:
            if (field.Type == TType.I32) {
              SpeedCoordType = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 102:
            if (field.Type == TType.I32) {
              FloatTime = iprot.ReadI32();
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
          case 121:
            if (field.Type == TType.I32) {
              PoxZ = iprot.ReadI32();
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
          case 141:
            if (field.Type == TType.I32) {
              InitSpeedZ = iprot.ReadI32();
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
            if (field.Type == TType.I32) {
              AddSpeedZ = iprot.ReadI32();
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
          case 190:
            if (field.Type == TType.I32) {
              BornRotate = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 200:
            if (field.Type == TType.I32) {
              MoveForward = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 210:
            if (field.Type == TType.I32) {
              Score = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 220:
            if (field.Type == TType.I32) {
              SpecialMpRate = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 230:
            if (field.Type == TType.I32) {
              DieDelayTime = iprot.ReadI32();
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
      if (Model != null && __isset.model) {
        field.Name = "model";
        field.Type = TType.String;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Model);
        oprot.WriteFieldEnd();
      }
      if (DataPrefab != null && __isset.dataPrefab) {
        field.Name = "dataPrefab";
        field.Type = TType.String;
        field.ID = 21;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(DataPrefab);
        oprot.WriteFieldEnd();
      }
      if (Blush != null && __isset.blush) {
        field.Name = "blush";
        field.Type = TType.String;
        field.ID = 22;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Blush);
        oprot.WriteFieldEnd();
      }
      if (__isset.blushType) {
        field.Name = "blushType";
        field.Type = TType.I32;
        field.ID = 23;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(BlushType);
        oprot.WriteFieldEnd();
      }
      if (__isset.totalTime) {
        field.Name = "totalTime";
        field.Type = TType.I32;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(TotalTime);
        oprot.WriteFieldEnd();
      }
      if (__isset.maxTime) {
        field.Name = "maxTime";
        field.Type = TType.I32;
        field.ID = 40;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(MaxTime);
        oprot.WriteFieldEnd();
      }
      if (__isset.collisionLimitId) {
        field.Name = "collisionLimitId";
        field.Type = TType.I32;
        field.ID = 45;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(CollisionLimitId);
        oprot.WriteFieldEnd();
      }
      if (__isset.collisionFuncId) {
        field.Name = "collisionFuncId";
        field.Type = TType.I32;
        field.ID = 46;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(CollisionFuncId);
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
      if (__isset.targetId) {
        field.Name = "targetId";
        field.Type = TType.I32;
        field.ID = 91;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(TargetId);
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
      if (__isset.posCoordType) {
        field.Name = "posCoordType";
        field.Type = TType.I32;
        field.ID = 100;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(PosCoordType);
        oprot.WriteFieldEnd();
      }
      if (__isset.speedCoordType) {
        field.Name = "speedCoordType";
        field.Type = TType.I32;
        field.ID = 101;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(SpeedCoordType);
        oprot.WriteFieldEnd();
      }
      if (__isset.floatTime) {
        field.Name = "floatTime";
        field.Type = TType.I32;
        field.ID = 102;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(FloatTime);
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
      if (__isset.poxZ) {
        field.Name = "poxZ";
        field.Type = TType.I32;
        field.ID = 121;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(PoxZ);
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
      if (__isset.initSpeedZ) {
        field.Name = "initSpeedZ";
        field.Type = TType.I32;
        field.ID = 141;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(InitSpeedZ);
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
      if (__isset.addSpeedZ) {
        field.Name = "addSpeedZ";
        field.Type = TType.I32;
        field.ID = 170;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(AddSpeedZ);
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
      if (__isset.bornRotate) {
        field.Name = "bornRotate";
        field.Type = TType.I32;
        field.ID = 190;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(BornRotate);
        oprot.WriteFieldEnd();
      }
      if (__isset.moveForward) {
        field.Name = "moveForward";
        field.Type = TType.I32;
        field.ID = 200;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(MoveForward);
        oprot.WriteFieldEnd();
      }
      if (__isset.score) {
        field.Name = "score";
        field.Type = TType.I32;
        field.ID = 210;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Score);
        oprot.WriteFieldEnd();
      }
      if (__isset.specialMpRate) {
        field.Name = "specialMpRate";
        field.Type = TType.I32;
        field.ID = 220;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(SpecialMpRate);
        oprot.WriteFieldEnd();
      }
      if (__isset.dieDelayTime) {
        field.Name = "dieDelayTime";
        field.Type = TType.I32;
        field.ID = 230;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DieDelayTime);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("BattleEffectConfig(");
      sb.Append("Id: ");
      sb.Append(Id);
      sb.Append(",Model: ");
      sb.Append(Model);
      sb.Append(",DataPrefab: ");
      sb.Append(DataPrefab);
      sb.Append(",Blush: ");
      sb.Append(Blush);
      sb.Append(",BlushType: ");
      sb.Append(BlushType);
      sb.Append(",TotalTime: ");
      sb.Append(TotalTime);
      sb.Append(",MaxTime: ");
      sb.Append(MaxTime);
      sb.Append(",CollisionLimitId: ");
      sb.Append(CollisionLimitId);
      sb.Append(",CollisionFuncId: ");
      sb.Append(CollisionFuncId);
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
      sb.Append(",TargetId: ");
      sb.Append(TargetId);
      sb.Append(",FollowInterval: ");
      sb.Append(FollowInterval);
      sb.Append(",PosCoordType: ");
      sb.Append(PosCoordType);
      sb.Append(",SpeedCoordType: ");
      sb.Append(SpeedCoordType);
      sb.Append(",FloatTime: ");
      sb.Append(FloatTime);
      sb.Append(",PosX: ");
      sb.Append(PosX);
      sb.Append(",PosY: ");
      sb.Append(PosY);
      sb.Append(",PoxZ: ");
      sb.Append(PoxZ);
      sb.Append(",InitSpeedX: ");
      sb.Append(InitSpeedX);
      sb.Append(",InitSpeedY: ");
      sb.Append(InitSpeedY);
      sb.Append(",InitSpeedZ: ");
      sb.Append(InitSpeedZ);
      sb.Append(",AddSpeedX: ");
      sb.Append(AddSpeedX);
      sb.Append(",AddSpeedY: ");
      sb.Append(AddSpeedY);
      sb.Append(",AddSpeedZ: ");
      sb.Append(AddSpeedZ);
      sb.Append(",DieEffect: ");
      sb.Append(DieEffect);
      sb.Append(",BornRotate: ");
      sb.Append(BornRotate);
      sb.Append(",MoveForward: ");
      sb.Append(MoveForward);
      sb.Append(",Score: ");
      sb.Append(Score);
      sb.Append(",SpecialMpRate: ");
      sb.Append(SpecialMpRate);
      sb.Append(",DieDelayTime: ");
      sb.Append(DieDelayTime);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
