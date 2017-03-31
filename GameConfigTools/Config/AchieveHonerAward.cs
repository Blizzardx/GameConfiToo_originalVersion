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
  public partial class AchieveHonerAward : TBase
  {
    private int _honer;
    private int _awardFuncId;

    public int Honer
    {
      get
      {
        return _honer;
      }
      set
      {
        __isset.honer = true;
        this._honer = value;
      }
    }

    public int AwardFuncId
    {
      get
      {
        return _awardFuncId;
      }
      set
      {
        __isset.awardFuncId = true;
        this._awardFuncId = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool honer;
      public bool awardFuncId;
    }

    public AchieveHonerAward() {
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
              Honer = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.I32) {
              AwardFuncId = iprot.ReadI32();
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
      TStruct struc = new TStruct("AchieveHonerAward");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.honer) {
        field.Name = "honer";
        field.Type = TType.I32;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Honer);
        oprot.WriteFieldEnd();
      }
      if (__isset.awardFuncId) {
        field.Name = "awardFuncId";
        field.Type = TType.I32;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(AwardFuncId);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("AchieveHonerAward(");
      sb.Append("Honer: ");
      sb.Append(Honer);
      sb.Append(",AwardFuncId: ");
      sb.Append(AwardFuncId);
      sb.Append(")");
      return sb.ToString();
    }

  }

}