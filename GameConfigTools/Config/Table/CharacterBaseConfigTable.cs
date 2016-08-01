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
  public partial class CharacterBaseConfigTable : TBase
  {
    private Dictionary<int, Config.CharacterBaseConfig> _characterBaseConfigMap;

    public Dictionary<int, Config.CharacterBaseConfig> CharacterBaseConfigMap
    {
      get
      {
        return _characterBaseConfigMap;
      }
      set
      {
        __isset.characterBaseConfigMap = true;
        this._characterBaseConfigMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool characterBaseConfigMap;
    }

    public CharacterBaseConfigTable() {
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
          case 10:
            if (field.Type == TType.Map) {
              {
                CharacterBaseConfigMap = new Dictionary<int, Config.CharacterBaseConfig>();
                TMap _map63 = iprot.ReadMapBegin();
                for( int _i64 = 0; _i64 < _map63.Count; ++_i64)
                {
                  int _key65;
                  Config.CharacterBaseConfig _val66;
                  _key65 = iprot.ReadI32();
                  _val66 = new Config.CharacterBaseConfig();
                  _val66.Read(iprot);
                  CharacterBaseConfigMap[_key65] = _val66;
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
      TStruct struc = new TStruct("CharacterBaseConfigTable");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (CharacterBaseConfigMap != null && __isset.characterBaseConfigMap) {
        field.Name = "characterBaseConfigMap";
        field.Type = TType.Map;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.Struct, CharacterBaseConfigMap.Count));
          foreach (int _iter67 in CharacterBaseConfigMap.Keys)
          {
            oprot.WriteI32(_iter67);
            CharacterBaseConfigMap[_iter67].Write(oprot);
          }
          oprot.WriteMapEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("CharacterBaseConfigTable(");
      sb.Append("CharacterBaseConfigMap: ");
      sb.Append(CharacterBaseConfigMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}