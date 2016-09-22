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
  public partial class PropsConfigTable : TBase
  {
    private Dictionary<int, Config.PropsConfig> _propsConfigMap;

    public Dictionary<int, Config.PropsConfig> PropsConfigMap
    {
      get
      {
        return _propsConfigMap;
      }
      set
      {
        __isset.propsConfigMap = true;
        this._propsConfigMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool propsConfigMap;
    }

    public PropsConfigTable() {
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
                PropsConfigMap = new Dictionary<int, Config.PropsConfig>();
                TMap _map215 = iprot.ReadMapBegin();
                for( int _i216 = 0; _i216 < _map215.Count; ++_i216)
                {
                  int _key217;
                  Config.PropsConfig _val218;
                  _key217 = iprot.ReadI32();
                  _val218 = new Config.PropsConfig();
                  _val218.Read(iprot);
                  PropsConfigMap[_key217] = _val218;
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
      TStruct struc = new TStruct("PropsConfigTable");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (PropsConfigMap != null && __isset.propsConfigMap) {
        field.Name = "propsConfigMap";
        field.Type = TType.Map;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.Struct, PropsConfigMap.Count));
          foreach (int _iter219 in PropsConfigMap.Keys)
          {
            oprot.WriteI32(_iter219);
            PropsConfigMap[_iter219].Write(oprot);
          }
          oprot.WriteMapEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("PropsConfigTable(");
      sb.Append("PropsConfigMap: ");
      sb.Append(PropsConfigMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
