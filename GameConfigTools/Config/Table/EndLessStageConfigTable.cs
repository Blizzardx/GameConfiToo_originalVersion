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
  public partial class EndlessStageConfigTable : TBase
  {
    private Dictionary<int, Config.EndlessStageConfig> _endlessStageConfigMap;

    public Dictionary<int, Config.EndlessStageConfig> EndlessStageConfigMap
    {
      get
      {
        return _endlessStageConfigMap;
      }
      set
      {
        __isset.endlessStageConfigMap = true;
        this._endlessStageConfigMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool endlessStageConfigMap;
    }

    public EndlessStageConfigTable() {
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
                EndlessStageConfigMap = new Dictionary<int, Config.EndlessStageConfig>();
                TMap _map363 = iprot.ReadMapBegin();
                for( int _i364 = 0; _i364 < _map363.Count; ++_i364)
                {
                  int _key365;
                  Config.EndlessStageConfig _val366;
                  _key365 = iprot.ReadI32();
                  _val366 = new Config.EndlessStageConfig();
                  _val366.Read(iprot);
                  EndlessStageConfigMap[_key365] = _val366;
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
      TStruct struc = new TStruct("EndlessStageConfigTable");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (EndlessStageConfigMap != null && __isset.endlessStageConfigMap) {
        field.Name = "endlessStageConfigMap";
        field.Type = TType.Map;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.Struct, EndlessStageConfigMap.Count));
          foreach (int _iter367 in EndlessStageConfigMap.Keys)
          {
            oprot.WriteI32(_iter367);
            EndlessStageConfigMap[_iter367].Write(oprot);
          }
          oprot.WriteMapEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("EndlessStageConfigTable(");
      sb.Append("EndlessStageConfigMap: ");
      sb.Append(EndlessStageConfigMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
