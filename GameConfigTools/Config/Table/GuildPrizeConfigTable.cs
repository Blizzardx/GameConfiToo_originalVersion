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
  public partial class GuildPrizeConfigTable : TBase
  {
    private Dictionary<int, Config.GuildPrizeConfig> _guildPriceConfigMap;

    public Dictionary<int, Config.GuildPrizeConfig> GuildPriceConfigMap
    {
      get
      {
        return _guildPriceConfigMap;
      }
      set
      {
        __isset.guildPriceConfigMap = true;
        this._guildPriceConfigMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool guildPriceConfigMap;
    }

    public GuildPrizeConfigTable() {
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
                GuildPriceConfigMap = new Dictionary<int, Config.GuildPrizeConfig>();
                TMap _map387 = iprot.ReadMapBegin();
                for( int _i388 = 0; _i388 < _map387.Count; ++_i388)
                {
                  int _key389;
                  Config.GuildPrizeConfig _val390;
                  _key389 = iprot.ReadI32();
                  _val390 = new Config.GuildPrizeConfig();
                  _val390.Read(iprot);
                  GuildPriceConfigMap[_key389] = _val390;
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
      TStruct struc = new TStruct("GuildPrizeConfigTable");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (GuildPriceConfigMap != null && __isset.guildPriceConfigMap) {
        field.Name = "guildPriceConfigMap";
        field.Type = TType.Map;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.Struct, GuildPriceConfigMap.Count));
          foreach (int _iter391 in GuildPriceConfigMap.Keys)
          {
            oprot.WriteI32(_iter391);
            GuildPriceConfigMap[_iter391].Write(oprot);
          }
          oprot.WriteMapEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("GuildPrizeConfigTable(");
      sb.Append("GuildPriceConfigMap: ");
      sb.Append(GuildPriceConfigMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}