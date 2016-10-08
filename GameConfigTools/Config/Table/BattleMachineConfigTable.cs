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
  public partial class BattleMachineConfigTable : TBase
  {
    private Dictionary<int, Config.BattleMachineConfig> _battleMachineConfigMap;

    public Dictionary<int, Config.BattleMachineConfig> BattleMachineConfigMap
    {
      get
      {
        return _battleMachineConfigMap;
      }
      set
      {
        __isset.battleMachineConfigMap = true;
        this._battleMachineConfigMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool battleMachineConfigMap;
    }

    public BattleMachineConfigTable() {
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
                BattleMachineConfigMap = new Dictionary<int, Config.BattleMachineConfig>();
                TMap _map328 = iprot.ReadMapBegin();
                for( int _i329 = 0; _i329 < _map328.Count; ++_i329)
                {
                  int _key330;
                  Config.BattleMachineConfig _val331;
                  _key330 = iprot.ReadI32();
                  _val331 = new Config.BattleMachineConfig();
                  _val331.Read(iprot);
                  BattleMachineConfigMap[_key330] = _val331;
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
      TStruct struc = new TStruct("BattleMachineConfigTable");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (BattleMachineConfigMap != null && __isset.battleMachineConfigMap) {
        field.Name = "battleMachineConfigMap";
        field.Type = TType.Map;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.Struct, BattleMachineConfigMap.Count));
          foreach (int _iter332 in BattleMachineConfigMap.Keys)
          {
            oprot.WriteI32(_iter332);
            BattleMachineConfigMap[_iter332].Write(oprot);
          }
          oprot.WriteMapEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("BattleMachineConfigTable(");
      sb.Append("BattleMachineConfigMap: ");
      sb.Append(BattleMachineConfigMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
