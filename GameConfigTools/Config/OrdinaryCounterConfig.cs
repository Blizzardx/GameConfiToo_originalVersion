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
  public partial class OrdinaryCounterConfig : TBase
  {
    private sbyte _type;
    private short _max;

    public sbyte Type
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

    public short Max
    {
      get
      {
        return _max;
      }
      set
      {
        __isset.max = true;
        this._max = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool type;
      public bool max;
    }

    public OrdinaryCounterConfig() {
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
          case 1:
            if (field.Type == TType.Byte) {
              Type = iprot.ReadByte();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.I16) {
              Max = iprot.ReadI16();
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
      TStruct struc = new TStruct("OrdinaryCounterConfig");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.type) {
        field.Name = "type";
        field.Type = TType.Byte;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteByte(Type);
        oprot.WriteFieldEnd();
      }
      if (__isset.max) {
        field.Name = "max";
        field.Type = TType.I16;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteI16(Max);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("OrdinaryCounterConfig(");
      sb.Append("Type: ");
      sb.Append(Type);
      sb.Append(",Max: ");
      sb.Append(Max);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
