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
  public partial class SystemLoverGiftInfo : TBase
  {
    private int _itemId;
    private int _counterId;
    private int _max;
    private int _broadcastMessageId;

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

    public int CounterId
    {
      get
      {
        return _counterId;
      }
      set
      {
        __isset.counterId = true;
        this._counterId = value;
      }
    }

    public int Max
    {
      get
      {
        return _max;
      }
      set
      {
        __isset.max = true;
        this._max = value;
      }
    }

    public int BroadcastMessageId
    {
      get
      {
        return _broadcastMessageId;
      }
      set
      {
        __isset.broadcastMessageId = true;
        this._broadcastMessageId = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool itemId;
      public bool counterId;
      public bool max;
      public bool broadcastMessageId;
    }

    public SystemLoverGiftInfo() {
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
              ItemId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.I32) {
              CounterId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.I32) {
              Max = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 40:
            if (field.Type == TType.I32) {
              BroadcastMessageId = iprot.ReadI32();
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
      TStruct struc = new TStruct("SystemLoverGiftInfo");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.itemId) {
        field.Name = "itemId";
        field.Type = TType.I32;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ItemId);
        oprot.WriteFieldEnd();
      }
      if (__isset.counterId) {
        field.Name = "counterId";
        field.Type = TType.I32;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(CounterId);
        oprot.WriteFieldEnd();
      }
      if (__isset.max) {
        field.Name = "max";
        field.Type = TType.I32;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Max);
        oprot.WriteFieldEnd();
      }
      if (__isset.broadcastMessageId) {
        field.Name = "broadcastMessageId";
        field.Type = TType.I32;
        field.ID = 40;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(BroadcastMessageId);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("SystemLoverGiftInfo(");
      sb.Append("ItemId: ");
      sb.Append(ItemId);
      sb.Append(",CounterId: ");
      sb.Append(CounterId);
      sb.Append(",Max: ");
      sb.Append(Max);
      sb.Append(",BroadcastMessageId: ");
      sb.Append(BroadcastMessageId);
      sb.Append(")");
      return sb.ToString();
    }

  }

}