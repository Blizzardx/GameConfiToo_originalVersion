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
  public partial class MusicGameSpeedConfig : TBase
  {
    private double _difficultyid;
    private double _speed;

    public double Difficultyid
    {
      get
      {
        return _difficultyid;
      }
      set
      {
        __isset.difficultyid = true;
        this._difficultyid = value;
      }
    }

    public double Speed
    {
      get
      {
        return _speed;
      }
      set
      {
        __isset.speed = true;
        this._speed = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool difficultyid;
      public bool speed;
    }

    public MusicGameSpeedConfig() {
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
            if (field.Type == TType.Double) {
              Difficultyid = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.Double) {
              Speed = iprot.ReadDouble();
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
      TStruct struc = new TStruct("MusicGameSpeedConfig");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.difficultyid) {
        field.Name = "difficultyid";
        field.Type = TType.Double;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(Difficultyid);
        oprot.WriteFieldEnd();
      }
      if (__isset.speed) {
        field.Name = "speed";
        field.Type = TType.Double;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(Speed);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("MusicGameSpeedConfig(");
      sb.Append("Difficultyid: ");
      sb.Append(Difficultyid);
      sb.Append(",Speed: ");
      sb.Append(Speed);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
