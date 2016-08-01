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
  public partial class DiyPresetConfigTable : TBase
  {
    private Dictionary<int, Config.DiyPresetConfig> _diyPreseConfigMap;

    public Dictionary<int, Config.DiyPresetConfig> DiyPreseConfigMap
    {
      get
      {
        return _diyPreseConfigMap;
      }
      set
      {
        __isset.diyPreseConfigMap = true;
        this._diyPreseConfigMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool diyPreseConfigMap;
    }

    public DiyPresetConfigTable() {
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
                DiyPreseConfigMap = new Dictionary<int, Config.DiyPresetConfig>();
                TMap _map230 = iprot.ReadMapBegin();
                for( int _i231 = 0; _i231 < _map230.Count; ++_i231)
                {
                  int _key232;
                  Config.DiyPresetConfig _val233;
                  _key232 = iprot.ReadI32();
                  _val233 = new Config.DiyPresetConfig();
                  _val233.Read(iprot);
                  DiyPreseConfigMap[_key232] = _val233;
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
      TStruct struc = new TStruct("DiyPresetConfigTable");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (DiyPreseConfigMap != null && __isset.diyPreseConfigMap) {
        field.Name = "diyPreseConfigMap";
        field.Type = TType.Map;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.Struct, DiyPreseConfigMap.Count));
          foreach (int _iter234 in DiyPreseConfigMap.Keys)
          {
            oprot.WriteI32(_iter234);
            DiyPreseConfigMap[_iter234].Write(oprot);
          }
          oprot.WriteMapEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("DiyPresetConfigTable(");
      sb.Append("DiyPreseConfigMap: ");
      sb.Append(DiyPreseConfigMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}