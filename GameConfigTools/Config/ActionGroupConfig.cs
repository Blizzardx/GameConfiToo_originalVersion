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

namespace Config
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class ActionGroupConfig : TBase
  {
    private int _id;
    private Dictionary<int, List<string>> _actionGroupMap;

    public int Id
    {
      get
      {
        return _id;
      }
      set
      {
        __isset.id = true;
        this._id = value;
      }
    }

    public Dictionary<int, List<string>> ActionGroupMap
    {
      get
      {
        return _actionGroupMap;
      }
      set
      {
        __isset.actionGroupMap = true;
        this._actionGroupMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool id;
      public bool actionGroupMap;
    }

    public ActionGroupConfig() {
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
            if (field.Type == TType.I32) {
              Id = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.Map) {
              {
                ActionGroupMap = new Dictionary<int, List<string>>();
                TMap _map121 = iprot.ReadMapBegin();
                for( int _i122 = 0; _i122 < _map121.Count; ++_i122)
                {
                  int _key123;
                  List<string> _val124;
                  _key123 = iprot.ReadI32();
                  {
                    _val124 = new List<string>();
                    TList _list125 = iprot.ReadListBegin();
                    for( int _i126 = 0; _i126 < _list125.Count; ++_i126)
                    {
                      string _elem127 = null;
                      _elem127 = iprot.ReadString();
                      _val124.Add(_elem127);
                    }
                    iprot.ReadListEnd();
                  }
                  ActionGroupMap[_key123] = _val124;
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
      TStruct struc = new TStruct("ActionGroupConfig");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.id) {
        field.Name = "id";
        field.Type = TType.I32;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Id);
        oprot.WriteFieldEnd();
      }
      if (ActionGroupMap != null && __isset.actionGroupMap) {
        field.Name = "actionGroupMap";
        field.Type = TType.Map;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.List, ActionGroupMap.Count));
          foreach (int _iter128 in ActionGroupMap.Keys)
          {
            oprot.WriteI32(_iter128);
            {
              oprot.WriteListBegin(new TList(TType.String, ActionGroupMap[_iter128].Count));
              foreach (string _iter129 in ActionGroupMap[_iter128])
              {
                oprot.WriteString(_iter129);
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
      StringBuilder sb = new StringBuilder("ActionGroupConfig(");
      sb.Append("Id: ");
      sb.Append(Id);
      sb.Append(",ActionGroupMap: ");
      sb.Append(ActionGroupMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
