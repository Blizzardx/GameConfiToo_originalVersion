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

namespace Config.Table
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class TierConfigTable : TBase
  {
    private Dictionary<int, Config.TierConfig> _tierConfigMap;

    public Dictionary<int, Config.TierConfig> TierConfigMap
    {
      get
      {
        return _tierConfigMap;
      }
      set
      {
        __isset.tierConfigMap = true;
        this._tierConfigMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool tierConfigMap;
    }

    public TierConfigTable() {
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
            if (field.Type == TType.Map) {
              {
                TierConfigMap = new Dictionary<int, Config.TierConfig>();
                TMap _map437 = iprot.ReadMapBegin();
                for( int _i438 = 0; _i438 < _map437.Count; ++_i438)
                {
                  int _key439;
                  Config.TierConfig _val440;
                  _key439 = iprot.ReadI32();
                  _val440 = new Config.TierConfig();
                  _val440.Read(iprot);
                  TierConfigMap[_key439] = _val440;
                }
                iprot.ReadMapEnd();
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
      TStruct struc = new TStruct("TierConfigTable");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (TierConfigMap != null && __isset.tierConfigMap) {
        field.Name = "tierConfigMap";
        field.Type = TType.Map;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.Struct, TierConfigMap.Count));
          foreach (int _iter441 in TierConfigMap.Keys)
          {
            oprot.WriteI32(_iter441);
            TierConfigMap[_iter441].Write(oprot);
          }
          oprot.WriteMapEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("TierConfigTable(");
      sb.Append("TierConfigMap: ");
      sb.Append(TierConfigMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
