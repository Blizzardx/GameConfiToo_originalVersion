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
  public partial class RoomActionConfigTable : TBase
  {
    private Dictionary<int, List<Config.RoomActionConfig>> _roomActionConfigMap;

    public Dictionary<int, List<Config.RoomActionConfig>> RoomActionConfigMap
    {
      get
      {
        return _roomActionConfigMap;
      }
      set
      {
        __isset.roomActionConfigMap = true;
        this._roomActionConfigMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool roomActionConfigMap;
    }

    public RoomActionConfigTable() {
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
                RoomActionConfigMap = new Dictionary<int, List<Config.RoomActionConfig>>();
                TMap _map259 = iprot.ReadMapBegin();
                for( int _i260 = 0; _i260 < _map259.Count; ++_i260)
                {
                  int _key261;
                  List<Config.RoomActionConfig> _val262;
                  _key261 = iprot.ReadI32();
                  {
                    _val262 = new List<Config.RoomActionConfig>();
                    TList _list263 = iprot.ReadListBegin();
                    for( int _i264 = 0; _i264 < _list263.Count; ++_i264)
                    {
                      Config.RoomActionConfig _elem265 = new Config.RoomActionConfig();
                      _elem265 = new Config.RoomActionConfig();
                      _elem265.Read(iprot);
                      _val262.Add(_elem265);
                    }
                    iprot.ReadListEnd();
                  }
                  RoomActionConfigMap[_key261] = _val262;
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
      TStruct struc = new TStruct("RoomActionConfigTable");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (RoomActionConfigMap != null && __isset.roomActionConfigMap) {
        field.Name = "roomActionConfigMap";
        field.Type = TType.Map;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.List, RoomActionConfigMap.Count));
          foreach (int _iter266 in RoomActionConfigMap.Keys)
          {
            oprot.WriteI32(_iter266);
            {
              oprot.WriteListBegin(new TList(TType.Struct, RoomActionConfigMap[_iter266].Count));
              foreach (Config.RoomActionConfig _iter267 in RoomActionConfigMap[_iter266])
              {
                _iter267.Write(oprot);
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
      StringBuilder sb = new StringBuilder("RoomActionConfigTable(");
      sb.Append("RoomActionConfigMap: ");
      sb.Append(RoomActionConfigMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
