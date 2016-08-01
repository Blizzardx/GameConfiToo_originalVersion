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
  public partial class BattleEffectConfigTable : TBase
  {
    private Dictionary<int, Config.BattleEffectConfig> _battleEffectConfigMap;

    public Dictionary<int, Config.BattleEffectConfig> BattleEffectConfigMap
    {
      get
      {
        return _battleEffectConfigMap;
      }
      set
      {
        __isset.battleEffectConfigMap = true;
        this._battleEffectConfigMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool battleEffectConfigMap;
    }

    public BattleEffectConfigTable() {
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
                BattleEffectConfigMap = new Dictionary<int, Config.BattleEffectConfig>();
                TMap _map91 = iprot.ReadMapBegin();
                for( int _i92 = 0; _i92 < _map91.Count; ++_i92)
                {
                  int _key93;
                  Config.BattleEffectConfig _val94;
                  _key93 = iprot.ReadI32();
                  _val94 = new Config.BattleEffectConfig();
                  _val94.Read(iprot);
                  BattleEffectConfigMap[_key93] = _val94;
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
      TStruct struc = new TStruct("BattleEffectConfigTable");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (BattleEffectConfigMap != null && __isset.battleEffectConfigMap) {
        field.Name = "battleEffectConfigMap";
        field.Type = TType.Map;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.Struct, BattleEffectConfigMap.Count));
          foreach (int _iter95 in BattleEffectConfigMap.Keys)
          {
            oprot.WriteI32(_iter95);
            BattleEffectConfigMap[_iter95].Write(oprot);
          }
          oprot.WriteMapEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("BattleEffectConfigTable(");
      sb.Append("BattleEffectConfigMap: ");
      sb.Append(BattleEffectConfigMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}