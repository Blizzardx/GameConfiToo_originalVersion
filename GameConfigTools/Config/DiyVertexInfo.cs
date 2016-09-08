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
  public partial class DiyVertexInfo : TBase
  {
    private int _vertexId;
    private int _radius;
    private int _min;
    private int _max;
    private Config.ThriftVector3 _dir;
    private int _diyType;

    public int VertexId
    {
      get
      {
        return _vertexId;
      }
      set
      {
        __isset.vertexId = true;
        this._vertexId = value;
      }
    }

    public int Radius
    {
      get
      {
        return _radius;
      }
      set
      {
        __isset.radius = true;
        this._radius = value;
      }
    }

    public int Min
    {
      get
      {
        return _min;
      }
      set
      {
        __isset.min = true;
        this._min = value;
      }
    }

    public int Max
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

    public Config.ThriftVector3 Dir
    {
      get
      {
        return _dir;
      }
      set
      {
        __isset.dir = true;
        this._dir = value;
      }
    }

    public int DiyType
    {
      get
      {
        return _diyType;
      }
      set
      {
        __isset.diyType = true;
        this._diyType = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool vertexId;
      public bool radius;
      public bool min;
      public bool max;
      public bool dir;
      public bool diyType;
    }

    public DiyVertexInfo() {
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
              VertexId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.I32) {
              Radius = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.I32) {
              Min = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 40:
            if (field.Type == TType.I32) {
              Max = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 50:
            if (field.Type == TType.Struct) {
              Dir = new Config.ThriftVector3();
              Dir.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 60:
            if (field.Type == TType.I32) {
              DiyType = iprot.ReadI32();
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
      TStruct struc = new TStruct("DiyVertexInfo");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.vertexId) {
        field.Name = "vertexId";
        field.Type = TType.I32;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(VertexId);
        oprot.WriteFieldEnd();
      }
      if (__isset.radius) {
        field.Name = "radius";
        field.Type = TType.I32;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Radius);
        oprot.WriteFieldEnd();
      }
      if (__isset.min) {
        field.Name = "min";
        field.Type = TType.I32;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Min);
        oprot.WriteFieldEnd();
      }
      if (__isset.max) {
        field.Name = "max";
        field.Type = TType.I32;
        field.ID = 40;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Max);
        oprot.WriteFieldEnd();
      }
      if (Dir != null && __isset.dir) {
        field.Name = "dir";
        field.Type = TType.Struct;
        field.ID = 50;
        oprot.WriteFieldBegin(field);
        Dir.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (__isset.diyType) {
        field.Name = "diyType";
        field.Type = TType.I32;
        field.ID = 60;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DiyType);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("DiyVertexInfo(");
      sb.Append("VertexId: ");
      sb.Append(VertexId);
      sb.Append(",Radius: ");
      sb.Append(Radius);
      sb.Append(",Min: ");
      sb.Append(Min);
      sb.Append(",Max: ");
      sb.Append(Max);
      sb.Append(",Dir: ");
      sb.Append(Dir== null ? "<null>" : Dir.ToString());
      sb.Append(",DiyType: ");
      sb.Append(DiyType);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
