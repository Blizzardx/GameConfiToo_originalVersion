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
  public partial class FlightGameConfigTable : TBase
  {
    private List<Config.FlightGameConfig> _flightConfigList;

    public List<Config.FlightGameConfig> FlightConfigList
    {
      get
      {
        return _flightConfigList;
      }
      set
      {
        __isset.flightConfigList = true;
        this._flightConfigList = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool flightConfigList;
    }

    public FlightGameConfigTable() {
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
            if (field.Type == TType.List) {
              {
                FlightConfigList = new List<Config.FlightGameConfig>();
                TList _list96 = iprot.ReadListBegin();
                for( int _i97 = 0; _i97 < _list96.Count; ++_i97)
                {
                  Config.FlightGameConfig _elem98 = new Config.FlightGameConfig();
                  _elem98 = new Config.FlightGameConfig();
                  _elem98.Read(iprot);
                  FlightConfigList.Add(_elem98);
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
      TStruct struc = new TStruct("FlightGameConfigTable");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (FlightConfigList != null && __isset.flightConfigList) {
        field.Name = "flightConfigList";
        field.Type = TType.List;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, FlightConfigList.Count));
          foreach (Config.FlightGameConfig _iter99 in FlightConfigList)
          {
            _iter99.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("FlightGameConfigTable(");
      sb.Append("FlightConfigList: ");
      sb.Append(FlightConfigList);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
