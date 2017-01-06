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
  public partial class WeaponConfig : TBase
  {
    private int _id;
    private int _decomposeId;
    private int _nameMessageId;
    private int _descMessageId;
    private int _firstType;
    private int _secondType;
    private string _model;
    private string _prefab;
    private string _icon;
    private int _quality;
    private string _attachPoint;
    private List<int> _textureList;
    private int _activeCostId;
    private int _sortId;
    private int _showLimitId;
    private int _showTipType;
    private int _showEventType;
    private int _activeIconTip;
    private int _activeTipType;
    private int _activeEnterType;
    private List<string> _motionList;

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

    public int DecomposeId
    {
      get
      {
        return _decomposeId;
      }
      set
      {
        __isset.decomposeId = true;
        this._decomposeId = value;
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

    public int SecondType
    {
      get
      {
        return _secondType;
      }
      set
      {
        __isset.secondType = true;
        this._secondType = value;
      }
    }

    public string Model
    {
      get
      {
        return _model;
      }
      set
      {
        __isset.model = true;
        this._model = value;
      }
    }

    public string Prefab
    {
      get
      {
        return _prefab;
      }
      set
      {
        __isset.prefab = true;
        this._prefab = value;
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

    public int Quality
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

    public string AttachPoint
    {
      get
      {
        return _attachPoint;
      }
      set
      {
        __isset.attachPoint = true;
        this._attachPoint = value;
      }
    }

    public List<int> TextureList
    {
      get
      {
        return _textureList;
      }
      set
      {
        __isset.textureList = true;
        this._textureList = value;
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

    public int SortId
    {
      get
      {
        return _sortId;
      }
      set
      {
        __isset.sortId = true;
        this._sortId = value;
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

    public int ShowTipType
    {
      get
      {
        return _showTipType;
      }
      set
      {
        __isset.showTipType = true;
        this._showTipType = value;
      }
    }

    public int ShowEventType
    {
      get
      {
        return _showEventType;
      }
      set
      {
        __isset.showEventType = true;
        this._showEventType = value;
      }
    }

    public int ActiveIconTip
    {
      get
      {
        return _activeIconTip;
      }
      set
      {
        __isset.activeIconTip = true;
        this._activeIconTip = value;
      }
    }

    public int ActiveTipType
    {
      get
      {
        return _activeTipType;
      }
      set
      {
        __isset.activeTipType = true;
        this._activeTipType = value;
      }
    }

    public int ActiveEnterType
    {
      get
      {
        return _activeEnterType;
      }
      set
      {
        __isset.activeEnterType = true;
        this._activeEnterType = value;
      }
    }

    public List<string> MotionList
    {
      get
      {
        return _motionList;
      }
      set
      {
        __isset.motionList = true;
        this._motionList = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool id;
      public bool decomposeId;
      public bool nameMessageId;
      public bool descMessageId;
      public bool firstType;
      public bool secondType;
      public bool model;
      public bool prefab;
      public bool icon;
      public bool quality;
      public bool attachPoint;
      public bool textureList;
      public bool activeCostId;
      public bool sortId;
      public bool showLimitId;
      public bool showTipType;
      public bool showEventType;
      public bool activeIconTip;
      public bool activeTipType;
      public bool activeEnterType;
      public bool motionList;
    }

    public WeaponConfig() {
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
              DecomposeId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.I32) {
              NameMessageId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 40:
            if (field.Type == TType.I32) {
              DescMessageId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 45:
            if (field.Type == TType.I32) {
              FirstType = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 46:
            if (field.Type == TType.I32) {
              SecondType = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 50:
            if (field.Type == TType.String) {
              Model = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 60:
            if (field.Type == TType.String) {
              Prefab = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 70:
            if (field.Type == TType.String) {
              Icon = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 80:
            if (field.Type == TType.I32) {
              Quality = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 90:
            if (field.Type == TType.String) {
              AttachPoint = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 100:
            if (field.Type == TType.List) {
              {
                TextureList = new List<int>();
                TList _list234 = iprot.ReadListBegin();
                for( int _i235 = 0; _i235 < _list234.Count; ++_i235)
                {
                  int _elem236 = 0;
                  _elem236 = iprot.ReadI32();
                  TextureList.Add(_elem236);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 110:
            if (field.Type == TType.I32) {
              ActiveCostId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 120:
            if (field.Type == TType.I32) {
              SortId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 130:
            if (field.Type == TType.I32) {
              ShowLimitId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 140:
            if (field.Type == TType.I32) {
              ShowTipType = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 150:
            if (field.Type == TType.I32) {
              ShowEventType = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 160:
            if (field.Type == TType.I32) {
              ActiveIconTip = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 170:
            if (field.Type == TType.I32) {
              ActiveTipType = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 171:
            if (field.Type == TType.I32) {
              ActiveEnterType = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 180:
            if (field.Type == TType.List) {
              {
                MotionList = new List<string>();
                TList _list237 = iprot.ReadListBegin();
                for( int _i238 = 0; _i238 < _list237.Count; ++_i238)
                {
                  string _elem239 = null;
                  _elem239 = iprot.ReadString();
                  MotionList.Add(_elem239);
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
      TStruct struc = new TStruct("WeaponConfig");
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
      if (__isset.decomposeId) {
        field.Name = "decomposeId";
        field.Type = TType.I32;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DecomposeId);
        oprot.WriteFieldEnd();
      }
      if (__isset.nameMessageId) {
        field.Name = "nameMessageId";
        field.Type = TType.I32;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(NameMessageId);
        oprot.WriteFieldEnd();
      }
      if (__isset.descMessageId) {
        field.Name = "descMessageId";
        field.Type = TType.I32;
        field.ID = 40;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DescMessageId);
        oprot.WriteFieldEnd();
      }
      if (__isset.firstType) {
        field.Name = "firstType";
        field.Type = TType.I32;
        field.ID = 45;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(FirstType);
        oprot.WriteFieldEnd();
      }
      if (__isset.secondType) {
        field.Name = "secondType";
        field.Type = TType.I32;
        field.ID = 46;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(SecondType);
        oprot.WriteFieldEnd();
      }
      if (Model != null && __isset.model) {
        field.Name = "model";
        field.Type = TType.String;
        field.ID = 50;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Model);
        oprot.WriteFieldEnd();
      }
      if (Prefab != null && __isset.prefab) {
        field.Name = "prefab";
        field.Type = TType.String;
        field.ID = 60;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Prefab);
        oprot.WriteFieldEnd();
      }
      if (Icon != null && __isset.icon) {
        field.Name = "icon";
        field.Type = TType.String;
        field.ID = 70;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Icon);
        oprot.WriteFieldEnd();
      }
      if (__isset.quality) {
        field.Name = "quality";
        field.Type = TType.I32;
        field.ID = 80;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Quality);
        oprot.WriteFieldEnd();
      }
      if (AttachPoint != null && __isset.attachPoint) {
        field.Name = "attachPoint";
        field.Type = TType.String;
        field.ID = 90;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(AttachPoint);
        oprot.WriteFieldEnd();
      }
      if (TextureList != null && __isset.textureList) {
        field.Name = "textureList";
        field.Type = TType.List;
        field.ID = 100;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.I32, TextureList.Count));
          foreach (int _iter240 in TextureList)
          {
            oprot.WriteI32(_iter240);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (__isset.activeCostId) {
        field.Name = "activeCostId";
        field.Type = TType.I32;
        field.ID = 110;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ActiveCostId);
        oprot.WriteFieldEnd();
      }
      if (__isset.sortId) {
        field.Name = "sortId";
        field.Type = TType.I32;
        field.ID = 120;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(SortId);
        oprot.WriteFieldEnd();
      }
      if (__isset.showLimitId) {
        field.Name = "showLimitId";
        field.Type = TType.I32;
        field.ID = 130;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ShowLimitId);
        oprot.WriteFieldEnd();
      }
      if (__isset.showTipType) {
        field.Name = "showTipType";
        field.Type = TType.I32;
        field.ID = 140;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ShowTipType);
        oprot.WriteFieldEnd();
      }
      if (__isset.showEventType) {
        field.Name = "showEventType";
        field.Type = TType.I32;
        field.ID = 150;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ShowEventType);
        oprot.WriteFieldEnd();
      }
      if (__isset.activeIconTip) {
        field.Name = "activeIconTip";
        field.Type = TType.I32;
        field.ID = 160;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ActiveIconTip);
        oprot.WriteFieldEnd();
      }
      if (__isset.activeTipType) {
        field.Name = "activeTipType";
        field.Type = TType.I32;
        field.ID = 170;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ActiveTipType);
        oprot.WriteFieldEnd();
      }
      if (__isset.activeEnterType) {
        field.Name = "activeEnterType";
        field.Type = TType.I32;
        field.ID = 171;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ActiveEnterType);
        oprot.WriteFieldEnd();
      }
      if (MotionList != null && __isset.motionList) {
        field.Name = "motionList";
        field.Type = TType.List;
        field.ID = 180;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.String, MotionList.Count));
          foreach (string _iter241 in MotionList)
          {
            oprot.WriteString(_iter241);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("WeaponConfig(");
      sb.Append("Id: ");
      sb.Append(Id);
      sb.Append(",DecomposeId: ");
      sb.Append(DecomposeId);
      sb.Append(",NameMessageId: ");
      sb.Append(NameMessageId);
      sb.Append(",DescMessageId: ");
      sb.Append(DescMessageId);
      sb.Append(",FirstType: ");
      sb.Append(FirstType);
      sb.Append(",SecondType: ");
      sb.Append(SecondType);
      sb.Append(",Model: ");
      sb.Append(Model);
      sb.Append(",Prefab: ");
      sb.Append(Prefab);
      sb.Append(",Icon: ");
      sb.Append(Icon);
      sb.Append(",Quality: ");
      sb.Append(Quality);
      sb.Append(",AttachPoint: ");
      sb.Append(AttachPoint);
      sb.Append(",TextureList: ");
      sb.Append(TextureList);
      sb.Append(",ActiveCostId: ");
      sb.Append(ActiveCostId);
      sb.Append(",SortId: ");
      sb.Append(SortId);
      sb.Append(",ShowLimitId: ");
      sb.Append(ShowLimitId);
      sb.Append(",ShowTipType: ");
      sb.Append(ShowTipType);
      sb.Append(",ShowEventType: ");
      sb.Append(ShowEventType);
      sb.Append(",ActiveIconTip: ");
      sb.Append(ActiveIconTip);
      sb.Append(",ActiveTipType: ");
      sb.Append(ActiveTipType);
      sb.Append(",ActiveEnterType: ");
      sb.Append(ActiveEnterType);
      sb.Append(",MotionList: ");
      sb.Append(MotionList);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
