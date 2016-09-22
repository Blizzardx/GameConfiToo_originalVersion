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
  public partial class AeroLevelUpConfigTable : TBase
  {
    private Dictionary<int, Dictionary<int, Config.AeroLevelUpConfig>> _aeroLevelUpConfigMap;

    public Dictionary<int, Dictionary<int, Config.AeroLevelUpConfig>> AeroLevelUpConfigMap
    {
      get
      {
        return _aeroLevelUpConfigMap;
      }
      set
      {
        __isset.aeroLevelUpConfigMap = true;
        this._aeroLevelUpConfigMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool aeroLevelUpConfigMap;
    }

    public AeroLevelUpConfigTable() {
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
                AeroLevelUpConfigMap = new Dictionary<int, Dictionary<int, Config.AeroLevelUpConfig>>();
                TMap _map288 = iprot.ReadMapBegin();
                for( int _i289 = 0; _i289 < _map288.Count; ++_i289)
                {
                  int _key290;
                  Dictionary<int, Config.AeroLevelUpConfig> _val291;
                  _key290 = iprot.ReadI32();
                  {
                    _val291 = new Dictionary<int, Config.AeroLevelUpConfig>();
                    TMap _map292 = iprot.ReadMapBegin();
                    for( int _i293 = 0; _i293 < _map292.Count; ++_i293)
                    {
                      int _key294;
                      Config.AeroLevelUpConfig _val295;
                      _key294 = iprot.ReadI32();
                      _val295 = new Config.AeroLevelUpConfig();
                      _val295.Read(iprot);
                      _val291[_key294] = _val295;
                    }
                    iprot.ReadMapEnd();
                  }
                  AeroLevelUpConfigMap[_key290] = _val291;
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
      TStruct struc = new TStruct("AeroLevelUpConfigTable");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (AeroLevelUpConfigMap != null && __isset.aeroLevelUpConfigMap) {
        field.Name = "aeroLevelUpConfigMap";
        field.Type = TType.Map;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.Map, AeroLevelUpConfigMap.Count));
          foreach (int _iter296 in AeroLevelUpConfigMap.Keys)
          {
            oprot.WriteI32(_iter296);
            {
              oprot.WriteMapBegin(new TMap(TType.I32, TType.Struct, AeroLevelUpConfigMap[_iter296].Count));
              foreach (int _iter297 in AeroLevelUpConfigMap[_iter296].Keys)
              {
                oprot.WriteI32(_iter297);
                AeroLevelUpConfigMap[_iter296][_iter297].Write(oprot);
              }
              oprot.WriteMapEnd();
            }
          }
          oprot.WriteMapEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("AeroLevelUpConfigTable(");
      sb.Append("AeroLevelUpConfigMap: ");
      sb.Append(AeroLevelUpConfigMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
