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
  public partial class StageLogicPointDescConfig : TBase
  {
    private int _id;
    private List<LogicPointElement> _pointList;

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

    public List<LogicPointElement> PointList
    {
      get
      {
        return _pointList;
      }
      set
      {
        __isset.pointList = true;
        this._pointList = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool id;
      public bool pointList;
    }

    public StageLogicPointDescConfig() {
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
            if (field.Type == TType.List) {
              {
                PointList = new List<LogicPointElement>();
                TList _list129 = iprot.ReadListBegin();
                for( int _i130 = 0; _i130 < _list129.Count; ++_i130)
                {
                  LogicPointElement _elem131 = new LogicPointElement();
                  _elem131 = new LogicPointElement();
                  _elem131.Read(iprot);
                  PointList.Add(_elem131);
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
      TStruct struc = new TStruct("StageLogicPointDescConfig");
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
      if (PointList != null && __isset.pointList) {
        field.Name = "pointList";
        field.Type = TType.List;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, PointList.Count));
          foreach (LogicPointElement _iter132 in PointList)
          {
            _iter132.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("StageLogicPointDescConfig(");
      sb.Append("Id: ");
      sb.Append(Id);
      sb.Append(",PointList: ");
      sb.Append(PointList);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
