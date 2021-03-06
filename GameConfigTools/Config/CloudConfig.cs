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
  public partial class CloudConfig : TBase
  {
    private int _id;
    private int _beginTimeMin;
    private int _beginTimeMax;
    private int _duringTimeMin;
    private int _duringTimeMax;
    private int _beginFuncId;

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

    public int BeginTimeMin
    {
      get
      {
        return _beginTimeMin;
      }
      set
      {
        __isset.beginTimeMin = true;
        this._beginTimeMin = value;
      }
    }

    public int BeginTimeMax
    {
      get
      {
        return _beginTimeMax;
      }
      set
      {
        __isset.beginTimeMax = true;
        this._beginTimeMax = value;
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

    public int BeginFuncId
    {
      get
      {
        return _beginFuncId;
      }
      set
      {
        __isset.beginFuncId = true;
        this._beginFuncId = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool id;
      public bool beginTimeMin;
      public bool beginTimeMax;
      public bool duringTimeMin;
      public bool duringTimeMax;
      public bool beginFuncId;
    }

    public CloudConfig() {
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
              BeginTimeMin = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 21:
            if (field.Type == TType.I32) {
              BeginTimeMax = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.I32) {
              DuringTimeMin = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 31:
            if (field.Type == TType.I32) {
              DuringTimeMax = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 40:
            if (field.Type == TType.I32) {
              BeginFuncId = iprot.ReadI32();
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
      TStruct struc = new TStruct("CloudConfig");
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
      if (__isset.beginTimeMin) {
        field.Name = "beginTimeMin";
        field.Type = TType.I32;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(BeginTimeMin);
        oprot.WriteFieldEnd();
      }
      if (__isset.beginTimeMax) {
        field.Name = "beginTimeMax";
        field.Type = TType.I32;
        field.ID = 21;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(BeginTimeMax);
        oprot.WriteFieldEnd();
      }
      if (__isset.duringTimeMin) {
        field.Name = "duringTimeMin";
        field.Type = TType.I32;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DuringTimeMin);
        oprot.WriteFieldEnd();
      }
      if (__isset.duringTimeMax) {
        field.Name = "duringTimeMax";
        field.Type = TType.I32;
        field.ID = 31;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DuringTimeMax);
        oprot.WriteFieldEnd();
      }
      if (__isset.beginFuncId) {
        field.Name = "beginFuncId";
        field.Type = TType.I32;
        field.ID = 40;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(BeginFuncId);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("CloudConfig(");
      sb.Append("Id: ");
      sb.Append(Id);
      sb.Append(",BeginTimeMin: ");
      sb.Append(BeginTimeMin);
      sb.Append(",BeginTimeMax: ");
      sb.Append(BeginTimeMax);
      sb.Append(",DuringTimeMin: ");
      sb.Append(DuringTimeMin);
      sb.Append(",DuringTimeMax: ");
      sb.Append(DuringTimeMax);
      sb.Append(",BeginFuncId: ");
      sb.Append(BeginFuncId);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
