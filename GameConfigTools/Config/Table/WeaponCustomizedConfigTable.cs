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
  public partial class WeaponCustomizedConfigTable : TBase
  {
    private Dictionary<int, Config.WeaponCustomizedConfig> _weaponMap;

    public Dictionary<int, Config.WeaponCustomizedConfig> WeaponMap
    {
      get
      {
        return _weaponMap;
      }
      set
      {
        __isset.weaponMap = true;
        this._weaponMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool weaponMap;
    }

    public WeaponCustomizedConfigTable() {
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
                WeaponMap = new Dictionary<int, Config.WeaponCustomizedConfig>();
                TMap _map427 = iprot.ReadMapBegin();
                for( int _i428 = 0; _i428 < _map427.Count; ++_i428)
                {
                  int _key429;
                  Config.WeaponCustomizedConfig _val430;
                  _key429 = iprot.ReadI32();
                  _val430 = new Config.WeaponCustomizedConfig();
                  _val430.Read(iprot);
                  WeaponMap[_key429] = _val430;
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
      TStruct struc = new TStruct("WeaponCustomizedConfigTable");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (WeaponMap != null && __isset.weaponMap) {
        field.Name = "weaponMap";
        field.Type = TType.Map;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.Struct, WeaponMap.Count));
          foreach (int _iter431 in WeaponMap.Keys)
          {
            oprot.WriteI32(_iter431);
            WeaponMap[_iter431].Write(oprot);
          }
          oprot.WriteMapEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("WeaponCustomizedConfigTable(");
      sb.Append("WeaponMap: ");
      sb.Append(WeaponMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}