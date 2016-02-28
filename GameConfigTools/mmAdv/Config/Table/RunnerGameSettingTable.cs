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

namespace Config.Table
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class RunnerGameSettingTable : TBase
  {
    private double _initSpeed;
    private double _gravity;
    private double _jumpSpeed;
    private double _jumpStartRiseTime;
    private double _jumpGlideTime;
    private double _superJumpSpeed;
    private double _superJumpStartRiseTime;
    private double _superJumpGlideTime;
    private double _jumpEndDelayTime;
    private int _trunkLoopCount;

    public double InitSpeed
    {
      get
      {
        return _initSpeed;
      }
      set
      {
        __isset.initSpeed = true;
        this._initSpeed = value;
      }
    }

    public double Gravity
    {
      get
      {
        return _gravity;
      }
      set
      {
        __isset.gravity = true;
        this._gravity = value;
      }
    }

    public double JumpSpeed
    {
      get
      {
        return _jumpSpeed;
      }
      set
      {
        __isset.jumpSpeed = true;
        this._jumpSpeed = value;
      }
    }

    public double JumpStartRiseTime
    {
      get
      {
        return _jumpStartRiseTime;
      }
      set
      {
        __isset.jumpStartRiseTime = true;
        this._jumpStartRiseTime = value;
      }
    }

    public double JumpGlideTime
    {
      get
      {
        return _jumpGlideTime;
      }
      set
      {
        __isset.jumpGlideTime = true;
        this._jumpGlideTime = value;
      }
    }

    public double SuperJumpSpeed
    {
      get
      {
        return _superJumpSpeed;
      }
      set
      {
        __isset.superJumpSpeed = true;
        this._superJumpSpeed = value;
      }
    }

    public double SuperJumpStartRiseTime
    {
      get
      {
        return _superJumpStartRiseTime;
      }
      set
      {
        __isset.superJumpStartRiseTime = true;
        this._superJumpStartRiseTime = value;
      }
    }

    public double SuperJumpGlideTime
    {
      get
      {
        return _superJumpGlideTime;
      }
      set
      {
        __isset.superJumpGlideTime = true;
        this._superJumpGlideTime = value;
      }
    }

    public double JumpEndDelayTime
    {
      get
      {
        return _jumpEndDelayTime;
      }
      set
      {
        __isset.jumpEndDelayTime = true;
        this._jumpEndDelayTime = value;
      }
    }

    public int TrunkLoopCount
    {
      get
      {
        return _trunkLoopCount;
      }
      set
      {
        __isset.trunkLoopCount = true;
        this._trunkLoopCount = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool initSpeed;
      public bool gravity;
      public bool jumpSpeed;
      public bool jumpStartRiseTime;
      public bool jumpGlideTime;
      public bool superJumpSpeed;
      public bool superJumpStartRiseTime;
      public bool superJumpGlideTime;
      public bool jumpEndDelayTime;
      public bool trunkLoopCount;
    }

    public RunnerGameSettingTable() {
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
          case 1:
            if (field.Type == TType.Double) {
              InitSpeed = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.Double) {
              Gravity = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.Double) {
              JumpSpeed = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.Double) {
              JumpStartRiseTime = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.Double) {
              JumpGlideTime = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 6:
            if (field.Type == TType.Double) {
              SuperJumpSpeed = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 7:
            if (field.Type == TType.Double) {
              SuperJumpStartRiseTime = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 8:
            if (field.Type == TType.Double) {
              SuperJumpGlideTime = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 9:
            if (field.Type == TType.Double) {
              JumpEndDelayTime = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 10:
            if (field.Type == TType.I32) {
              TrunkLoopCount = iprot.ReadI32();
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
      TStruct struc = new TStruct("RunnerGameSettingTable");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.initSpeed) {
        field.Name = "initSpeed";
        field.Type = TType.Double;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(InitSpeed);
        oprot.WriteFieldEnd();
      }
      if (__isset.gravity) {
        field.Name = "gravity";
        field.Type = TType.Double;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(Gravity);
        oprot.WriteFieldEnd();
      }
      if (__isset.jumpSpeed) {
        field.Name = "jumpSpeed";
        field.Type = TType.Double;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(JumpSpeed);
        oprot.WriteFieldEnd();
      }
      if (__isset.jumpStartRiseTime) {
        field.Name = "jumpStartRiseTime";
        field.Type = TType.Double;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(JumpStartRiseTime);
        oprot.WriteFieldEnd();
      }
      if (__isset.jumpGlideTime) {
        field.Name = "jumpGlideTime";
        field.Type = TType.Double;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(JumpGlideTime);
        oprot.WriteFieldEnd();
      }
      if (__isset.superJumpSpeed) {
        field.Name = "superJumpSpeed";
        field.Type = TType.Double;
        field.ID = 6;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(SuperJumpSpeed);
        oprot.WriteFieldEnd();
      }
      if (__isset.superJumpStartRiseTime) {
        field.Name = "superJumpStartRiseTime";
        field.Type = TType.Double;
        field.ID = 7;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(SuperJumpStartRiseTime);
        oprot.WriteFieldEnd();
      }
      if (__isset.superJumpGlideTime) {
        field.Name = "superJumpGlideTime";
        field.Type = TType.Double;
        field.ID = 8;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(SuperJumpGlideTime);
        oprot.WriteFieldEnd();
      }
      if (__isset.jumpEndDelayTime) {
        field.Name = "jumpEndDelayTime";
        field.Type = TType.Double;
        field.ID = 9;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(JumpEndDelayTime);
        oprot.WriteFieldEnd();
      }
      if (__isset.trunkLoopCount) {
        field.Name = "trunkLoopCount";
        field.Type = TType.I32;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(TrunkLoopCount);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("RunnerGameSettingTable(");
      sb.Append("InitSpeed: ");
      sb.Append(InitSpeed);
      sb.Append(",Gravity: ");
      sb.Append(Gravity);
      sb.Append(",JumpSpeed: ");
      sb.Append(JumpSpeed);
      sb.Append(",JumpStartRiseTime: ");
      sb.Append(JumpStartRiseTime);
      sb.Append(",JumpGlideTime: ");
      sb.Append(JumpGlideTime);
      sb.Append(",SuperJumpSpeed: ");
      sb.Append(SuperJumpSpeed);
      sb.Append(",SuperJumpStartRiseTime: ");
      sb.Append(SuperJumpStartRiseTime);
      sb.Append(",SuperJumpGlideTime: ");
      sb.Append(SuperJumpGlideTime);
      sb.Append(",JumpEndDelayTime: ");
      sb.Append(JumpEndDelayTime);
      sb.Append(",TrunkLoopCount: ");
      sb.Append(TrunkLoopCount);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
