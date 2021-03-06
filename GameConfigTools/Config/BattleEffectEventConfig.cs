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
  public partial class BattleEffectEventConfig : TBase
  {
    private int _effectId;
    private int _eventTime;
    private int _limitId;
    private int _funcId;

    public int EffectId
    {
      get
      {
        return _effectId;
      }
      set
      {
        __isset.effectId = true;
        this._effectId = value;
      }
    }

    public int EventTime
    {
      get
      {
        return _eventTime;
      }
      set
      {
        __isset.eventTime = true;
        this._eventTime = value;
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

    public int FuncId
    {
      get
      {
        return _funcId;
      }
      set
      {
        __isset.funcId = true;
        this._funcId = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool effectId;
      public bool eventTime;
      public bool limitId;
      public bool funcId;
    }

    public BattleEffectEventConfig() {
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
              EffectId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.I32) {
              EventTime = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.I32) {
              LimitId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 40:
            if (field.Type == TType.I32) {
              FuncId = iprot.ReadI32();
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
      TStruct struc = new TStruct("BattleEffectEventConfig");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.effectId) {
        field.Name = "effectId";
        field.Type = TType.I32;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(EffectId);
        oprot.WriteFieldEnd();
      }
      if (__isset.eventTime) {
        field.Name = "eventTime";
        field.Type = TType.I32;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(EventTime);
        oprot.WriteFieldEnd();
      }
      if (__isset.limitId) {
        field.Name = "limitId";
        field.Type = TType.I32;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(LimitId);
        oprot.WriteFieldEnd();
      }
      if (__isset.funcId) {
        field.Name = "funcId";
        field.Type = TType.I32;
        field.ID = 40;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(FuncId);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("BattleEffectEventConfig(");
      sb.Append("EffectId: ");
      sb.Append(EffectId);
      sb.Append(",EventTime: ");
      sb.Append(EventTime);
      sb.Append(",LimitId: ");
      sb.Append(LimitId);
      sb.Append(",FuncId: ");
      sb.Append(FuncId);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
