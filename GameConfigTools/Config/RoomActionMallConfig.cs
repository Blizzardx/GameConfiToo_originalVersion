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
  public partial class RoomActionMallConfig : TBase
  {
    private int _itemId;
    private int _nameMessageId;
    private int _currencyType;
    private int _price;
    private int _actionType;

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

    public int NameMessageId
    {
      get
      {
        return _nameMessageId;
      }
      set
      {
        __isset.nameMessageId = true;
        this._nameMessageId = value;
      }
    }

    public int CurrencyType
    {
      get
      {
        return _currencyType;
      }
      set
      {
        __isset.currencyType = true;
        this._currencyType = value;
      }
    }

    public int Price
    {
      get
      {
        return _price;
      }
      set
      {
        __isset.price = true;
        this._price = value;
      }
    }

    public int ActionType
    {
      get
      {
        return _actionType;
      }
      set
      {
        __isset.actionType = true;
        this._actionType = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool itemId;
      public bool nameMessageId;
      public bool currencyType;
      public bool price;
      public bool actionType;
    }

    public RoomActionMallConfig() {
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
              NameMessageId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.I32) {
              CurrencyType = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 40:
            if (field.Type == TType.I32) {
              Price = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 50:
            if (field.Type == TType.I32) {
              ActionType = iprot.ReadI32();
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
      TStruct struc = new TStruct("RoomActionMallConfig");
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
      if (__isset.nameMessageId) {
        field.Name = "nameMessageId";
        field.Type = TType.I32;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(NameMessageId);
        oprot.WriteFieldEnd();
      }
      if (__isset.currencyType) {
        field.Name = "currencyType";
        field.Type = TType.I32;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(CurrencyType);
        oprot.WriteFieldEnd();
      }
      if (__isset.price) {
        field.Name = "price";
        field.Type = TType.I32;
        field.ID = 40;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Price);
        oprot.WriteFieldEnd();
      }
      if (__isset.actionType) {
        field.Name = "actionType";
        field.Type = TType.I32;
        field.ID = 50;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ActionType);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("RoomActionMallConfig(");
      sb.Append("ItemId: ");
      sb.Append(ItemId);
      sb.Append(",NameMessageId: ");
      sb.Append(NameMessageId);
      sb.Append(",CurrencyType: ");
      sb.Append(CurrencyType);
      sb.Append(",Price: ");
      sb.Append(Price);
      sb.Append(",ActionType: ");
      sb.Append(ActionType);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
