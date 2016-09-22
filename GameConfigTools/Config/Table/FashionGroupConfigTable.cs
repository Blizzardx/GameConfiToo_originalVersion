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
  public partial class FashionGroupConfigTable : TBase
  {
    private Dictionary<int, Config.FashionGroupConfig> _fashionGroupMap;

    public Dictionary<int, Config.FashionGroupConfig> FashionGroupMap
    {
      get
      {
        return _fashionGroupMap;
      }
      set
      {
        __isset.fashionGroupMap = true;
        this._fashionGroupMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool fashionGroupMap;
    }

    public FashionGroupConfigTable() {
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
                FashionGroupMap = new Dictionary<int, Config.FashionGroupConfig>();
                TMap _map235 = iprot.ReadMapBegin();
                for( int _i236 = 0; _i236 < _map235.Count; ++_i236)
                {
                  int _key237;
                  Config.FashionGroupConfig _val238;
                  _key237 = iprot.ReadI32();
                  _val238 = new Config.FashionGroupConfig();
                  _val238.Read(iprot);
                  FashionGroupMap[_key237] = _val238;
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
      TStruct struc = new TStruct("FashionGroupConfigTable");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (FashionGroupMap != null && __isset.fashionGroupMap) {
        field.Name = "fashionGroupMap";
        field.Type = TType.Map;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.Struct, FashionGroupMap.Count));
          foreach (int _iter239 in FashionGroupMap.Keys)
          {
            oprot.WriteI32(_iter239);
            FashionGroupMap[_iter239].Write(oprot);
          }
          oprot.WriteMapEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("FashionGroupConfigTable(");
      sb.Append("FashionGroupMap: ");
      sb.Append(FashionGroupMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
