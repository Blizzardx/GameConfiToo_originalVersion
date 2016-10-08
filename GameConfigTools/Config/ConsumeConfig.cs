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
  public partial class ConsumeConfig : TBase
  {
    private int _id;
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
      public bool needItemConfigList;
      public bool needCurrencyConfigList;
    }

    public ConsumeConfig() {
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
            if (field.Type == TType.List) {
              {
                NeedItemConfigList = new List<NeedItemConfig>();
                TList _list89 = iprot.ReadListBegin();
                for( int _i90 = 0; _i90 < _list89.Count; ++_i90)
                {
                  NeedItemConfig _elem91 = new NeedItemConfig();
                  _elem91 = new NeedItemConfig();
                  _elem91.Read(iprot);
                  NeedItemConfigList.Add(_elem91);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.List) {
              {
                NeedCurrencyConfigList = new List<NeedCurrencyConfig>();
                TList _list92 = iprot.ReadListBegin();
                for( int _i93 = 0; _i93 < _list92.Count; ++_i93)
                {
                  NeedCurrencyConfig _elem94 = new NeedCurrencyConfig();
                  _elem94 = new NeedCurrencyConfig();
                  _elem94.Read(iprot);
                  NeedCurrencyConfigList.Add(_elem94);
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
      TStruct struc = new TStruct("ConsumeConfig");
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
      if (NeedItemConfigList != null && __isset.needItemConfigList) {
        field.Name = "needItemConfigList";
        field.Type = TType.List;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, NeedItemConfigList.Count));
          foreach (NeedItemConfig _iter95 in NeedItemConfigList)
          {
            _iter95.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (NeedCurrencyConfigList != null && __isset.needCurrencyConfigList) {
        field.Name = "needCurrencyConfigList";
        field.Type = TType.List;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, NeedCurrencyConfigList.Count));
          foreach (NeedCurrencyConfig _iter96 in NeedCurrencyConfigList)
          {
            _iter96.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("ConsumeConfig(");
      sb.Append("Id: ");
      sb.Append(Id);
      sb.Append(",NeedItemConfigList: ");
      sb.Append(NeedItemConfigList);
      sb.Append(",NeedCurrencyConfigList: ");
      sb.Append(NeedCurrencyConfigList);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
