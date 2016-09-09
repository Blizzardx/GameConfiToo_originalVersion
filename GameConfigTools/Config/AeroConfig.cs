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
  public partial class AeroConfig : TBase
  {
    private int _id;
    private int _groupId;
    private int _evolutionLevel;
    private int _evolutionConusmeId;
    private int _nameMessageId;
    private int _descMessageId;
    private string _model;
    private string _prefab;
    private string _icon;
    private int _quality;
    private int _moveAdd;
    private int _flyAdd;
    private int _moveMax;
    private int _flyMax;
    private int _dropAdd;
    private int _dropMax;
    private int _friction;
    private int _resistanceAdd;
    private int _recoverId;
    private int _recoverHp;
    private string _attachPoint;
    private int _deadFuncId;

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

    public int GroupId
    {
      get
      {
        return _groupId;
      }
      set
      {
        __isset.groupId = true;
        this._groupId = value;
      }
    }

    public int EvolutionLevel
    {
      get
      {
        return _evolutionLevel;
      }
      set
      {
        __isset.evolutionLevel = true;
        this._evolutionLevel = value;
      }
    }

    public int EvolutionConusmeId
    {
      get
      {
        return _evolutionConusmeId;
      }
      set
      {
        __isset.evolutionConusmeId = true;
        this._evolutionConusmeId = value;
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

    public int MoveAdd
    {
      get
      {
        return _moveAdd;
      }
      set
      {
        __isset.moveAdd = true;
        this._moveAdd = value;
      }
    }

    public int FlyAdd
    {
      get
      {
        return _flyAdd;
      }
      set
      {
        __isset.flyAdd = true;
        this._flyAdd = value;
      }
    }

    public int MoveMax
    {
      get
      {
        return _moveMax;
      }
      set
      {
        __isset.moveMax = true;
        this._moveMax = value;
      }
    }

    public int FlyMax
    {
      get
      {
        return _flyMax;
      }
      set
      {
        __isset.flyMax = true;
        this._flyMax = value;
      }
    }

    public int DropAdd
    {
      get
      {
        return _dropAdd;
      }
      set
      {
        __isset.dropAdd = true;
        this._dropAdd = value;
      }
    }

    public int DropMax
    {
      get
      {
        return _dropMax;
      }
      set
      {
        __isset.dropMax = true;
        this._dropMax = value;
      }
    }

    public int Friction
    {
      get
      {
        return _friction;
      }
      set
      {
        __isset.friction = true;
        this._friction = value;
      }
    }

    public int ResistanceAdd
    {
      get
      {
        return _resistanceAdd;
      }
      set
      {
        __isset.resistanceAdd = true;
        this._resistanceAdd = value;
      }
    }

    public int RecoverId
    {
      get
      {
        return _recoverId;
      }
      set
      {
        __isset.recoverId = true;
        this._recoverId = value;
      }
    }

    public int RecoverHp
    {
      get
      {
        return _recoverHp;
      }
      set
      {
        __isset.recoverHp = true;
        this._recoverHp = value;
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

    public int DeadFuncId
    {
      get
      {
        return _deadFuncId;
      }
      set
      {
        __isset.deadFuncId = true;
        this._deadFuncId = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool id;
      public bool groupId;
      public bool evolutionLevel;
      public bool evolutionConusmeId;
      public bool nameMessageId;
      public bool descMessageId;
      public bool model;
      public bool prefab;
      public bool icon;
      public bool quality;
      public bool moveAdd;
      public bool flyAdd;
      public bool moveMax;
      public bool flyMax;
      public bool dropAdd;
      public bool dropMax;
      public bool friction;
      public bool resistanceAdd;
      public bool recoverId;
      public bool recoverHp;
      public bool attachPoint;
      public bool deadFuncId;
    }

    public AeroConfig() {
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
          case 11:
            if (field.Type == TType.I32) {
              GroupId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 12:
            if (field.Type == TType.I32) {
              EvolutionLevel = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 13:
            if (field.Type == TType.I32) {
              EvolutionConusmeId = iprot.ReadI32();
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
            if (field.Type == TType.String) {
              Model = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 50:
            if (field.Type == TType.String) {
              Prefab = iprot.ReadString();
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
          case 65:
            if (field.Type == TType.I32) {
              Quality = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 70:
            if (field.Type == TType.I32) {
              MoveAdd = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 80:
            if (field.Type == TType.I32) {
              FlyAdd = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 90:
            if (field.Type == TType.I32) {
              MoveMax = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 100:
            if (field.Type == TType.I32) {
              FlyMax = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 110:
            if (field.Type == TType.I32) {
              DropAdd = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 111:
            if (field.Type == TType.I32) {
              DropMax = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 120:
            if (field.Type == TType.I32) {
              Friction = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 130:
            if (field.Type == TType.I32) {
              ResistanceAdd = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 140:
            if (field.Type == TType.I32) {
              RecoverId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 150:
            if (field.Type == TType.I32) {
              RecoverHp = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 160:
            if (field.Type == TType.String) {
              AttachPoint = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 170:
            if (field.Type == TType.I32) {
              DeadFuncId = iprot.ReadI32();
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
      TStruct struc = new TStruct("AeroConfig");
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
      if (__isset.groupId) {
        field.Name = "groupId";
        field.Type = TType.I32;
        field.ID = 11;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(GroupId);
        oprot.WriteFieldEnd();
      }
      if (__isset.evolutionLevel) {
        field.Name = "evolutionLevel";
        field.Type = TType.I32;
        field.ID = 12;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(EvolutionLevel);
        oprot.WriteFieldEnd();
      }
      if (__isset.evolutionConusmeId) {
        field.Name = "evolutionConusmeId";
        field.Type = TType.I32;
        field.ID = 13;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(EvolutionConusmeId);
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
      if (Model != null && __isset.model) {
        field.Name = "model";
        field.Type = TType.String;
        field.ID = 40;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Model);
        oprot.WriteFieldEnd();
      }
      if (Prefab != null && __isset.prefab) {
        field.Name = "prefab";
        field.Type = TType.String;
        field.ID = 50;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Prefab);
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
      if (__isset.quality) {
        field.Name = "quality";
        field.Type = TType.I32;
        field.ID = 65;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Quality);
        oprot.WriteFieldEnd();
      }
      if (__isset.moveAdd) {
        field.Name = "moveAdd";
        field.Type = TType.I32;
        field.ID = 70;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(MoveAdd);
        oprot.WriteFieldEnd();
      }
      if (__isset.flyAdd) {
        field.Name = "flyAdd";
        field.Type = TType.I32;
        field.ID = 80;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(FlyAdd);
        oprot.WriteFieldEnd();
      }
      if (__isset.moveMax) {
        field.Name = "moveMax";
        field.Type = TType.I32;
        field.ID = 90;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(MoveMax);
        oprot.WriteFieldEnd();
      }
      if (__isset.flyMax) {
        field.Name = "flyMax";
        field.Type = TType.I32;
        field.ID = 100;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(FlyMax);
        oprot.WriteFieldEnd();
      }
      if (__isset.dropAdd) {
        field.Name = "dropAdd";
        field.Type = TType.I32;
        field.ID = 110;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DropAdd);
        oprot.WriteFieldEnd();
      }
      if (__isset.dropMax) {
        field.Name = "dropMax";
        field.Type = TType.I32;
        field.ID = 111;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DropMax);
        oprot.WriteFieldEnd();
      }
      if (__isset.friction) {
        field.Name = "friction";
        field.Type = TType.I32;
        field.ID = 120;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Friction);
        oprot.WriteFieldEnd();
      }
      if (__isset.resistanceAdd) {
        field.Name = "resistanceAdd";
        field.Type = TType.I32;
        field.ID = 130;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ResistanceAdd);
        oprot.WriteFieldEnd();
      }
      if (__isset.recoverId) {
        field.Name = "recoverId";
        field.Type = TType.I32;
        field.ID = 140;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(RecoverId);
        oprot.WriteFieldEnd();
      }
      if (__isset.recoverHp) {
        field.Name = "recoverHp";
        field.Type = TType.I32;
        field.ID = 150;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(RecoverHp);
        oprot.WriteFieldEnd();
      }
      if (AttachPoint != null && __isset.attachPoint) {
        field.Name = "attachPoint";
        field.Type = TType.String;
        field.ID = 160;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(AttachPoint);
        oprot.WriteFieldEnd();
      }
      if (__isset.deadFuncId) {
        field.Name = "deadFuncId";
        field.Type = TType.I32;
        field.ID = 170;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DeadFuncId);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("AeroConfig(");
      sb.Append("Id: ");
      sb.Append(Id);
      sb.Append(",GroupId: ");
      sb.Append(GroupId);
      sb.Append(",EvolutionLevel: ");
      sb.Append(EvolutionLevel);
      sb.Append(",EvolutionConusmeId: ");
      sb.Append(EvolutionConusmeId);
      sb.Append(",NameMessageId: ");
      sb.Append(NameMessageId);
      sb.Append(",DescMessageId: ");
      sb.Append(DescMessageId);
      sb.Append(",Model: ");
      sb.Append(Model);
      sb.Append(",Prefab: ");
      sb.Append(Prefab);
      sb.Append(",Icon: ");
      sb.Append(Icon);
      sb.Append(",Quality: ");
      sb.Append(Quality);
      sb.Append(",MoveAdd: ");
      sb.Append(MoveAdd);
      sb.Append(",FlyAdd: ");
      sb.Append(FlyAdd);
      sb.Append(",MoveMax: ");
      sb.Append(MoveMax);
      sb.Append(",FlyMax: ");
      sb.Append(FlyMax);
      sb.Append(",DropAdd: ");
      sb.Append(DropAdd);
      sb.Append(",DropMax: ");
      sb.Append(DropMax);
      sb.Append(",Friction: ");
      sb.Append(Friction);
      sb.Append(",ResistanceAdd: ");
      sb.Append(ResistanceAdd);
      sb.Append(",RecoverId: ");
      sb.Append(RecoverId);
      sb.Append(",RecoverHp: ");
      sb.Append(RecoverHp);
      sb.Append(",AttachPoint: ");
      sb.Append(AttachPoint);
      sb.Append(",DeadFuncId: ");
      sb.Append(DeadFuncId);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
