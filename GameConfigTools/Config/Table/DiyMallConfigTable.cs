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
  public partial class DiyMallConfigTable : TBase
  {
    private Dictionary<int, Config.DiyMallConfig> _diyMallConfigMap;

    public Dictionary<int, Config.DiyMallConfig> DiyMallConfigMap
    {
      get
      {
        return _diyMallConfigMap;
      }
      set
      {
        __isset.diyMallConfigMap = true;
        this._diyMallConfigMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool diyMallConfigMap;
    }

    public DiyMallConfigTable() {
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
                DiyMallConfigMap = new Dictionary<int, Config.DiyMallConfig>();
                TMap _map215 = iprot.ReadMapBegin();
                for( int _i216 = 0; _i216 < _map215.Count; ++_i216)
                {
                  int _key217;
                  Config.DiyMallConfig _val218;
                  _key217 = iprot.ReadI32();
                  _val218 = new Config.DiyMallConfig();
                  _val218.Read(iprot);
                  DiyMallConfigMap[_key217] = _val218;
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
      TStruct struc = new TStruct("DiyMallConfigTable");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (DiyMallConfigMap != null && __isset.diyMallConfigMap) {
        field.Name = "diyMallConfigMap";
        field.Type = TType.Map;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.Struct, DiyMallConfigMap.Count));
          foreach (int _iter219 in DiyMallConfigMap.Keys)
          {
            oprot.WriteI32(_iter219);
            DiyMallConfigMap[_iter219].Write(oprot);
          }
          oprot.WriteMapEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("DiyMallConfigTable(");
      sb.Append("DiyMallConfigMap: ");
      sb.Append(DiyMallConfigMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
