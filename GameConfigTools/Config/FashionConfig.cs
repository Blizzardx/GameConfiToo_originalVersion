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
  public partial class FashionConfig : TBase
  {
    private int _id;
    private int _nameId;
    private int _descId;
    private string _icon;
    private int _firstType;
    private string _resource;
    private int _activeCostId;
    private int _activeLimitId;
    private int _mainPanelTipType;
    private int _posPanelTipType;
    private int _activeType;

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

    public int NameId
    {
      get
      {
        return _nameId;
      }
      set
      {
        __isset.nameId = true;
        this._nameId = value;
      }
    }

    public int DescId
    {
      get
      {
        return _descId;
      }
      set
      {
        __isset.descId = true;
        this._descId = value;
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

    public int FirstType
    {
      get
      {
        return _firstType;
      }
      set
      {
        __isset.firstType = true;
        this._firstType = value;
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

    public int ActiveCostId
    {
      get
      {
        return _activeCostId;
      }
      set
      {
        __isset.activeCostId = true;
        this._activeCostId = value;
      }
    }

    public int ActiveLimitId
    {
      get
      {
        return _activeLimitId;
      }
      set
      {
        __isset.activeLimitId = true;
        this._activeLimitId = value;
      }
    }

    public int MainPanelTipType
    {
      get
      {
        return _mainPanelTipType;
      }
      set
      {
        __isset.mainPanelTipType = true;
        this._mainPanelTipType = value;
      }
    }

    public int PosPanelTipType
    {
      get
      {
        return _posPanelTipType;
      }
      set
      {
        __isset.posPanelTipType = true;
        this._posPanelTipType = value;
      }
    }

    public int ActiveType
    {
      get
      {
        return _activeType;
      }
      set
      {
        __isset.activeType = true;
        this._activeType = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool id;
      public bool nameId;
      public bool descId;
      public bool icon;
      public bool firstType;
      public bool resource;
      public bool activeCostId;
      public bool activeLimitId;
      public bool mainPanelTipType;
      public bool posPanelTipType;
      public bool activeType;
    }

    public FashionConfig() {
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
              NameId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.I32) {
              DescId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 40:
            if (field.Type == TType.String) {
              Icon = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 50:
            if (field.Type == TType.I32) {
              FirstType = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 60:
            if (field.Type == TType.String) {
              Resource = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 70:
            if (field.Type == TType.I32) {
              ActiveCostId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 80:
            if (field.Type == TType.I32) {
              ActiveLimitId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 90:
            if (field.Type == TType.I32) {
              MainPanelTipType = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 100:
            if (field.Type == TType.I32) {
              PosPanelTipType = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 110:
            if (field.Type == TType.I32) {
              ActiveType = iprot.ReadI32();
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
      TStruct struc = new TStruct("FashionConfig");
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
      if (__isset.nameId) {
        field.Name = "nameId";
        field.Type = TType.I32;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(NameId);
        oprot.WriteFieldEnd();
      }
      if (__isset.descId) {
        field.Name = "descId";
        field.Type = TType.I32;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DescId);
        oprot.WriteFieldEnd();
      }
      if (Icon != null && __isset.icon) {
        field.Name = "icon";
        field.Type = TType.String;
        field.ID = 40;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Icon);
        oprot.WriteFieldEnd();
      }
      if (__isset.firstType) {
        field.Name = "firstType";
        field.Type = TType.I32;
        field.ID = 50;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(FirstType);
        oprot.WriteFieldEnd();
      }
      if (Resource != null && __isset.resource) {
        field.Name = "resource";
        field.Type = TType.String;
        field.ID = 60;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Resource);
        oprot.WriteFieldEnd();
      }
      if (__isset.activeCostId) {
        field.Name = "activeCostId";
        field.Type = TType.I32;
        field.ID = 70;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ActiveCostId);
        oprot.WriteFieldEnd();
      }
      if (__isset.activeLimitId) {
        field.Name = "activeLimitId";
        field.Type = TType.I32;
        field.ID = 80;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ActiveLimitId);
        oprot.WriteFieldEnd();
      }
      if (__isset.mainPanelTipType) {
        field.Name = "mainPanelTipType";
        field.Type = TType.I32;
        field.ID = 90;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(MainPanelTipType);
        oprot.WriteFieldEnd();
      }
      if (__isset.posPanelTipType) {
        field.Name = "posPanelTipType";
        field.Type = TType.I32;
        field.ID = 100;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(PosPanelTipType);
        oprot.WriteFieldEnd();
      }
      if (__isset.activeType) {
        field.Name = "activeType";
        field.Type = TType.I32;
        field.ID = 110;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ActiveType);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("FashionConfig(");
      sb.Append("Id: ");
      sb.Append(Id);
      sb.Append(",NameId: ");
      sb.Append(NameId);
      sb.Append(",DescId: ");
      sb.Append(DescId);
      sb.Append(",Icon: ");
      sb.Append(Icon);
      sb.Append(",FirstType: ");
      sb.Append(FirstType);
      sb.Append(",Resource: ");
      sb.Append(Resource);
      sb.Append(",ActiveCostId: ");
      sb.Append(ActiveCostId);
      sb.Append(",ActiveLimitId: ");
      sb.Append(ActiveLimitId);
      sb.Append(",MainPanelTipType: ");
      sb.Append(MainPanelTipType);
      sb.Append(",PosPanelTipType: ");
      sb.Append(PosPanelTipType);
      sb.Append(",ActiveType: ");
      sb.Append(ActiveType);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
