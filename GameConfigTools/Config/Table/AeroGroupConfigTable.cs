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
  public partial class AeroGroupConfigTable : TBase
  {
    private Dictionary<int, Config.AeroGroupConfig> _aeroGroupConfigMap;

    public Dictionary<int, Config.AeroGroupConfig> AeroGroupConfigMap
    {
      get
      {
        return _aeroGroupConfigMap;
      }
      set
      {
        __isset.aeroGroupConfigMap = true;
        this._aeroGroupConfigMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool aeroGroupConfigMap;
    }

    public AeroGroupConfigTable() {
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
                AeroGroupConfigMap = new Dictionary<int, Config.AeroGroupConfig>();
                TMap _map293 = iprot.ReadMapBegin();
                for( int _i294 = 0; _i294 < _map293.Count; ++_i294)
                {
                  int _key295;
                  Config.AeroGroupConfig _val296;
                  _key295 = iprot.ReadI32();
                  _val296 = new Config.AeroGroupConfig();
                  _val296.Read(iprot);
                  AeroGroupConfigMap[_key295] = _val296;
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
      TStruct struc = new TStruct("AeroGroupConfigTable");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (AeroGroupConfigMap != null && __isset.aeroGroupConfigMap) {
        field.Name = "aeroGroupConfigMap";
        field.Type = TType.Map;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.Struct, AeroGroupConfigMap.Count));
          foreach (int _iter297 in AeroGroupConfigMap.Keys)
          {
            oprot.WriteI32(_iter297);
            AeroGroupConfigMap[_iter297].Write(oprot);
          }
          oprot.WriteMapEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("AeroGroupConfigTable(");
      sb.Append("AeroGroupConfigMap: ");
      sb.Append(AeroGroupConfigMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
