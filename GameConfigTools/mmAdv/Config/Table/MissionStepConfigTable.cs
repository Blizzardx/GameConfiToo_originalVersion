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
  public partial class MissionStepConfigTable : TBase
  {
    private Dictionary<int, List<Config.MissionStepConfig>> _missionStepConfigMap;

    public Dictionary<int, List<Config.MissionStepConfig>> MissionStepConfigMap
    {
      get
      {
        return _missionStepConfigMap;
      }
      set
      {
        __isset.missionStepConfigMap = true;
        this._missionStepConfigMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool missionStepConfigMap;
    }

    public MissionStepConfigTable() {
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
                MissionStepConfigMap = new Dictionary<int, List<Config.MissionStepConfig>>();
                TMap _map55 = iprot.ReadMapBegin();
                for( int _i56 = 0; _i56 < _map55.Count; ++_i56)
                {
                  int _key57;
                  List<Config.MissionStepConfig> _val58;
                  _key57 = iprot.ReadI32();
                  {
                    _val58 = new List<Config.MissionStepConfig>();
                    TList _list59 = iprot.ReadListBegin();
                    for( int _i60 = 0; _i60 < _list59.Count; ++_i60)
                    {
                      Config.MissionStepConfig _elem61 = new Config.MissionStepConfig();
                      _elem61 = new Config.MissionStepConfig();
                      _elem61.Read(iprot);
                      _val58.Add(_elem61);
                    }
                    iprot.ReadListEnd();
                  }
                  MissionStepConfigMap[_key57] = _val58;
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
      TStruct struc = new TStruct("MissionStepConfigTable");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (MissionStepConfigMap != null && __isset.missionStepConfigMap) {
        field.Name = "missionStepConfigMap";
        field.Type = TType.Map;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.List, MissionStepConfigMap.Count));
          foreach (int _iter62 in MissionStepConfigMap.Keys)
          {
            oprot.WriteI32(_iter62);
            {
              oprot.WriteListBegin(new TList(TType.Struct, MissionStepConfigMap[_iter62].Count));
              foreach (Config.MissionStepConfig _iter63 in MissionStepConfigMap[_iter62])
              {
                _iter63.Write(oprot);
              }
              oprot.WriteListEnd();
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
      StringBuilder sb = new StringBuilder("MissionStepConfigTable(");
      sb.Append("MissionStepConfigMap: ");
      sb.Append(MissionStepConfigMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}