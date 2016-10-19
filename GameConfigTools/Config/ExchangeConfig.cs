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
  public partial class ExchangeConfig : TBase
  {
    private int _id;
    private int _exchangeItemId;
    private List<NeedItemConfig> _needItemConfigList;
    private List<NeedCurrencyConfig> _needCurrencyConfigList;

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

    public int ExchangeItemId
    {
      get
      {
        return _exchangeItemId;
      }
      set
      {
        __isset.exchangeItemId = true;
        this._exchangeItemId = value;
      }
    }

    public List<NeedItemConfig> NeedItemConfigList
    {
      get
      {
        return _needItemConfigList;
      }
      set
      {
        __isset.needItemConfigList = true;
        this._needItemConfigList = value;
      }
    }

    public List<NeedCurrencyConfig> NeedCurrencyConfigList
    {
      get
      {
        return _needCurrencyConfigList;
      }
      set
      {
        __isset.needCurrencyConfigList = true;
        this._needCurrencyConfigList = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool id;
      public bool exchangeItemId;
      public bool needItemConfigList;
      public bool needCurrencyConfigList;
    }

    public ExchangeConfig() {
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
            if (field.Type == TType.I32) {
              Id = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.I32) {
              ExchangeItemId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.List) {
              {
                NeedItemConfigList = new List<NeedItemConfig>();
                TList _list85 = iprot.ReadListBegin();
                for( int _i86 = 0; _i86 < _list85.Count; ++_i86)
                {
                  NeedItemConfig _elem87 = new NeedItemConfig();
                  _elem87 = new NeedItemConfig();
                  _elem87.Read(iprot);
                  NeedItemConfigList.Add(_elem87);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.List) {
              {
                NeedCurrencyConfigList = new List<NeedCurrencyConfig>();
                TList _list88 = iprot.ReadListBegin();
                for( int _i89 = 0; _i89 < _list88.Count; ++_i89)
                {
                  NeedCurrencyConfig _elem90 = new NeedCurrencyConfig();
                  _elem90 = new NeedCurrencyConfig();
                  _elem90.Read(iprot);
                  NeedCurrencyConfigList.Add(_elem90);
                }
                iprot.ReadListEnd();
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
      TStruct struc = new TStruct("ExchangeConfig");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.id) {
        field.Name = "id";
        field.Type = TType.I32;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Id);
        oprot.WriteFieldEnd();
      }
      if (__isset.exchangeItemId) {
        field.Name = "exchangeItemId";
        field.Type = TType.I32;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ExchangeItemId);
        oprot.WriteFieldEnd();
      }
      if (NeedItemConfigList != null && __isset.needItemConfigList) {
        field.Name = "needItemConfigList";
        field.Type = TType.List;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, NeedItemConfigList.Count));
          foreach (NeedItemConfig _iter91 in NeedItemConfigList)
          {
            _iter91.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (NeedCurrencyConfigList != null && __isset.needCurrencyConfigList) {
        field.Name = "needCurrencyConfigList";
        field.Type = TType.List;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, NeedCurrencyConfigList.Count));
          foreach (NeedCurrencyConfig _iter92 in NeedCurrencyConfigList)
          {
            _iter92.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("ExchangeConfig(");
      sb.Append("Id: ");
      sb.Append(Id);
      sb.Append(",ExchangeItemId: ");
      sb.Append(ExchangeItemId);
      sb.Append(",NeedItemConfigList: ");
      sb.Append(NeedItemConfigList);
      sb.Append(",NeedCurrencyConfigList: ");
      sb.Append(NeedCurrencyConfigList);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
