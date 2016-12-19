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
  public partial class TestCompose4 : TBase
  {
    private Dictionary<int, TestCompose3> _tmpMap;

    public Dictionary<int, TestCompose3> TmpMap
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

    public TestCompose4() {
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
                TmpMap = new Dictionary<int, TestCompose3>();
                TMap _map13 = iprot.ReadMapBegin();
                for( int _i14 = 0; _i14 < _map13.Count; ++_i14)
                {
                  int _key15;
                  TestCompose3 _val16;
                  _key15 = iprot.ReadI32();
                  _val16 = new TestCompose3();
                  _val16.Read(iprot);
                  TmpMap[_key15] = _val16;
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
      TStruct struc = new TStruct("TestCompose4");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (TmpMap != null && __isset.tmpMap) {
        field.Name = "tmpMap";
        field.Type = TType.Map;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.Struct, TmpMap.Count));
          foreach (int _iter17 in TmpMap.Keys)
          {
            oprot.WriteI32(_iter17);
            TmpMap[_iter17].Write(oprot);
          }
          oprot.WriteMapEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("TestCompose4(");
      sb.Append("TmpMap: ");
      sb.Append(TmpMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}