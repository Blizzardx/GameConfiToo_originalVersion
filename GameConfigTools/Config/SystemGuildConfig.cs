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
  public partial class SystemGuildConfig : TBase
  {
    private int _createGuildPrice;
    private int _changeGuildNamePrice;
    private int _changeGuildIconPrice;
    private int _localRecruitPrice;
    private int _crossRecruitPrice;
    private Dictionary<int, GuildPowerConfig> _powerConfigMap;
    private Dictionary<int, GuildRightConfig> _rightConfigMap;
    private List<GuildDonateConfig> _donateConfigList;

    public int CreateGuildPrice
    {
      get
      {
        return _createGuildPrice;
      }
      set
      {
        __isset.createGuildPrice = true;
        this._createGuildPrice = value;
      }
    }

    public int ChangeGuildNamePrice
    {
      get
      {
        return _changeGuildNamePrice;
      }
      set
      {
        __isset.changeGuildNamePrice = true;
        this._changeGuildNamePrice = value;
      }
    }

    public int ChangeGuildIconPrice
    {
      get
      {
        return _changeGuildIconPrice;
      }
      set
      {
        __isset.changeGuildIconPrice = true;
        this._changeGuildIconPrice = value;
      }
    }

    public int LocalRecruitPrice
    {
      get
      {
        return _localRecruitPrice;
      }
      set
      {
        __isset.localRecruitPrice = true;
        this._localRecruitPrice = value;
      }
    }

    public int CrossRecruitPrice
    {
      get
      {
        return _crossRecruitPrice;
      }
      set
      {
        __isset.crossRecruitPrice = true;
        this._crossRecruitPrice = value;
      }
    }

    public Dictionary<int, GuildPowerConfig> PowerConfigMap
    {
      get
      {
        return _powerConfigMap;
      }
      set
      {
        __isset.powerConfigMap = true;
        this._powerConfigMap = value;
      }
    }

    public Dictionary<int, GuildRightConfig> RightConfigMap
    {
      get
      {
        return _rightConfigMap;
      }
      set
      {
        __isset.rightConfigMap = true;
        this._rightConfigMap = value;
      }
    }

    public List<GuildDonateConfig> DonateConfigList
    {
      get
      {
        return _donateConfigList;
      }
      set
      {
        __isset.donateConfigList = true;
        this._donateConfigList = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool createGuildPrice;
      public bool changeGuildNamePrice;
      public bool changeGuildIconPrice;
      public bool localRecruitPrice;
      public bool crossRecruitPrice;
      public bool powerConfigMap;
      public bool rightConfigMap;
      public bool donateConfigList;
    }

    public SystemGuildConfig() {
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
              CreateGuildPrice = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.I32) {
              ChangeGuildNamePrice = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.I32) {
              ChangeGuildIconPrice = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 40:
            if (field.Type == TType.I32) {
              LocalRecruitPrice = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 50:
            if (field.Type == TType.I32) {
              CrossRecruitPrice = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 60:
            if (field.Type == TType.Map) {
              {
                PowerConfigMap = new Dictionary<int, GuildPowerConfig>();
                TMap _map233 = iprot.ReadMapBegin();
                for( int _i234 = 0; _i234 < _map233.Count; ++_i234)
                {
                  int _key235;
                  GuildPowerConfig _val236;
                  _key235 = iprot.ReadI32();
                  _val236 = new GuildPowerConfig();
                  _val236.Read(iprot);
                  PowerConfigMap[_key235] = _val236;
                }
                iprot.ReadMapEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 70:
            if (field.Type == TType.Map) {
              {
                RightConfigMap = new Dictionary<int, GuildRightConfig>();
                TMap _map237 = iprot.ReadMapBegin();
                for( int _i238 = 0; _i238 < _map237.Count; ++_i238)
                {
                  int _key239;
                  GuildRightConfig _val240;
                  _key239 = iprot.ReadI32();
                  _val240 = new GuildRightConfig();
                  _val240.Read(iprot);
                  RightConfigMap[_key239] = _val240;
                }
                iprot.ReadMapEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 80:
            if (field.Type == TType.List) {
              {
                DonateConfigList = new List<GuildDonateConfig>();
                TList _list241 = iprot.ReadListBegin();
                for( int _i242 = 0; _i242 < _list241.Count; ++_i242)
                {
                  GuildDonateConfig _elem243 = new GuildDonateConfig();
                  _elem243 = new GuildDonateConfig();
                  _elem243.Read(iprot);
                  DonateConfigList.Add(_elem243);
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
      TStruct struc = new TStruct("SystemGuildConfig");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.createGuildPrice) {
        field.Name = "createGuildPrice";
        field.Type = TType.I32;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(CreateGuildPrice);
        oprot.WriteFieldEnd();
      }
      if (__isset.changeGuildNamePrice) {
        field.Name = "changeGuildNamePrice";
        field.Type = TType.I32;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ChangeGuildNamePrice);
        oprot.WriteFieldEnd();
      }
      if (__isset.changeGuildIconPrice) {
        field.Name = "changeGuildIconPrice";
        field.Type = TType.I32;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ChangeGuildIconPrice);
        oprot.WriteFieldEnd();
      }
      if (__isset.localRecruitPrice) {
        field.Name = "localRecruitPrice";
        field.Type = TType.I32;
        field.ID = 40;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(LocalRecruitPrice);
        oprot.WriteFieldEnd();
      }
      if (__isset.crossRecruitPrice) {
        field.Name = "crossRecruitPrice";
        field.Type = TType.I32;
        field.ID = 50;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(CrossRecruitPrice);
        oprot.WriteFieldEnd();
      }
      if (PowerConfigMap != null && __isset.powerConfigMap) {
        field.Name = "powerConfigMap";
        field.Type = TType.Map;
        field.ID = 60;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.Struct, PowerConfigMap.Count));
          foreach (int _iter244 in PowerConfigMap.Keys)
          {
            oprot.WriteI32(_iter244);
            PowerConfigMap[_iter244].Write(oprot);
          }
          oprot.WriteMapEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (RightConfigMap != null && __isset.rightConfigMap) {
        field.Name = "rightConfigMap";
        field.Type = TType.Map;
        field.ID = 70;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.Struct, RightConfigMap.Count));
          foreach (int _iter245 in RightConfigMap.Keys)
          {
            oprot.WriteI32(_iter245);
            RightConfigMap[_iter245].Write(oprot);
          }
          oprot.WriteMapEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (DonateConfigList != null && __isset.donateConfigList) {
        field.Name = "donateConfigList";
        field.Type = TType.List;
        field.ID = 80;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, DonateConfigList.Count));
          foreach (GuildDonateConfig _iter246 in DonateConfigList)
          {
            _iter246.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("SystemGuildConfig(");
      sb.Append("CreateGuildPrice: ");
      sb.Append(CreateGuildPrice);
      sb.Append(",ChangeGuildNamePrice: ");
      sb.Append(ChangeGuildNamePrice);
      sb.Append(",ChangeGuildIconPrice: ");
      sb.Append(ChangeGuildIconPrice);
      sb.Append(",LocalRecruitPrice: ");
      sb.Append(LocalRecruitPrice);
      sb.Append(",CrossRecruitPrice: ");
      sb.Append(CrossRecruitPrice);
      sb.Append(",PowerConfigMap: ");
      sb.Append(PowerConfigMap);
      sb.Append(",RightConfigMap: ");
      sb.Append(RightConfigMap);
      sb.Append(",DonateConfigList: ");
      sb.Append(DonateConfigList);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
