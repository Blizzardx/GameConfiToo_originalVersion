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
  public partial class BattleBuffConfig : TBase
  {
    private int _id;
    private int _type;
    private int _affectType;
    private string _icon;
    private string _effectResource;
    private string _bindPoint;
    private int _tickTime;
    private int _continueTime;
    private int _addTargetId;
    private int _addLimitId;
    private int _addFuncId;
    private int _tickTargetId;
    private int _tickLimitId;
    private int _tickFuncId;
    private int _delTargetId;
    private int _delLimitId;
    private int _delFuncId;
    private int _trigProb;
    private int _bindingAction;
    private int _buffDurability;

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

    public int AffectType
    {
      get
      {
        return _affectType;
      }
      set
      {
        __isset.affectType = true;
        this._affectType = value;
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

    public string EffectResource
    {
      get
      {
        return _effectResource;
      }
      set
      {
        __isset.effectResource = true;
        this._effectResource = value;
      }
    }

    public string BindPoint
    {
      get
      {
        return _bindPoint;
      }
      set
      {
        __isset.bindPoint = true;
        this._bindPoint = value;
      }
    }

    public int TickTime
    {
      get
      {
        return _tickTime;
      }
      set
      {
        __isset.tickTime = true;
        this._tickTime = value;
      }
    }

    public int ContinueTime
    {
      get
      {
        return _continueTime;
      }
      set
      {
        __isset.continueTime = true;
        this._continueTime = value;
      }
    }

    public int AddTargetId
    {
      get
      {
        return _addTargetId;
      }
      set
      {
        __isset.addTargetId = true;
        this._addTargetId = value;
      }
    }

    public int AddLimitId
    {
      get
      {
        return _addLimitId;
      }
      set
      {
        __isset.addLimitId = true;
        this._addLimitId = value;
      }
    }

    public int AddFuncId
    {
      get
      {
        return _addFuncId;
      }
      set
      {
        __isset.addFuncId = true;
        this._addFuncId = value;
      }
    }

    public int TickTargetId
    {
      get
      {
        return _tickTargetId;
      }
      set
      {
        __isset.tickTargetId = true;
        this._tickTargetId = value;
      }
    }

    public int TickLimitId
    {
      get
      {
        return _tickLimitId;
      }
      set
      {
        __isset.tickLimitId = true;
        this._tickLimitId = value;
      }
    }

    public int TickFuncId
    {
      get
      {
        return _tickFuncId;
      }
      set
      {
        __isset.tickFuncId = true;
        this._tickFuncId = value;
      }
    }

    public int DelTargetId
    {
      get
      {
        return _delTargetId;
      }
      set
      {
        __isset.delTargetId = true;
        this._delTargetId = value;
      }
    }

    public int DelLimitId
    {
      get
      {
        return _delLimitId;
      }
      set
      {
        __isset.delLimitId = true;
        this._delLimitId = value;
      }
    }

    public int DelFuncId
    {
      get
      {
        return _delFuncId;
      }
      set
      {
        __isset.delFuncId = true;
        this._delFuncId = value;
      }
    }

    public int TrigProb
    {
      get
      {
        return _trigProb;
      }
      set
      {
        __isset.trigProb = true;
        this._trigProb = value;
      }
    }

    public int BindingAction
    {
      get
      {
        return _bindingAction;
      }
      set
      {
        __isset.bindingAction = true;
        this._bindingAction = value;
      }
    }

    public int BuffDurability
    {
      get
      {
        return _buffDurability;
      }
      set
      {
        __isset.buffDurability = true;
        this._buffDurability = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool id;
      public bool type;
      public bool affectType;
      public bool icon;
      public bool effectResource;
      public bool bindPoint;
      public bool tickTime;
      public bool continueTime;
      public bool addTargetId;
      public bool addLimitId;
      public bool addFuncId;
      public bool tickTargetId;
      public bool tickLimitId;
      public bool tickFuncId;
      public bool delTargetId;
      public bool delLimitId;
      public bool delFuncId;
      public bool trigProb;
      public bool bindingAction;
      public bool buffDurability;
    }

    public BattleBuffConfig() {
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
              Type = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 21:
            if (field.Type == TType.I32) {
              AffectType = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.String) {
              Icon = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 40:
            if (field.Type == TType.String) {
              EffectResource = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 50:
            if (field.Type == TType.String) {
              BindPoint = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 60:
            if (field.Type == TType.I32) {
              TickTime = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 70:
            if (field.Type == TType.I32) {
              ContinueTime = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 79:
            if (field.Type == TType.I32) {
              AddTargetId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 80:
            if (field.Type == TType.I32) {
              AddLimitId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 90:
            if (field.Type == TType.I32) {
              AddFuncId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 99:
            if (field.Type == TType.I32) {
              TickTargetId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 100:
            if (field.Type == TType.I32) {
              TickLimitId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 110:
            if (field.Type == TType.I32) {
              TickFuncId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 119:
            if (field.Type == TType.I32) {
              DelTargetId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 120:
            if (field.Type == TType.I32) {
              DelLimitId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 130:
            if (field.Type == TType.I32) {
              DelFuncId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 140:
            if (field.Type == TType.I32) {
              TrigProb = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 150:
            if (field.Type == TType.I32) {
              BindingAction = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 160:
            if (field.Type == TType.I32) {
              BuffDurability = iprot.ReadI32();
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
      TStruct struc = new TStruct("BattleBuffConfig");
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
      if (__isset.type) {
        field.Name = "type";
        field.Type = TType.I32;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Type);
        oprot.WriteFieldEnd();
      }
      if (__isset.affectType) {
        field.Name = "affectType";
        field.Type = TType.I32;
        field.ID = 21;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(AffectType);
        oprot.WriteFieldEnd();
      }
      if (Icon != null && __isset.icon) {
        field.Name = "icon";
        field.Type = TType.String;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Icon);
        oprot.WriteFieldEnd();
      }
      if (EffectResource != null && __isset.effectResource) {
        field.Name = "effectResource";
        field.Type = TType.String;
        field.ID = 40;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(EffectResource);
        oprot.WriteFieldEnd();
      }
      if (BindPoint != null && __isset.bindPoint) {
        field.Name = "bindPoint";
        field.Type = TType.String;
        field.ID = 50;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(BindPoint);
        oprot.WriteFieldEnd();
      }
      if (__isset.tickTime) {
        field.Name = "tickTime";
        field.Type = TType.I32;
        field.ID = 60;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(TickTime);
        oprot.WriteFieldEnd();
      }
      if (__isset.continueTime) {
        field.Name = "continueTime";
        field.Type = TType.I32;
        field.ID = 70;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ContinueTime);
        oprot.WriteFieldEnd();
      }
      if (__isset.addTargetId) {
        field.Name = "addTargetId";
        field.Type = TType.I32;
        field.ID = 79;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(AddTargetId);
        oprot.WriteFieldEnd();
      }
      if (__isset.addLimitId) {
        field.Name = "addLimitId";
        field.Type = TType.I32;
        field.ID = 80;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(AddLimitId);
        oprot.WriteFieldEnd();
      }
      if (__isset.addFuncId) {
        field.Name = "addFuncId";
        field.Type = TType.I32;
        field.ID = 90;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(AddFuncId);
        oprot.WriteFieldEnd();
      }
      if (__isset.tickTargetId) {
        field.Name = "tickTargetId";
        field.Type = TType.I32;
        field.ID = 99;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(TickTargetId);
        oprot.WriteFieldEnd();
      }
      if (__isset.tickLimitId) {
        field.Name = "tickLimitId";
        field.Type = TType.I32;
        field.ID = 100;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(TickLimitId);
        oprot.WriteFieldEnd();
      }
      if (__isset.tickFuncId) {
        field.Name = "tickFuncId";
        field.Type = TType.I32;
        field.ID = 110;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(TickFuncId);
        oprot.WriteFieldEnd();
      }
      if (__isset.delTargetId) {
        field.Name = "delTargetId";
        field.Type = TType.I32;
        field.ID = 119;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DelTargetId);
        oprot.WriteFieldEnd();
      }
      if (__isset.delLimitId) {
        field.Name = "delLimitId";
        field.Type = TType.I32;
        field.ID = 120;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DelLimitId);
        oprot.WriteFieldEnd();
      }
      if (__isset.delFuncId) {
        field.Name = "delFuncId";
        field.Type = TType.I32;
        field.ID = 130;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DelFuncId);
        oprot.WriteFieldEnd();
      }
      if (__isset.trigProb) {
        field.Name = "trigProb";
        field.Type = TType.I32;
        field.ID = 140;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(TrigProb);
        oprot.WriteFieldEnd();
      }
      if (__isset.bindingAction) {
        field.Name = "bindingAction";
        field.Type = TType.I32;
        field.ID = 150;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(BindingAction);
        oprot.WriteFieldEnd();
      }
      if (__isset.buffDurability) {
        field.Name = "buffDurability";
        field.Type = TType.I32;
        field.ID = 160;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(BuffDurability);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("BattleBuffConfig(");
      sb.Append("Id: ");
      sb.Append(Id);
      sb.Append(",Type: ");
      sb.Append(Type);
      sb.Append(",AffectType: ");
      sb.Append(AffectType);
      sb.Append(",Icon: ");
      sb.Append(Icon);
      sb.Append(",EffectResource: ");
      sb.Append(EffectResource);
      sb.Append(",BindPoint: ");
      sb.Append(BindPoint);
      sb.Append(",TickTime: ");
      sb.Append(TickTime);
      sb.Append(",ContinueTime: ");
      sb.Append(ContinueTime);
      sb.Append(",AddTargetId: ");
      sb.Append(AddTargetId);
      sb.Append(",AddLimitId: ");
      sb.Append(AddLimitId);
      sb.Append(",AddFuncId: ");
      sb.Append(AddFuncId);
      sb.Append(",TickTargetId: ");
      sb.Append(TickTargetId);
      sb.Append(",TickLimitId: ");
      sb.Append(TickLimitId);
      sb.Append(",TickFuncId: ");
      sb.Append(TickFuncId);
      sb.Append(",DelTargetId: ");
      sb.Append(DelTargetId);
      sb.Append(",DelLimitId: ");
      sb.Append(DelLimitId);
      sb.Append(",DelFuncId: ");
      sb.Append(DelFuncId);
      sb.Append(",TrigProb: ");
      sb.Append(TrigProb);
      sb.Append(",BindingAction: ");
      sb.Append(BindingAction);
      sb.Append(",BuffDurability: ");
      sb.Append(BuffDurability);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
