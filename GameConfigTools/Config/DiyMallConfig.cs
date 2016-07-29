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
  public partial class DiyMallConfig : TBase
  {
    private int _itemId;
    private int _gender;
    private int _currencyType;
    private int _price;
    private List<string> _availableClos;
    private string _defaultColor;

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

    public int Gender
    {
      get
      {
        return _gender;
      }
      set
      {
        __isset.gender = true;
        this._gender = value;
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

    public List<string> AvailableClos
    {
      get
      {
        return _availableClos;
      }
      set
      {
        __isset.availableClos = true;
        this._availableClos = value;
      }
    }

    public string DefaultColor
    {
      get
      {
        return _defaultColor;
      }
      set
      {
        __isset.defaultColor = true;
        this._defaultColor = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool itemId;
      public bool gender;
      public bool currencyType;
      public bool price;
      public bool availableClos;
      public bool defaultColor;
    }

    public DiyMallConfig() {
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
              Gender = iprot.ReadI32();
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
            if (field.Type == TType.List) {
              {
                AvailableClos = new List<string>();
                TList _list137 = iprot.ReadListBegin();
                for( int _i138 = 0; _i138 < _list137.Count; ++_i138)
                {
                  string _elem139 = null;
                  _elem139 = iprot.ReadString();
                  AvailableClos.Add(_elem139);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 60:
            if (field.Type == TType.String) {
              DefaultColor = iprot.ReadString();
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
      TStruct struc = new TStruct("DiyMallConfig");
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
      if (__isset.gender) {
        field.Name = "gender";
        field.Type = TType.I32;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Gender);
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
      if (AvailableClos != null && __isset.availableClos) {
        field.Name = "availableClos";
        field.Type = TType.List;
        field.ID = 50;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.String, AvailableClos.Count));
          foreach (string _iter140 in AvailableClos)
          {
            oprot.WriteString(_iter140);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (DefaultColor != null && __isset.defaultColor) {
        field.Name = "defaultColor";
        field.Type = TType.String;
        field.ID = 60;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(DefaultColor);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("DiyMallConfig(");
      sb.Append("ItemId: ");
      sb.Append(ItemId);
      sb.Append(",Gender: ");
      sb.Append(Gender);
      sb.Append(",CurrencyType: ");
      sb.Append(CurrencyType);
      sb.Append(",Price: ");
      sb.Append(Price);
      sb.Append(",AvailableClos: ");
      sb.Append(AvailableClos);
      sb.Append(",DefaultColor: ");
      sb.Append(DefaultColor);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
