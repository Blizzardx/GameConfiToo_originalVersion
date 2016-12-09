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
  public partial class GuildExpConfigTable : TBase
  {
    private Dictionary<int, Config.GuildExpConfig> _guildExpConfigMap;

    public Dictionary<int, Config.GuildExpConfig> GuildExpConfigMap
    {
      get
      {
        return _guildExpConfigMap;
      }
      set
      {
        __isset.guildExpConfigMap = true;
        this._guildExpConfigMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool guildExpConfigMap;
    }

    public GuildExpConfigTable() {
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
                GuildExpConfigMap = new Dictionary<int, Config.GuildExpConfig>();
                TMap _map382 = iprot.ReadMapBegin();
                for( int _i383 = 0; _i383 < _map382.Count; ++_i383)
                {
                  int _key384;
                  Config.GuildExpConfig _val385;
                  _key384 = iprot.ReadI32();
                  _val385 = new Config.GuildExpConfig();
                  _val385.Read(iprot);
                  GuildExpConfigMap[_key384] = _val385;
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
      TStruct struc = new TStruct("GuildExpConfigTable");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (GuildExpConfigMap != null && __isset.guildExpConfigMap) {
        field.Name = "guildExpConfigMap";
        field.Type = TType.Map;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.Struct, GuildExpConfigMap.Count));
          foreach (int _iter386 in GuildExpConfigMap.Keys)
          {
            oprot.WriteI32(_iter386);
            GuildExpConfigMap[_iter386].Write(oprot);
          }
          oprot.WriteMapEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("GuildExpConfigTable(");
      sb.Append("GuildExpConfigMap: ");
      sb.Append(GuildExpConfigMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
