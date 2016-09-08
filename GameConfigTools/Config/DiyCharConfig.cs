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
  public partial class DiyCharConfig : TBase
  {
    private int _charId;
    private List<DiyPositionInfo> _positionInfoList;

    public int CharId
    {
      get
      {
        return _charId;
      }
      set
      {
        __isset.charId = true;
        this._charId = value;
      }
    }

    public List<DiyPositionInfo> PositionInfoList
    {
      get
      {
        return _positionInfoList;
      }
      set
      {
        __isset.positionInfoList = true;
        this._positionInfoList = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool charId;
      public bool positionInfoList;
    }

    public DiyCharConfig() {
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
              CharId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.List) {
              {
                PositionInfoList = new List<DiyPositionInfo>();
                TList _list162 = iprot.ReadListBegin();
                for( int _i163 = 0; _i163 < _list162.Count; ++_i163)
                {
                  DiyPositionInfo _elem164 = new DiyPositionInfo();
                  _elem164 = new DiyPositionInfo();
                  _elem164.Read(iprot);
                  PositionInfoList.Add(_elem164);
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
      TStruct struc = new TStruct("DiyCharConfig");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.charId) {
        field.Name = "charId";
        field.Type = TType.I32;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(CharId);
        oprot.WriteFieldEnd();
      }
      if (PositionInfoList != null && __isset.positionInfoList) {
        field.Name = "positionInfoList";
        field.Type = TType.List;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, PositionInfoList.Count));
          foreach (DiyPositionInfo _iter165 in PositionInfoList)
          {
            _iter165.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("DiyCharConfig(");
      sb.Append("CharId: ");
      sb.Append(CharId);
      sb.Append(",PositionInfoList: ");
      sb.Append(PositionInfoList);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
