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
  public partial class ConsumeConfigTable : TBase
  {
    private Dictionary<int, Config.ConsumeConfig> _consumeConfigMap;

    public Dictionary<int, Config.ConsumeConfig> ConsumeConfigMap
    {
      get
      {
        return _consumeConfigMap;
      }
      set
      {
        __isset.consumeConfigMap = true;
        this._consumeConfigMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool consumeConfigMap;
    }

    public ConsumeConfigTable() {
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
                ConsumeConfigMap = new Dictionary<int, Config.ConsumeConfig>();
                TMap _map298 = iprot.ReadMapBegin();
                for( int _i299 = 0; _i299 < _map298.Count; ++_i299)
                {
                  int _key300;
                  Config.ConsumeConfig _val301;
                  _key300 = iprot.ReadI32();
                  _val301 = new Config.ConsumeConfig();
                  _val301.Read(iprot);
                  ConsumeConfigMap[_key300] = _val301;
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
      TStruct struc = new TStruct("ConsumeConfigTable");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (ConsumeConfigMap != null && __isset.consumeConfigMap) {
        field.Name = "consumeConfigMap";
        field.Type = TType.Map;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.Struct, ConsumeConfigMap.Count));
          foreach (int _iter302 in ConsumeConfigMap.Keys)
          {
            oprot.WriteI32(_iter302);
            ConsumeConfigMap[_iter302].Write(oprot);
          }
          oprot.WriteMapEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("ConsumeConfigTable(");
      sb.Append("ConsumeConfigMap: ");
      sb.Append(ConsumeConfigMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
