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
  public partial class TierConfig : TBase
  {
    private int _type;
    private string _nameResource;
    private string _bedgeResource;
    private int _star;
    private int _nextSeasonTierType;
    private int _nextSeasonStar;
    private int _nextMessageId;

    public int Type
    {
      get
      {
        return _type;
      }
      set
      {
        __isset.type = true;
        this._type = value;
      }
    }

    public string NameResource
    {
      get
      {
        return _nameResource;
      }
      set
      {
        __isset.nameResource = true;
        this._nameResource = value;
      }
    }

    public string BedgeResource
    {
      get
      {
        return _bedgeResource;
      }
      set
      {
        __isset.bedgeResource = true;
        this._bedgeResource = value;
      }
    }

    public int Star
    {
      get
      {
        return _star;
      }
      set
      {
        __isset.star = true;
        this._star = value;
      }
    }

    public int NextSeasonTierType
    {
      get
      {
        return _nextSeasonTierType;
      }
      set
      {
        __isset.nextSeasonTierType = true;
        this._nextSeasonTierType = value;
      }
    }

    public int NextSeasonStar
    {
      get
      {
        return _nextSeasonStar;
      }
      set
      {
        __isset.nextSeasonStar = true;
        this._nextSeasonStar = value;
      }
    }

    public int NextMessageId
    {
      get
      {
        return _nextMessageId;
      }
      set
      {
        __isset.nextMessageId = true;
        this._nextMessageId = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool type;
      public bool nameResource;
      public bool bedgeResource;
      public bool star;
      public bool nextSeasonTierType;
      public bool nextSeasonStar;
      public bool nextMessageId;
    }

    public TierConfig() {
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
              Type = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.String) {
              NameResource = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.String) {
              BedgeResource = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 40:
            if (field.Type == TType.I32) {
              Star = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 50:
            if (field.Type == TType.I32) {
              NextSeasonTierType = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 60:
            if (field.Type == TType.I32) {
              NextSeasonStar = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 70:
            if (field.Type == TType.I32) {
              NextMessageId = iprot.ReadI32();
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
      TStruct struc = new TStruct("TierConfig");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.type) {
        field.Name = "type";
        field.Type = TType.I32;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Type);
        oprot.WriteFieldEnd();
      }
      if (NameResource != null && __isset.nameResource) {
        field.Name = "nameResource";
        field.Type = TType.String;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(NameResource);
        oprot.WriteFieldEnd();
      }
      if (BedgeResource != null && __isset.bedgeResource) {
        field.Name = "bedgeResource";
        field.Type = TType.String;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(BedgeResource);
        oprot.WriteFieldEnd();
      }
      if (__isset.star) {
        field.Name = "star";
        field.Type = TType.I32;
        field.ID = 40;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Star);
        oprot.WriteFieldEnd();
      }
      if (__isset.nextSeasonTierType) {
        field.Name = "nextSeasonTierType";
        field.Type = TType.I32;
        field.ID = 50;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(NextSeasonTierType);
        oprot.WriteFieldEnd();
      }
      if (__isset.nextSeasonStar) {
        field.Name = "nextSeasonStar";
        field.Type = TType.I32;
        field.ID = 60;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(NextSeasonStar);
        oprot.WriteFieldEnd();
      }
      if (__isset.nextMessageId) {
        field.Name = "nextMessageId";
        field.Type = TType.I32;
        field.ID = 70;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(NextMessageId);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("TierConfig(");
      sb.Append("Type: ");
      sb.Append(Type);
      sb.Append(",NameResource: ");
      sb.Append(NameResource);
      sb.Append(",BedgeResource: ");
      sb.Append(BedgeResource);
      sb.Append(",Star: ");
      sb.Append(Star);
      sb.Append(",NextSeasonTierType: ");
      sb.Append(NextSeasonTierType);
      sb.Append(",NextSeasonStar: ");
      sb.Append(NextSeasonStar);
      sb.Append(",NextMessageId: ");
      sb.Append(NextMessageId);
      sb.Append(")");
      return sb.ToString();
    }

  }

}