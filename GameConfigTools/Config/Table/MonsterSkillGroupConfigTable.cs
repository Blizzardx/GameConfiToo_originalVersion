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
  public partial class MonsterSkillGroupConfigTable : TBase
  {
    private Dictionary<int, Config.MonsterSkillGroupConfig> _skillGroupConfigMap;

    public Dictionary<int, Config.MonsterSkillGroupConfig> SkillGroupConfigMap
    {
      get
      {
        return _skillGroupConfigMap;
      }
      set
      {
        __isset.skillGroupConfigMap = true;
        this._skillGroupConfigMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool skillGroupConfigMap;
    }

    public MonsterSkillGroupConfigTable() {
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
                SkillGroupConfigMap = new Dictionary<int, Config.MonsterSkillGroupConfig>();
                TMap _map125 = iprot.ReadMapBegin();
                for( int _i126 = 0; _i126 < _map125.Count; ++_i126)
                {
                  int _key127;
                  Config.MonsterSkillGroupConfig _val128;
                  _key127 = iprot.ReadI32();
                  _val128 = new Config.MonsterSkillGroupConfig();
                  _val128.Read(iprot);
                  SkillGroupConfigMap[_key127] = _val128;
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
      TStruct struc = new TStruct("MonsterSkillGroupConfigTable");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (SkillGroupConfigMap != null && __isset.skillGroupConfigMap) {
        field.Name = "skillGroupConfigMap";
        field.Type = TType.Map;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.Struct, SkillGroupConfigMap.Count));
          foreach (int _iter129 in SkillGroupConfigMap.Keys)
          {
            oprot.WriteI32(_iter129);
            SkillGroupConfigMap[_iter129].Write(oprot);
          }
          oprot.WriteMapEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("MonsterSkillGroupConfigTable(");
      sb.Append("SkillGroupConfigMap: ");
      sb.Append(SkillGroupConfigMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
