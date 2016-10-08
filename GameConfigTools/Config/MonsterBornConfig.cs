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
  public partial class MonsterBornConfig : TBase
  {
    private int _id;
    private int _limitId;
    private int _waitForBegin;
    private int _waitTime;
    private int _duringTimeMin;
    private int _duringTimeMax;
    private int _countMax;
    private List<MonsterWeightConfig> _monsterWeightConfigList;

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

    public int LimitId
    {
      get
      {
        return _limitId;
      }
      set
      {
        __isset.limitId = true;
        this._limitId = value;
      }
    }

    public int WaitForBegin
    {
      get
      {
        return _waitForBegin;
      }
      set
      {
        __isset.waitForBegin = true;
        this._waitForBegin = value;
      }
    }

    public int WaitTime
    {
      get
      {
        return _waitTime;
      }
      set
      {
        __isset.waitTime = true;
        this._waitTime = value;
      }
    }

    public int DuringTimeMin
    {
      get
      {
        return _duringTimeMin;
      }
      set
      {
        __isset.duringTimeMin = true;
        this._duringTimeMin = value;
      }
    }

    public int DuringTimeMax
    {
      get
      {
        return _duringTimeMax;
      }
      set
      {
        __isset.duringTimeMax = true;
        this._duringTimeMax = value;
      }
    }

    public int CountMax
    {
      get
      {
        return _countMax;
      }
      set
      {
        __isset.countMax = true;
        this._countMax = value;
      }
    }

    public List<MonsterWeightConfig> MonsterWeightConfigList
    {
      get
      {
        return _monsterWeightConfigList;
      }
      set
      {
        __isset.monsterWeightConfigList = true;
        this._monsterWeightConfigList = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool id;
      public bool limitId;
      public bool waitForBegin;
      public bool waitTime;
      public bool duringTimeMin;
      public bool duringTimeMax;
      public bool countMax;
      public bool monsterWeightConfigList;
    }

    public MonsterBornConfig() {
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
              LimitId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.I32) {
              WaitForBegin = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 40:
            if (field.Type == TType.I32) {
              WaitTime = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 50:
            if (field.Type == TType.I32) {
              DuringTimeMin = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 60:
            if (field.Type == TType.I32) {
              DuringTimeMax = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 70:
            if (field.Type == TType.I32) {
              CountMax = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 80:
            if (field.Type == TType.List) {
              {
                MonsterWeightConfigList = new List<MonsterWeightConfig>();
                TList _list183 = iprot.ReadListBegin();
                for( int _i184 = 0; _i184 < _list183.Count; ++_i184)
                {
                  MonsterWeightConfig _elem185 = new MonsterWeightConfig();
                  _elem185 = new MonsterWeightConfig();
                  _elem185.Read(iprot);
                  MonsterWeightConfigList.Add(_elem185);
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
      TStruct struc = new TStruct("MonsterBornConfig");
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
      if (__isset.limitId) {
        field.Name = "limitId";
        field.Type = TType.I32;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(LimitId);
        oprot.WriteFieldEnd();
      }
      if (__isset.waitForBegin) {
        field.Name = "waitForBegin";
        field.Type = TType.I32;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(WaitForBegin);
        oprot.WriteFieldEnd();
      }
      if (__isset.waitTime) {
        field.Name = "waitTime";
        field.Type = TType.I32;
        field.ID = 40;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(WaitTime);
        oprot.WriteFieldEnd();
      }
      if (__isset.duringTimeMin) {
        field.Name = "duringTimeMin";
        field.Type = TType.I32;
        field.ID = 50;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DuringTimeMin);
        oprot.WriteFieldEnd();
      }
      if (__isset.duringTimeMax) {
        field.Name = "duringTimeMax";
        field.Type = TType.I32;
        field.ID = 60;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DuringTimeMax);
        oprot.WriteFieldEnd();
      }
      if (__isset.countMax) {
        field.Name = "countMax";
        field.Type = TType.I32;
        field.ID = 70;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(CountMax);
        oprot.WriteFieldEnd();
      }
      if (MonsterWeightConfigList != null && __isset.monsterWeightConfigList) {
        field.Name = "monsterWeightConfigList";
        field.Type = TType.List;
        field.ID = 80;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, MonsterWeightConfigList.Count));
          foreach (MonsterWeightConfig _iter186 in MonsterWeightConfigList)
          {
            _iter186.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("MonsterBornConfig(");
      sb.Append("Id: ");
      sb.Append(Id);
      sb.Append(",LimitId: ");
      sb.Append(LimitId);
      sb.Append(",WaitForBegin: ");
      sb.Append(WaitForBegin);
      sb.Append(",WaitTime: ");
      sb.Append(WaitTime);
      sb.Append(",DuringTimeMin: ");
      sb.Append(DuringTimeMin);
      sb.Append(",DuringTimeMax: ");
      sb.Append(DuringTimeMax);
      sb.Append(",CountMax: ");
      sb.Append(CountMax);
      sb.Append(",MonsterWeightConfigList: ");
      sb.Append(MonsterWeightConfigList);
      sb.Append(")");
      return sb.ToString();
    }

  }

}