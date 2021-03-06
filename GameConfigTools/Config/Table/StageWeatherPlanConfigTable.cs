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
  public partial class StageWeatherPlanConfigTable : TBase
  {
    private Dictionary<int, Config.StageWeatherPlanConfig> _stageWeatherPlanConfigMap;

    public Dictionary<int, Config.StageWeatherPlanConfig> StageWeatherPlanConfigMap
    {
      get
      {
        return _stageWeatherPlanConfigMap;
      }
      set
      {
        __isset.stageWeatherPlanConfigMap = true;
        this._stageWeatherPlanConfigMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool stageWeatherPlanConfigMap;
    }

    public StageWeatherPlanConfigTable() {
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
                StageWeatherPlanConfigMap = new Dictionary<int, Config.StageWeatherPlanConfig>();
                TMap _map175 = iprot.ReadMapBegin();
                for( int _i176 = 0; _i176 < _map175.Count; ++_i176)
                {
                  int _key177;
                  Config.StageWeatherPlanConfig _val178;
                  _key177 = iprot.ReadI32();
                  _val178 = new Config.StageWeatherPlanConfig();
                  _val178.Read(iprot);
                  StageWeatherPlanConfigMap[_key177] = _val178;
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
      TStruct struc = new TStruct("StageWeatherPlanConfigTable");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (StageWeatherPlanConfigMap != null && __isset.stageWeatherPlanConfigMap) {
        field.Name = "stageWeatherPlanConfigMap";
        field.Type = TType.Map;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.Struct, StageWeatherPlanConfigMap.Count));
          foreach (int _iter179 in StageWeatherPlanConfigMap.Keys)
          {
            oprot.WriteI32(_iter179);
            StageWeatherPlanConfigMap[_iter179].Write(oprot);
          }
          oprot.WriteMapEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("StageWeatherPlanConfigTable(");
      sb.Append("StageWeatherPlanConfigMap: ");
      sb.Append(StageWeatherPlanConfigMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
