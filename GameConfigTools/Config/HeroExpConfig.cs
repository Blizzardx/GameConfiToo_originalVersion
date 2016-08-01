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
  public partial class HeroExpConfig : TBase
  {
    private short _level;
    private int _exp;
    private int _levelUpLimitId;
    private int _LevelUpFuncId;

    public short Level
    {
      get
      {
        return _level;
      }
      set
      {
        __isset.level = true;
        this._level = value;
      }
    }

    public int Exp
    {
      get
      {
        return _exp;
      }
      set
      {
        __isset.exp = true;
        this._exp = value;
      }
    }

    public int LevelUpLimitId
    {
      get
      {
        return _levelUpLimitId;
      }
      set
      {
        __isset.levelUpLimitId = true;
        this._levelUpLimitId = value;
      }
    }

    public int LevelUpFuncId
    {
      get
      {
        return _LevelUpFuncId;
      }
      set
      {
        __isset.LevelUpFuncId = true;
        this._LevelUpFuncId = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool level;
      public bool exp;
      public bool levelUpLimitId;
      public bool LevelUpFuncId;
    }

    public HeroExpConfig() {
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
              Level = iprot.ReadI16();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.I32) {
              Exp = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.I32) {
              LevelUpLimitId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 40:
            if (field.Type == TType.I32) {
              LevelUpFuncId = iprot.ReadI32();
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
      TStruct struc = new TStruct("HeroExpConfig");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.level) {
        field.Name = "level";
        field.Type = TType.I16;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteI16(Level);
        oprot.WriteFieldEnd();
      }
      if (__isset.exp) {
        field.Name = "exp";
        field.Type = TType.I32;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Exp);
        oprot.WriteFieldEnd();
      }
      if (__isset.levelUpLimitId) {
        field.Name = "levelUpLimitId";
        field.Type = TType.I32;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(LevelUpLimitId);
        oprot.WriteFieldEnd();
      }
      if (__isset.LevelUpFuncId) {
        field.Name = "LevelUpFuncId";
        field.Type = TType.I32;
        field.ID = 40;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(LevelUpFuncId);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("HeroExpConfig(");
      sb.Append("Level: ");
      sb.Append(Level);
      sb.Append(",Exp: ");
      sb.Append(Exp);
      sb.Append(",LevelUpLimitId: ");
      sb.Append(LevelUpLimitId);
      sb.Append(",LevelUpFuncId: ");
      sb.Append(LevelUpFuncId);
      sb.Append(")");
      return sb.ToString();
    }

  }

}