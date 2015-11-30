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
  public partial class ItemsConfig : TBase
  {
    private int _id;
    private int _nameMessageId;
    private int _descMessageId;
    private string _icon;
    private string _dropIcon;
    private sbyte _quality;
    private int _sellGold;
    private int _useLimitId;
    private int _useFuncId;
    private int _accessMessageId;

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

    public int DescMessageId
    {
      get
      {
        return _descMessageId;
      }
      set
      {
        __isset.descMessageId = true;
        this._descMessageId = value;
      }
    }

    public string Icon
    {
      get
      {
        return _icon;
      }
      set
      {
        __isset.icon = true;
        this._icon = value;
      }
    }

    public string DropIcon
    {
      get
      {
        return _dropIcon;
      }
      set
      {
        __isset.dropIcon = true;
        this._dropIcon = value;
      }
    }

    public sbyte Quality
    {
      get
      {
        return _quality;
      }
      set
      {
        __isset.quality = true;
        this._quality = value;
      }
    }

    public int SellGold
    {
      get
      {
        return _sellGold;
      }
      set
      {
        __isset.sellGold = true;
        this._sellGold = value;
      }
    }

    public int UseLimitId
    {
      get
      {
        return _useLimitId;
      }
      set
      {
        __isset.useLimitId = true;
        this._useLimitId = value;
      }
    }

    public int UseFuncId
    {
      get
      {
        return _useFuncId;
      }
      set
      {
        __isset.useFuncId = true;
        this._useFuncId = value;
      }
    }

    public int AccessMessageId
    {
      get
      {
        return _accessMessageId;
      }
      set
      {
        __isset.accessMessageId = true;
        this._accessMessageId = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool id;
      public bool nameMessageId;
      public bool descMessageId;
      public bool icon;
      public bool dropIcon;
      public bool quality;
      public bool sellGold;
      public bool useLimitId;
      public bool useFuncId;
      public bool accessMessageId;
    }

    public ItemsConfig() {
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
            if (field.Type == TType.I32) {
              NameMessageId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.I32) {
              DescMessageId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 50:
            if (field.Type == TType.String) {
              Icon = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 51:
            if (field.Type == TType.String) {
              DropIcon = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 60:
            if (field.Type == TType.Byte) {
              Quality = iprot.ReadByte();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 70:
            if (field.Type == TType.I32) {
              SellGold = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 80:
            if (field.Type == TType.I32) {
              UseLimitId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 90:
            if (field.Type == TType.I32) {
              UseFuncId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 100:
            if (field.Type == TType.I32) {
              AccessMessageId = iprot.ReadI32();
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
      TStruct struc = new TStruct("ItemsConfig");
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
      if (__isset.nameMessageId) {
        field.Name = "nameMessageId";
        field.Type = TType.I32;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(NameMessageId);
        oprot.WriteFieldEnd();
      }
      if (__isset.descMessageId) {
        field.Name = "descMessageId";
        field.Type = TType.I32;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DescMessageId);
        oprot.WriteFieldEnd();
      }
      if (Icon != null && __isset.icon) {
        field.Name = "icon";
        field.Type = TType.String;
        field.ID = 50;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Icon);
        oprot.WriteFieldEnd();
      }
      if (DropIcon != null && __isset.dropIcon) {
        field.Name = "dropIcon";
        field.Type = TType.String;
        field.ID = 51;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(DropIcon);
        oprot.WriteFieldEnd();
      }
      if (__isset.quality) {
        field.Name = "quality";
        field.Type = TType.Byte;
        field.ID = 60;
        oprot.WriteFieldBegin(field);
        oprot.WriteByte(Quality);
        oprot.WriteFieldEnd();
      }
      if (__isset.sellGold) {
        field.Name = "sellGold";
        field.Type = TType.I32;
        field.ID = 70;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(SellGold);
        oprot.WriteFieldEnd();
      }
      if (__isset.useLimitId) {
        field.Name = "useLimitId";
        field.Type = TType.I32;
        field.ID = 80;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(UseLimitId);
        oprot.WriteFieldEnd();
      }
      if (__isset.useFuncId) {
        field.Name = "useFuncId";
        field.Type = TType.I32;
        field.ID = 90;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(UseFuncId);
        oprot.WriteFieldEnd();
      }
      if (__isset.accessMessageId) {
        field.Name = "accessMessageId";
        field.Type = TType.I32;
        field.ID = 100;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(AccessMessageId);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("ItemsConfig(");
      sb.Append("Id: ");
      sb.Append(Id);
      sb.Append(",NameMessageId: ");
      sb.Append(NameMessageId);
      sb.Append(",DescMessageId: ");
      sb.Append(DescMessageId);
      sb.Append(",Icon: ");
      sb.Append(Icon);
      sb.Append(",DropIcon: ");
      sb.Append(DropIcon);
      sb.Append(",Quality: ");
      sb.Append(Quality);
      sb.Append(",SellGold: ");
      sb.Append(SellGold);
      sb.Append(",UseLimitId: ");
      sb.Append(UseLimitId);
      sb.Append(",UseFuncId: ");
      sb.Append(UseFuncId);
      sb.Append(",AccessMessageId: ");
      sb.Append(AccessMessageId);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
