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
  public partial class Maplist : TBase
  {
    private Dictionary<int, List<int>> _tmpMap;

    public Dictionary<int, List<int>> TmpMap
    {
      get
      {
        return _tmpMap;
      }
      set
      {
        __isset.tmpMap = true;
        this._tmpMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool tmpMap;
    }

    public Maplist() {
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
                TmpMap = new Dictionary<int, List<int>>();
                TMap _map43 = iprot.ReadMapBegin();
                for( int _i44 = 0; _i44 < _map43.Count; ++_i44)
                {
                  int _key45;
                  List<int> _val46;
                  _key45 = iprot.ReadI32();
                  {
                    _val46 = new List<int>();
                    TList _list47 = iprot.ReadListBegin();
                    for( int _i48 = 0; _i48 < _list47.Count; ++_i48)
                    {
                      int _elem49 = 0;
                      _elem49 = iprot.ReadI32();
                      _val46.Add(_elem49);
                    }
                    iprot.ReadListEnd();
                  }
                  TmpMap[_key45] = _val46;
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
      TStruct struc = new TStruct("Maplist");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (TmpMap != null && __isset.tmpMap) {
        field.Name = "tmpMap";
        field.Type = TType.Map;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.List, TmpMap.Count));
          foreach (int _iter50 in TmpMap.Keys)
          {
            oprot.WriteI32(_iter50);
            {
              oprot.WriteListBegin(new TList(TType.I32, TmpMap[_iter50].Count));
              foreach (int _iter51 in TmpMap[_iter50])
              {
                oprot.WriteI32(_iter51);
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
      StringBuilder sb = new StringBuilder("Maplist(");
      sb.Append("TmpMap: ");
      sb.Append(TmpMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
