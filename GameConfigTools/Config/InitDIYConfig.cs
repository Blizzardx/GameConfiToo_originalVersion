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
  public partial class InitDIYConfig : TBase
  {
    private int _pos;
    private int _itemId;

    public int Pos
    {
      get
      {
        return _pos;
      }
      set
      {
        __isset.pos = true;
        this._pos = value;
      }
    }

    public int ItemId
    {
      get
      {
        return _itemId;
      }
      set
      {
        __isset.itemId = true;
        this._itemId = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool pos;
      public bool itemId;
    }

    public InitDIYConfig() {
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
              Pos = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.I32) {
              ItemId = iprot.ReadI32();
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
      TStruct struc = new TStruct("InitDIYConfig");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.pos) {
        field.Name = "pos";
        field.Type = TType.I32;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Pos);
        oprot.WriteFieldEnd();
      }
      if (__isset.itemId) {
        field.Name = "itemId";
        field.Type = TType.I32;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ItemId);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("InitDIYConfig(");
      sb.Append("Pos: ");
      sb.Append(Pos);
      sb.Append(",ItemId: ");
      sb.Append(ItemId);
      sb.Append(")");
      return sb.ToString();
    }

  }

}