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
  public partial class AchieveConfig : TBase
  {
    private int _id;
    private int _nameMessageId;
    private int _descMessageId;
    private int _type;
    private int _forwardId;
    private string _icon;
    private int _showLimitId;
    private int _honor;
    private int _order;
    private string _color;
    private string _resource;
    private Dictionary<int, int> _attrMap;

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

    public int ForwardId
    {
      get
      {
        return _forwardId;
      }
      set
      {
        __isset.forwardId = true;
        this._forwardId = value;
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

    public int ShowLimitId
    {
      get
      {
        return _showLimitId;
      }
      set
      {
        __isset.showLimitId = true;
        this._showLimitId = value;
      }
    }

    public int Honor
    {
      get
      {
        return _honor;
      }
      set
      {
        __isset.honor = true;
        this._honor = value;
      }
    }

    public int Order
    {
      get
      {
        return _order;
      }
      set
      {
        __isset.order = true;
        this._order = value;
      }
    }

    public string Color
    {
      get
      {
        return _color;
      }
      set
      {
        __isset.color = true;
        this._color = value;
      }
    }

    public string Resource
    {
      get
      {
        return _resource;
      }
      set
      {
        __isset.resource = true;
        this._resource = value;
      }
    }

    public Dictionary<int, int> AttrMap
    {
      get
      {
        return _attrMap;
      }
      set
      {
        __isset.attrMap = true;
        this._attrMap = value;
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
      public bool type;
      public bool forwardId;
      public bool icon;
      public bool showLimitId;
      public bool honor;
      public bool order;
      public bool color;
      public bool resource;
      public bool attrMap;
    }

    public AchieveConfig() {
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
          case 40:
            if (field.Type == TType.I32) {
              Type = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 50:
            if (field.Type == TType.I32) {
              ForwardId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 60:
            if (field.Type == TType.String) {
              Icon = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 70:
            if (field.Type == TType.I32) {
              ShowLimitId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 80:
            if (field.Type == TType.I32) {
              Honor = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 90:
            if (field.Type == TType.I32) {
              Order = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 100:
            if (field.Type == TType.String) {
              Color = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 110:
            if (field.Type == TType.String) {
              Resource = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 120:
            if (field.Type == TType.Map) {
              {
                AttrMap = new Dictionary<int, int>();
                TMap _map272 = iprot.ReadMapBegin();
                for( int _i273 = 0; _i273 < _map272.Count; ++_i273)
                {
                  int _key274;
                  int _val275;
                  _key274 = iprot.ReadI32();
                  _val275 = iprot.ReadI32();
                  AttrMap[_key274] = _val275;
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
      TStruct struc = new TStruct("AchieveConfig");
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
      if (__isset.type) {
        field.Name = "type";
        field.Type = TType.I32;
        field.ID = 40;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Type);
        oprot.WriteFieldEnd();
      }
      if (__isset.forwardId) {
        field.Name = "forwardId";
        field.Type = TType.I32;
        field.ID = 50;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ForwardId);
        oprot.WriteFieldEnd();
      }
      if (Icon != null && __isset.icon) {
        field.Name = "icon";
        field.Type = TType.String;
        field.ID = 60;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Icon);
        oprot.WriteFieldEnd();
      }
      if (__isset.showLimitId) {
        field.Name = "showLimitId";
        field.Type = TType.I32;
        field.ID = 70;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ShowLimitId);
        oprot.WriteFieldEnd();
      }
      if (__isset.honor) {
        field.Name = "honor";
        field.Type = TType.I32;
        field.ID = 80;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Honor);
        oprot.WriteFieldEnd();
      }
      if (__isset.order) {
        field.Name = "order";
        field.Type = TType.I32;
        field.ID = 90;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Order);
        oprot.WriteFieldEnd();
      }
      if (Color != null && __isset.color) {
        field.Name = "color";
        field.Type = TType.String;
        field.ID = 100;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Color);
        oprot.WriteFieldEnd();
      }
      if (Resource != null && __isset.resource) {
        field.Name = "resource";
        field.Type = TType.String;
        field.ID = 110;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Resource);
        oprot.WriteFieldEnd();
      }
      if (AttrMap != null && __isset.attrMap) {
        field.Name = "attrMap";
        field.Type = TType.Map;
        field.ID = 120;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.I32, AttrMap.Count));
          foreach (int _iter276 in AttrMap.Keys)
          {
            oprot.WriteI32(_iter276);
            oprot.WriteI32(AttrMap[_iter276]);
          }
          oprot.WriteMapEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("AchieveConfig(");
      sb.Append("Id: ");
      sb.Append(Id);
      sb.Append(",NameMessageId: ");
      sb.Append(NameMessageId);
      sb.Append(",DescMessageId: ");
      sb.Append(DescMessageId);
      sb.Append(",Type: ");
      sb.Append(Type);
      sb.Append(",ForwardId: ");
      sb.Append(ForwardId);
      sb.Append(",Icon: ");
      sb.Append(Icon);
      sb.Append(",ShowLimitId: ");
      sb.Append(ShowLimitId);
      sb.Append(",Honor: ");
      sb.Append(Honor);
      sb.Append(",Order: ");
      sb.Append(Order);
      sb.Append(",Color: ");
      sb.Append(Color);
      sb.Append(",Resource: ");
      sb.Append(Resource);
      sb.Append(",AttrMap: ");
      sb.Append(AttrMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
