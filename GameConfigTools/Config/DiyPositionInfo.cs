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
  public partial class DiyPositionInfo : TBase
  {
    private int _positionId;
    private List<DiyVertexInfo> _vertexList;

    public int PositionId
    {
      get
      {
        return _positionId;
      }
      set
      {
        __isset.positionId = true;
        this._positionId = value;
      }
    }

    public List<DiyVertexInfo> VertexList
    {
      get
      {
        return _vertexList;
      }
      set
      {
        __isset.vertexList = true;
        this._vertexList = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool positionId;
      public bool vertexList;
    }

    public DiyPositionInfo() {
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
              PositionId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.List) {
              {
                VertexList = new List<DiyVertexInfo>();
                TList _list179 = iprot.ReadListBegin();
                for( int _i180 = 0; _i180 < _list179.Count; ++_i180)
                {
                  DiyVertexInfo _elem181 = new DiyVertexInfo();
                  _elem181 = new DiyVertexInfo();
                  _elem181.Read(iprot);
                  VertexList.Add(_elem181);
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
      TStruct struc = new TStruct("DiyPositionInfo");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.positionId) {
        field.Name = "positionId";
        field.Type = TType.I32;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(PositionId);
        oprot.WriteFieldEnd();
      }
      if (VertexList != null && __isset.vertexList) {
        field.Name = "vertexList";
        field.Type = TType.List;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, VertexList.Count));
          foreach (DiyVertexInfo _iter182 in VertexList)
          {
            _iter182.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("DiyPositionInfo(");
      sb.Append("PositionId: ");
      sb.Append(PositionId);
      sb.Append(",VertexList: ");
      sb.Append(VertexList);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
