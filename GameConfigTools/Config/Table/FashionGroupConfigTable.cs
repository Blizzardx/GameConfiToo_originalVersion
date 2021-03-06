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
                TMap _map230 = iprot.ReadMapBegin();
                for( int _i231 = 0; _i231 < _map230.Count; ++_i231)
                {
                  int _key232;
                  Config.FashionGroupConfig _val233;
                  _key232 = iprot.ReadI32();
                  _val233 = new Config.FashionGroupConfig();
                  _val233.Read(iprot);
                  FashionGroupMap[_key232] = _val233;
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
          foreach (int _iter234 in FashionGroupMap.Keys)
          {
            oprot.WriteI32(_iter234);
            FashionGroupMap[_iter234].Write(oprot);
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
