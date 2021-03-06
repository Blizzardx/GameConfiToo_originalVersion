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
  public partial class HeroQualityLevelUpConfig : TBase
  {
    private short _needLevel;
    private int _needGold;
    private List<NeedItemConfig> _needItemList;

    public short NeedLevel
    {
      get
      {
        return _needLevel;
      }
      set
      {
        __isset.needLevel = true;
        this._needLevel = value;
      }
    }

    public int NeedGold
    {
      get
      {
        return _needGold;
      }
      set
      {
        __isset.needGold = true;
        this._needGold = value;
      }
    }

    public List<NeedItemConfig> NeedItemList
    {
      get
      {
        return _needItemList;
      }
      set
      {
        __isset.needItemList = true;
        this._needItemList = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool needLevel;
      public bool needGold;
      public bool needItemList;
    }

    public HeroQualityLevelUpConfig() {
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
            if (field.Type == TType.I16) {
              NeedLevel = iprot.ReadI16();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.I32) {
              NeedGold = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.List) {
              {
                NeedItemList = new List<NeedItemConfig>();
                TList _list113 = iprot.ReadListBegin();
                for( int _i114 = 0; _i114 < _list113.Count; ++_i114)
                {
                  NeedItemConfig _elem115 = new NeedItemConfig();
                  _elem115 = new NeedItemConfig();
                  _elem115.Read(iprot);
                  NeedItemList.Add(_elem115);
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
      TStruct struc = new TStruct("HeroQualityLevelUpConfig");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.needLevel) {
        field.Name = "needLevel";
        field.Type = TType.I16;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteI16(NeedLevel);
        oprot.WriteFieldEnd();
      }
      if (__isset.needGold) {
        field.Name = "needGold";
        field.Type = TType.I32;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(NeedGold);
        oprot.WriteFieldEnd();
      }
      if (NeedItemList != null && __isset.needItemList) {
        field.Name = "needItemList";
        field.Type = TType.List;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, NeedItemList.Count));
          foreach (NeedItemConfig _iter116 in NeedItemList)
          {
            _iter116.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("HeroQualityLevelUpConfig(");
      sb.Append("NeedLevel: ");
      sb.Append(NeedLevel);
      sb.Append(",NeedGold: ");
      sb.Append(NeedGold);
      sb.Append(",NeedItemList: ");
      sb.Append(NeedItemList);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
