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
  public partial class LimitFuncSceneConfigTable : TBase
  {
    private Dictionary<int, List<Config.LimitFuncSceneConfig>> _limitFuncSceneConfigMap;

    /// <summary>
    /// <key: sceneId,   value: List<LimitFuncSceneConfig>>
    /// </summary>
    public Dictionary<int, List<Config.LimitFuncSceneConfig>> LimitFuncSceneConfigMap
    {
      get
      {
        return _limitFuncSceneConfigMap;
      }
      set
      {
        __isset.limitFuncSceneConfigMap = true;
        this._limitFuncSceneConfigMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool limitFuncSceneConfigMap;
    }

    public LimitFuncSceneConfigTable() {
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
                LimitFuncSceneConfigMap = new Dictionary<int, List<Config.LimitFuncSceneConfig>>();
                TMap _map29 = iprot.ReadMapBegin();
                for( int _i30 = 0; _i30 < _map29.Count; ++_i30)
                {
                  int _key31;
                  List<Config.LimitFuncSceneConfig> _val32;
                  _key31 = iprot.ReadI32();
                  {
                    _val32 = new List<Config.LimitFuncSceneConfig>();
                    TList _list33 = iprot.ReadListBegin();
                    for( int _i34 = 0; _i34 < _list33.Count; ++_i34)
                    {
                      Config.LimitFuncSceneConfig _elem35 = new Config.LimitFuncSceneConfig();
                      _elem35 = new Config.LimitFuncSceneConfig();
                      _elem35.Read(iprot);
                      _val32.Add(_elem35);
                    }
                    iprot.ReadListEnd();
                  }
                  LimitFuncSceneConfigMap[_key31] = _val32;
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
      TStruct struc = new TStruct("LimitFuncSceneConfigTable");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (LimitFuncSceneConfigMap != null && __isset.limitFuncSceneConfigMap) {
        field.Name = "limitFuncSceneConfigMap";
        field.Type = TType.Map;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.List, LimitFuncSceneConfigMap.Count));
          foreach (int _iter36 in LimitFuncSceneConfigMap.Keys)
          {
            oprot.WriteI32(_iter36);
            {
              oprot.WriteListBegin(new TList(TType.Struct, LimitFuncSceneConfigMap[_iter36].Count));
              foreach (Config.LimitFuncSceneConfig _iter37 in LimitFuncSceneConfigMap[_iter36])
              {
                _iter37.Write(oprot);
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
      StringBuilder sb = new StringBuilder("LimitFuncSceneConfigTable(");
      sb.Append("LimitFuncSceneConfigMap: ");
      sb.Append(LimitFuncSceneConfigMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}