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
  public partial class BattleActionConfigTable : TBase
  {
    private Dictionary<int, List<Config.BattleActionConfig>> _battleActionConfigMap;

    public Dictionary<int, List<Config.BattleActionConfig>> BattleActionConfigMap
    {
      get
      {
        return _battleActionConfigMap;
      }
      set
      {
        __isset.battleActionConfigMap = true;
        this._battleActionConfigMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool battleActionConfigMap;
    }

    public BattleActionConfigTable() {
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
                BattleActionConfigMap = new Dictionary<int, List<Config.BattleActionConfig>>();
                TMap _map63 = iprot.ReadMapBegin();
                for( int _i64 = 0; _i64 < _map63.Count; ++_i64)
                {
                  int _key65;
                  List<Config.BattleActionConfig> _val66;
                  _key65 = iprot.ReadI32();
                  {
                    _val66 = new List<Config.BattleActionConfig>();
                    TList _list67 = iprot.ReadListBegin();
                    for( int _i68 = 0; _i68 < _list67.Count; ++_i68)
                    {
                      Config.BattleActionConfig _elem69 = new Config.BattleActionConfig();
                      _elem69 = new Config.BattleActionConfig();
                      _elem69.Read(iprot);
                      _val66.Add(_elem69);
                    }
                    iprot.ReadListEnd();
                  }
                  BattleActionConfigMap[_key65] = _val66;
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
      TStruct struc = new TStruct("BattleActionConfigTable");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (BattleActionConfigMap != null && __isset.battleActionConfigMap) {
        field.Name = "battleActionConfigMap";
        field.Type = TType.Map;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.List, BattleActionConfigMap.Count));
          foreach (int _iter70 in BattleActionConfigMap.Keys)
          {
            oprot.WriteI32(_iter70);
            {
              oprot.WriteListBegin(new TList(TType.Struct, BattleActionConfigMap[_iter70].Count));
              foreach (Config.BattleActionConfig _iter71 in BattleActionConfigMap[_iter70])
              {
                _iter71.Write(oprot);
              }
              oprot.WriteListEnd();
            }
          }
          oprot.WriteMapEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("BattleActionConfigTable(");
      sb.Append("BattleActionConfigMap: ");
      sb.Append(BattleActionConfigMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
