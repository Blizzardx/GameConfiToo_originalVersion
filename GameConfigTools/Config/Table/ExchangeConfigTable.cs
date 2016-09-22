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
  public partial class ExchangeConfigTable : TBase
  {
    private Dictionary<int, Config.ExchangeConfig> _exchangeConfigMap;

    public Dictionary<int, Config.ExchangeConfig> ExchangeConfigMap
    {
      get
      {
        return _exchangeConfigMap;
      }
      set
      {
        __isset.exchangeConfigMap = true;
        this._exchangeConfigMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool exchangeConfigMap;
    }

    public ExchangeConfigTable() {
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
                ExchangeConfigMap = new Dictionary<int, Config.ExchangeConfig>();
                TMap _map308 = iprot.ReadMapBegin();
                for( int _i309 = 0; _i309 < _map308.Count; ++_i309)
                {
                  int _key310;
                  Config.ExchangeConfig _val311;
                  _key310 = iprot.ReadI32();
                  _val311 = new Config.ExchangeConfig();
                  _val311.Read(iprot);
                  ExchangeConfigMap[_key310] = _val311;
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
      TStruct struc = new TStruct("ExchangeConfigTable");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (ExchangeConfigMap != null && __isset.exchangeConfigMap) {
        field.Name = "exchangeConfigMap";
        field.Type = TType.Map;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.Struct, ExchangeConfigMap.Count));
          foreach (int _iter312 in ExchangeConfigMap.Keys)
          {
            oprot.WriteI32(_iter312);
            ExchangeConfigMap[_iter312].Write(oprot);
          }
          oprot.WriteMapEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("ExchangeConfigTable(");
      sb.Append("ExchangeConfigMap: ");
      sb.Append(ExchangeConfigMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
